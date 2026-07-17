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

## Decisao 2026-07-17: adotar o visual das fichas de personagem (v04) como definitivo

O usuario confirmou ("Sim") que o visual das "fichas de personagem" do ChatGPT (jaqueta laranja com barra/forro, capuz, ficha completa com paleta/turnaround/ciclos -- ver `artbook/pixel-reference/characters/theo/chatgpt-2026-07-17/theo-character-sheet-v01.png` e as demais) e o design definitivo do Theo, **substituindo o v03** (idle+corrida atualmente integrados no Unity). Essas fichas continuam com os mesmos problemas tecnicos ja identificados (sem transparencia real, frames colados sem grade, escala diferente entre sub-imagens), entao nao dao pra recortar direto -- precisam ser regeradas como poses isoladas nesse estilo.

Prompt ja escrito para a primeira geracao (parado + corrida juntos, mesmo metodo que funcionou pro v03): `docs/03_VisualDevelopment/prompts/characters/theo-v04-idle-and-run-reference-sheet.txt`, referenciando as fichas de personagem para identidade/estilo. **Ainda sem confirmacao/imagem gerada de volta.**

Quando a imagem v04 chegar: medir bbox de personagem via PIL, repetir o processo ja feito pro v03 (`TheoSpriteSetup.SpritePath`/`IdleSpritePixelsPerUnit`, `TheoAnimationSetup.IdleSpritePath`/`RunFramesFolder`, `tools/art-pipeline/normalize_run_frames.py` se as escalas nao baterem), e então continuar o ciclo de corrida (passing, high-point, espelhamentos) e o pulo nesse novo estilo v04, seguindo o mesmo metodo de poses isoladas/pequenos grupos ancorados na imagem aprovada. O trabalho ja feito no v03 (secao abaixo) fica de referencia historica de como o pipeline funciona, mas os arquivos v03 devem ser tratados como superados assim que o v04 chegar.

## Trabalho anterior (v03, superado pela decisao acima): ciclo de corrida do Theo

Contexto: o sprite idle do Theo (`theo-sprite-v02.png`) e os primeiros frames de corrida foram gerados em conversas/prompts separados no ChatGPT, o que causou inconsistencia visual (tamanho de cabeca, espessura do corpo, saturacao de cor diferentes entre parado e corrida), mesmo depois de varias correcoes programaticas de escala (PPU, recomposicao de frames via `tools/art-pipeline/normalize_run_frames.py`). O usuario diagnosticou a causa raiz (seguindo medicoes proprias em ferramenta de design) e decidiu: **regerar parado + corrida juntos, no mesmo prompt/imagem**, em vez de seguir corrigindo por escala.

Estado atual:

- Gerada com sucesso uma imagem de referencia combinada (parado + corrida) com consistencia interna validada (medicao de bbox mostrou alturas de personagem dentro de 0.5% de diferenca entre as poses).
- `theo-sprite-v03.png` (idle) e `Run-v03/theo-run-v03-01-contact.png` (frame 1 de 6 do ciclo de corrida, pose de contato com o chao) ja existem em `unity/FragmentosDoAmanha/Assets/Art/Characters/Theo/` (ainda nao configurados/importados -- `TheoSpriteSetup.SpritePath` continua apontando pro v02, ver passo 2 abaixo).
- Prompt do frame 2 (pose "passing"/recoil) ja escrito e entregue ao usuario em `docs/03_VisualDevelopment/prompts/characters/theo-v03-run-frame-02-passing.txt`, referenciando as duas imagens v03 anexadas. **Ainda sem confirmacao/imagem gerada de volta.**
- Faltam gerar: passing, high-point, e os espelhamentos correspondentes (total de 6 frames no ciclo).

Proximo passo assim que os frames v03 restantes chegarem:

1. Rodar `Import Theo Sprite`, `Import Theo Run Frames`, `Build Theo Animator Controller`, `Apply Theo Animator (Current Scene)` (menus em `Fragmentos do Amanha/...`, scripts em `Assets/Editor/TheoSpriteSetup.cs` e `TheoAnimationSetup.cs`) nas 3 cenas (`Prototype_Theo_Controller`, `VS_Egypt_Blockout`, `VS_EraZero_Lab`).
2. Medir a nova altura de personagem em `theo-sprite-v03.png` via PIL (bbox de alpha) e atualizar `TheoSpriteSetup.IdleSpritePixelsPerUnit` (atualmente `437.08f`, calculado para o v02 — precisa remedir para o v03; `SpritePath` tambem aponta para `theo-sprite-v02.png` e precisa apontar para `theo-sprite-v03.png`).
3. Confirmar visualmente em Play Mode que idle e run batem em tamanho, proporcao e cor.
4. Decidir com o usuario se os arquivos v01/v02 do Theo (sprite e frames de corrida antigos) devem ser removidos ou arquivados agora que v03 e a versao adotada.

## Estrutura de pastas do repositorio (reorganizada em 2026-07-16, art/ eliminada em 2026-07-17)

Por pedido explicito do usuario em 2026-07-17 ("Preciso separar em uma pasta o que realmente e arquivo do jogo... Todos os arquivos que serao criados devem ser inseridos nessa pasta, mesmo os sprites gerados via chatgpt que vao ser usados pra configurar no unity. Os demais arquivos podem ficar em uma pasta chamada artbook"), a pasta `art/` na raiz (criada em 2026-07-16) foi eliminada. Estrutura atual, so duas pastas de arte:

- `unity/FragmentosDoAmanha/Assets/Art/...` — **todo** arquivo necessario para o jogo funcionar, incluindo sprites/tilesets ainda nao configurados/importados (ex.: `theo-sprite-v03.png` e `Run-v03/theo-run-v03-01-contact.png` foram movidos pra dentro daqui mesmo antes de rodar `Import Theo Sprite`/`Import Theo Run Frames`). Nao existe mais copia espelhada fora da Unity — arte nova do jogo (mesmo gerada por IA) deve ser salva direto aqui.
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
