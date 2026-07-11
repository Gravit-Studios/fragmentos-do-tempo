# Tileset Image Prompts

## Objetivo

Guardar prompts oficiais para gerar **tilesets placeholder** de Era Zero e Egito Antigo — pecas de tile reutilizaveis para o Tilemap da Unity, diferente das pixel art environment sheets (`docs/03_VisualDevelopment/environment-image-prompts.md`), que sao ilustracoes de referencia unicas, nao tiles individuais recortaveis.

Este documento cobre o item liberado no roadmap: "Criar tileset placeholder da Era Zero" e "Criar tileset placeholder visual do Egito" (Fase 1 / Escopo da Demo Inicial).

## Como usar no ChatGPT

1. Se possivel, anexe junto do prompt a pixel art environment sheet ja aprovada da mesma epoca (`art/pixel/environments/era-zero-lab/era-zero-lab-pixel-environment-v01.png` ou `art/pixel/environments/egypt-temple/egypt-temple-pixel-environment-v01.png`) como referencia visual/de paleta.
2. Cole o "Prompt Base — Tileset Sheet" e depois o bloco especifico da epoca.
3. Gere, avalie contra o checklist de sprite/tileset pronto (`pixel-art-bible.md`), e salve o resultado aprovado em `art/pixel/environments/<epoca>/` com nome versionado (`-tileset-v01.png`), atualizando o `asset-index.md` da pasta.
4. Validacao final e sempre manual — a IA e assistente de producao, nao diretora criativa.

## Regras herdadas (nao repetir por epoca)

- Canvas de personagem: 64x96 px. Tile grid: 32x32 px. PPU: 32.
- Luz superior esquerda, ~45 graus.
- Outline colorido e contextual, nunca preto puro.
- Dithering moderado, nunca competindo com leitura em movimento.
- Cobre/laranja reservado para tecnologia temporal. Preto/dourado reservado para presenca de Voss.
- Cada tileset deve cobrir: chao principal, plataformas, paredes, bordas, props de leitura, props narrativos, elementos destrutiveis/interativos, elementos de fundo sem colisao.

---

## Prompt Base — Tileset Sheet

```text
Authentic low-resolution pixel art tileset sheet for a 2D metroidvania game built in Unity (Tilemap, Pixel Perfect Camera). Hard pixel grid clearly visible, sharp blocky pixel edges, no anti-aliasing, no smooth blending, no soft painterly gradients, no photorealism, no 3D render. Shading achieved through visible dithering patterns and clean pixel clusters.

Grid and scale:
- Individual tiles designed on a 32x32 pixel grid.
- Character scale reference: a humanoid character is roughly 64px wide by 96px tall (2x3 tiles), so tile detail must read clearly at that relative scale.
- Present tiles laid out in clean rows on a neutral or transparent-looking background, not composed into a finished scene.

Required tile categories (label each group):
1. Main ground/floor tiles (top edge + fill + variations).
2. Platform tiles (one-way/elevated, distinct from main ground).
3. Wall tiles (vertical surfaces, corners, edges).
4. Border/edge tiles (transition pieces between materials or into void/background).
5. Readable gameplay props (small interactive-looking objects: switches, crates, machinery panels, torch/light sources — whatever fits the era).
6. Narrative props (small background-only decoration reflecting story elements of the era).
7. Destructible/interactive elements (cracked variants, breakable panels, or triggerable objects).
8. Non-collision background filler tiles (no gameplay function, pure atmosphere).

Lighting:
- Consistent single light source, upper-left, ~45 degrees, across every tile.
- Colored outlines that respond to material (never pure black).

Avoid:
- Photoreal textures or noisy photo-bashed materials.
- Tiles that only make sense as part of one large illustration (each tile must be reusable on its own).
- Excessive detail that would flicker or distract during tile repetition.
- Text or UI elements inside the sheet.
```

---

## Era Zero — Laboratorio / Tileset

```text
Use the Tileset Sheet prompt base.

Era: ERA ZERO — near-future research laboratory, before/around the temporal catastrophe.

Material language:
- Cold blue-gray structural panels and graphite-dark shadows as the main floor/wall material.
- Sterile white/cyan light strips as accents on floor edges or wall trim.
- Restrained copper/orange glow reserved for temporal-technology props only (cables, small reactor/core fragments, console screens) — matching Theo's own copper/orange technological accent, so character and environment read as the same visual world.
- Voss presence as narrative prop: a small repeated framed portrait, ID badge silhouette, or corporate symbol tile, rendered in the same restrained black/gold used for Voss elsewhere.

Gameplay tiles:
- Main ground: dark graphite/blue-gray floor panel tiles with subtle seams.
- Platforms: raised metal catwalk/floor tiles, visually distinct from main ground.
- Walls: server-rack-like paneling, glass partition tiles, cable conduits.
- Borders: damaged/cracked panel variants (for later use once the explosion state is needed).
- Props: consoles, floor grates, warning lights, server racks, small temporal-core fragment (copper/orange glow).
- Destructible/interactive: crackable glass panel, sparking exposed panel.
- Background filler: distant pipework, faint monitor glow, non-collision cable silhouettes.

Mood: quiet, controlled, scientific, with hidden tension — consistent with the approved Era Zero lab reference sheet.
```

## Egito Antigo — Camara do Templo / Tileset

```text
Use the Tileset Sheet prompt base.

Era: EGITO ANTIGO — ancient temple chamber, first playable historical era.

Material language:
- Warm sandstone and deep umber shadow as the main floor/wall material.
- Gold accent trim and lapis/teal secondary color for carved details.
- Voss presence as narrative prop: a small corrupted cartouche or black/gold emblem tile subtly inserted into the Egyptian iconography.
- Naiara/resistance hint as narrative prop: a small ivory symbol or cloth-marker tile, distinct from Voss's black/gold language, hinting at local resistance.
- Restrained cyan accent reserved for any temporal-technology intrusion into this era (matching the project's rule that cyan marks temporal rupture).

Gameplay tiles:
- Main ground: carved sandstone floor tiles with subtle wear/sand drift.
- Platforms: raised stone block/ledge tiles, distinct from main ground.
- Walls: carved pillar sections, hieroglyph wall panels, torch alcoves.
- Borders: sand-drift transition tiles, broken stone edge variants.
- Props: torch/brazier (warm light source), hanging cloth, carved statue fragment.
- Destructible/interactive: crackable stone block, collapsing column piece.
- Background filler: distant columns, faint sunbeam shafts, non-collision sand/dust silhouettes.

Mood: ancient, oppressive, sacred, exploratory — consistent with the approved Egypt temple reference sheet.
```

---

## Prompt — Tile Individual (arquivo unico, pronto pra ladrilhar)

O ChatGPT gera uma imagem por pedido, entao nao existe um botao unico que devolve "um pacote de arquivos". Para os tiles que realmente precisam repetir sem costura (chao, plataforma, parede, borda), o caminho mais confiavel e pedir **um arquivo por vez**, um por tile, em vez de tentar recortar um sheet de referencia (que nao esta num grid limpo). Repita o prompt abaixo trocando `[TILE NAME]` e a lista de `[MATERIAL LANGUAGE]` da epoca (ver secoes acima) para cada tile que faltar.

Props, props narrativos, elementos destrutiveis e fundo **nao precisam** desse tratamento — esses podem continuar vindo do sheet de referencia ja aprovado e ser recortados manualmente na Unity (Sprite Editor, modo Multiple, retangulo manual), porque sao posicionados uma vez, nao repetidos lado a lado.

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: [TILE NAME] — e.g. "main ground floor tile", "one-way platform tile", "wall panel tile", "outer corner border tile".

Material language: [MATERIAL LANGUAGE — colar a lista da era correspondente, secao acima].

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- If it is a floor/platform tile, the top edge is the walkable surface and must read clearly as "safe to stand on" from above.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

## Prompts Prontos — Era Zero (4 tiles essenciais)

### Era Zero — Chao Principal

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: main ground/floor tile for a near-future research laboratory.

Material language: cold blue-gray structural floor panel, graphite-dark shadows, a thin sterile white/cyan light strip accent along one edge. No copper/orange in this tile (that color is reserved for temporal-technology props elsewhere).

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top edge is the walkable surface and must read clearly as "safe to stand on" from above.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Era Zero — Plataforma

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: one-way elevated platform/catwalk tile for a near-future research laboratory, visually distinct from the main ground tile (thinner, metal-grate or raised-walkway look).

Material language: cold blue-gray metal catwalk, graphite-dark shadows, a thin sterile white/cyan light strip accent on the top edge.

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top edge is the walkable surface and must read clearly as "safe to stand on" from above.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Era Zero — Parede

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: vertical wall panel tile for a near-future research laboratory (server-rack-like paneling or glass partition look).

Material language: cold blue-gray structural panel, graphite-dark shadows, sterile white/cyan light strip accent, small restrained copper/orange glow only if depicting a cable or console detail.

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top and bottom edges must also align seamlessly if stacked vertically.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Era Zero — Borda/Transicao

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: outer corner/edge transition tile for the laboratory floor panel material, showing the floor tile transitioning into empty space/void at a 90-degree outer corner.

Material language: same cold blue-gray structural panel and graphite-dark shadow as the main ground tile, so it visually matches when placed next to it.

Tiling requirement:
- Must align seamlessly against the main ground/floor tile on the sides that touch it.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

## Prompts Prontos — Egito Antigo (4 tiles essenciais)

### Egito — Chao Principal

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: main ground/floor tile for an ancient Egyptian temple chamber.

Material language: carved sandstone floor block, deep umber shadow, subtle sand wear, thin gold accent trim along one edge.

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top edge is the walkable surface and must read clearly as "safe to stand on" from above.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Egito — Plataforma

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: one-way elevated stone ledge/platform tile for an ancient Egyptian temple chamber, visually distinct from the main ground tile (thinner carved stone block look).

Material language: carved sandstone block, deep umber shadow, thin gold accent trim on the top edge.

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top edge is the walkable surface and must read clearly as "safe to stand on" from above.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Egito — Parede

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: vertical carved pillar/wall panel tile for an ancient Egyptian temple chamber, with subtle hieroglyph-style carving.

Material language: carved sandstone, deep umber shadow, gold accent trim, small lapis/teal secondary color detail.

Tiling requirement:
- The left and right edges must align seamlessly with a copy of itself repeated side by side (no visible seam).
- The top and bottom edges must also align seamlessly if stacked vertically.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

### Egito — Borda/Transicao

```text
Single isolated pixel art game tile, exactly one tile, no scene, no composition, no other objects, no text, no label, no frame or border decoration around it.

Canvas: square, designed on a 32x32 pixel grid (export at 128x128 or 256x256 for quality, keeping hard pixel edges — no anti-aliasing, no smooth blending, no soft gradients, no photorealism).

Background: fully transparent (or flat solid magenta #ff00ff if transparency is not supported, so it can be chroma-keyed later).

Tile: outer corner/edge transition tile for the sandstone floor material, showing the floor tile transitioning into sand drift/void at a 90-degree outer corner.

Material language: same carved sandstone and deep umber shadow as the main ground tile, so it visually matches when placed next to it.

Tiling requirement:
- Must align seamlessly against the main ground/floor tile on the sides that touch it.
- Keep detail simple and centered enough that it still reads at small scale.

Lighting: single light source, upper-left, ~45 degrees, consistent with the rest of the tileset.

Avoid: scene composition, multiple tiles, labels, UI, borders/frames, photorealism, 3D render.
```

