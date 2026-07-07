# Animation Guide
## Fragmentos do Amanhã / Era Zero

Guia inicial de animação para sprites 2D em pixel art.

---

## 1. Filosofia de animação

A animação deve priorizar responsividade. O jogador precisa sentir controle imediato, especialmente em combate e plataforma.

A estética pode ser detalhada, mas nunca deve prejudicar:

- leitura de antecipação;
- sensação de impacto;
- cancelamento de ações;
- previsibilidade de hitboxes e hurtboxes.

---

## 2. Taxa de animação

Recomendação inicial:

- animações principais em 12 fps;
- efeitos e impactos podem usar 12 a 15 fps;
- cutscenes in-game podem usar mais frames se necessário;
- evitar suavização automática/interpolação.

---

## 3. Poses-chave

Toda animação deve ser construída com:

1. pose inicial;
2. antecipação;
3. ação principal;
4. recuperação;
5. retorno para estado neutro.

Para ataques, separar claramente:

- startup frames;
- active frames;
- recovery frames.

---

## 4. Animações essenciais do Theo

### Locomoção

- idle;
- walk;
- run;
- turn;
- jump start;
- jump loop;
- fall;
- land;
- dash;
- crouch;
- ledge grab;
- wall slide;
- wall jump.

### Combate

- attack 1;
- attack 2;
- attack 3;
- charged attack;
- air attack;
- downward attack;
- parry/block, se aprovado;
- hurt;
- knockback;
- death.

### Interação

- inspect;
- collect fragment;
- activate machine;
- dialogue idle;
- use device.

---

## 5. Timing sugerido

### Idle

6 a 8 frames, loop leve.

Movimento pequeno, evitando excesso de respiração para não encarecer todas as versões.

### Run

8 frames como base.

Precisa funcionar com armas diferentes.

### Jump

Separar em três estados:

- início do salto;
- subida/loop;
- queda.

### Attack combo

Cada ataque deve ter identidade própria:

- ataque 1: rápido, baixo comprometimento;
- ataque 2: alcance maior;
- ataque 3: impacto mais forte e recuperação maior.

---

## 6. Hitboxes e hurtboxes

Nunca depender apenas do visual do sprite.

Cada ataque precisa documentar:

- frames ativos;
- alcance;
- dano;
- empurrão;
- cancelamento permitido;
- vulnerabilidade.

---

## 7. Reaproveitamento por época

Animações de corpo devem ser desenhadas para suportar troca de roupa/arma.

Priorizar uma base comum para:

- corrida;
- pulo;
- dano;
- morte;
- interação;
- uso do dispositivo temporal.

Animações específicas por época:

- ataques com armas distintas;
- habilidades únicas;
- interações culturais específicas;
- animações de fragmento.

---

## 8. Exportação

Cada animação deve ser exportada como sprite sheet separado ou atlas organizado por personagem.

Nome recomendado:

`char_theo_egypt_run.png`

`char_theo_egypt_attack_01.png`

`char_naiara_egypt_idle.png`

---

## 9. Checklist de animação

Antes de aprovar:

- funciona em loop;
- mantém pivô consistente;
- não treme indevidamente;
- silhueta é clara;
- arma não muda de tamanho sem intenção;
- pés não escorregam na corrida;
- hitbox corresponde ao impacto visual;
- exportação está sem blur.

