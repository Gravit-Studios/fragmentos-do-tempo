# Unity Base Project Setup

## Objetivo

Criar o primeiro projeto Unity real do repositorio de forma limpa, sem arquivos simulados, seguindo a recomendacao da versao web:

- Unity 6 LTS.
- URP 2D.
- Input System.
- Pixel Perfect Camera.
- Cinemachine.
- Git LFS.

## Estado atual

Unity 6 foi encontrada em:

```text
/Applications/Unity/Hub/Editor/6000.5.2f1/Unity.app
```

O projeto Unity real foi criado em:

```text
unity/FragmentosDoAmanha/
```

Ja existem:

- `Assets/`
- `Packages/`
- `ProjectSettings/`
- Universal Render Pipeline `17.5.0`
- Input System `1.19.0`
- estrutura base de pastas em `Assets/`

Ainda pendente:

- Git LFS na maquina de producao.
- Cinemachine.
- 2D Pixel Perfect.
- 2D Animation.
- 2D Sprite.
- Confirmar/instalar pacotes 2D restantes pelo Package Manager da Unity.

## Passo a passo no Mac

1. Instalar Unity Hub. **Concluido.**
2. Instalar Unity 6 LTS, preferindo o template 2D/URP quando disponivel. **Concluido.**
3. Instalar Git LFS:

```bash
brew install git-lfs
git lfs install
```

4. Abrir a pasta do repositorio:

```bash
cd "/Users/geansantos/Projetos/fragmentos-do-amanha"
```

5. Criar o projeto pela Unity Hub em:

```text
unity/FragmentosDoAmanha/
```

6. Confirmar que a Unity criou pastas reais:

```text
unity/FragmentosDoAmanha/Assets/
unity/FragmentosDoAmanha/Packages/
unity/FragmentosDoAmanha/ProjectSettings/
```

7. Fazer o primeiro commit do projeto base Unity. **Concluido via Codex.**

## Estrutura esperada dentro de Assets

```text
Assets/
  Art/
    Characters/
    Environments/
    Tilesets/
    UI/
    FX/
  Audio/
  Data/
    Characters/
    Weapons/
    Abilities/
    Enemies/
  Gameplay/
  Prefabs/
  Resources/
  Scenes/
  Scripts/
    Core/
    Player/
    Combat/
    Enemies/
    Camera/
    UI/
    Systems/
  Settings/
```

## Pacotes recomendados

Instalar ou confirmar no Package Manager:

- Universal Render Pipeline.
- Input System.
- Cinemachine.
- 2D Pixel Perfect.
- 2D Tilemap Editor.
- 2D Animation.
- 2D Sprite.

## Configuracoes iniciais recomendadas

- Template: 2D URP.
- PPU inicial: 32.
- Tile grid: 32x32 px.
- Pixel Perfect Camera ativada na cena de teste.
- Input System como sistema principal de input.
- Cena inicial: `Assets/Scenes/Prototype_Theo_Controller.unity`.
- Primeira cena de vertical slice: `Assets/Scenes/VS_EraZero_Lab.unity`.
- Segunda cena de vertical slice: `Assets/Scenes/VS_Egypt_Blockout.unity`.

## Primeiro commit esperado depois da criacao Unity

Mensagem sugerida:

```text
chore: add Unity base project
```

Antes do commit, verificar:

- [ ] `Library/` nao aparece no Git.
- [ ] `Temp/` nao aparece no Git.
- [ ] `Logs/` nao aparece no Git.
- [ ] `Assets/`, `Packages/` e `ProjectSettings/` aparecem.
- [ ] Git LFS esta instalado e ativo.
- [ ] Arquivos grandes estao rastreados via LFS.

## Depois do projeto base

Seguir a ordem:

1. Character Controller.
2. Input System.
3. Camera.
4. Combat.
5. Health/Damage.
6. Enemy AI simples.
7. Save/checkpoints.
8. Dialogue.
9. Inventory/equipment.
10. Timeline/fragmentos.
11. Boss AI.
