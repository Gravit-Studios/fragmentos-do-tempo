# Environment Image Prompts

## Objetivo

Guardar prompts oficiais para cenarios em dois niveis de arte:

- **Pixel art / in-game:** referencias de ambiente para tilesets, camadas de parallax, leitura de plataforma e atmosfera jogavel.
- **Concept art / artbook:** ilustracoes detalhadas para apresentacao, lore e direcao visual.

Todo asset gerado deve ser salvo junto ao prompt usado e registrado no indice de assets.

## Regras globais

- Cada cenario deve deixar clara a funcao jogavel da camada principal.
- Cada cenario deve sugerir camadas de parallax: fundo distante, camada de tras, camada de jogo e primeiro plano.
- A presenca de Voss deve ser ambiental, mesmo que discreta.
- Arte de concept pode ser detalhada; pixel art deve priorizar leitura.
- Evitar texto pequeno ou ilegivel dentro da imagem, exceto nomes grandes de ficha quando solicitado.

---

## Prompt Base — Pixel Art Environment Sheet

```text
Authentic low-resolution pixel art environment reference sheet for a 2D metroidvania game, hard pixel grid clearly visible, sharp blocky pixel edges, no anti-aliasing, no smooth blending, no soft painterly gradients. Shading achieved through visible dithering patterns and clean pixel clusters. Designed for Unity 2D, Tilemap, Pixel Perfect Camera, and parallax layers.

Layout:
- Main wide 2D side-scrolling environment view.
- Clear parallax separation: background sky/far layer, back layer, gameplay midground/platform layer, foreground silhouette layer.
- 2 to 3 small detail close-up insets for props, symbols, materials, or light sources.
- Small flat color palette swatch bar.
- Location name and one-line mood label.

Gameplay readability:
- Main walking path and platforms must be readable.
- Collision surfaces should be visually clear.
- Props must not obscure the player path.
- Avoid over-detailing the gameplay layer.

Lighting:
- Strong directional light.
- Pixel-readable shadow groups.
- Moderate dithering only where useful.

Avoid:
- Photorealism.
- 3D render.
- Smooth painterly gradients.
- Blurry atmosphere.
- Excessive text.
- Decorative clutter that hides the playable path.
```

## Prompt Base — Concept Art Environment

```text
Detailed cinematic concept art environment for an artbook and pitch presentation, not pixel art. Richly illustrated, atmospheric, clear composition, material differentiation, strong lighting, and strong sense of place. Designed as a visual target that can later be translated into pixel art and Unity parallax layers.

Layout:
- Wide 2D side-scrolling composition.
- Clear visual separation between far background, back layer, gameplay path, and foreground elements.
- Strong focal point.
- No player character required unless used only as a tiny scale reference silhouette.

Style:
- Polished concept art.
- Detailed but readable.
- Not photorealistic.
- Not pixel art.
- Not flat vector.

Avoid:
- Busy unreadable layout.
- Excessive fog or blur.
- Camera angle too cinematic to be useful for a side-scroller.
- Text-heavy UI.
```

---

## Era Zero — Laboratorio Inicial / Pixel Art

```text
Use the Pixel Art Environment Sheet prompt base.

Location:
ERA ZERO — Laboratorio Inicial.

Scene:
Near-future research laboratory before the catastrophe. Quiet, functional, slightly unsettling. The room should feel clean but not sterile: workstations, suspended cables, glass containment pods, monitors, floor panels, server racks, and a central temporal machine prototype.

Gameplay layer:
Clear 2D side-scrolling floor with readable platforms, stairs or catwalks, and a few cover-like lab props that do not block the path.

Voss presence:
Subtle: repeated framed photo, ID badge, corporate/project symbol, or screen portrait of Voss in the background. It should feel like he already occupies too much space in the lab.

Palette:
Cold blue-gray structure, dark graphite shadows, white/cyan lab light, restrained copper/orange accents on temporal technology.

Mood:
Quiet, controlled, scientific, with hidden tension.
```

## Era Zero — Laboratorio Inicial / Concept Art

```text
Use the Concept Art Environment prompt base.

Location:
ERA ZERO — Laboratorio Inicial.

Scene:
Near-future research laboratory moments before the rupture in time. A central temporal machine prototype sits in the mid-background, surrounded by research consoles, glass partitions, cables, diagnostic screens, floor panels, and server racks. The space is believable for scientists, not a superhero base.

Composition:
Wide side-scrolling layout with a readable walking path. Far background shows lab architecture and glass walls. Back layer has monitors and temporal apparatus. Gameplay layer has floor panels, workstations, and clear traversal space. Foreground has dark silhouettes of cables or equipment.

Voss presence:
Subtle but intentional: a portrait/photo, project badge, or repeated symbol connected to Voss.

Palette:
Cold blue-gray, graphite, sterile white/cyan light, copper/orange temporal accents.

Mood:
Calm before disaster, controlled, intelligent, uneasy.
```

---

## Era Zero — Momento da Explosao / Pixel Art

```text
Use the Pixel Art Environment Sheet prompt base.

Location:
ERA ZERO — Laboratorio / Momento da Explosao.

Scene:
The same laboratory during the temporal explosion. The central machine is rupturing, emitting harsh copper/orange light, broken glass, sparks, emergency lights, smoke columns, cracked floor panels, hanging cables, and distorted temporal fragments. Keep the playable path readable.

Gameplay layer:
Damaged floor panels, broken catwalks, safe ledges, debris pushed away from the main path, readable hazards such as sparks and exposed energy.

Voss presence:
Partially damaged photo, cracked monitor with his face/symbol, or distorted project logo near the explosion.

Palette:
Cold blue-gray and charcoal shadows contrasted with hot copper/orange emergency light, small cyan remnants from lab screens.

Mood:
Tense, disorienting, dangerous, but still readable for gameplay.
```

## Era Zero — Momento da Explosao / Concept Art

```text
Use the Concept Art Environment prompt base.

Location:
ERA ZERO — Laboratorio / Momento da Explosao.

Scene:
The near-future research laboratory at the instant of temporal catastrophe. The central machine tears open with copper/orange energy, emergency lighting floods the room, glass panels fracture, cables whip loose, sparks and smoke cut through the space, and time-distortion shards bend the light. It should feel like the origin point of the story.

Composition:
Wide side-scrolling view, not a first-person shot. Keep the ground path visible under debris. Far background shows lab architecture in chaos. Back layer has ruptured machinery and monitors. Gameplay layer has damaged floor, broken platforms, and clear hazard silhouettes. Foreground has dark cable/equipment silhouettes.

Voss presence:
A cracked screen, damaged photo, or corrupted project symbol hinting at Voss's role.

Palette:
Blue-gray lab structure, black smoke, hot copper/orange temporal energy, emergency red/orange highlights, small cyan screen remnants.

Mood:
Catastrophic, urgent, readable, narrative-heavy.
```

---

## Egito Antigo — Primeira Era / Pixel Art

```text
Use the Pixel Art Environment Sheet prompt base.

Location:
EGITO ANTIGO — Camara do Templo / Primeira Era.

Scene:
Ancient Egyptian temple chamber adapted for metroidvania exploration. Sandstone blocks, carved pillars, hieroglyphs, warm torchlight, shafts of sunlight, shallow sand drifts, stone platforms, ramps, and hidden passages. Include signs that Voss has inserted himself into local iconography.

Gameplay layer:
Readable stone floor, platforms, ledges, columns, and climbable-looking architecture. Avoid cluttering the traversal route.

Voss presence:
Subtle corrupted cartouche, gold-black emblem, statue face that resembles Voss, or altered mural showing his authority.

Naiara/resistance hint:
Small hidden cloth marker, ivory symbol, or resistance mark near a side path.

Palette:
Warm sandstone, deep umber shadows, gold accents, lapis/teal secondary color, restrained black/gold Voss marks.

Mood:
Ancient, oppressive, sacred, exploratory.
```

## Egito Antigo — Primeira Era / Concept Art

```text
Use the Concept Art Environment prompt base.

Location:
EGITO ANTIGO — Camara do Templo / Primeira Era.

Scene:
Ancient Egyptian temple chamber for the first historical era. Monumental sandstone architecture, carved columns, hieroglyphic walls, torch basins, shafts of desert sunlight, sand gathered in corners, stone platforms and ramps designed for side-scrolling exploration. The room should feel sacred but corrupted by Voss's presence.

Composition:
Wide side-scrolling composition. Far background shows massive temple depth and columns. Back layer shows murals, statues and Voss-corrupted iconography. Gameplay layer has readable stone floor, platforms and traversal ledges. Foreground has dark stone silhouettes or hanging cloth shadows.

Voss presence:
A black/gold corrupted cartouche, statue or mural that subtly resembles Voss, integrated into Egyptian visual language.

Naiara/resistance hint:
A small ivory mark or cloth marker hidden near a side path, suggesting the local resistance.

Palette:
Warm sandstone, ochre, deep brown shadows, gold, lapis/teal accents, restrained black/gold Voss contamination.

Mood:
Ancient, sacred, oppressive, mysterious, ready for exploration.
```
