# Theo — Lista de Habilidades (Rascunho)

Status: rascunho para revisao. Ainda nao substitui a decisao final do roadmap (`Fase 0 > Definir lista de habilidades do Theo`).

## Objetivo deste documento

Propor uma progressao de habilidades para Theo, amarrada a estrutura de 7 epocas + Era Zero, ao pilar de metroidvania legivel e ao DNA visual/narrativo ja registrado em `docs/04_Characters/character-dna.md`. O objetivo e ter uma base concreta para discussao, nao uma decisao fechada.

## Principios usados nesta proposta

- Theo comeca nao-combatente e improvisado; toda habilidade deve parecer adaptacao, nao arsenal militar pronto.
- Cada nova epoca contribui com uma habilidade de assinatura, reforcando o pilar "viagem no tempo como estrutura de mundo".
- Habilidades novas devem abrir caminho para areas anteriores (metroidvania), nao apenas aumentar dano.
- O cronometro/dispositivo temporal (DNA visual de Theo) e a fonte narrativa de toda habilidade nao fisica.
- Reaproveitar o que ja existe no prototipo (`TheoController.cs`, `PlayerAttack.cs`) como base do kit inicial, em vez de propor um sistema paralelo.

## Kit atual (ja implementado no prototipo)

- Movimento horizontal, pulo com coyote time, checagem de chao por `BoxCast` (`TheoController.cs`).
- Ataque basico placeholder com hitbox curta a frente (`PlayerAttack.cs`).
- Vida, dano, invulnerabilidade curta e respawn (`PlayerHealth.cs`).
- Coleta de fragmento temporal com contador no HUD (`TemporalFragment.cs`, `FragmentInventory.cs`).

Esse kit cobre a base de Era Zero. As habilidades abaixo sao propostas de evolucao, uma por epoca.

## Escopo para a demo inicial (Era Zero + Egito)

O `roadmap.md` trava o escopo atual em Era Zero + Egito ate essa fatia fechar (`Escopo da Demo Inicial`). Dentro dessa trava, a demo so precisa das duas primeiras entradas desta lista (Golpe Improvisado + Passo Temporal/Dash), ja implementadas. As habilidades de Grecia em diante ficam propositalmente fora de escopo agora — nao sao "trabalho perdido", sao a continuacao natural depois que a fatia inicial provar o ciclo do jogo (mover, explorar, combate simples, objetivo, transicao de era).

Antes de implementar qualquer habilidade nova (pulo duplo, parry, etc.), decidir: a demo inicial precisa provar so o ciclo basico com o kit minimo atual, ou ja precisa mostrar mais profundidade de combate? Ver `Fase 5 — Pos-slice` do roadmap, que ja reserva esse tipo de decisao para depois da fatia fechar.

## Progressao proposta por epoca

### Era Zero — Laboratorio (intro)

- **Golpe Improvisado** (existente): ataque curto com ferramenta/chave inglesa, reforca "nao guerreiro nato".
- **Leitura Temporal** (nova, leve): pressionar um botao de foco destaca brevemente objetos interativos/perigos proximos. Serve como tutorial de leitura de sala, sem custo de fragmento.

### Egito Antigo

- **Passo Temporal (Dash):** deslocamento curto com i-frames, custa 1 uso de energia recarregavel. Abre gaps e desvia de armadilhas. Primeira habilidade de mobilidade real.
- Uso de metroidvania: abre acesso a fendas estreitas e desvia da zona de perigo ja existente no blockout.
- Status: implementado no prototipo (`TheoController.cs`, tecla Shift), sem custo de energia ainda (dash livre com cooldown fixo). Aguardando teste em Play Mode para validar velocidade, duracao e cooldown.

### Grecia Antiga

- **Eco Ascendente (pulo duplo):** um segundo impulso no ar, gerado por um eco temporal de Theo. Abre verticalidade nova.
- Uso de metroidvania: acessa plataformas altas inacessiveis nas epocas anteriores, permitindo backtracking.

### Medieval

- **Bloqueio Temporal (parry):** janela curta de bloqueio/parry cronometrado pelo dispositivo de Theo, converte um ataque inimigo em abertura de contra-ataque.
- Uso de metroidvania: necessario contra um tipo de inimigo com ataque forte introduzido nesta epoca.

### Piratas

- **Corrente Temporal (gancho):** tether/gancho que puxa Theo em direcao a um ponto de ancoragem ou puxa um objeto/alavanca em direcao a Theo.
- Uso de metroidvania: cruza vaos largos e ativa mecanismos a distancia, inclusive em epocas anteriores.

### Segunda Guerra Mundial

- **Carga Temporal:** projetil arremessavel que congela brevemente uma area pequena (inimigo ou mecanismo).
- Uso de metroidvania: resolve obstaculos com temporizacao (ex: destravar uma porta pausando um mecanismo).

### Inicio da Internet

- **Eco Registrado (clone temporal):** grava um trecho curto de movimento de Theo e reproduz como eco solido, usado para pressionar gatilhos ou servir de plataforma temporaria.
- Uso de metroidvania: puzzles de multiplas alavancas/plataformas simultaneas.

### Futuro Proximo / Era Tecnologica Final

- **Ruptura Total:** habilidade de fechamento que combina dash + parry + eco em uma janela curta, pensada como clímax de kit, nao como poder isolado novo.
- Uso: sequencias finais e possivel encontro com Voss.

## Fragmentos e habilidades

Cada habilidade de assinatura deve estar amarrada a coleta do "fragmento da maquina do tempo" da respectiva epoca (ver proposta em `docs/00_Project/fragments-mechanic.md`), reforcando a leitura de que cada epoca concede tanto progresso de historia quanto progresso de jogabilidade.

## Perguntas em aberto para validacao

- O ritmo de uma habilidade nova por epoca e rapido ou lento demais para 8 epocas?
- Alguma habilidade parece combate demais para o Theo "nao-combatente"?
- Faz sentido a habilidade final ser uma combinacao das anteriores, ou o jogo precisa de algo inteiramente novo no fim?
- O parry (Medieval) deve vir antes do dash (Egito) para ensinar defesa mais cedo?
