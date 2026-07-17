"""Shift a sprite frame vertically (pure translation, no rescaling) so its
character's foot line lands at a target canvas Y.

Unlike normalize_run_frames.py (which corrects scale mismatches between
AI-generated poses of different sizes), this is for hand-crafted frames that
already share the same canvas size and character scale, but were positioned
at a different height within the canvas -- e.g. Theo's Photoshop idle frames
(foot around y=987 in a 1024-tall canvas) versus the run frames (foot around
y=926). Since scale is already consistent, only a vertical shift is needed;
shifting is lossless (no resampling).

Usage: python3 align_foot_line.py <src.png> <dst.png> <target_foot_y>
"""
import sys
from PIL import Image


def character_bbox(img):
    w, h = img.size
    px = img.load()
    minx, miny, maxx, maxy = w, h, 0, 0
    found = False
    for y in range(h):
        for x in range(w):
            if px[x, y][3] > 40:
                found = True
                minx = min(minx, x)
                maxx = max(maxx, x)
                miny = min(miny, y)
                maxy = max(maxy, y)
    if not found:
        return None
    return (minx, miny, maxx, maxy)


def align(src_path, dst_path, target_foot_y):
    img = Image.open(src_path).convert("RGBA")
    w, h = img.size
    _, _, _, maxy = character_bbox(img)
    shift = target_foot_y - maxy

    canvas = Image.new("RGBA", (w, h), (0, 0, 0, 0))
    canvas.alpha_composite(img, (0, shift))
    canvas.save(dst_path)
    print(f"{src_path}: foot {maxy} -> {target_foot_y} (shift {shift:+d})")


if __name__ == "__main__":
    align(sys.argv[1], sys.argv[2], int(sys.argv[3]))
