# Prototype Theo Controller

## Cena

`unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity`

## Objetivo

Primeira cena jogavel para validar a sensacao basica de controle antes de integrar sprite final, tileset e Cinemachine.

## Controles

- `A` / seta esquerda: mover para esquerda.
- `D` / seta direita: mover para direita.
- `Space` / `W` / seta para cima: pular.
- `J` / clique esquerdo: ataque basico placeholder.

## Implementado

- Theo placeholder com `Rigidbody2D`, `BoxCollider2D` e controller basico.
- Movimento horizontal.
- Pulo com checagem de chao.
- Gravidade via `Rigidbody2D`.
- Plataformas com colisao.
- Camera 2D seguindo Theo por script temporario.
- Sistema temporario de vida, dano e respawn.
- HUD temporario de vida.
- Ataque basico placeholder com hitbox visual curta.
- Zona de dano placeholder para validar colisao de perigo.
- Blockout inicial do laboratorio Era Zero.
- Elementos de direcao visual: nucleo temporal, monitor de Voss, luz fria e acento cobre.

## Ainda pendente

- Teste manual no Play Mode do fluxo de dano/respawn e HUD.
- Teste manual do timing e alcance do ataque basico.
- Substituir placeholders por sprites e tiles.
- Integrar Pixel Perfect Camera quando o pacote estiver instalado.
- Trocar camera temporaria por Cinemachine quando o pacote estiver instalado.
- Criar cenas separadas `VS_EraZero_Lab` e `VS_Egypt_Blockout`.
