# Linha Visual — Cenários
*(documento de direção de arte — paralelo ao `linha-visual.md` de personagens)*

## Decisão de pipeline técnico

**Motor: Unity** (revisado — substitui a decisão anterior de Unreal Engine).

> **Nota de revisão:** o projeto começou sendo planejado em Unreal Engine (Paper2D), mas essa decisão foi revista após avaliação de que Unity oferece ferramentas 2D nativas mais maduras (Tilemap, pacote 2D Animation com esqueleto/bones para sprites), um ecossistema de assets muito maior voltado a jogos 2D indie, e uma comunidade/tutoriais mais robustos para quem não tem experiência prévia em modelagem 3D — relevante já que a equipe não é composta por modeladores profissionais e precisa de apoio em animação de personagem, montagem de cenário e mecânicas prontas/adaptáveis via asset store. Unreal permanece uma alternativa válida caso o projeto migre para 3D no futuro, mas não é a recomendação atual.

**Abordagem definida: 2D puro (sprites com parallax), via Unity.**

- **Tilemap** (sistema nativo da Unity) cuida da montagem de cenário em grade, com suporte nativo a múltiplas camadas (tilemap layers) para parallax.
- **2D Animation** (pacote oficial da Unity) permite animação de personagem por esqueleto/bones aplicado a sprites 2D, sem precisar desenhar frame a frame nem modelar em 3D.
- **Parallax** é resolvido com múltiplas camadas de sprite/tilemap em profundidades diferentes, cada uma rolando a uma velocidade distinta em relação à câmera (via scripts simples de parallax, amplamente documentados na comunidade Unity).
- Consequência direta para produção: **todo concept de cenário deve ser pensado já separado em camadas**, não como uma ilustração única — essa parte da diretriz não muda com a troca de motor.

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
