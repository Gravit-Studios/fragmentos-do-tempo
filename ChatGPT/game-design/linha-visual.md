# Linha Visual — Personagens
*(documento de direção de arte)*

> **✅ ESTILO OFICIAL DEFINIDO (v2) — PIXEL ART**
> Após uma segunda rodada de testes, a direção visual do projeto migrou de vetor flat/low-poly 3D para **pixel art autêntico**, validado com o concept aprovado do Theo (versão cientista, Era Zero). Esta é a diretriz vigente e substitui a v1 (cel-shading vetorial) documentada no histórico abaixo.

## Histórico de decisões de estilo (contexto)

1. **Moodboard Zinkase/Bee Square (cel-shading duro):** silhueta em primeiro lugar, paleta reduzida. Testes internos via SVG não atingiram o nível de acabamento desejado.
2. **Teste techwear semi-realista:** descartado — render pictórico, gradiente suave, rim light.
3. **Referência "Survivor" (ArtStation):** aproveitado o formato de entrega (turnaround + color script), descartado o render pictórico.
4. **Estilo vetorial de traço definido (v1, aprovado temporariamente):** contorno forte, shading em blocos — validado nos 3 personagens principais (Theo, Voss, Naiara) e usado durante o desenvolvimento das 7 épocas.
5. **Teste low-poly 3D faceado:** avaliado como alternativa de pipeline 3D — mantido como referência secundária, não adotado como padrão principal (ver nota de pipeline abaixo).
6. **Pixel art autêntico (v2, ESTILO ATUAL):** testado a partir de referências de pixel art atmosférico (dithering, dramatic lighting) — resultado aprovado após duas iterações (primeira versão ficou "pixel art suavizado/com filtro"; segunda versão, com instruções explícitas contra anti-aliasing e a favor de dithering real, foi aprovada).

## Por que pixel art e não low-poly 3D
Pixel art é sprite 2D genuíno — **100% alinhado ao pipeline técnico vigente** (Unity 2D + Tilemap + 2D Animation + parallax em camadas), sem a ambiguidade que o teste low-poly 3D introduzia (aquele exigiria repensar pipeline para modelos 3D reais). Pixel art resolve o "traço duro sem gradiente" que sempre foi a meta do projeto, mas com uma técnica que tem economia de produção mais previsível para um estúdio pequeno.

## Definição de estilo (fechada e aprovada)

| Aspecto | Definição |
|---|---|
| **Resolução efetiva** | Baixa resolução real antes do upscale (referência: ~64-96px de altura por personagem) — grid de pixel visível, nunca uma ilustração "com filtro de pixelização". |
| **Bordas** | Sem anti-aliasing, sem suavização — pixels quadrados nítidos. |
| **Shading** | Dithering (padrão de pontos/xadrez entre bandas de cor) em vez de gradiente suave — técnica clássica de pixel art moderno (referências: Owlboy, Eastward, Dead Cells). |
| **Iluminação** | Forte e atmosférica — uma fonte de luz de destaque (ex: o brilho do cronômetro/lanterna do Theo) contra um fundo mais escuro/monocromático, criando um ponto focal claro. |
| **Silhueta** | Elementos como capuz/capa ajudam a criar uma forma dramática reconhecível mesmo em baixa resolução. |
| **Paleta** | Estritamente limitada e "contável" (sem gama contínua de tons) — barra "FLAT COLORS" documentada em toda entrega. |
| **Elementos fixos dos personagens** | Continuam válidos independentemente do estilo de renderização (óculos na testa do Theo, cronômetro, marca de Naiara, dispositivo do peito de Voss) — a mudança é técnica de renderização, não de design de personagem. |

**Resumo em uma frase:** *Pixel art autêntico de baixa resolução efetiva, sombreado por dithering, com um único ponto de luz forte e atmosférico como âncora visual de cada composição — nunca ilustração suavizada com aparência de pixel art.*

## Prompt-base reutilizável (personagens)

```
Authentic low-resolution pixel art character sprite, hard pixel grid clearly visible — sharp, blocky pixel edges with NO anti-aliasing, NO smooth blending, NO soft painterly gradients. Shading achieved through visible dithering patterns (checkerboard/ordered dithering between adjacent color bands) rather than smooth blends. Effective canvas resolution should read as roughly 64-96 pixels tall before upscaling.

Full body sprite, standing dynamic pose.

CHARACTER: [descrição específica]

Color palette: strictly limited, countable flat colors, no blended in-between tones. Include a small "FLAT COLORS" labeled swatch bar in the corner.

Lighting: hard-edged directional lighting from a single strong accent light source, shadow shapes defined by dithering, not smooth falloff.

Background: flat solid color, no gradient, no scene detail (for character sheets) / layered for parallax (for environment scenes).
```

## Prompts aplicados aos personagens principais (Era Zero)

### Theo (cientista, fase inicial) — ✅ APROVADO
Prompt completo salvo em `docs/03_VisualDevelopment/character-image-prompts.md`. Jaqueta terracota com capuz, capa fluida atrás, óculos na testa, cronômetro brilhante no pulso (ponto focal), lanterna/scanner na mão com feixe de luz em cone de pixel duro.

### Voss e Naiara
Prompts completos salvos em `docs/03_VisualDevelopment/character-image-prompts.md`, reaproveitando as descrições de figurino já aprovadas nas versões anteriores e adaptando para a técnica de pixel art vigente.

## Template de Concept Sheet (formato de entrega oficial)
Baseado em referências de character sheet (estilo Riot/Ekko), adotando apenas a **estrutura de composição**, não o estilo de arte (que continua pixel art):

```
Authentic low-resolution pixel art character reference sheet, hard pixel grid clearly visible — sharp, blocky pixel edges with NO anti-aliasing, NO smooth blending, NO soft painterly gradients. Shading achieved through visible dithering patterns rather than smooth blends. Futuristic UI-style frame/border around the entire composition (thin glowing corner brackets, HUD-style accent lines).

BACKGROUND: instead of a flat empty background, use a low-detail, low-contrast environment silhouette suggesting the character's era/context (e.g. faint temple columns for Egypt, a smoky lab corridor for the explosion scene) — heavily muted/desaturated and darker or lower-contrast than the character, kept simple enough to never compete with the character's silhouette or readability. Think of it as a soft contextual backdrop, not a detailed scene.

LAYOUT:
- Three full-body poses: front, 3/4 profile, back — consistent proportions and outfit.
- 2-3 small detail close-up insets (weapon, glove, device).
- 2 small head/expression variant thumbnails.
- Character name (bold pixel-font-style) + one-line description, positioned like a character-select screen.
- Small labeled "FLAT COLORS" swatch bar.
```

## Status
- ✅ Estilo pixel art aprovado como direção oficial (substitui vetor flat e descarta low-poly 3D como padrão principal).
- ✅ Template de concept sheet definido (frame + 3 poses + detalhes + variações de cabeça + nome/descrição).
- ✅ Alinhado ao pipeline técnico (Unity 2D + Tilemap + 2D Animation + parallax) sem necessidade de revisão.
- 🔄 Teste de cenário em andamento no mesmo estilo (ver `linha-visual-cenario.md`).
- ⏳ Próximo passo: gerar Voss e Naiara em pixel art, e retroaplicar o estilo às 7 épocas já roteirizadas em vetor/low-poly.
