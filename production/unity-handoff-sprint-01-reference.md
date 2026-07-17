# Unity Handoff Sprint 01 Reference

Status: referencia recebida de handoff externo. Mantida apenas para coordenacao com a frente de Unity.

Esta frente atual do Codex esta focada em ilustracao, concept art, artbook e visual de pixel art. As tarefas abaixo nao devem ser executadas aqui sem pedido explicito do usuario.

## Estado Registrado

- Projeto Unity 2D Metroidvania.
- Fluxo desejado: GitHub -> commits -> testes.
- O handoff original indicava que nao foi possivel editar o GitHub pelo conector na conversa anterior.

## Sprint 1 Planejada

1. PlayerAttack.
2. PlayerHealth.
3. PrototypeEnemy.
4. Refatoracao.

## Melhorias Planejadas

### PlayerAttack

- Corrigir dano duplicado causado por multiplos `Collider2D`.
- Utilizar `HashSet<IDamageable>`.
- Garantir um `TakeHit()` por alvo por ataque.
- Manter multiplos inimigos funcionando.

### PlayerHealth

- Invulnerabilidade temporaria.
- Knockback consistente.
- Fluxo unico de morte.
- Preparacao para checkpoints.

### PrototypeEnemy

- Fluxo consistente de dano.
- Estados de morte.
- Limpeza de referencias.
- Preparacao para IA.

## Proximas Sprints Citadas

- IA.
- Habilidades temporais.
- Inventario.
- Save/load.
- Polimento.

## Observacao De Fluxo

Este documento existe para que o contexto tecnico nao se perca entre dispositivos, mas a producao ativa desta conversa permanece concentrada em:

- artbook;
- concept art;
- guias visuais;
- prompts de imagem;
- pixel art como direcao visual.
