"""Re-composite a run-cycle frame so its character matches the idle sprite's
scale and foot line within a shared canvas height.

AI-generated pose frames (ChatGPT/DALL-E) are not reliably framed the same
way across separate generations -- Theo's run-cycle frames filled a much
smaller fraction of their canvas than the idle sprite, so importing them
with the same Pixels-Per-Unit as idle made him shrink and made his feet
drift relative to the ground between animation frames (feet weren't at a
consistent height within the canvas).

This crops each frame to its own character bounding box (alpha > 40),
rescales it so its height matches the idle sprite's measured character
height, and re-pastes it onto a fresh transparent canvas so the character's
foot line lands at the same canvas Y as idle's. After this, a single
Pixels-Per-Unit constant (see TheoSpriteSetup.IdleSpritePixelsPerUnit) works
correctly for both idle and run sprites, and Center pivot won't drift.

Usage: python3 normalize_run_frames.py <src.png> <dst.png>

Re-measure IDLE_BBOX / re-run this whenever the idle sprite or run frames
are regenerated.
"""
import sys
from PIL import Image

CANVAS_W, CANVAS_H = 900, 1024

# Idle sprite's own measured character bbox (excluding the lantern
# light-spray effect), measured via PIL against
# unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/theo-sprite-v03.png (368x1024 canvas).
# Previous constants (v02, 1400x1536 canvas, bbox (174, 92, 784, 1140)) are
# obsolete now that v03 is the adopted sprite -- re-measure again if the
# idle sprite is regenerated.
IDLE_BBOX = (29, 190, 336, 762)
IDLE_CHAR_HEIGHT = IDLE_BBOX[3] - IDLE_BBOX[1]  # 572
IDLE_FOOT_Y = IDLE_BBOX[3]  # 762, bottom edge in canvas space (PIL, y grows down)


def character_bbox(img):
    w, h = img.size
    px = img.load()
    minx, miny, maxx, maxy = w, h, 0, 0
    found = False
    for y in range(h):
        for x in range(w):
            _, _, _, a = px[x, y]
            if a < 40:
                continue
            found = True
            minx = min(minx, x)
            maxx = max(maxx, x)
            miny = min(miny, y)
            maxy = max(maxy, y)
    if not found:
        return None
    return (minx, miny, maxx, maxy)


def normalize(src_path, dst_path):
    img = Image.open(src_path).convert("RGBA")
    minx, miny, maxx, maxy = character_bbox(img)
    char_w = maxx - minx
    char_h = maxy - miny

    scale = IDLE_CHAR_HEIGHT / char_h
    new_w = max(1, round(char_w * scale))
    new_h = max(1, round(char_h * scale))

    cropped = img.crop((minx, miny, maxx, maxy))
    resized = cropped.resize((new_w, new_h), Image.LANCZOS)

    canvas = Image.new("RGBA", (CANVAS_W, CANVAS_H), (0, 0, 0, 0))
    paste_x = (CANVAS_W - new_w) // 2
    paste_y = IDLE_FOOT_Y - new_h
    canvas.alpha_composite(resized, (paste_x, paste_y))
    canvas.save(dst_path)
    print(f"{src_path}: char {char_w}x{char_h} -> scale {scale:.4f} -> {new_w}x{new_h} at ({paste_x},{paste_y})")


if __name__ == "__main__":
    normalize(sys.argv[1], sys.argv[2])
