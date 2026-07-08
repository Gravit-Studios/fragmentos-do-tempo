# Unity Production Pipeline

## Estado atual

O repositorio esta preparado para receber um projeto Unity, mas nao deve conter arquivos Unity falsos. O projeto real deve ser criado pela Unity quando a producao entrar nessa etapa.

Local planejado:

`unity/FragmentosDoAmanha/`

## Estrutura esperada dentro do projeto Unity

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

Packages/
ProjectSettings/
```

## Regras iniciais

- Criar o projeto pela Unity Hub ou fluxo oficial da Unity.
- Confirmar versao LTS antes de iniciar producao pesada.
- Evitar importar pacotes antes de existir necessidade real.
- Separar scripts por responsabilidade desde o inicio.
- Prefabs devem ser modulares e testaveis em cenas pequenas.
- Assets temporarios devem ser nomeados claramente como placeholder.

## Configuracoes recomendadas

- Projeto 2D.
- Pixel Perfect Camera quando a direcao de resolucao estiver validada.
- PPU inicial: 32.
- Grid de tiles: 32x32 px.
- Sistema de input definido antes de escalar combate.
- Tilemap para blocagem e tilesets iniciais.
- Cinemachine pode ser avaliado para camera 2D.
- Unity 2D Animation pode ser avaliado para personagens modulares.

## Ordem de implementacao sugerida

1. Cena de teste do Theo.
2. Movimento basico.
3. Camera.
4. Colisao e plataformas.
5. Vida e dano.
6. Ataque basico.
7. Inimigo simples.
8. Tileset placeholder.
9. Prefabs modulares.
10. Cena vertical slice Era Zero.
11. Cena vertical slice Egito.

## Padrao de pastas para scripts

- `Core/` - utilitarios centrais e bootstrap.
- `Player/` - controle, movimento e estado do jogador.
- `Combat/` - dano, hitboxes, hurtboxes e ataques.
- `Enemies/` - IA simples, patrulha e estados.
- `Camera/` - camera, limites e seguimento.
- `UI/` - HUD e menus.
- `Systems/` - sistemas compartilhados como save, checkpoints e eventos.

## Criterios antes de escalar conteudo

- Theo se move com resposta agradavel.
- Camera acompanha sem atrapalhar leitura.
- Dano e invulnerabilidade funcionam.
- Um inimigo simples fecha o ciclo de combate.
- Prefabs podem ser reutilizados em mais de uma cena.
- Tileset inicial permite montar salas rapidamente.
