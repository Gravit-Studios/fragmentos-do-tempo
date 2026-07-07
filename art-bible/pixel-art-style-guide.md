# Pixel Art Style Guide
## Fragmentos do Amanhã / Era Zero

Documento de referência para consolidar o estilo final de pixel art do projeto, com foco em sprites jogáveis, animação, leitura em gameplay e integração com Unity.

---

## 1. Objetivo visual

O estilo final deve combinar:

- leitura clara em movimento;
- riqueza suficiente para diferenciar épocas históricas;
- produção viável para animações extensas;
- consistência entre personagens, cenários, UI e efeitos;
- identidade própria de um metroidvania histórico-temporal.

A direção recomendada é um pixel art moderno, com aparência artesanal, sem anti-aliasing, com sombreado controlado, uso moderado de dithering e paleta limitada.

Referência interna de estilo:

- usar a clareza estrutural de Theo Cientista, Voss Parceiro e Voss Faraó;
- aproveitar a textura e agressividade visual de Naiara Última Guardiã, mas com redução de ruído para animação;
- evitar excesso de microdetalhes em sprites que serão animados.

---

## 2. Princípios principais

### 2.1 Legibilidade primeiro

Todo sprite deve funcionar em três distâncias:

1. zoom de produção, para avaliação artística;
2. escala real de gameplay;
3. gameplay em movimento, com cenário, partículas e inimigos.

Se um detalhe só é percebido em zoom, ele deve ser simplificado ou removido.

### 2.2 Silhueta forte

Cada personagem precisa ser reconhecido pela silhueta antes da cor:

- Theo: postura investigativa, equipamentos temporais, óculos ou tecnologia visível;
- Naiara: postura combativa, marca herdada, leitura de resistência;
- Voss: presença dominante, simetria, autoridade, silhueta de poder.

### 2.3 Poucas cores, bom contraste

A paleta deve ser limitada por personagem e por época. O objetivo não é realismo, mas leitura visual.

Recomendação inicial:

- personagens principais: 18 a 28 cores totais;
- inimigos comuns: 12 a 20 cores;
- NPCs simples: 8 a 16 cores;
- efeitos temporais: paleta própria e recorrente.

### 2.4 Dithering moderado

O dithering deve ser usado para textura e atmosfera, não como preenchimento automático.

Usar em:

- tecido gasto;
- pedra;
- metal envelhecido;
- sombras atmosféricas;
- transições de fundo.

Evitar em:

- rostos pequenos;
- articulações em movimento;
- armas pequenas;
- áreas que precisam de leitura limpa durante combate.

---

## 3. Resolução e escala dos sprites

A resolução final deve ser validada no vertical slice. Até lá, usar estes parâmetros como base de teste.

### 3.1 Personagem jogável

Recomendação inicial:

- sprite base em pé: entre 64 px e 80 px de altura;
- largura variável conforme arma e roupa;
- manter pés e cabeça dentro de uma caixa previsível para colisão.

### 3.2 NPCs e inimigos humanos

- humanos comuns: mesma escala do protagonista ou ligeiramente menor;
- elites: 10% a 25% maiores;
- bosses humanos: maiores por silhueta, não apenas por escala.

### 3.3 Tile grid

Recomendação inicial para teste:

- 16x16 px para tiles de detalhe;
- 32x32 px para módulos principais de cenário;
- personagens entre 2 e 2,5 tiles de altura, dependendo da escala final.

### 3.4 Pixels Per Unit no Unity

Ponto de partida recomendado:

- 16 PPU se o tile principal for 16x16;
- 32 PPU se o tile principal for 32x32.

A decisão deve ser congelada antes da produção massiva de cenários.

---

## 4. Outline

### 4.1 Regra principal

Usar outline externo escuro, mas não necessariamente preto puro.

Preferência:

- outline azul-escuro, marrom-escuro ou cinza-frio, dependendo do personagem;
- preto absoluto apenas para pontos de máximo contraste.

### 4.2 Outline interno

Usar com moderação para separar:

- braços do tronco;
- arma do corpo;
- peças de roupa sobrepostas;
- rosto/cabelo em retratos.

Evitar excesso de linhas internas em áreas pequenas, principalmente nos sprites animados.

### 4.3 Outline quebrado

Permitido em áreas iluminadas para dar acabamento mais moderno. Não deve comprometer a leitura da silhueta.

---

## 5. Luz e sombra

### 5.1 Fonte de luz padrão

Regra recomendada:

- luz principal vindo de cima, levemente frontal;
- variação lateral pequena conforme pose;
- manter consistência dentro do mesmo sprite sheet.

### 5.2 Níveis de sombra

Para sprites de personagem:

- cor base;
- sombra média;
- sombra profunda;
- highlight principal;
- highlight pontual opcional.

Evitar degradês longos. A sensação de volume deve vir da escolha de massas de luz e sombra.

### 5.3 Iluminação temporal

Elementos ligados à máquina do tempo usam cobre/laranja como identidade tecnológica. Energia temporal pode usar ciano claro ou azul-esverdeado quando precisar contrastar com o cobre.

---

## 6. Paleta

### 6.1 Paleta por personagem

Cada personagem deve ter:

- paleta base;
- paleta de sombra;
- paleta de highlight;
- cor de identidade;
- cor de efeito, quando aplicável.

### 6.2 Paleta por época

Cada época deve ter uma paleta dominante, mas os personagens principais precisam manter seus elementos de reconhecimento.

Exemplo:

- Egito: areia, bronze, linho, pedra quente;
- Grécia: mármore, azul profundo, bronze, terracota;
- Medieval: ferro, couro, verde escuro, madeira;
- Piratas: azul marinho, couro, vermelho queimado, madeira;
- Segunda Guerra: verde oliva, cinza, marrom, metal fosco;
- Início da Internet: cinza plástico, azul CRT, verde terminal, laranja técnico;
- Futuro próximo: preto, grafite, ciano, cobre, branco frio.

### 6.3 Cor de Voss

Voss deve se integrar à época, mas sempre carregar sinais visuais de poder acumulado:

- preto ou tom dominante escuro;
- dourado, cobre ou metal nobre;
- simetria e ornamento;
- rosto reconhecível em qualquer era.

---

## 7. Tratamento de materiais

### Tecido

- blocos grandes de sombra;
- dobras simples;
- dithering apenas em tecido gasto.

### Couro

- contraste médio;
- highlights curtos;
- bordas mais marcadas.

### Metal

- contraste alto;
- poucos pixels de brilho;
- não usar degradê suave.

### Bronze/cobre

- reservado para tecnologia temporal, ornamentos de Voss e armas antigas;
- usar highlights quentes.

### Pele

- evitar dithering pesado;
- priorizar leitura de rosto e expressão;
- sombra simples.

### Energia temporal

- silhueta limpa;
- brilho controlado;
- pode quebrar a regra de paleta limitada quando for efeito visual importante.

---

## 8. Retratos e expressões

Retratos podem ter mais detalhe que sprites de gameplay, mas devem seguir a mesma paleta e linguagem.

Regras:

- olhos e sobrancelhas são os principais vetores emocionais;
- boca deve ser simples;
- não exagerar textura no rosto;
- expressões devem ser planejadas por personagem.

Expressões mínimas recomendadas:

- neutra;
- alerta;
- dor/preocupação;
- determinação;
- raiva;
- surpresa.

---

## 9. UI e molduras

A UI atual dos concepts funciona como base: molduras tecnológicas, cantos iluminados e linguagem de dossiê/arquivo temporal.

Regras recomendadas:

- linhas retas e angulares;
- ciano/cobre como acentos tecnológicos;
- fundo escuro de baixa saturação;
- texto limpo, pixelado, mas legível.

A UI não deve parecer medieval, egípcia ou pirata. Ela pertence à camada temporal/científica do jogo.

---

## 10. Critérios de aprovação de sprite

Um sprite só deve ser considerado final quando passar pelos testes:

1. legível em 100% da escala de gameplay;
2. silhueta reconhecível em preto chapado;
3. paleta dentro do limite definido;
4. animação não perde os elementos principais;
5. funciona sobre fundo claro e escuro;
6. exportado corretamente para Unity sem blur;
7. pivô e escala padronizados.

