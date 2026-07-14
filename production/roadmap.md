# Roadmap

## Escopo da Demo Inicial

Decisao: focar em **Era Zero + Egito** ate existir uma fatia funcional, padronizada e polida, antes de expandir para as outras 5 epocas (Grecia, Medieval, Piratas, Segunda Guerra, Inicio da Internet, Futuro proximo continuam fora do escopo ate aqui fechar).

Checklist de definicao de "pronto" para a demo inicial:

- [x] Controle de Theo responsivo e validado em Play Mode (movimento, pulo, coyote time, colisao). Confirmado em Play Mode no PC Windows e no Mac.
- [x] Ataque basico de Theo com timing e alcance validados. Confirmado funcionando em Play Mode (`PlayerAttack.cs`).
- [x] Inimigo comunica ataque antes de causar dano (telegraph visual antes da hitbox ativar).
- [x] Telegraph do inimigo testado em Play Mode e com timing validado (nao muito rapido nem muito lento). Confirmado funcionando (`PrototypeEnemy.cs`).
- [x] Vida, dano, invulnerabilidade e respawn testados de ponta a ponta. Confirmado funcionando (`PlayerHealth.cs`).
- [x] Fragmento coletavel e HUD (vida, fragmento, objetivo) testados de ponta a ponta. Confirmado funcionando.
- [x] Portal temporal Era Zero -> Egito testado e sem bugs de carregamento. Confirmado funcionando (`TemporalScenePortal.cs`).
- [x] Cena oficial `VS_EraZero_Lab` gerada e testada (script pronto: `Fragmentos do Amanha > Create VS Era Zero Lab Scene`), separada da cena de sandbox `Prototype_Theo_Controller`. Gerada do zero ja com o sprite do Theo integrado (sem precisar de "Replace Theo Blockout With Sprite"), HUD, fragmento, inimigo e portal para o Egito confirmados funcionando em Play Mode.
- [ ] Pixel Perfect Camera e Cinemachine integrados (substituindo camera temporaria).
- [x] Tileset placeholder proprio para Era Zero e para Egito (mesmo que simples, cada epoca visualmente distinta). Sheets completos (`era-zero-lab-pixel-environment-v03.png`, `egypt-temple-pixel-environment-v03.png`) e tiles individuais (`era-zero-lab-tiles-core-v02.png`, `egypt-temple-tiles-core-v02.png`, corrigidos para preenchimento total sem rotacao/margem branca) ja importados, fatiados (`TilesetImportSetup.cs`) e testados no Tilemap da Unity — emenda validada visualmente sem costura no chao do Egito.
- [x] Sprite/animacao minima do Theo (ainda que placeholder) substituindo o blockout de caixas. `theo-sprite-v01.png` (pose idle) importado e integrado via `TheoSpriteSetup.cs`. Corrigidos: transparencia real (fundo nao era alpha=0, era um xadrez cinza opaco desenhado na imagem), esticamento (SpriteRenderer estava herdando a escala nao-uniforme do collider do "Theo Placeholder", corrigido com objeto filho "Theo Sprite" com escala inversa) e franja branca residual nas bordas. Validado em Play Mode: proporcao correta, sem esticamento, sem caixa/halo branco. Feixe de luz da lanterna descendo do personagem e efeito de arte intencional, nao bug. Confirmado nas duas cenas (`Prototype_Theo_Controller` e `VS_Egypt_Blockout`) apos rodar `Replace Theo Blockout With Sprite (Current Scene)` em cada uma (cenas ja existentes nao sao atualizadas automaticamente pela troca de codigo).
- [x] Lista de habilidades de movimento do Theo (dash etc.) definida e com pelo menos uma implementada e testada. Dash implementado e testado em Play Mode (`TheoController.cs`, tecla Shift), confirmado funcionando no PC Windows e no Mac. Decisao registrada em `docs/04_Characters/theo-abilities.md`: para esta demo (Era Zero + Egito), o kit fica no ataque basico + dash; habilidades das proximas epocas ficam para depois da fatia fechar.
- [ ] Build interna jogavel cobrindo Era Zero + Egito.

So depois de fechar essa checklist a prioridade avanca para a proxima epoca do roadmap de conteudo.

## Fase 0 — Organizacao e Direcao

Status: em andamento.

- [x] Criar estrutura inicial do repositorio.
- [x] Consolidar diretrizes atuais: Unity, pixel art, Era Zero + 7 epocas.
- [x] Salvar prompts oficiais de personagem.
- [x] Organizar primeiros assets por personagem.
- [x] Criar Production Handbook v1.0.
- [x] Preparar `.gitignore` e `.gitattributes` para Unity/Git LFS.
- [ ] Revisar nomes finais do jogo e personagens.
- [ ] Definir lista de habilidades do Theo. Rascunho pronto para revisao em `docs/04_Characters/theo-abilities.md`.
- [ ] Definir mecanica de fragmentos. Rascunho pronto para revisao em `docs/00_Project/fragments-mechanic.md`.

## Fase 1 — Pre-producao do Vertical Slice

Objetivo: preparar tudo que precisa existir antes da primeira cena jogavel.

- [x] Definir versao alvo da Unity: Unity 6 LTS.
- [x] Instalar Unity Hub / Unity 6 LTS na maquina de producao.
- [ ] Instalar Git LFS na maquina de producao.
- [x] Criar projeto Unity real em `unity/FragmentosDoAmanha/`.
- [x] Configurar URP 2D.
- [x] Configurar Input System.
- [ ] Configurar Pixel Perfect Camera. Tentativa via `manifest.json` gerou erro de compilacao (API obsoleta na Unity `6000.5.3f1`); removido. Adicionar pelo Package Manager quando for integrar.
- [ ] Configurar Cinemachine. Tentativa via `manifest.json` gerou erro de compilacao (API obsoleta na Unity `6000.5.3f1`); removido. Adicionar pelo Package Manager quando for integrar.
- [ ] Configurar Git LFS antes de adicionar binarios pesados.
- [x] Criar cena de teste do Theo.
- [x] Criar tileset placeholder da Era Zero. Tiles individuais (`era-zero-lab-tiles-core-v02.png`) fatiados e integrados ao Tilemap da Unity, emenda testada.
- [x] Criar blockout placeholder do Egito.
- [x] Criar tileset placeholder visual do Egito. Tiles individuais (`egypt-temple-tiles-core-v02.png`) fatiados e integrados ao Tilemap da Unity, emenda testada e sem costura no chao.

## Fase 2 — Prototipo Jogavel

Objetivo: validar sensacao de controle.

- [x] Movimento horizontal.
- [x] Pulo.
- [x] Queda/gravidade.
- [x] Camera seguindo o jogador.
- [x] Colisoes e plataformas.
- [x] Vida e dano.
- [x] HUD temporario de vida.
- [x] Ataque basico.
- [x] Inimigo simples.
- [x] Respawn/checkpoint temporario.
- [x] Fragmento coletavel placeholder.

## Fase 3 — Arte Integrada

Objetivo: substituir placeholders principais por assets direcionais.

- [ ] Sprite base do Theo.
- [ ] Idle/run/jump/land.
- [ ] Ataque basico.
- [ ] Hit/death placeholder.
- [ ] Props de Voss na Era Zero.
- [ ] Props de Voss no Egito.
- [ ] FX inicial de tecnologia temporal.
- [x] HUD temporario de vida.

## Fase 4 — Vertical Slice

Objetivo: uma fatia curta, jogavel e apresentavel.

- [x] Sala introdutoria Era Zero.
- [x] Pequena area do Egito.
- [x] Transicao temporal placeholder.
- [x] Fragmento coletavel.
- [x] Inimigo comum placeholder do Egito.
- [x] Primeira presenca ambiental placeholder de Voss.
- [x] Indicacao placeholder de Naiara.
- [ ] Build jogavel interna.

## Fase 5 — Pos-slice

Objetivo: decidir se o pipeline escala.

- [ ] Revisar sensacao de controle.
- [ ] Revisar pipeline de arte.
- [ ] Revisar custo de animacao.
- [ ] Decidir escopo da proxima era.
- [ ] Planejar primeiro boss/miniboss.
