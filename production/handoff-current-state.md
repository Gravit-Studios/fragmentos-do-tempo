# Handoff Current State

Atualizado em: 2026-07-17

Use este arquivo para retomar *Fragmentos do Amanha / Era Zero* em outro computador, outra sessao de nuvem (Codex web, Claude web), Claude Desktop local (com ou sem MCP for Unity), tablet, celular ou nova conversa, exatamente do ponto onde a producao parou.

`production/current-status.md` esta desatualizado (2026-07-09); usar este arquivo e `production/roadmap.md` como fonte de verdade.

## Fonte principal

Repositorio GitHub:

```text
https://github.com/Gravit-Studios/fragmentos-do-amanha
```

Branches ativas:

- `main` — sempre sincronizada com o trabalho fechado.
- `claude/fragmentos-do-amanha-kum12e` — branch de desenvolvimento da sessao de nuvem (Claude). Todo commit feito nela e mesclado (fast-forward quando possivel) em `main` logo em seguida, na mesma sessao.

O usuario tambem commita direto do Unity local as vezes (commits com mensagem ".", tipicamente `.meta` novos e os `.anim`/`.controller` atualizados apos rodar os menus do editor). Sempre `git fetch`/mesclar antes de assumir que uma branch esta atualizada.

Antes de trabalhar em outro dispositivo:

```text
git pull --ff-only origin main
```

## Leitura obrigatoria ao retomar

1. `AGENTS.md`
2. `production/handoff-current-state.md` (este arquivo)
3. `production/roadmap.md`
4. Para Unity: `docs/08_UnityPipeline/prototype-theo-controller.md`
5. Para arte de personagens: `docs/03_VisualDevelopment/prompts/characters/`
6. Para sprites/pixel art: `docs/03_VisualDevelopment/sprite-prompt-guide.md`

## Decisao de escopo em vigor

Confirmado pelo usuario em 2026-07-14: **nao fechar o jogo completo (8 epocas) agora**. Prioridade e transformar a fatia **Era Zero + Egito** numa demo completa e polida — visual correto, funcionalidades sem bugs, personagens com arte final — antes de expandir para Grecia ou qualquer outra epoca. Nao mudar essa prioridade sem o usuario pedir explicitamente.

## Escopo da Demo Inicial: fechado

Toda a checklist de "Escopo da Demo Inicial" em `production/roadmap.md` esta marcada `[x]` e testada em Play Mode e em build standalone (Windows): controle do Theo, ataque basico, inimigo com telegraph, vida/dano/respawn, fragmento + HUD, portal Era Zero -> Egito, Cinemachine + Pixel Perfect Camera, tilesets de Era Zero e Egito, sprite base do Theo, dash, build interna jogavel.

Com isso fechado, o trabalho atual e **Fase 3 (Arte Integrada)** do roadmap: substituir os placeholders restantes (animacoes do Theo, Voss e Naiara) por arte final.

## Sprint 1 (backend/combate) -- fechada e testada em 2026-07-17

Executados os itens definidos em `production/unity-handoff-sprint-01-reference.md` (handoff de outra frente/sessao):

- `PlayerAttack.cs`: corrigido dano duplicado quando um alvo tem mais de um `Collider2D` (`OverlapBoxAll` chamava `TakeHit` uma vez por collider atingido). Agora usa `HashSet<IDamageable>` pra garantir um hit por alvo por ataque.
- `PrototypeEnemy.cs`: adicionado estado `Dead` explicito na maquina de estados (antes so desativava o GameObject sem passar por nenhum estado); `trackedPlayer` zerado ao morrer.
- `PlayerHealth.cs`: os itens pedidos (invulnerabilidade, knockback, fluxo unico de morte, preparacao pra checkpoint) ja estavam cobertos pelo trabalho anterior desta sessao, nada mudou.
- Confirmado pelo usuario em Play Mode: "Tudo funcionando".

## Visual definitivo do Theo (v04), feito a mao no Photoshop

O usuario confirmou que o visual das "fichas de personagem" do ChatGPT (`artbook/pixel-reference/characters/theo/chatgpt-2026-07-17/`) e o design definitivo, mas como essas fichas nao dao pra recortar direto (sem transparencia real, frames colados, escala inconsistente entre sub-imagens), decidiu desenhar os frames a mao no Photoshop, um arquivo por pose/frame.

Especificacao fixa (documentada em `unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/README.md`, template de guia em `docs/03_VisualDevelopment/theo-sprite-canvas-template-1024.png`):

- Canvas fixo `1024x1024` em todo arquivo.
- Linha de chao (pes) sempre no mesmo Y do canvas -- adotado `y=987`.
- Transparencia real (alpha), sem xadrez pintado.

### Idle -- completo e integrado

6 frames em `Idle/theo-sprite-idle-01.png` a `06.png`. Foi reenviado uma vez (mesma arte, reposicionada ~6px no canvas) e realinhado pra `y=987` com `tools/art-pipeline/align_foot_line.py`. Altura de personagem ~947px, usada como referencia de escala (`TheoSpriteSetup.IdleSpritePixelsPerUnit = 394.58`).

### Idle validado em Play Mode via Unity MCP (2026-07-17, sessao local)

Rodados `Import Theo Sprite`, `Import Theo Run Frames`, `Build Theo Animator Controller` e `Apply Theo Animator (Current Scene)` nas 3 cenas (`Prototype_Theo_Controller`, `VS_Egypt_Blockout`, `VS_EraZero_Lab`) via Unity MCP, sem erro de compilacao, todas salvas. Play Mode testado em `Prototype_Theo_Controller`: Idle renderiza corretamente com o sprite final (screenshot conferida), sem erros/warnings novos no console. O Animator ja construido/aplicado inclui o clip de Run com o problema de alternancia de perna descrito abaixo -- nao testar Run como referencia de qualidade ate a correcao chegar.

### Run -- integrado no codigo (2026-07-20), mas o problema de alternancia de perna persiste

Tres lotes de 8 frames recebidos ate agora, todos com o mesmo problema real: **todas as poses lideram com a mesma perna** (nunca mostra a perna oposta passando a frente), entao o ciclo se repete como um saltitar/mancar em vez de correr. Isso e o que o usuario descreveu como "nao ficou natural".

- Lote 1 (2026-07-17): pe ~61px mais alto que o idle, frames 03/04 pixel-a-pixel identicos. Nao integrado.
- Lote 2 (2026-07-18, 5 frames): tecnicamente melhor (pe ja nascia alinhado, sem duplicatas), mas mesma perna sempre lider. Nao integrado.
- Lote 3 (2026-07-18/20): gerado depois de criar um diagrama de referencia (`theo-run-cycle-leg-alternation-diagram.html`, poses coloridas mostrando exatamente Reach-Left/Recovery-Left que faltam) e mandar pro ChatGPT. Duas tentativas com esse lote: a primeira veio com a grade-guia do template gravada nos pixels (esquecimento de esconder a camada antes de exportar); a segunda (2026-07-20) veio limpa (transparencia real, sem grade), mas **as 8 poses continuam identicas em estrutura as do lote anterior** -- o diagrama nao resultou em poses novas, so a arte foi reexportada sem a grade. Integrado mesmo assim no Unity (`Import Theo Run Frames` -> `Build Theo Animator Controller` -> `Apply Theo Animator` nas 3 cenas, via Unity MCP, sem erro de compilacao) a pedido do usuario, pra nao ficar sem nenhuma corrida enquanto a arte corrigida nao chega. Confirmado visualmente em Play Mode (screenshots do ciclo rodando) -- sem crash, mas o problema de perna deve se manter na tela.

Como o Theo e desenhado de perfil verdadeiro, nao da pra espelhar o sprite inteiro pra gerar a perna oposta (isso viraria o personagem de costas/left-facing). As poses espelhadas precisam ser desenhadas/geradas a parte, mesma direcao (direita), so trocando qual perna lidera.

Referencias do que falta: `docs/03_VisualDevelopment/prompts/characters/theo-run-cycle-mirror-poses-reference.txt` (texto) e `docs/03_VisualDevelopment/prompts/characters/theo-run-cycle-leg-alternation-diagram.html` (diagrama visual com poses coloridas, publicado como artifact). **Aguardando o usuario gerar/desenhar essas poses corretamente e reenviar** antes do ciclo de corrida ficar visualmente correto.

### Codigo (ja commitado, ja rodado pelo usuario localmente)

- `TheoSpriteSetup.cs`: `SpritePath` aponta pro primeiro frame do Idle; `IdleSpritePixelsPerUnit = 394.58`. `ImportTheoSprite()` importa todos os frames de `Idle/`.
- `TheoAnimationSetup.cs`: `IdleFramesFolder`/`RunFramesFolder` apontam pras pastas `Idle`/`Run`. `BuildAnimatorController()` monta o clip de Idle com 6 frames (`IdleFrameRate = 6f`), igual ja fazia pro Run.
- Removidos `theo-sprite-v03.png` e `Run-v03/` (visual anterior, superado).
- O usuario ja rodou `Import Theo Sprite` / `Import Theo Run Frames` / `Build Theo Animator Controller` / `Apply Theo Animator` localmente pelo menos uma vez (confirmado pelos commits "." com `.meta` novos e `Theo.controller`/`Theo_Idle.anim`/`Theo_Run.anim` atualizados). Precisa rodar de novo depois que o ciclo de corrida corrigido chegar.

### Jump -- integrado no codigo (2026-07-20), pendente de teste visual em Play Mode

6 frames em `Jump/theo-sprite-jump-01.png` a `06.png`, cobrindo o arco inteiro (agachamento de saida -> subida -> apice -> queda -> agachamento de pouso). Ao contrario de Idle/Run, o pe NAO foi realinhado pra y=987 -- cada frame representa a altura real do personagem no ar. `TheoAnimationSetup.cs` ganhou `ImportJumpFrames()` (novo menu `Import Theo Jump Frames`) e `BuildAnimatorController()` agora monta um clip `Theo_Jump` nao-looping e liga `Idle/Run -> Jump` quando `Grounded == false` e `Jump -> Idle` quando `Grounded == true` (o parametro `Grounded` ja era calculado pelo `TheoController` desde a Sprint 1, so nao tinha nenhum estado consumindo).

Rodado via Unity MCP nas 3 cenas, sem erro de compilacao. **Tentei validar em Play Mode simulando um pulo via `Rigidbody2D.linearVelocity` diretamente por `execute_code`, mas o Play Mode headless se mostrou instavel** (a fisica parou de avançar em tempo real em alguns momentos, e forçar `transform.position`/`RigidbodyType2D.Kinematic` manualmente quebrou a referencia ao GameObject e a câmera saiu de enquadramento) -- não é um bug do jogo, é limitação de testar Play Mode sem foco de janela real. **Precisa de um teste manual local**: abrir `Prototype_Theo_Controller`, rodar Play Mode, apertar Space/W/seta-cima e confirmar visualmente que a animação de pulo troca corretamente com Idle/Run e que a escala/proporcao bate.

### Pastas de pose (`unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/`)

`Idle/`, `Run/` (pendente de correcao de perna acima) e `Jump/` completos. Vazias, aguardando arte no mesmo padrao: `Land/`, `Attack/`, `Fall/`, `Crouch/` (sem mecanica de jogo ainda, nao prioritario), `HitDeath/` (a ficha de personagem NAO cobre essa pose -- precisa ser gerada a parte, item do roadmap Fase 3).

## Unity MCP -- configurado e funcionando no PC principal (2026-07-17)

Esta sessao de nuvem **nunca** vai ter acesso a um MCP do Unity, mesmo que o usuario configure um -- MCP local so e alcancavel por uma sessao rodando na mesma maquina. No PC Windows (Claude Code local) isso ja foi configurado e testado com sucesso:

- Pacote: [CoplayDev/unity-mcp](https://github.com/CoplayDev/unity-mcp) (gratuito, MIT, nao e da Unity Technologies), instalado em `Packages/manifest.json` como `com.coplaydev.unity-mcp` (`?path=/MCPForUnity#main`). Compativel com Unity 2021.3 LTS a 6.x (cobre a `6000.5.3f1` do projeto).
- Bridge HTTP local em `http://127.0.0.1:8080/mcp`, registrado em `.mcp.json` na raiz do repositorio (versionado -- funciona em qualquer maquina que tenha o Unity Editor aberto localmente, o endereco e sempre localhost).
- **Passo manual obrigatorio a cada maquina nova**: o bridge nao inicia sozinho por padrao. Precisa abrir `Window > MCP For Unity` no Unity Editor, clicar em Start Server, e marcar "Auto-Start on Editor Load" pra nao repetir isso a cada sessao.
- Confirmado funcionando: Claude Code local rodou os 4 menus de import/build/apply do Theo nas 3 cenas e validou Idle em Play Mode direto pelo MCP (ver secao "Idle validado em Play Mode" acima), sem precisar do usuario descrever o resultado manualmente.
- Existe tambem um MCP oficial da Unity (`com.unity.ai.assistant`, Unity 6+), mas exige assinatura paga -- nao e o que esta em uso aqui.

## Estrutura de pastas do repositorio

- `unity/FragmentosDoAmanha/Assets/Art/...` — **todo** arquivo necessario para o jogo funcionar, incluindo sprites/tilesets ainda nao configurados/importados. Nao existe copia espelhada fora da Unity — arte nova do jogo deve ser salva direto aqui.
- `artbook/` — todo material de concept art, ilustracao, branding, PDFs do concept book e reference sheets/crops que NAO entram no jogo: `illustration/`, `concept-book/`, `pdf/`, `branding/`, `marketing/`, `pixel-reference/`.
- `ChatGPT/` — documentos de game design/narrativa vindos de outra sessao/ferramenta (`GDD.md`, `game-design/`, `narrativa/`, `nomes/`, `personagens/`), mantidos como referencia historica, sem consolidar com `docs/`/`production/`.
- `unity/FragmentosDoAmanha/game/` — pasta de build standalone, nao versionada (`.gitignore`).

Nota de coordenacao com a frente Unity (de outra sessao/ferramenta, focada em artbook/concept art):

```text
production/unity-handoff-sprint-01-reference.md
```

## Unity

Versao registrada:

```text
Unity 6000.5.3f1
```

Abrir pelo Unity Hub, selecionando a pasta `unity/FragmentosDoAmanha` (nao a raiz do repositorio).

Pacotes principais confirmados: URP 2D, Input System `1.19.0`, Cinemachine `3.1.7` (namespace `Unity.Cinemachine`), 2D Pixel Perfect `6.0.0` (`UnityEngine.U2D.PixelPerfectCamera`).

### Cenas ativas

```text
Assets/Scenes/Prototype_Theo_Controller.unity
Assets/Scenes/VS_Egypt_Blockout.unity
Assets/Scenes/VS_EraZero_Lab.unity
```

### Menus de editor relevantes (`Fragmentos do Amanha > ...`)

- `Create VS Egypt Blockout Scene` / `Create VS Era Zero Lab Scene`
- `Import Theo Sprite` / `Replace Theo Blockout With Sprite (Current Scene)`
- `Import Theo Run Frames` / `Build Theo Animator Controller` / `Apply Theo Animator (Current Scene)`
- `Upgrade Camera To Cinemachine + Pixel Perfect (Current Scene)`

### Scripts-chave

```text
Assets/Scripts/Player/TheoController.cs        movimento, dash, flip de sprite, "Speed"/"Grounded"/"VerticalSpeed" do Animator
Assets/Scripts/Player/PlayerHealth.cs          vida, dano, fallDamage, respawn
Assets/Scripts/Combat/PlayerAttack.cs          ataque basico (HashSet anti-dano-duplicado)
Assets/Scripts/Enemies/PrototypeEnemy.cs       patrulha, telegraph, estado Dead, IgnorePlayerBodyCollision
Assets/Editor/TheoSpriteSetup.cs               import/escala dos frames de idle do Theo
Assets/Editor/TheoAnimationSetup.cs            import de frames de corrida + Animator Controller (Idle+Run)
Assets/Editor/CameraUpgradeSetup.cs            migracao para Cinemachine + Pixel Perfect
```

`Grounded`/`VerticalSpeed` ja sao parametros do Animator (preparados pra Jump/Fall/Land quando essa arte chegar), mas nenhum estado ainda os usa.

## Ferramentas de pipeline de arte

```text
tools/art-pipeline/normalize_run_frames.py   recorta+reescala+reposiciona (usado no v03/AI, escalas diferentes)
tools/art-pipeline/align_foot_line.py        so translada verticalmente (usado no v04/Photoshop, escala ja bate)
```

## Fluxo de trabalho estabelecido nesta sessao (nuvem)

- Commits automaticos: o usuario autorizou commitar e enviar sem perguntar a cada vez.
- Depois de cada commit na branch de nuvem: mesclar (fast-forward quando possivel) em `main`, `git push origin main`, e voltar para `claude/fragmentos-do-amanha-kum12e`. Nunca deixar um commit so na branch de feature sem sincronizar `main`. O usuario tambem pode ter commitado direto do Unity local (mensagens ".") -- sempre `git fetch` antes de assumir estado.
- Pull/push de LFS a partir desta sessao de nuvem ja falhou de forma persistente por bloqueio de rede do ambiente (nao intermitente -- 403 de policy no proxy). Resolvido uma vez ajustando o nivel de rede do ambiente pra Custom + `lfs.github.com` na lista permitida; se voltar a falhar, e a mesma causa.
- No lado do usuario (Windows): usar PowerShell standalone (Win+R > powershell), nao o terminal integrado do VS Code.
- Arte: poses isoladas/unicas (uma por arquivo) sao muito mais confiaveis que "sprite sheets" com varios frames numa imagem so. Desde 2026-07-17 a arte do Theo e feita a mao no Photoshop (nao mais gerada por IA), com canvas/escala/linha-de-chao fixos combinados previamente -- ver secao do Theo acima.

## Proximos passos recomendados (em ordem)

1. Receber e integrar as poses "Reach-Left"/"Recovery-Left" do ciclo de corrida do Theo (ver `docs/03_VisualDevelopment/prompts/characters/theo-run-cycle-mirror-poses-reference.txt`), montar o ciclo final alternando esquerda/direita.
2. Rodar os 4 menus de import/build/apply nas 3 cenas de novo com o ciclo de corrida corrigido, confirmar em Play Mode que a animacao le como corrida natural (nao mais saltitando).
3. Gerar as poses que faltam no Theo, mesmo padrao (canvas 1024x1024, pe em y=987): Pulo, Pouso, Ataque, Cair, e Hit/Death (nao coberta pela ficha de personagem).
4. Se o usuario confirmar que configurou o MCP for Unity no Claude Desktop local, considerar mover trabalho de teste/Play Mode pra la (ver secao acima) em vez do ciclo manual atual.
5. Continuar Fase 3 do roadmap: props/arte final de Voss e Naiara (hoje sao blockout).
6. So depois de Era Zero + Egito estarem completos e polidos, revisitar a Fase 5 e decidir se/quando expandir pra proxima epoca (Grecia).

## Prompt para nova conversa

```text
Estamos trabalhando no projeto Fragmentos do Amanha / Era Zero.
Use o repositorio GitHub https://github.com/Gravit-Studios/fragmentos-do-amanha como fonte principal, branch de desenvolvimento claude/fragmentos-do-amanha-kum12e (mesclada em main a cada commit).
Leia AGENTS.md, production/handoff-current-state.md e production/roadmap.md antes de qualquer coisa.
A fatia Era Zero + Egito ja esta jogavel de ponta a ponta; a prioridade agora e Fase 3 (arte final do Theo/Voss/Naiara). O item mais urgente: o ciclo de corrida do Theo (visual v04, Photoshop) tem um problema de alternancia de perna (sempre lidera com a direita) -- ver a secao "Run" no handoff e o arquivo theo-run-cycle-mirror-poses-reference.txt para o que falta.
Se esta rodando em Claude Desktop local com MCP for Unity configurado, priorize testar em Play Mode direto. Se esta num ambiente sem Unity (nuvem), prepare mudancas versionadas e marque teste local como pendente.
Nao expandir para outras epocas (Grecia etc.) sem confirmacao explicita do usuario.
```
