# Modelo de Jogo — Metroidvania / Ação-Plataforma 2D

Referências principais: Guacamelee, Dead Cells, Castlevania: Symphony of the Night, Bloodstained: Ritual of the Night, Prince of Persia: The Lost Crown, Blasphemous, Ori and the Blind Forest, Hades.

## 1. Estrutura de Fases (Level Design)

### 1.1 Lock-and-key clássico (Hollow Knight, SOTN, Bloodstained, Guacamelee, Lost Crown)
Mundo interconectado e não-linear onde novas habilidades abrem caminhos antigos. A equipe define primeiro o *shape* geral do mundo e a ordem de aquisição de habilidades — essa ordem vira a "linha" que o jogador percorre sem perceber que está sendo guiado.

- **Hollow Knight** reforça isso com um sistema diegético de mapa: o jogador compra mapas incompletos de um cartógrafo (Cornifer) e precisa preenchê-los manualmente com pena, alfinetes e bússola — tudo comprado, tudo opcional no início.
- **Lost Crown** resolve o problema clássico de "esquecer onde estava a porta trancada" com os **Memory Shards**: o jogador tira um print do obstáculo bloqueado e fixa no mapa, para lembrar depois com qual habilidade voltar.

### 1.2 Torção estrutural — "castelo invertido" (SOTN / Bloodstained)
Na reta final, o mapa inteiro é reaproveitado de forma invertida ou alterada (gravidade invertida, novo tom visual), dobrando o conteúdo percebido sem gerar novos assets do zero. Ótimo truque para dar uma segunda metade surpreendente com orçamento controlado.

### 1.3 Procedural com "trilhos" narrativos (Dead Cells)
Em vez de handcraft puro ou aleatoriedade pura, usa-se um **grafo por bioma**: define-se entrada, saída, salas especiais (loja, tesouro) e o "tom" daquele bioma (mais labiríntico ou mais linear). Só depois o algoritmo sorteia salas prontas dentro dessas regras.

### 1.4 Hub + runs (Hades)
Estrutura de roguelike: um hub central entre tentativas, onde o jogador desbloqueia upgrades permanentes e novos diálogos a cada retorno.

### 1.5 Aplicação ao projeto
A estrutura por **épocas históricas** (medieval, e outras a definir) funciona naturalmente como um sistema lock-and-key expandido: cada era é uma "região" no sentido metroidvania, mas a chave de progressão entre eras é a própria máquina do tempo, melhorada por **fragmentos coletados como recompensa de fase**. Isso combina o modelo 1.1 (exploração não-linear dentro de cada época) com uma progressão mais linear entre épocas (a era seguinte só abre com fragmentos suficientes).

---

## 2. Evolução do Personagem

| Jogo | Sistema de progressão |
|---|---|
| Hollow Knight | Charms equipáveis apenas sentado em bancos + sistema de Soul (cura ou ataque) |
| Dead Cells | Builds por run (permadeath), mutações temporárias e runas permanentes |
| Bloodstained | Stats de RPG completos + Shards colecionáveis de inimigos, upgráveis |
| Lost Crown | Amuletos customizáveis + 3 moedas de progressão diferentes |
| Ori | Árvore de habilidades leve, dividida em ofensiva / defensiva / movimento |
| Hades | Boons dos deuses por run (temporários) + upgrades permanentes no hub |
| Guacamelee | Golpes com cor específica que abrem obstáculos da mesma cor no cenário |

**Padrão comum:** a evolução quase sempre serve dois papéis simultâneos — abrir áreas novas (progressão dura, obrigatória) e dar poder de customização opcional (progressão suave).

### 2.1 Aplicação ao projeto — Progressão dupla e única do jogo
O projeto tem uma característica rara entre as referências: **a evolução de figurino e armamento está atrelada à época, não só a pontos de habilidade.**

- **Fase 0 (era zero, sem combate):** o protagonista é um cientista fugitivo. Sem armas — usa um scanner/lanterna portátil para investigação. Gameplay de stealth (evitar seguranças, puzzles de furtividade), estabelecendo comandos e movimentação básica.
- **Fases seguintes (uma por época):** ao voltar em cada era, a **anomalia** (efeito colateral de mexer no tempo) adapta automaticamente roupas e ferramentas do protagonista ao padrão daquele período (ex: era medieval → arco, espada, escudo, vestimenta de época). Isso resolve narrativamente por que o personagem "aprende" a lutar sem quebrar a lógica de que ele começou como não-combatente.
- **Recompensa de fase = Fragmento:** cada época completada concede um fragmento que melhora a máquina do tempo (permitindo acesso a novas eras/áreas) — o equivalente funcional aos charms/amuletos das referências, mas com peso narrativo direto.

---

## 3. Estilo de Diálogo

1. **Protagonista mudo + narrativa ambiental** (Blasphemous): a história é contada por detalhes do cenário, descrições de itens e NPCs enigmáticos, sem cutscenes longas.
2. **Quase sem fala, narração poética mínima** (Ori): só comentários breves e narração pontual. O resto é "show, don't tell", apoiado na animação e trilha sonora.
3. **Diálogo reativo e ramificado, cheio de personalidade** (Hades): um "banco" de falas filtradas por condições de jogo. Cada NPC reage ao estado do jogador.

### 3.1 Aplicação ao projeto
O protagonista é silencioso — a narrativa deve se apoiar principalmente na abordagem (1) e (2). A terceira personagem (guia recorrente) funciona no modelo de **aparição pontual com peso narrativo alto e pouco tempo de tela**, similar a Maria Renard em SOTN — não é um sistema de diálogo reativo complexo como Hades, mas um punhado de aparições cuidadosamente posicionadas nos momentos-chave de cada era.

---

## 4. Cutscenes

| Jogo | Abordagem |
|---|---|
| Bloodstained / SOTN | Cutscenes CG/2.5D estilo anime, pontuando bosses e reviravoltas |
| Blasphemous | Quase nenhuma cutscene tradicional; a introdução é encenada dentro do próprio gameplay |
| Hades | Flashbacks e memórias reveladas aos poucos, entrelaçando cutscene com diálogo de gameplay |
| Ori | Cutscenes cinematográficas silenciosas, trilha sonora carregando a emoção |

### 4.1 Aplicação ao projeto
A introdução do jogo (explosão no laboratório → descoberta dos documentos → salto temporal) deve seguir o modelo Blasphemous/Hades: **jogável, não cortado em cutscene**, para já ensinar comandos básicos nesse momento emocionalmente carregado. Reviravoltas maiores (encontro com a terceira personagem, confrontos com o vilão) podem usar cutscenes mais tradicionais no estilo Bloodstained/SOTN.

---

## 5. Cenário e Plano de Fundo

- **Parallax multicamadas** (Hollow Knight, Ori, Bloodstained): sprites em diferentes profundidades criam sensação de espaço em cenário 2D.
- **Referências pictóricas reais** (Blasphemous): converter arte real (arquitetura/pintura de época) em pixel art ou ilustração estilizada.
- **Inspiração em animação ocidental** (Ori): cenários que parecem "lugares reais", não só camadas geométricas.
- **2.5D teatral** (Bloodstained): cada sala com identidade visual própria (vitrais, lustres, cortinas).

### 5.1 Aplicação ao projeto
Cada época deve ter uma paleta e linguagem arquitetônica de fundo distintas (mesmo mantendo as cores-base do projeto), para que o jogador identifique imediatamente em qual era está — essencial já que a mecânica central depende do jogador reconhecer mudanças de período.

---

## 6. Referência Visual de Personagens (Character Design)

> **Nota de produção (em teste ativo):** duas direções de estilo estão sendo avaliadas em paralelo — ver `references/characters/` para os testes visuais mais recentes.

### Direção A — Cel-shading duro (moodboard original: Pablo Hernández/Zinkase, Bee Square)
- Shading duro / cel-shading sem gradiente: sombras em blocos sólidos e recortados.
- Silhueta em primeiro lugar, legível mesmo só pela forma.
- Paleta reduzida (3–4 cores dominantes por personagem).
- Proporções semi-estilizadas (nem chibi, nem realista).
- Textura implícita na silhueta (rasgos/remendos recortados, não pintados).

### Direção B — Vetor limpo, tom adulto/sério (teste com referência techwear)
- Shading flat/vetorizado, poucas sombras (2-3 tons por superfície), sem gradiente suave nem rim light.
- Figurino techwear contemporâneo adaptado (jaqueta de campo, colete modular simplificado).
- Personagens mais jovens e alertas, evitando expressões de exaustão/envelhecimento.
- Paleta com acento único de cor por personagem (ex: cobre/laranja como cor de tecnologia).

**Recomendações práticas (válidas para ambas as direções):**
1. Fixar paleta-mãe de 4–5 cores por personagem antes de detalhar equipamento.
2. Desenhar a silhueta em preto sólido primeiro e testar legibilidade antes de colorir.
3. Reservar gradientes/glow (se usados) só para elementos tecnológicos de destaque, nunca na roupa ou pele.
4. Manter consistência de estilo entre todos os personagens antes de produção final.

> Tentativas de gerar os concepts via SVG interno não atingiram o nível de acabamento desejado — produção visual está sendo conduzida externamente (Gemini/ilustrador), usando este documento como brief de direção de arte.

---

## 7. Checklist Rápida de Referência

- [ ] Mundo interconectado com ordem de habilidades definida antes do layout final
- [ ] Sistema de mapa/anotação que ajuda o jogador a lembrar de obstáculos bloqueados
- [ ] Progressão dupla: habilidades obrigatórias + customização opcional
- [ ] Diálogo com pelo menos uma camada reativa
- [ ] Cutscenes reservadas para poucos momentos-chave
- [ ] Parallax de cenário com identidade própria por região/época
- [ ] Character design com silhueta testada em preto sólido antes de colorir
- [ ] Paleta de cor limitada e consistente por personagem
- [ ] Direção de estilo final decidida entre cel-shading duro e vetor limpo
