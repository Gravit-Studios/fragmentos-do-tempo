# Linha Visual — Cenários
*(documento de direção de arte — paralelo ao `linha-visual.md` de personagens)*

## Decisão de pipeline técnico

**Abordagem definida: 2D puro (sprites com parallax), via Unreal Paper2D.**

- **Paper2D** (plugin nativo da Unreal Engine) cuida de sprites, animação por flipbook e tilemaps — não requer engine externa.
- **Parallax** é resolvido com múltiplas camadas de sprite em profundidades Z diferentes, cada uma rolando a uma velocidade distinta em relação à câmera.
- Consequência direta para produção: **todo concept de cenário deve ser pensado já separado em camadas**, não como uma ilustração única.

## Estrutura de camadas (padrão para todas as épocas)

| Camada | Função | Tratamento visual |
|---|---|---|
| **Fundo distante** | Céu/horizonte, sem interação | Blocos de cor sólidos, sem gradiente, silhueta simples |
| **Camada de trás** | Contexto do ambiente | 1 tom de sombra, menos detalhe que o primeiro plano |
| **Camada de jogo** | Onde o personagem caminha/interage | Mais detalhe, contorno definido (mesma lógica dos personagens), hitbox clara |
| **Camada de frente** | Elementos em frente ao personagem (parallax invertido) | Silhuetas escuras/sombra, pouco detalhe, reforça profundidade |

## Regras de estilo (consistentes com `linha-visual.md` de personagens)

- Sem gradiente suave, sem oclusão ambiental pintada, sem brilho especular.
- Sombra em blocos sólidos (1-2 tons por superfície).
- Paleta limitada por cena: 4-6 cores + barra de "production color" documentada.
- Cor de acento (cobre/laranja) reservada para elementos tecnológicos, seguindo a mesma lógica usada nos personagens — presença discreta (Theo/fase inicial), ausente ou mínima em épocas históricas antigas, ostentada apenas nas cenas ligadas a Voss/tecnologia do futuro.
- Cada época deve ter uma "assinatura de forma arquitetônica" reconhecível à distância (ex: colunas gregas, castelo medieval, trincheiras) — ver `epocas.md` para a lista de identidades visuais por período.
- **Presença ambiental de Voss (obrigatória em toda época):** cada cenário deve reservar ao menos um elemento visual referenciando Voss, adaptado à linguagem daquele período — estátua/afresco (Egito, Grécia), retrato a óleo (Absolutismo), cartaz de propaganda (WWII), foto/tela digital (Internet, Era Moderna). Ver `personagens/voss.md`, seção "Comportamento visual em cena".

## Prompt-base reutilizável (cenário)

```
Wide 2D side-scrolling game background illustration, layered for parallax (background sky layer, back layer, gameplay midground layer, foreground silhouette layer — describe each layer clearly separated).
Illustration style: clean flat cel-shading with hard-edged shadows (1-2 tones per surface), no soft gradients, no painted texture, bold clean shapes, consistent with a stylized indie game background (not photorealistic, not overly painterly).

SCENE: [descrição específica da cena/época]

LAYERS:
- Background: [descrição]
- Back layer: [descrição]
- Gameplay midground layer: [descrição, elementos de plataforma legíveis]
- Foreground: [descrição, silhuetas escuras passando na frente do personagem]

Color palette: [cores base da cena + uso do acento cobre/laranja se aplicável]. Include a labeled flat color swatch bar in the corner.

Mood: [tom emocional da cena]
```

## Primeiro teste — Era Zero (Laboratório)

Duas versões do mesmo espaço, geradas para comparação lado a lado (reforça a mecânica central: mesmo lugar, timeline diferente):

### A — Laboratório destruído (momento da explosão)
Paleta: azul-acinzentado frio (estrutura) + preto carvão (dano/sombra) + laranja quente (iluminação de emergência, faíscas, acento tecnológico). Tom: tenso, desorientador.

### B — Laboratório intacto (timeline alterada, fotos espalhadas)
Mesma paleta-base, mas mais calma/limpa — sem laranja de emergência, iluminação branca/fria neutra, acento cobre só em telas/tecnologia funcional. Tom: quieto, ordeiro, mas perturbador pelo excesso de fotos repetidas, não por destruição.

> Prompts completos disponíveis no histórico da conversa.

## Template de Ficha de Cenário (formato de entrega oficial)
Paralelo ao template de concept sheet de personagens (ver `linha-visual.md`):

```
Authentic low-resolution pixel art environment reference sheet, hard pixel grid clearly visible — sharp, blocky pixel edges with NO anti-aliasing, NO smooth blending. Shading achieved through visible dithering patterns rather than smooth blends. Futuristic UI-style frame/border around the entire composition (thin glowing corner brackets, HUD-style accent lines).

LAYOUT:
- Main wide environment illustration, composed as a 2.5D side-scrolling game background with clear parallax depth layers (background/midground gameplay path/foreground silhouette).
- 2-3 small detail close-up insets (a specific set-piece prop, light source, or symbol from the scene).
- Location name (bold pixel-font-style) + one-line description, positioned like a level-select screen.
- Small labeled "FLAT COLORS" swatch bar.
```

## Status
- ✅ Pipeline técnico definido (2D + Paper2D + parallax).
- ✅ Estrutura de camadas e regras de estilo fechadas.
- ✅ Template de ficha de cenário definido, com 3 primeiros ambientes gerados (Laboratório intacto, Laboratório pós-explosão, Egito Antigo — câmara do templo).
- ⏳ Próximo passo: aplicar a mesma diretriz às 6 épocas históricas restantes.
