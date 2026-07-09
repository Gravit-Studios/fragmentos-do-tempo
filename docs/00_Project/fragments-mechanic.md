# Mecanica de Fragmentos (Rascunho)

Status: rascunho para revisao. Ainda nao substitui a decisao final do roadmap (`Fase 0 > Definir mecanica de fragmentos`).

## Objetivo deste documento

Propor uma mecanica de fragmentos com dois niveis, amarrada ao que ja esta implementado no prototipo (`TemporalFragment.cs`, `FragmentInventory.cs`, `PrototypeObjectiveState.cs`) e a estrutura narrativa de 7 epocas + Era Zero descrita em `docs/00_Project/project-overview.md`, que ja menciona "fragmento da maquina do tempo" por epoca.

## Dois tipos de fragmento

### 1. Fragmentos Temporais (comuns)

Ja implementados no prototipo como coletavel com bob visual e contador no HUD.

Proposta de funcao:

- Recurso espalhado pelas salas, opcional, recompensa exploracao.
- Acumulado por Theo e usado como "energia" para ativar/melhorar habilidades (ex: reduzir cooldown do dash, aumentar duracao do parry).
- Nao bloqueia progresso principal; e sistema de investimento/otimizacao, nao gate obrigatorio.
- Ponto de gasto proposto: uma "bancada" ou "nucleo" acessivel em pontos seguros de cada epoca (reaproveita a ideia do Nucleo Temporal ja presente no blockout de Era Zero).

### 2. Fragmento da Maquina do Tempo (unico por epoca)

Ainda nao implementado como item distinto; hoje o prototipo trata o fragmento coletavel como o proprio gate de objetivo (`PrototypeObjectiveState` exige 1 fragmento e depois libera o marcador final/portal).

Proposta de funcao:

- Item unico e obrigatorio por epoca, ligado a historia (pedaco da maquina do tempo original, quebrada na explosao inicial).
- Coletar esse fragmento e o que abre o portal temporal para a proxima epoca (a `TemporalScenePortal` ja existente e o mecanismo natural para isso).
- Coletar esse fragmento tambem concede a habilidade de assinatura daquela epoca (ver `docs/04_Characters/theo-abilities.md`), reforcando: cada epoca = 1 fragmento de maquina + 1 habilidade nova + acesso a proxima epoca.
- Serve de gancho narrativo direto: Theo está remontando a maquina do tempo enquanto foge de Voss e cruza com uma Naiara de cada epoca.

## Compatibilidade com o prototipo atual

Para nao introduzir dois sistemas paralelos antes da hora, a proposta para o vertical slice atual (Era Zero + Egito) e:

- Manter o fragmento coletavel unico ja implementado fazendo os dois papeis (fragmento comum de teste + fragmento de maquina do tempo) ate o escopo pedir a separacao.
- Separar os dois sistemas (`FragmentInventory` generico vs. um `EraKeyFragment` dedicado) apenas quando houver mais de um fragmento coletavel por sala nos testes, para nao adicionar complexidade sem necessidade imediata.

## Perguntas em aberto para validacao

- O jogador deve conseguir progredir na historia sem nenhum fragmento comum, so com o fragmento de epoca?
- A bancada/nucleo de upgrade deve existir desde o vertical slice ou so a partir da Fase 3/4?
- O fragmento de epoca deve ter uma leitura visual diferente do fragmento comum desde ja (cor, forma, tamanho) para o jogador nunca confundir os dois?
