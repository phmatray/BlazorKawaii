#!/usr/bin/env node
// Measures how much each animated kawaii face visibly moves, so "is it animated?" is a number, not a guess.
//
// Usage: node tools/face-motion.mjs <url> [--seconds 6] [--out dir] [--reduced-motion] [--strict]
//   <url>              a running demo page with animated faces, e.g. http://localhost:5000/documentation#animation
//   --seconds N        how long to sample (default 6: the slowest cycle)
//   --out dir          also write <dir>/sheet.png, one row of frames per face (default: no sheet)
//   --reduced-motion   emulate prefers-reduced-motion: every face must stay still
//   --strict           fail on SUBTLE as well as NONE
// Prints one row per face: mood, face width, the largest on-screen displacement (px) and opacity change of its
// eyes, mouth and cheeks, and a verdict. Exit 1 when a face fails, 2 on a usage or browser error.
// Needs Node 22+ (global WebSocket) and Chrome; set CHROME to its path if it isn't in the macOS default place.

import { spawn } from 'node:child_process';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';

const args = process.argv.slice(2);
const flag = name => args.includes(name);
const opt = (name, fallback) => { const i = args.indexOf(name); return i >= 0 ? args[i + 1] : fallback; };
const url = args.find(a => /^https?:/.test(a));
if (!url) { console.error('usage: node tools/face-motion.mjs <url> [--seconds 6] [--out dir] [--reduced-motion] [--strict]'); process.exit(2); }
const seconds = Number(opt('--seconds', 6));
const outDir = opt('--out');
const reduced = flag('--reduced-motion');
const strict = flag('--strict');

// Thresholds in CSS px at the rendered size: below VISIBLE a person watching the page will not notice the motion.
const VISIBLE_PX = 2, SUBTLE_PX = 0.5, VISIBLE_OPACITY = 0.15, SUBTLE_OPACITY = 0.05;

const chrome = process.env.CHROME ?? '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome';
const port = 9600 + Math.floor(Math.random() * 300);
const profile = mkdtempSync(join(tmpdir(), 'face-motion-'));
const browser = spawn(chrome, ['--headless=new', '--disable-gpu', `--remote-debugging-port=${port}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
const sleep = ms => new Promise(r => setTimeout(r, ms));
const quit = code => {
  browser.once('exit', () => { rmSync(profile, { recursive: true, force: true, maxRetries: 5 }); process.exit(code); });
  browser.kill();
};

let target;
for (let i = 0; i < 50 && !target; i++) {
  try { target = await (await fetch(`http://127.0.0.1:${port}/json/new?about:blank`, { method: 'PUT' })).json(); } catch { await sleep(200); }
}
if (!target) { console.error('face-motion: Chrome did not start'); quit(2); }
const ws = new WebSocket(target.webSocketDebuggerUrl);
await new Promise(r => ws.onopen = r);
let id = 0; const pending = new Map();
ws.onmessage = e => { const m = JSON.parse(e.data); if (pending.has(m.id)) { pending.get(m.id)(m); pending.delete(m.id); } };
const send = (method, params = {}) => new Promise(r => { const i = ++id; pending.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const ev = async expr => {
  const m = await send('Runtime.evaluate', { expression: expr, returnByValue: true, awaitPromise: true });
  if (m.result?.exceptionDetails) throw new Error(m.result.exceptionDetails.exception?.description ?? 'page error');
  return m.result?.result?.value;
};

await send('Emulation.setDeviceMetricsOverride', { width: 1400, height: 1000, deviceScaleFactor: 1, mobile: false });
if (reduced) await send('Emulation.setEmulatedMedia', { features: [{ name: 'prefers-reduced-motion', value: 'reduce' }] });
await send('Page.navigate', { url });
let count = 0;
for (let i = 0; i < 120 && !count; i++) { await sleep(500); count = await ev(`document.querySelectorAll('.kawaii-face--animated').length`); }
if (!count) { console.error(`face-motion: no .kawaii-face--animated element on ${url}`); quit(2); }
await sleep(1000);

// Sampled in the page on every frame: each shape's bounding-box corners mapped to the screen, and its effective opacity.
const results = await ev(`(async () => {
  const faces = [...document.querySelectorAll('.kawaii-face--animated')];
  const parts = ['eyes', 'mouth', 'cheeks'];
  const corners = el => { const b = el.getBBox(), m = el.getScreenCTM();
    return [[b.x, b.y], [b.x + b.width, b.y], [b.x, b.y + b.height], [b.x + b.width, b.y + b.height]]
      .map(([x, y]) => [m.a * x + m.c * y + m.e, m.b * x + m.d * y + m.f]); };
  const opacity = el => { let o = 1; for (let n = el; n && n.nodeType === 1; n = n.parentElement) o *= +getComputedStyle(n).opacity; return o; };
  const track = faces.map(f => parts.map(p => [...f.querySelectorAll('.kawaii-face__' + p + ' :is(path, circle, ellipse)')]
    .map(el => ({ el, min: null, max: null, oMin: 1, oMax: 0 }))));
  const end = performance.now() + ${seconds * 1000};
  while (performance.now() < end) {
    for (const face of track) for (const shapes of face) for (const s of shapes) {
      const c = corners(s.el); s.min ??= c.map(p => [...p]); s.max ??= c.map(p => [...p]);
      c.forEach(([x, y], i) => { s.min[i][0] = Math.min(s.min[i][0], x); s.min[i][1] = Math.min(s.min[i][1], y);
                                 s.max[i][0] = Math.max(s.max[i][0], x); s.max[i][1] = Math.max(s.max[i][1], y); });
      const o = opacity(s.el); s.oMin = Math.min(s.oMin, o); s.oMax = Math.max(s.oMax, o);
    }
    await new Promise(r => requestAnimationFrame(r));
  }
  return faces.map((f, i) => {
    const r = f.getBoundingClientRect();
    return { mood: [...f.classList].find(c => c.startsWith('kawaii-face--') && c !== 'kawaii-face--animated')?.slice(13) ?? '?',
      width: r.width, box: { x: r.x + scrollX, y: r.y + scrollY, width: r.width, height: r.height },
      parts: Object.fromEntries(parts.map((p, j) => [p, track[i][j].reduce((acc, s) => s.min ? {
        px: Math.max(acc.px, ...s.min.map((m, k) => Math.hypot(s.max[k][0] - m[0], s.max[k][1] - m[1]))),
        opacity: Math.max(acc.opacity, s.oMax - s.oMin) } : acc, { px: 0, opacity: 0 })])) };
  });
})()`);

const verdict = r => {
  const px = Math.max(...Object.values(r.parts).map(p => p.px));
  const op = Math.max(...Object.values(r.parts).map(p => p.opacity));
  if (reduced) return px > 0.1 || op > 0.01 ? 'MOVES' : 'STILL';
  return px >= VISIBLE_PX || op >= VISIBLE_OPACITY ? 'VISIBLE' : px >= SUBTLE_PX || op >= SUBTLE_OPACITY ? 'SUBTLE' : 'NONE';
};
const fmt = p => `${p.px.toFixed(1).padStart(5)}px ${p.opacity.toFixed(2)}`;
console.log(`${'mood'.padEnd(12)} ${'width'.padStart(6)}  ${'eyes'.padEnd(13)} ${'mouth'.padEnd(13)} ${'cheeks'.padEnd(13)} verdict`);
let failed = 0;
for (const r of results) {
  const v = verdict(r);
  const bad = reduced ? v === 'MOVES' : v === 'NONE' || (strict && v === 'SUBTLE');
  failed += bad;
  console.log(`${r.mood.padEnd(12)} ${r.width.toFixed(0).padStart(5)}px  ${fmt(r.parts.eyes)}  ${fmt(r.parts.mouth)}  ${fmt(r.parts.cheeks)}  ${v}${bad ? '  ✗' : ''}`);
}

if (outDir) {
  // One row per face: 8 frames across the sampled window, each face cropped at 2x.
  mkdirSync(outDir, { recursive: true });
  const frames = results.map(() => []);
  for (let f = 0; f < 8; f++) {
    for (const [i, r] of results.entries()) {
      const pad = r.box.width * 0.15;
      const shot = await send('Page.captureScreenshot', { format: 'png', captureBeyondViewport: true,
        clip: { x: r.box.x - pad, y: r.box.y - pad, width: r.box.width + 2 * pad, height: r.box.height + 2 * pad, scale: 2 } });
      frames[i].push(shot.result.data);
    }
    await sleep(seconds * 1000 / 8);
  }
  const html = `<body style="margin:0;font:14px sans-serif;background:#fff;width:max-content">${results.map((r, i) =>
    `<div style="display:flex;align-items:center;gap:6px;padding:4px 8px;border-bottom:1px solid #eee"><b style="width:90px">${r.mood}</b>${
      frames[i].map(d => `<img src="data:image/png;base64,${d}" style="height:90px;flex-shrink:0">`).join('')}<span>${verdict(r)}</span></div>`).join('')}</body>`;
  await send('Page.navigate', { url: 'about:blank' });
  await ev(`document.open(); document.write(${JSON.stringify(html)}); document.close(); new Promise(r => setTimeout(r, 500))`);
  const [width, height] = await ev('[document.documentElement.scrollWidth, document.body.scrollHeight]');
  const sheet = await send('Page.captureScreenshot', { format: 'png', captureBeyondViewport: true, clip: { x: 0, y: 0, width, height, scale: 1 } });
  writeFileSync(join(outDir, 'sheet.png'), Buffer.from(sheet.result.data, 'base64'));
  console.log(`sheet: ${join(outDir, 'sheet.png')}`);
}

ws.close();
console.log(failed ? `${failed} face(s) failed` : 'ok');
quit(failed ? 1 : 0);
