# Theo -- pastas de pose (visual v04, ficha de personagem)

Cada pasta recebe os frames de cada pose, seguindo o visual definitivo confirmado em 2026-07-17 (jaqueta com capuz/forro, ficha completa em `artbook/pixel-reference/characters/theo/chatgpt-2026-07-17/`). Uma imagem por frame. A partir de 2026-07-17 os frames sao feitos a mao no Photoshop (nao mais gerados via ChatGPT), usando `docs/03_VisualDevelopment/theo-sprite-canvas-template-1024.png` como guia: canvas fixo `1024x1024`, linha de chao (pes) sempre no mesmo Y do canvas, fundo com transparencia real (sem xadrez pintado).

- `Idle/` -- **completo**, 6 frames (`theo-sprite-idle-01.png` a `06.png`), pe em y=987. E a referencia de escala (`TheoSpriteSetup.IdleSpritePixelsPerUnit`).
- `Run/` -- **completo**, 8 frames (`theo-sprite-run-01.png` a `08.png`). Vieram com o pe em y~918-929 (canvas identico, so deslocado verticalmente em relacao ao idle); realinhados para y=987 com `tools/art-pipeline/align_foot_line.py` antes de importar.
- `Jump/` -- pulo (referencia: "PULO").
- `Land/` -- pouso/aterrissagem (referencia: "POUSO").
- `Attack/` -- ataque com lanterna (referencia: "ATAQUE COM LANTERNA").
- `Fall/` -- queda/em voo antes de pousar (referencia: "CAIR"). Faz sentido pro jogo: `TheoController` ja expoe `Grounded`/`VerticalSpeed` pro Animator (preparado na Sprint 1), entao dá pra distinguir Pulo (subindo) de Fall (caindo) quando os frames chegarem.
- `Crouch/` -- agachar (referencia: "AGACHAR"). **Sem uso no jogo ainda** -- `TheoController` nao tem mecanica de agachar. Nao e bloqueante, so nao sera integrado ate existir a mecanica.
- `HitDeath/` -- reacao a dano / morte. **Nao existe na ficha de personagem** -- precisa ser gerado a parte. E um item pendente do roadmap (Fase 3: "Hit/death placeholder") que a ficha atual nao cobre.

Nomeie os arquivos como `theo-sprite-<pose>-NN.png` (ex.: `theo-sprite-run-01.png`), numerados em ordem dentro do ciclo. O visual anterior (`theo-sprite-v03.png`, `Run-v03/`) ja foi removido -- Idle e Run novos ja estao no codigo (`TheoSpriteSetup`/`TheoAnimationSetup`), **ainda pendente de teste em Play Mode**.
