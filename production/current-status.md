# Current Status

Atualizado em: 2026-07-09 (sessao Codex web)

## Objetivo deste documento

Este arquivo existe para permitir retomar o projeto em qualquer ambiente: Codex local, Codex web, outro computador ou uma nova conversa. Ele resume onde o projeto esta, o que ja foi feito, quais caminhos importam e qual deve ser o proximo passo.

## Fonte principal do projeto

Repositorio GitHub:

```text
https://github.com/Gravit-Studios/fragmentos-do-amanha
```

Repositorio local atual:

```text
C:\Users\Gean Santos\Documents\Codex\fragmentos-do-amanha
```

Projeto Unity:

```text
C:\Users\Gean Santos\Documents\Codex\fragmentos-do-amanha\unity\FragmentosDoAmanha
```

Ao abrir pelo Unity Hub, selecionar a pasta `FragmentosDoAmanha`, nao a raiz `fragmentos-do-amanha`.

## Estado geral

O projeto esta em transicao de pre-producao para primeiro prototipo jogavel.

Ja existe:

- documentacao base do projeto;
- bible visual inicial;
- prompts oficiais de personagens;
- prompts oficiais de cenarios;
- artes iniciais de personagens;
- artes iniciais de cenarios em concept art e pixel art;
- estrutura inicial do concept book;
- primeiro lote de paginas de validacao do concept book;
- prompts de exploracao de logotipo;
- projeto Unity real;
- primeira cena jogavel placeholder do Theo.
- Theo com blockout visual direcional baseado no concept art;
- sistema temporario de vida, dano e respawn.
- HUD temporario de vida.
- ataque basico placeholder.
- inimigo placeholder com patrulha, dano de contato, vida e morte.
- fragmento temporal coletavel com contador no HUD.
- primeira sala curta de vertical slice com inicio, perigo, inimigo e objetivo.
- scripts e menu de editor para gerar `VS_Egypt_Blockout`.
- cena `VS_Egypt_Blockout` gerada localmente e adicionada ao Build Settings;
- portal temporal placeholder preparado para carregar a cena do Egito apos completar o objetivo;
- rascunho de lista de habilidades do Theo por epoca (`docs/04_Characters/theo-abilities.md`), aguardando revisao;
- rascunho de mecanica de fragmentos com dois niveis (`docs/00_Project/fragments-mechanic.md`), aguardando revisao.

Ainda nao existe:

- sprite final do Theo integrado na Unity;
- tileset real de Era Zero;
- tileset real do Egito;
- transicao temporal final com arte/FX;
- build interna jogavel.

## Commits importantes

```text
28f44fa feat: add Theo prototype controller scene
58e7ad3 chore: add Unity base project
bb398bd art: add initial environment concept and pixel references
e628442 art: add corrected Theo and Voss concept sheets
49ee923 chore: prepare repository for Unity base project
a83ffec docs: add character prompt library and production handbook
e6b3bec docs: align world bible with current production direction
13ade4b chore: add initial production documentation structure
```

## Unity

Versao usada:

```text
Unity 6000.5.3f1
```

Instalacao local encontrada:

```text
C:\Program Files\Unity\Hub\Editor\6000.5.3f1\Editor\Unity.exe
```

Observacao Windows: o projeto foi aberto e salvo neste PC com Unity `6000.5.3f1`, atualizando `ProjectSettings/ProjectVersion.txt` a partir de `6000.5.2f1`.

Pacotes ja registrados:

- Universal Render Pipeline `17.5.0`
- Input System `1.19.0`

Pendencias de pacote:

- Git LFS na maquina de producao;
- Cinemachine;
- 2D Pixel Perfect;
- 2D Animation;
- 2D Sprite;
- confirmar pacotes 2D restantes pelo Package Manager da Unity.

Observacao: `brew` nao estava disponivel no terminal local, entao o Git LFS ainda nao foi instalado por Homebrew.

## Cenas jogaveis atuais

Cena:

```text
unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity
unity/FragmentosDoAmanha/Assets/Scenes/VS_Egypt_Blockout.unity
```

Documentacao:

```text
docs/08_UnityPipeline/prototype-theo-controller.md
```

Implementado:

- Theo placeholder;
- Theo blockout visual com jaqueta terracota, roupa escura, oculos e cronometro temporal;
- movimento horizontal;
- pulo;
- gravidade;
- colisoes com plataformas;
- camera 2D seguindo Theo;
- limites temporarios de camera na sala;
- checagem de chao por `BoxCast`;
- colisores sem atrito para reduzir travamento em bordas;
- vida/dano temporario;
- HUD temporario de vida;
- ataque basico placeholder;
- inimigo placeholder;
- fragmento temporal coletavel;
- respawn temporario;
- zona de dano placeholder;
- zona de queda com respawn;
- blockout do laboratorio Era Zero;
- primeira sala curta com inicio seguro, salto, perigo, inimigo e fragmento;
- nucleo temporal;
- monitor do Voss;
- cena adicionada ao Build Settings.
- menu `Fragmentos do Amanha > Create VS Egypt Blockout Scene`;
- script `TemporalScenePortal` para carregar cena alvo apos objetivo completo.
- cena `VS_Egypt_Blockout` com chegada por fenda temporal, inimigos placeholder, obelisco de Voss, sinal de Naiara, fragmento, HUD e zona de queda.

Controles:

- `A` / seta esquerda: mover para esquerda;
- `D` / seta direita: mover para direita;
- `Space` / `W` / seta para cima: pular.
- `J` / clique esquerdo: ataque basico placeholder.

Proximo teste recomendado:

1. Abrir `unity/FragmentosDoAmanha` no Unity Hub.
2. Abrir `Assets/Scenes/Prototype_Theo_Controller.unity`.
3. Rodar Play Mode.
4. Avaliar peso do pulo, velocidade horizontal, pulo em plataformas, movimento no ar, queda/respawn, camera, zona de dano, HUD, ataque, inimigo, fragmento coletavel e leitura da sala.
5. Coletar o fragmento e entrar no marcador final para validar o portal para `VS_Egypt_Blockout`.
6. Abrir/testar `Assets/Scenes/VS_Egypt_Blockout.unity` diretamente.
7. Ajustar `TheoController`, `CameraFollow2D`, `PlayerHealth`, `PrototypeHealthHud`, `PrototypeFragmentHud`, `PlayerAttack`, `PrototypeEnemy`, `TemporalFragment` e `TemporalScenePortal`.

## Arte e referencias

Personagens:

```text
art/pixel/characters/
art/illustration/characters/
docs/03_VisualDevelopment/character-image-prompts.md
```

Cenarios:

```text
art/pixel/environments/
art/illustration/environments/
docs/03_VisualDevelopment/environment-image-prompts.md
```

Cenarios ja criados:

- Laboratorio inicial;
- Momento da explosao;
- Egito Antigo / camara do templo.

## Documentos centrais

```text
README.md
production/roadmap.md
production/vertical-slice-plan.md
production/production-handbook.md
docs/00_Project/project-overview.md
docs/03_VisualDevelopment/visual-development-guide.md
docs/03_VisualDevelopment/concept-book-outline.md
docs/03_VisualDevelopment/concept-book-page-plan.md
docs/03_VisualDevelopment/pixel-art-bible.md
docs/03_VisualDevelopment/logo-exploration-prompts.md
docs/04_Characters/character-dna.md
docs/06_Animation/animation-bible.md
docs/08_UnityPipeline/unity-base-project-setup.md
```

## Fluxo recomendado local + nuvem

### Local

Usar para:

- criar e abrir projeto Unity;
- rodar Play Mode;
- testar sensacao de controle;
- validar camera, fisica, colisao e cenas;
- integrar assets no editor.

### Codex web / nuvem

Usar para:

- continuar documentacao;
- revisar roadmap;
- gerar/ajustar scripts versionados;
- organizar issues, prompts e plano de producao;
- trabalhar em mudancas que possam ser feitas apenas com GitHub.

Limite importante: o Codex web trabalha sobre o repositorio no GitHub, mas nao roda a Unity instalada neste Mac nem substitui o teste visual no editor local.

### GitHub

Usar como ponte central entre todos os ambientes. Antes de trocar de dispositivo ou ambiente:

```text
git status
git add ...
git commit -m "mensagem"
git push origin main
```

Ao retomar em outro ambiente:

```text
git pull origin main
```

## Proximos passos recomendados

0. Revisar e aprovar (ou ajustar) os rascunhos de habilidades do Theo e mecanica de fragmentos.
1. Testar `Prototype_Theo_Controller` no Play Mode.
2. Ajustar sensacao de movimento do Theo.
3. Instalar/confirmar Cinemachine e Pixel Perfect.
4. Trocar camera temporaria por Cinemachine.
5. Criar tileset placeholder da Era Zero.
6. Criar tileset placeholder do Egito.
7. Testar primeiro loop de combate Theo versus inimigo placeholder.
8. Testar coleta do fragmento temporal.
9. Ajustar a primeira sala curta com base no teste manual.
10. Planejar primeira transicao temporal jogavel.

## Prompt de retomada para nova conversa

```text
Estamos trabalhando no projeto Fragmentos do Amanha / Era Zero.
Use o repositorio GitHub https://github.com/Gravit-Studios/fragmentos-do-amanha como fonte principal.
Leia primeiro production/current-status.md, production/roadmap.md e docs/08_UnityPipeline/prototype-theo-controller.md.
O projeto Unity esta em unity/FragmentosDoAmanha.
Continue a partir da cena Prototype_Theo_Controller, priorizando teste de movimento, camera, Pixel Perfect/Cinemachine e depois tilesets placeholder da Era Zero e Egito.
```
