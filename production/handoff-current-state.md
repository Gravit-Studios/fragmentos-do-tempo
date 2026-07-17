# Handoff Current State

Atualizado em: 2026-07-16

Use este arquivo para retomar *Fragmentos do Amanha / Era Zero* em outro computador, outra sessao de nuvem (Codex web, Claude web), tablet, celular ou nova conversa, exatamente do ponto onde a producao parou.

Este arquivo substitui a versao anterior (2026-07-09), que estava desatualizada em praticamente tudo abaixo. `production/current-status.md` tambem esta desatualizado (mesma data); usar este arquivo e o `production/roadmap.md` como fonte de verdade.

## Fonte principal

Repositorio GitHub:

```text
https://github.com/Gravit-Studios/fragmentos-do-amanha
```

Branches ativas:

- `main` — sempre sincronizada com o trabalho fechado.
- `claude/fragmentos-do-amanha-kum12e` — branch de desenvolvimento da sessao de nuvem (Claude). Todo commit feito nela e mesclado (fast-forward) em `main` logo em seguida, na mesma sessao.

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
6. Para concept book: `docs/03_VisualDevelopment/concept-book-art-direction.md`
7. Para sprites/pixel art: `docs/03_VisualDevelopment/sprite-prompt-guide.md`

## Decisao de escopo em vigor

Confirmado pelo usuario em 2026-07-14: **nao fechar o jogo completo (8 epocas) agora**. Prioridade e transformar a fatia **Era Zero + Egito** numa demo completa e polida — visual correto, funcionalidades sem bugs, personagens com arte final — antes de expandir para Grecia ou qualquer outra epoca. Nao mudar essa prioridade sem o usuario pedir explicitamente.

## Escopo da Demo Inicial: fechado

Toda a checklist de "Escopo da Demo Inicial" em `production/roadmap.md` esta marcada `[x]` e testada em Play Mode e em build standalone (Windows). Isso inclui: controle do Theo, ataque basico, inimigo com telegraph, vida/dano/respawn (com correcao do exploit de dano de queda), fragmento + HUD, portal Era Zero -> Egito, Cinemachine + Pixel Perfect Camera, tilesets de Era Zero e Egito, sprite base do Theo, dash, e build interna jogavel testada de ponta a ponta fora do editor.

Bugs reais encontrados e corrigidos durante os testes (nao sao mais pendencias):

- Cair num buraco curava a vida de graca (exploit) — corrigido com `fallDamage` em `PlayerHealth.cs`.
- Inimigo empurrava fisicamente o Theo so por encostar — corrigido com `Physics2D.IgnoreCollision` em `PrototypeEnemy.cs`.
- Pixel Perfect Camera com zoom ~3.7x maior que o esperado no build standalone — corrigido ajustando resolucao de referencia (960x540) e `assetsPPU` (54) em `CameraUpgradeSetup.cs`.
- `LensSettings.Orthographic` e somente leitura no Cinemachine 3.1.x — usar `LensSettings.ModeOverride = LensSettings.OverrideModes.Orthographic`.

Com isso fechado, o trabalho atual e **Fase 3 (Arte Integrada)** do roadmap: substituir os placeholders restantes (animacoes do Theo, Voss e Naiara) por arte final, dentro da fatia Era Zero + Egito.

## Decisao 2026-07-17: visual definitivo do Theo (v04), feito a mao no Photoshop

O usuario confirmou ("Sim") que o visual das "fichas de personagem" do ChatGPT (jaqueta laranja com forro/capuz -- ver `artbook/pixel-reference/characters/theo/chatgpt-2026-07-17/theo-character-sheet-v01.png` e as demais) e o design definitivo do Theo, substituindo o v03 (era so referencia, nunca virou arte final). Como essas fichas nao dao pra recortar direto (sem transparencia real, frames colados, escala inconsistente entre sub-imagens), o usuario decidiu desenhar os frames a mao no Photoshop, um arquivo por pose/frame, em vez de continuar gerando via ChatGPT.

Especificacao fixa combinada (documentada em `unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/README.md`), com template de guia gerado e enviado ao usuario (`docs/03_VisualDevelopment/theo-sprite-canvas-template-1024.png`, grade de 64px + linha de centro + linha de chao):

- Canvas fixo `1024x1024` em todo arquivo.
- Linha de chao (pes) sempre no mesmo Y do canvas -- adotado `y=987` (media medida no idle).
- Transparencia real (alpha), sem xadrez pintado.

Estado atual (Idle + Run completos e integrados no codigo, pendente teste em Play Mode):

- **Idle**: 6 frames recebidos (`unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/Idle/theo-sprite-idle-01.png` a `06.png`). Medidos via PIL: altura de personagem 946-952px (0.6% de variacao), pe em y=985-989 -- excelente consistencia, sem necessidade de correcao.
- **Run**: 8 frames recebidos (`.../Run/theo-sprite-run-01.png` a `08.png`). Mesmo canvas e escala do idle, mas pe em y=918-929 -- ~61px mais alto que o idle. Corrigido com um novo script, `tools/art-pipeline/align_foot_line.py` (desloca verticalmente sem redimensionar, ao contrario do `normalize_run_frames.py` usado antes pro v03/AI, que tambem reescalava), alinhando todos os 8 frames pro pe em y=987 igual ao idle. Nenhum frame ficou cortado apos o deslocamento (conferido via bbox).
- `TheoSpriteSetup.cs`: `SpritePath` agora aponta pro primeiro frame do Idle (`Idle/theo-sprite-idle-01.png`), `IdleSpritePixelsPerUnit` recalculado (`394.58` = 947px / `TargetWorldHeight` 2.4). `ImportTheoSprite()` agora importa TODOS os frames da pasta `Idle/` (nao so um), pra alimentar a animacao.
- `TheoAnimationSetup.cs`: `IdleFramesFolder`/`RunFramesFolder` apontam pras pastas novas (`Idle`, `Run`). `BuildAnimatorController()` agora monta o clip de Idle com os 6 frames (`IdleFrameRate = 6f`) em vez de 1 frame fixo, igual ja fazia pro Run.
- Removidos: `theo-sprite-v03.png` e `Run-v03/` (visual anterior, totalmente superado).

Status em 2026-07-17 (sessao local, via Unity MCP): concluido no PC principal.

1. `Import Theo Sprite` (6 frames de Idle), `Import Theo Run Frames` (8 frames), `Build Theo Animator Controller` e `Apply Theo Animator (Current Scene)` rodados nas 3 cenas (`Prototype_Theo_Controller`, `VS_Egypt_Blockout`, `VS_EraZero_Lab`) sem erro de compilacao, todas salvas.
2. Play Mode testado em `Prototype_Theo_Controller`: Idle renderiza corretamente com o sprite final (screenshot conferida), sem erros/warnings novos no console. Troca para animacao de Run **nao foi validada** nesta sessao -- o MCP nao tem input de teclado simulado, precisa teste manual (`A`/`D`) para confirmar que idle/run batem em tamanho/proporcao/linha de chao sem "pulo".
3. Proximo passo: validar Run manualmente, depois gerar os frames que faltam no mesmo padrao (canvas 1024x1024, pe em y=987): Pulo, Pouso, Ataque, Cair, e reacao a dano/morte (`HitDeath/`, ver `production/roadmap.md` Fase 3). Agachar tem pasta pronta mas sem mecanica de jogo ainda, nao e prioridade.

### Unity MCP (MCP for Unity, CoplayDev) conectado nesta sessao local

Pacote `com.coplaydev.unity-mcp` adicionado ao `Packages/manifest.json` (resolvido via Git, `?path=/MCPForUnity#main`). Bridge HTTP local em `http://127.0.0.1:8080/mcp`, configurado em `.mcp.json` na raiz do repositorio (versionavel, mas o servidor so funciona com o Unity Editor aberto na mesma maquina). O bridge **nao inicia sozinho** por padrao -- precisa abrir `Window > MCP For Unity`, clicar em Start Server e, se quiser que persista entre sessoes, marcar "Auto-Start on Editor Load". Com isso ativo, sessoes futuras de Claude Code nesta pasta podem controlar cena, GameObjects, Play Mode, console etc. diretamente.

## Estrutura de pastas do repositorio (reorganizada em 2026-07-16, art/ eliminada em 2026-07-17)

Por pedido explicito do usuario em 2026-07-17 ("Preciso separar em uma pasta o que realmente e arquivo do jogo... Todos os arquivos que serao criados devem ser inseridos nessa pasta, mesmo os sprites gerados via chatgpt que vao ser usados pra configurar no unity. Os demais arquivos podem ficar em uma pasta chamada artbook"), a pasta `art/` na raiz (criada em 2026-07-16) foi eliminada. Estrutura atual, so duas pastas de arte:

- `unity/FragmentosDoAmanha/Assets/Art/...` — **todo** arquivo necessario para o jogo funcionar, incluindo sprites/tilesets ainda nao configurados/importados (ex.: os frames do Theo em `Characters/Theo/Idle/` e `Characters/Theo/Run/` ficam ali assim que chegam do Photoshop, antes mesmo de rodar `Import Theo Sprite`/`Import Theo Run Frames`). Nao existe mais copia espelhada fora da Unity — arte nova do jogo deve ser salva direto aqui.
- `artbook/` — todo material de concept art, ilustracao, branding, PDFs do concept book e reference sheets/crops que NAO entram no jogo: `illustration/`, `concept-book/`, `pdf/`, `branding/`, `marketing/`, `pixel-reference/` (inclui agora os sheets completos de ambiente `-pixel-environment-v01/v03.png` que nunca foram importados na Unity — so os `-tiles-core-v02.png` fatiados sao usados de fato).
- `unity/FragmentosDoAmanha/game/` — pasta de build standalone, foi commitada por acidente (~184 arquivos, incluindo `UnityPlayer.dll` de 37MB), removida do tracking (`git rm -r --cached`) e adicionada ao `.gitignore`. Continua existindo localmente, so nao e mais versionada.

### Pastas de documentacao de outra sessao -- resolvido em 2026-07-17

As pastas `game-design/`, `narrativa/`, `nomes/`, `personagens/` e o arquivo `GDD.md` vieram de outra sessao/ferramenta e se sobrepunham com `docs/00_Project/`, `docs/04_Characters/` e `production/roadmap.md`. Por instrucao do usuario ("o que nao for arquivos necessarios para o jogo, pode colocar em uma pasta chamada ChatGPT"), foram movidas para `ChatGPT/` na raiz (`ChatGPT/GDD.md`, `ChatGPT/game-design/`, `ChatGPT/narrativa/`, `ChatGPT/nomes/`, `ChatGPT/personagens/`), mantidas como referencia historica, sem consolidar conteudo com `docs/`/`production/`.

Nota de coordenacao com a frente Unity:

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
Assets/Scripts/Player/TheoController.cs        movimento, dash, flip de sprite, parametro "Speed" do Animator
Assets/Scripts/Player/PlayerHealth.cs          vida, dano, fallDamage, respawn
Assets/Scripts/Player/PlayerAttack.cs          ataque basico
Assets/Scripts/Enemies/PrototypeEnemy.cs       patrulha, telegraph, IgnorePlayerBodyCollision
Assets/Editor/TheoSpriteSetup.cs               import/escala do sprite idle do Theo
Assets/Editor/TheoAnimationSetup.cs            import de frames de corrida + Animator Controller
Assets/Editor/CameraUpgradeSetup.cs            migracao para Cinemachine + Pixel Perfect
```

## Fluxo de trabalho estabelecido nesta sessao (nuvem)

- Commits automaticos: o usuario autorizou commitar e enviar sem perguntar a cada vez ("Pode deixar o envio do commit automatico e seguir com a producao").
- Depois de cada commit na branch de nuvem: mesclar (fast-forward quando possivel) em `main`, `git push origin main`, e voltar para `claude/fragmentos-do-amanha-kum12e`. Nunca deixar um commit so na branch de feature sem sincronizar `main`.
- Pull/push de LFS a partir desta sessao de nuvem falha de forma intermitente ("Forbidden" via proxy). Quando isso acontece: gerar os comandos git exatos e mandar para o usuario rodar no PowerShell local (Windows), depois puxar o resultado de volta.
- No lado do usuario (Windows): usar PowerShell standalone (Win+R > powershell), nao o terminal integrado do VS Code (tenta abrir WSL, que nao esta instalado).
- Arte gerada por IA: poses isoladas/unicas sao muito mais confiaveis (transparencia real, sem corte) do que "sprite sheets" com varios frames numa imagem so (que falham quase sempre: fundo branco, frames cortados). Gerar poses relacionadas (ex.: parado + corrida) juntas na mesma imagem da muito mais consistencia visual do que gerar em conversas separadas.

## Proximos passos recomendados (em ordem)

1. Gerar os 5 frames restantes do ciclo de corrida v03 do Theo (passing, high-point, e espelhamentos), usando os prompts em `docs/03_VisualDevelopment/prompts/characters/`.
2. Reintegrar o ciclo de corrida completo na Unity (ver secao "Trabalho em andamento" acima) e validar em Play Mode.
3. Decidir e resolver a pendencia das pastas de documentacao duplicadas (`game-design/`, `narrativa/`, `nomes/`, `personagens/`, `GDD.md`).
4. Continuar Fase 3 do roadmap: jump/land/attack/hit-death do Theo, e props/arte final de Voss e Naiara (hoje sao blockout).
5. So depois de Era Zero + Egito estarem completos e polidos (visual, funcionalidade, personagens), revisitar a Fase 5 e decidir se/quando expandir para a proxima epoca (Grecia).

## Prompt para nova conversa

```text
Estamos trabalhando no projeto Fragmentos do Amanha / Era Zero.
Use o repositorio GitHub https://github.com/Gravit-Studios/fragmentos-do-amanha como fonte principal, branch de desenvolvimento claude/fragmentos-do-amanha-kum12e (mesclada em main a cada commit).
Leia AGENTS.md, production/handoff-current-state.md e production/roadmap.md antes de qualquer coisa.
A fatia Era Zero + Egito ja esta jogavel de ponta a ponta (build standalone testada); a prioridade agora e Fase 3 do roadmap (arte final: animacoes do Theo, Voss, Naiara), especificamente terminar o ciclo de corrida v03 do Theo (ver secao "Trabalho em andamento" no handoff) e depois seguir para as proximas animacoes.
Nao expandir para outras epocas (Grecia etc.) sem confirmacao explicita do usuario.
Se estiver num ambiente sem Unity, prepare mudancas versionadas e marque teste local como pendente; se tiver Unity, priorize testar em Play Mode.
```
