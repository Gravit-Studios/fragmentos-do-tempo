# Theo -- pastas de pose (visual v04, ficha de personagem)

Cada pasta recebe os frames gerados isoladamente no ChatGPT para aquela pose, seguindo o visual definitivo confirmado em 2026-07-17 (jaqueta com capuz/forro, ficha completa em `artbook/pixel-reference/characters/theo/chatgpt-2026-07-17/`). Uma imagem por frame, nao sheets combinadas (ver seguranca de escala/transparencia em `production/handoff-current-state.md`).

- `Idle/` -- parado (referencia: "IDLE" na ficha).
- `Run/` -- corrida (referencia: "CORRIDA").
- `Jump/` -- pulo (referencia: "PULO").
- `Land/` -- pouso/aterrissagem (referencia: "POUSO").
- `Attack/` -- ataque com lanterna (referencia: "ATAQUE COM LANTERNA").
- `Fall/` -- queda/em voo antes de pousar (referencia: "CAIR"). Faz sentido pro jogo: `TheoController` ja expoe `Grounded`/`VerticalSpeed` pro Animator (preparado na Sprint 1), entao dá pra distinguir Pulo (subindo) de Fall (caindo) quando os frames chegarem.
- `Crouch/` -- agachar (referencia: "AGACHAR"). **Sem uso no jogo ainda** -- `TheoController` nao tem mecanica de agachar. Nao e bloqueante, so nao sera integrado ate existir a mecanica.
- `HitDeath/` -- reacao a dano / morte. **Nao existe na ficha de personagem** -- precisa ser gerado a parte. E um item pendente do roadmap (Fase 3: "Hit/death placeholder") que a ficha atual nao cobre.

Nomeie os arquivos como `theo-<pose>-NN-descricao.png` (ex.: `theo-run-01-contact.png`, seguindo o padrao ja usado). `theo-sprite-v03.png` e `Run-v03/` (fora dessas pastas) sao o visual anterior, superado por esta decisao -- ficam ate o Idle/Run novos chegarem e serem testados, depois sao removidos como o v01/v02 foram.
