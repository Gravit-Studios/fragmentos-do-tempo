# Sprite Prompt Guide

Status: guia operacional para geracao de sprites e sheets de pixel art.

Escopo: frente artistica, concept visual e pixel art. Este documento nao define implementacao na Unity.

## Estilo Base

- Pixel art autentico.
- Hard edges.
- Sem anti-aliasing.
- Dithering visivel quando houver gradiente ou textura.
- Paleta limitada.
- Silhueta legivel antes de detalhes.
- Fundo transparente para sprites, tiles e props isolados.

## Escala

- Tile base: `32x32`.
- Personagem jogavel: aproximadamente `64x96`, equivalente a `2x3 tiles`.
- Props pequenos devem respeitar a leitura em tela e nao competir com a silhueta do personagem.

## Tileset Sheet

Um tileset sheet deve ser organizado em grade, com tiles encostados e fundo transparente.

Categorias minimas:

- ground;
- platform;
- walls;
- borders;
- props.

Regras:

- cada tile deve ocupar a area planejada;
- bordas laterais precisam ser tileaveis;
- elementos decorativos devem ter versoes limpas e versoes com detalhe;
- separar tiles funcionais de props ornamentais sempre que possivel.

## Single Tile

Use esta estrutura quando a geracao for de um unico tile:

- `32x32`;
- fundo transparente;
- um unico tile central;
- tile ocupa toda a area;
- bordas laterais tileaveis;
- sem cena ao redor;
- sem multiplas variacoes na mesma imagem.

## Theo - Leitura Em Pixel Art

Elementos obrigatorios:

- cientista em fuga;
- jaqueta terracota sem emblema;
- goggles;
- cabelo castanho;
- cinto utilitario;
- cronometro/dispositivo temporal em cobre;
- scanner preso ao cinto;
- visual maduro, pratico e vulneravel.

Elementos de leitura em escala pequena:

- contraste entre jaqueta terracota e roupa escura;
- cobre/laranja no dispositivo temporal;
- goggles como marca facial;
- postura levemente inclinada, de improviso e movimento.

## Corrida Do Theo

Base para prompt de animacao:

- 6 frames;
- vista lateral;
- fundo transparente;
- mesma linha de chao;
- silhueta consistente entre frames;
- sem mudanca de escala entre poses;
- cabelo, jaqueta e equipamentos podem ter movimento secundario discreto.

## Construcao De Prompts

Ordem recomendada:

1. escolher o tipo: `Tileset Sheet`, `Single Tile`, `Character Sprite`, `Run Cycle` ou `Prop`;
2. acrescentar era;
3. definir material;
4. listar props ou elementos funcionais;
5. indicar narrativa visual;
6. indicar iluminacao;
7. reforcar escala, fundo transparente e restricoes de pixel art.

## Prompt Base - Tileset Sheet

```text
Pixel art tileset sheet for Fragmentos do Amanha, authentic pixel art, hard edges, no anti-aliasing, visible dithering, limited palette, transparent background, organized 32x32 grid, adjacent tileable tiles, categories for ground, platforms, walls, borders and props, readable silhouette, game-ready visual language.
```

Acrescentar depois:

```text
Era: [era/contexto].
Material: [pedra, metal, vidro, terra, areia, madeira, circuito, tecido].
Props: [lista curta].
Narrative cue: [o que esse lugar conta visualmente].
Lighting: [ciano temporal, cobre, luz quente, sombra fria].
```

## Prompt Base - Single Tile

```text
Single 32x32 pixel art tile for Fragmentos do Amanha, transparent background, one tile only, fills the full tile area, tileable side borders, hard edges, no anti-aliasing, visible dithering, limited palette, readable at small scale, no extra objects, no scene, no multiple variations.
```

## Prompt Base - Theo Run Cycle

```text
Pixel art run cycle sprite sheet of Theo from Fragmentos do Amanha, 6 frames, side view, transparent background, same ground line across all frames, consistent scale and silhouette, mature scientist in flight, terracotta jacket with no emblem, dark clothing, goggles, brown hair, utility belt, copper temporal chronometer on wrist, scanner attached to belt, hard edges, no anti-aliasing, limited palette, readable 64x96 character scale.
```

## Relacao Com Outros Documentos

- `docs/03_VisualDevelopment/pixel-art-bible.md`
- `docs/03_VisualDevelopment/tileset-image-prompts.md`
- `docs/03_VisualDevelopment/character-image-prompts.md`
- `docs/06_Animation/animation-bible.md`
