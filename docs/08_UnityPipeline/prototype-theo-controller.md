# Prototype Theo Controller

## Cena

`unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity`

## Objetivo

Primeira cena jogavel para validar a sensacao basica de controle, combate e objetivo antes de integrar sprite final, tileset e Cinemachine.

## Controles

- `A` / seta esquerda: mover para esquerda.
- `D` / seta direita: mover para direita.
- `Space` / `W` / seta para cima: pular.
- `J` / clique esquerdo: ataque basico placeholder.

## Implementado

- Theo placeholder com `Rigidbody2D`, `CapsuleCollider2D` e controller basico.
- Movimento horizontal.
- Pulo com checagem de chao.
- Checagem de chao por `BoxCast`, mais estavel em plataformas.
- Pequena tolerancia de pulo em beiradas para evitar perda de comando.
- Protecao anti-travamento quando Theo encosta em quinas de plataforma no ar.
- Collider em capsula para reduzir travamento em quinas de plataformas.
- Gravidade via `Rigidbody2D`.
- Plataformas de chao e elevadas com colisao somente no topo para evitar travamento lateral durante o pulo.
- Plataformas com `PlatformEffector2D`: Theo atravessa por baixo e pousa por cima.
- Movimento horizontal no ar nao continua empurrando Theo contra laterais de plataformas.
- Materiais de fisica sem atrito para reduzir travamento em bordas.
- Camera 2D seguindo Theo por script temporario.
- Camera 2D com limites temporarios da sala e enquadramento ajustado ao tamanho visivel.
- Sistema temporario de vida, dano e respawn.
- HUD temporario de vida.
- Ataque basico placeholder com hitbox visual curta.
- Inimigo placeholder com patrulha, dano de contato, vida e morte.
- Fragmento temporal coletavel com contador no HUD.
- Objetivo temporario no HUD: coletar o fragmento e chegar ao marcador final.
- Zona de dano placeholder para validar colisao de perigo.
- Zona de queda que faz respawn quando Theo cai fora da sala.
- Blockout inicial do laboratorio Era Zero.
- Primeira sala curta com inicio seguro, salto, perigo, inimigo e fragmento.
- Elementos de direcao visual: nucleo temporal, monitor de Voss, luz fria e acento cobre.

## Ainda pendente

- Teste manual no Play Mode do fluxo de dano/respawn e HUD.
- Teste manual do timing e alcance do ataque basico.
- Teste manual do loop Theo ataca, inimigo toma dano e desaparece.
- Teste manual do coletavel `Temporal Fragment` e contador `FRAG`.
- Teste manual da leitura da sala curta: entrada, perigo, combate e recompensa.
- Teste manual de pulo em cima de plataformas, movimento no ar e respawn por queda.
- Substituir placeholders por sprites e tiles.
- Integrar Pixel Perfect Camera quando o pacote estiver instalado.
- Trocar camera temporaria por Cinemachine quando o pacote estiver instalado.
- Criar cenas separadas `VS_EraZero_Lab` e `VS_Egypt_Blockout`.
