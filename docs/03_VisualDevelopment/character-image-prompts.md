# Character Image Prompts

## Objetivo

Guardar prompts oficiais e reutilizaveis para gerar imagens dos personagens principais em dois niveis de arte:

- **Pixel art / in-game:** sprites e reference sheets limpos, legiveis e animaveis.
- **Concept art / artbook:** ilustracoes detalhadas para apresentacao, lore e direcao visual.

Todo resultado aprovado deve ser salvo junto ao prompt usado, para que a producao seja repetivel.

## Regras globais

- A IA e assistente de producao, nao diretora criativa.
- Validacao final e manual.
- Geracoes devem preservar o DNA visual de Theo, Naiara e Voss.
- Pixel art nao deve parecer pintura filtrada.
- Concept art nao deve tentar imitar pixel art.

---

## Prompt Base — Pixel Art Character Sheet

```text
Authentic low-resolution pixel art character reference sheet, hard pixel grid clearly visible, sharp blocky pixel edges, no anti-aliasing, no smooth blending, no soft painterly gradients. Shading achieved through visible dithering patterns and clean color clusters rather than smooth blends. Effective sprite scale should read as roughly 64 to 96 pixels tall before upscaling.

Create a production-facing character sheet for a 2D metroidvania game.

Layout:
- Main full-body front-facing sprite at 100% scale.
- Smaller scale readability samples at 75%, 50%, 25%, and 16x.
- One idle pose, one run pose, one jump pose, one attack anticipation pose.
- Small detail callouts for fixed identity elements.
- Small flat color palette swatch bar.
- Character name and one-line function label.

Lighting:
- Main light from upper left at 45 degrees.
- Strong readable shadow shapes.
- Moderate dithering only where it helps material transitions.

Style constraints:
- Clean silhouette first.
- Colored outline, not pure black.
- Details must not compete with animation.
- No painterly texture.
- No vector smoothing.
- No photorealism.
- No 3D render.
- No UI clutter beyond a simple reference-sheet frame.
```

## Prompt Base — Concept Art / Artbook Character Sheet

```text
Clean, precise semi-realistic RPG/MOBA character concept sheet for an artbook and pitch presentation, not pixel art. Confident medium-weight linework, controlled cel-shading with selective soft gradient blending on fabric folds, hair, and skin. Clear material differentiation: metallic sheen, matte leather, soft fabric drape, worn fabric, and subtle technology glow where relevant.

Create a polished full-body character concept sheet.

Layout:
- Large full-body three-quarter pose with personality and readable silhouette.
- Small back-view thumbnail.
- 1 to 2 equipment or weapon detail renders.
- Small head or expression close-up.
- Small labeled color palette swatch bar.
- Character name and 2 to 3 line lore/personality blurb.

Background:
- Neutral or soft minimal background.
- No busy scene.
- Full focus on the character.

Style constraints:
- This is richly rendered illustration.
- Not pixel art.
- Not flat vector.
- Not chibi.
- Not photorealistic.
- No excessive ornament that breaks gameplay readability.
```

---

## Theo — Pixel Art / Era Zero

```text
Use the Pixel Art Character Sheet prompt base.

Character:
THEO, the scientist protagonist. Initially non-combatant, cautious, intelligent, improvised, and physically capable but not a trained warrior.

Era:
Era Zero / near-future laboratory introduction.

Visual DNA:
- Protective goggles on forehead.
- Wrist-mounted temporal chronometer device.
- Copper/orange technological accent.
- Functional asymmetric outfit.
- Terracotta/orange jacket with practical pockets and straps.
- Dark teal or desaturated green undersuit/pants.
- Worn boots and utility belt.
- Small scanner/lantern tool with hard pixel cone-light.

Pose and attitude:
- Alert and defensive, as if escaping a damaged laboratory.
- Not heroic swagger.
- Slight forward lean, ready to move.

Important identity rule:
Even at tiny scale, Theo must be readable through goggles, wrist chronometer, copper/orange accent, and practical asymmetric silhouette.
```

## Theo — Concept Art / Artbook

```text
Use the Concept Art / Artbook Character Sheet prompt base.

Character:
THEO, scientist protagonist of Fragmentos do Amanha / Era Zero. He is not a classic hero at the start; he is a brilliant researcher forced into survival after a temporal catastrophe.

Visual DNA:
- Protective goggles resting on the forehead.
- Wrist-mounted temporal chronometer, softly glowing copper/orange.
- Terracotta field jacket with hood, asymmetrical straps, utility pockets, and signs of use.
- Dark teal technical clothing beneath the jacket.
- Practical boots, gloves, small scanner/lantern device.
- Copper/orange technology accent, used sparingly.

Personality:
Cautious, focused, analytical, improvised, emotionally under pressure.

Pose:
Dynamic three-quarter pose, one foot back, holding scanner/lantern, wrist chronometer visible. He should feel ready to run, not ready to pose.

Avoid:
Do not make him look like a soldier, superhero, cyberpunk mercenary, or fantasy rogue. Keep him grounded as a scientist adapting under pressure.
```

---

## Naiara — Pixel Art / Lineage

```text
Use the Pixel Art Character Sheet prompt base.

Character:
NAIARA, the lineage of warrior-resistance figures. This version should read as a timeless base design for the lineage, suitable for adaptation across eras.

Visual DNA:
- Natural fabrics.
- Agile silhouette.
- Inherited ivory mark, pendant, or object.
- Grounded resistance identity, not royal or chosen-one fantasy.
- Curved movement language and triangular shapes.
- Capable fighter, not playable protagonist.

Palette:
Warm natural cloth, ivory accent, dark hair, earthy shadows, restrained copper/orange only if connected to temporal legacy.

Pose and attitude:
Low, balanced, ready to move. Calm intensity. Protective rather than theatrical.

Important identity rule:
Every version of Naiara must feel like a different person from a lineage, but the inherited object/mark and agile resistance posture must remain visible.
```

## Naiara — Concept Art / Artbook

```text
Use the Concept Art / Artbook Character Sheet prompt base.

Character:
NAIARA, a warrior from a lineage of resistance across time. She is not a single immortal character; she represents legacy carried by different women in different eras.

Visual DNA:
- Natural fabrics and practical layered clothing.
- Inherited ivory pendant, mark, or object clearly visible.
- Agile combat posture.
- Grounded, capable, alert expression.
- No royal costume, no chosen-one glow, no decorative excess.

Personality:
Resilient, direct, protective, perceptive, connected to resistance and legacy.

Pose:
Dynamic grounded combat-ready pose, body angled, one hand near weapon or defensive stance, inherited object visible.

Avoid:
Do not make her look like a fantasy princess, divine oracle, superhero, or generic assassin. She should feel human, local, and connected to a historical resistance.
```

---

## Voss — Pixel Art / Tyrant

```text
Use the Pixel Art Character Sheet prompt base.

Character:
VOSS, the antagonist and former scientific partner of Theo. He rewrites history and accumulates power across eras.

Visual DNA:
- Vertical, heavy, imposing silhouette.
- Symmetry.
- Black and gold palette with dark red/wine undertones.
- Copper/orange technology accent, more exposed and ostentatious than Theo's.
- Central chest device, geometric and precise, like a power-control instrument rather than an antique clock.
- Subtle remnant of a scientist coat or formal lab silhouette beneath authoritarian design.

Pose and attitude:
Still, controlled, certain. He does not need to threaten; the environment already obeys him.

Important identity rule:
Voss must read as control, power, and accumulated authority, not as a medieval king. Avoid ornate old-world royalty unless adapted through technological geometry.
```

## Voss — Concept Art / Artbook

```text
Use the Concept Art / Artbook Character Sheet prompt base.

Character:
VOSS, ex-partner of Theo and tyrant across rewritten history. He believes he is the only one willing to do what is necessary.

Visual DNA:
- Tall, vertical, symmetrical silhouette.
- Black, gold, and dark wine/red palette.
- Imposing coat with geometric panels.
- Subtle circuit-like copper/orange lines.
- Central chest device as a precise technological power symbol.
- Recognizable beard and severe controlled expression.
- Hints of former scientist identity in collar, internal garment, or lab-coat-derived structure.

Personality:
Absolute certainty, control, cold conviction, accumulated authority.

Pose:
Formal three-quarter pose, upright and calm, one hand near chest device or behind back, looking directly at the viewer.

Avoid:
Do not make him look like a generic fantasy king, vampire noble, or chaotic villain. He is a technological tyrant with scientific origins and authoritarian elegance.
```
