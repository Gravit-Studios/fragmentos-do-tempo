# Vertical Slice Plan

## Objetivo

Criar uma fatia jogavel curta que prove a base do projeto antes de expandir para todas as epocas. O vertical slice deve validar controle, camera, combate, leitura visual, tileset, dano e pipeline de producao.

## Escopo

### Incluido

- Era Zero.
- Egito Antigo.
- Theo jogavel.
- Movimento basico.
- Combate basico.
- Um inimigo simples.
- Sistema de vida e dano.
- Camera.
- Tileset inicial.
- Prefabs modulares quando o projeto Unity existir.

### Fora do escopo inicial

- Todas as epocas.
- Boss completo.
- Sistema final de save.
- Arvore completa de habilidades.
- Cinematics finais.
- Arte final de todos os personagens.
- UI definitiva.

## Experiencia desejada

O jogador deve entender rapidamente que Theo e um cientista em fuga, sentir a mudanca de epoca e testar um primeiro ciclo de exploracao e combate. A fatia nao precisa ser longa, mas precisa parecer um pedaco real do jogo.

## Etapas

### 1. Pre-producao

- Consolidar controles.
- Definir tamanho do Theo.
- Definir PPU e resolucao-alvo.
- Criar tileset placeholder.
- Definir inimigo simples.
- Definir uma sala de Era Zero e uma sala do Egito.

### 2. Prototipo jogavel

- Movimento.
- Pulo.
- Colisao.
- Camera.
- Ataque basico.
- Dano.
- Inimigo simples.
- Checkpoint ou respawn temporario.

### 3. Arte inicial

- Sprite base do Theo.
- Primeiro set de animacoes.
- Tileset de Era Zero.
- Tileset do Egito.
- Props de Voss no Egito.
- FX simples de ataque e dano.

### 4. Integracao

- Prefab do Theo.
- Prefab do inimigo.
- Prefabs de dano/hitbox.
- Cena Era Zero.
- Cena Egito.
- Transicao ou placeholder de viagem temporal.

### 5. Refinamento

- Ajustar peso do pulo.
- Ajustar camera.
- Ajustar alcance e tempo de ataque.
- Ajustar vida/dano.
- Melhorar contraste dos tiles.
- Registrar pendencias para a proxima fase.

## Criterios de sucesso

- O controle de Theo e responsivo.
- O jogador entende onde pode andar, pular e atacar.
- O inimigo comunica ataque antes de causar dano.
- A camera nao esconde informacao importante.
- Era Zero e Egito parecem visualmente distintos.
- O pipeline de asset para Unity esta claro.
- A estrutura permite adicionar novas epocas sem reorganizacao grande.

## Proximos documentos derivados

- Lista de habilidades do Theo.
- Documento de inimigos do Egito.
- Documento de tileset da Era Zero.
- Documento de tileset do Egito.
- Plano de cenas Unity.
