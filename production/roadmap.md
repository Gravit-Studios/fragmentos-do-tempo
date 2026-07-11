# Roadmap

## Escopo da Demo Inicial

Decisao: focar em **Era Zero + Egito** ate existir uma fatia funcional, padronizada e polida, antes de expandir para as outras 5 epocas (Grecia, Medieval, Piratas, Segunda Guerra, Inicio da Internet, Futuro proximo continuam fora do escopo ate aqui fechar).

Checklist de definicao de "pronto" para a demo inicial:

- [ ] Controle de Theo responsivo e validado em Play Mode (movimento, pulo, coyote time, colisao).
- [ ] Ataque basico de Theo com timing e alcance validados.
- [x] Inimigo comunica ataque antes de causar dano (telegraph visual antes da hitbox ativar).
- [ ] Telegraph do inimigo testado em Play Mode e com timing validado (nao muito rapido nem muito lento).
- [ ] Vida, dano, invulnerabilidade e respawn testados de ponta a ponta.
- [ ] Fragmento coletavel e HUD (vida, fragmento, objetivo) testados de ponta a ponta.
- [ ] Portal temporal Era Zero -> Egito testado e sem bugs de carregamento.
- [ ] Cena oficial `VS_EraZero_Lab` gerada e testada (script pronto: `Fragmentos do Amanha > Create VS Era Zero Lab Scene`), separada da cena de sandbox `Prototype_Theo_Controller`.
- [ ] Pixel Perfect Camera e Cinemachine integrados (substituindo camera temporaria).
- [x] Tileset placeholder proprio para Era Zero e para Egito (mesmo que simples, cada epoca visualmente distinta). Era Zero (`era-zero-lab-pixel-environment-v02.png`) e Egito (`egypt-temple-pixel-environment-v02.png`) prontos, ainda nao integrados ao Tilemap da Unity.
- [ ] Sprite/animacao minima do Theo (ainda que placeholder) substituindo o blockout de caixas.
- [ ] Lista de habilidades de movimento do Theo (dash etc.) definida e com pelo menos uma implementada e testada. Dash implementado e testado em Play Mode (`TheoController.cs`, tecla Shift), confirmado funcionando.
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
- [x] Criar tileset placeholder da Era Zero. `art/pixel/environments/era-zero-lab/era-zero-lab-pixel-environment-v02.png`, ainda nao integrado ao Tilemap da Unity.
- [x] Criar blockout placeholder do Egito.
- [x] Criar tileset placeholder visual do Egito. `art/pixel/environments/egypt-temple/egypt-temple-pixel-environment-v02.png`, ainda nao integrado ao Tilemap da Unity.

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
