# Animation Bible

## Objetivo

Definir uma estrategia inicial de animacao para personagens, inimigos, bosses e elementos interativos, mantendo qualidade sem ampliar demais o escopo.

## Principios

1. Animacao deve servir a leitura de gameplay.
2. Poses-chave devem ser fortes antes de qualquer interpolacao.
3. Ataques precisam ter antecipacao, impacto e recuperacao claros.
4. Cada epoca pode alterar armas e postura, mas o controle de Theo deve continuar familiar.
5. Economia de frames e melhor que excesso de frames sem leitura.
6. Nao finalizar visual de personagem antes de entender como ele anda, pula e luta.

## Estrategia tecnica

### Personagens principais

Podem usar rig 2D modular, spritesheets hibridos ou uma combinacao dos dois. Unity 2D Animation deve ser avaliado primeiro, pois reduz dependencia externa no inicio.

### Inimigos simples

Preferir spritesheets tradicionais. Sao mais rapidos de produzir, testar e substituir durante o vertical slice.

### Bosses

Podem misturar sprites em partes, animacao por bones e FX separados. A decisao deve ser feita por boss, considerando tamanho, quantidade de ataques e necessidade de expressividade.

## Lista minima de animacoes do Theo

Para o vertical slice:

- Idle.
- Run.
- Jump start.
- In air.
- Land.
- Basic attack.
- Hit.
- Death ou defeat placeholder.
- Interact.

Animacoes futuras:

- Dash.
- Wall slide.
- Wall jump.
- Crouch ou slide.
- Ataques por arma de epoca.
- Uso do dispositivo temporal.

## Lista minima de inimigo simples

- Idle.
- Patrol ou walk.
- Notice.
- Attack.
- Hit.
- Death.

## Regras de timing

- Controles principais devem responder imediatamente.
- Antecipacao de ataque inimigo deve ser legivel antes do dano.
- Hit stop pode ser usado com cuidado para impacto.
- Recuperacao longa deve ser uma escolha de balanceamento, nao resultado de animacao lenta.

## Pipeline de animacao

1. Definir funcao da animacao no gameplay.
2. Criar thumbnails de pose.
3. Aprovar poses-chave.
4. Produzir rough em pixel ou rig.
5. Testar na Unity.
6. Ajustar timing com controle real.
7. Limpar frames.
8. Exportar e documentar pivots.

## Checklist

- [ ] Pose inicial comunica intencao.
- [ ] Movimento funciona em silhueta.
- [ ] Timing foi testado em gameplay.
- [ ] Pivot consistente.
- [ ] Hitboxes/hurtboxes podem ser lidas pela animacao.
- [ ] Animacao nao depende de detalhe pequeno demais.
