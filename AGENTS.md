# Fragmentos do Amanha — Codex Project Guide

Este repositorio e a fonte central do projeto **Fragmentos do Amanha / Era Zero**. Qualquer sessao do Codex, local ou web, deve tratar o GitHub como o estado principal do projeto e usar este arquivo como guia antes de agir.

## Ao iniciar uma nova sessao

1. Leia este arquivo.
2. Leia `production/current-status.md`.
3. Leia `production/roadmap.md`.
4. Para trabalho na Unity, leia tambem `docs/08_UnityPipeline/prototype-theo-controller.md`.
5. Verifique o estado do Git antes de editar.
6. Se estiver em maquina local, atualize a branch antes de trabalhar:

```bash
git pull --ff-only origin main
```

Nao comece por memoria de conversa antiga se os documentos do repositorio disserem outra coisa. Os documentos versionados vencem.

## Projeto e caminhos

Repositorio GitHub:

```text
https://github.com/Gravit-Studios/fragmentos-do-amanha
```

Projeto Unity dentro do repo:

```text
unity/FragmentosDoAmanha
```

Ao abrir pelo Unity Hub, selecionar a pasta `FragmentosDoAmanha`, nao a raiz do repositorio.

## Papel de cada ambiente

### Codex local no PC principal

Use para:

- abrir e validar o projeto Unity;
- rodar Play Mode;
- testar controle, camera, fisica, combate, HUD e performance;
- integrar assets no editor;
- criar ou salvar cenas Unity;
- fazer commits apos teste local.

### Codex web / tablet / celular

Use para:

- revisar documentacao;
- planejar proximas etapas;
- criar e revisar scripts versionados;
- organizar prompts, roadmap e status;
- preparar tarefas que possam ser avaliadas por diff;
- analisar historico e propor ajustes.

Nao assumir que Codex web consegue rodar a Unity instalada no PC principal. Para qualquer mudanca dependente de Play Mode, marcar como pendente de teste local.

### GitHub

GitHub e a ponte entre todos os ambientes. Sempre que uma sessao concluir trabalho util:

```bash
git status
git add ...
git commit -m "mensagem clara"
git push origin main
```

Antes de retomar em outra maquina:

```bash
git pull --ff-only origin main
```

## Estado atual resumido

O projeto ja tem:

- documentacao base;
- roadmap e status de continuidade;
- prompt library de personagens;
- prompt library de cenarios;
- artes iniciais de personagens;
- artes iniciais de cenarios em pixel art e concept art;
- projeto Unity real;
- cena `Prototype_Theo_Controller`;
- movimento, pulo, camera, plataformas e respawn;
- vida, dano, ataque placeholder e inimigo simples;
- fragmento temporal coletavel;
- HUD temporario de vida, fragmento e objetivo;
- primeira sala curta de laboratorio Era Zero.
- scripts e menu de editor para gerar o blockout `VS_Egypt_Blockout`;
- portal temporal placeholder para carregar a cena do Egito apos objetivo completo.

O projeto ainda precisa:

- teste manual continuo no PC principal;
- Git LFS instalado e ativo na maquina de producao;
- Cinemachine;
- Pixel Perfect Camera;
- tileset placeholder da Era Zero;
- tileset placeholder do Egito;
- sprites e animacoes reais do Theo;
- FX/arte final de transicao temporal;
- teste manual da area inicial do Egito;
- build interna jogavel.

## Unity

Versao atual registrada no projeto:

```text
Unity 6000.5.3f1
```

Pacotes ja registrados:

- Universal Render Pipeline `17.5.0`
- Input System `1.19.0`

Pacotes pendentes:

- Cinemachine;
- 2D Pixel Perfect;
- 2D Animation;
- 2D Sprite.

Se uma sessao estiver em uma maquina com outra patch version da Unity 6, pode abrir o projeto, mas deve registrar em `production/current-status.md` se `ProjectSettings/ProjectVersion.txt` mudar.

## Cena principal atual

Cena:

```text
unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity
```

Documentacao:

```text
docs/08_UnityPipeline/prototype-theo-controller.md
```

Controles atuais:

- `A` / seta esquerda: mover para esquerda;
- `D` / seta direita: mover para direita;
- `Space` / `W` / seta para cima: pular;
- `J` / clique esquerdo: ataque basico placeholder.

Scripts principais:

```text
unity/FragmentosDoAmanha/Assets/Scripts/Player/TheoController.cs
unity/FragmentosDoAmanha/Assets/Scripts/Player/PlayerHealth.cs
unity/FragmentosDoAmanha/Assets/Scripts/Player/FragmentInventory.cs
unity/FragmentosDoAmanha/Assets/Scripts/Camera/CameraFollow2D.cs
unity/FragmentosDoAmanha/Assets/Scripts/Combat/PlayerAttack.cs
unity/FragmentosDoAmanha/Assets/Scripts/Combat/IDamageable.cs
unity/FragmentosDoAmanha/Assets/Scripts/Enemies/PrototypeEnemy.cs
unity/FragmentosDoAmanha/Assets/Scripts/Systems/TemporalFragment.cs
unity/FragmentosDoAmanha/Assets/Scripts/Systems/PrototypeObjectiveState.cs
unity/FragmentosDoAmanha/Assets/Scripts/UI/PrototypeHealthHud.cs
unity/FragmentosDoAmanha/Assets/Scripts/UI/PrototypeFragmentHud.cs
unity/FragmentosDoAmanha/Assets/Scripts/UI/PrototypeObjectiveHud.cs
```

## Regras de trabalho

- Preservar arquivos `.meta` da Unity.
- Nao commitar `Library/`, `Temp/`, `Logs/`, `UserSettings/`, crash logs ou caches locais.
- Nao criar arquivos Unity falsos fora do editor se isso puder corromper cena, prefab ou asset serializado.
- Scripts C# podem ser editados normalmente fora da Unity.
- Cenas e prefabs devem ser preferencialmente criados ou modificados pela Unity, ou por scripts de editor executados pela Unity.
- Atualizar `production/current-status.md` quando houver mudanca significativa de escopo, cena, pacote, versao Unity ou fluxo.
- Atualizar `production/roadmap.md` quando uma tarefa for concluida ou uma nova pendencia importante aparecer.
- Manter respostas e documentos em portugues, exceto nomes tecnicos, paths e codigo.
- Usar ASCII em arquivos novos, salvo se o arquivo existente ja usar acentos de forma consistente.

## Arte e prompts

Prompts oficiais:

```text
docs/03_VisualDevelopment/character-image-prompts.md
docs/03_VisualDevelopment/environment-image-prompts.md
```

Assets de personagens:

```text
art/pixel/characters/
art/illustration/characters/
```

Assets de cenarios:

```text
art/pixel/environments/
art/illustration/environments/
```

Ao gerar novas artes, salvar em pasta organizada por tipo, personagem/cenario e versao. Atualizar o `asset-index.md` correspondente.

## Antes de finalizar uma tarefa

Checklist minimo:

1. Verificar `git status`.
2. Se houver codigo Unity, tentar compilar/validar na Unity local quando possivel.
3. Se nao foi possivel testar no Play Mode, declarar isso no resumo.
4. Atualizar docs de status/roadmap quando necessario.
5. Criar commit com mensagem clara.
6. Enviar para GitHub.

## Prompt padrao para retomar o projeto

Use este prompt em nova conversa, Codex web, tablet, celular ou outro PC:

```text
Estamos trabalhando no projeto Fragmentos do Amanha / Era Zero.
Use o repositorio GitHub https://github.com/Gravit-Studios/fragmentos-do-amanha como fonte principal.
Leia AGENTS.md, production/current-status.md, production/roadmap.md e docs/08_UnityPipeline/prototype-theo-controller.md antes de agir.
Continue do estado atual do projeto.
Se estiver no Codex web, nao assuma que consegue testar Unity; prepare mudancas versionadas e marque Play Mode como pendente.
Se estiver no PC principal com Unity, priorize testar Prototype_Theo_Controller no Play Mode e ajustar controle, camera, combate, HUD e leitura da sala.
```
