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

## Status
- ✅ Pipeline técnico definido (2D + Paper2D + parallax).
- ✅ Estrutura de camadas e regras de estilo fechadas.
- 🔄 Primeiro teste de cenário (Laboratório, versões A e B) gerado — aguardando avaliação visual.
- ⏳ Próximo passo: aplicar a mesma diretriz às 6 épocas históricas definidas em `epocas.md`.
