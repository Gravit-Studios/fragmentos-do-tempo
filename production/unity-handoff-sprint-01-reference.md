# Unity Handoff Sprint 01 Reference

Status: referencia recebida de handoff externo. Mantida apenas para coordenacao com a frente de Unity.

Esta frente atual do Codex esta focada em ilustracao, concept art, artbook e visual de pixel art. As tarefas abaixo nao devem ser executadas aqui sem pedido explicito do usuario.

## Estado Registrado

- Projeto Unity 2D Metroidvania.
- Fluxo desejado: GitHub -> commits -> testes.
- O handoff original indicava que nao foi possivel editar o GitHub pelo conector na conversa anterior.

## Sprint 1 -- executada e testada em 2026-07-17 pela frente Unity (Claude)

Confirmado pelo usuario em Play Mode: "Tudo funcionando" (ataque sem dano duplicado, inimigo morre normalmente).

1. PlayerAttack. `[x]`
2. PlayerHealth. `[x]` (ja estava satisfeito antes desta sprint)
3. PrototypeEnemy. `[x]`
4. Refatoracao. Nao foi necessaria alem do que esta listado abaixo -- codigo ja estava organizado.

## Melhorias Planejadas

### PlayerAttack

- [x] Corrigir dano duplicado causado por multiplos `Collider2D`. Confirmado: `OverlapBoxAll` retornava um `Collider2D` por parte atingida, e cada um resolvia pro mesmo `IDamageable` via `GetComponentInParent`, chamando `TakeHit` mais de uma vez no mesmo ataque se o alvo tivesse mais de um collider.
- [x] Utilizar `HashSet<IDamageable>`.
- [x] Garantir um `TakeHit()` por alvo por ataque. `alreadyHit.Add(damageable)` so deixa passar a primeira vez que aquele alvo aparece nos hits do frame.
- [x] Manter multiplos inimigos funcionando. Cada inimigo tem sua propria entrada no `HashSet`, sem alterar o comportamento existente de acertar varios alvos num unico swing.

### PlayerHealth

- [x] Invulnerabilidade temporaria. Ja implementado (`GrantInvulnerability`/`isInvulnerable`).
- [x] Knockback consistente. Ja implementado (`ApplyKnockback`, direcao baseada na posicao relativa da fonte).
- [x] Fluxo unico de morte. Ja implementado -- `TakeDamage` (dano de combate) e `RespawnNow` (queda) convergem no mesmo `RespawnRoutine`.
- [x] Preparacao para checkpoints. Ja implementado (`SetRespawnPoint`/`respawnPoint`).
- Nenhuma mudanca de codigo foi necessaria aqui; os itens ja estavam cobertos pelo trabalho anterior desta sessao (fix do exploit de dano de queda).

### PrototypeEnemy

- [x] Fluxo consistente de dano. `TakeHit` agora ignora chamadas repetidas depois que o estado vira `Dead` (`if (damage <= 0 || state == State.Dead) return;`).
- [x] Estados de morte. Adicionado `State.Dead` a maquina de estados (antes a morte so desativava o GameObject sem passar por um estado explicito).
- [x] Limpeza de referencias. `trackedPlayer` e zerado (`null`) ao morrer.
- [ ] Preparacao para IA. Nao enderecado -- a maquina de estados atual (Patrol/Telegraph/Attacking/Cooldown/Dead) ja e extensivel, mas nenhum sistema de IA foi desenhado ainda. Fica para uma sprint futura, junto com as "Proximas Sprints Citadas" abaixo.

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
