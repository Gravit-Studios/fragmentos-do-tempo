# Prototype Theo Controller

## Cena

`unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity`

## Objetivo

Primeira cena jogavel para validar a sensacao basica de controle antes de integrar sprite final, tileset e Cinemachine.

## Controles

- `A` / seta esquerda: mover para esquerda.
- `D` / seta direita: mover para direita.
- `Space` / `W` / seta para cima: pular.

## Implementado

- Theo placeholder com `Rigidbody2D`, `BoxCollider2D` e controller basico.
- Movimento horizontal.
- Pulo com checagem de chao.
- Gravidade via `Rigidbody2D`.
- Plataformas com colisao.
- Camera 2D seguindo Theo por script temporario.
- Blockout inicial do laboratorio Era Zero.
- Elementos de direcao visual: nucleo temporal, monitor de Voss, luz fria e acento cobre.

## Ainda pendente

- Teste manual no Play Mode.
- Substituir placeholders por sprites e tiles.
- Integrar Pixel Perfect Camera quando o pacote estiver instalado.
- Trocar camera temporaria por Cinemachine quando o pacote estiver instalado.
- Criar cenas separadas `VS_EraZero_Lab` e `VS_Egypt_Blockout`.
