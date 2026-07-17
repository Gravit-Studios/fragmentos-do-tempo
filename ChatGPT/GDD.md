# Game Design Document
### Nome de trabalho: Fragmentos do Amanhã / Era Zero
*(ver candidatos de nome em `nomes/candidatos.md` — decisão final pendente)*

> Este é o documento vivo de referência central do projeto. Ele resume e conecta todos os documentos detalhados do repositório. Para profundidade em qualquer seção, siga os links.

---

## 1. Visão Geral

**Gênero:** Metroidvania de ação-plataforma 2D
**Engine:** Unity (revisado de Unreal Engine — ver justificativa em `game-design/linha-visual-cenario.md`)
**Estilo visual:** Pixel art autêntico, dithering, iluminação atmosférica de ponto único (ver `game-design/linha-visual.md`)
**Escopo:** 7 épocas jogáveis + fase introdutória ("Era Zero")

**Pitch em uma frase:** *Um cientista foge pelo tempo para desfazer o golpe de seu ex-parceiro, que reescreveu a história para se tornar um tirano absoluto — enquanto uma linhagem secreta de guerreiras, nascida do próprio paradoxo que ele criou, luta contra ele em cada época, sem saber por completo por quê.*

---

## 2. Premissa e Narrativa

Ver detalhamento completo em `narrativa/premissa-e-timeline.md`.

**Resumo:** Num futuro de colapso ambiental, dois cientistas parceiros (Theo e Voss) tentam construir uma máquina para resolver a escassez de comida e água da humanidade. Voss propõe uma solução "impossível" — viajar no tempo para corrigir os erros da humanidade — e Theo recusa. Uma explosão no laboratório leva Theo a descobrir que Voss já usou a máquina: a timeline foi alterada, e Voss agora é um ditador com poder absoluto através da história. Uma segunda máquina lança Theo para o início da timeline corrompida, de onde ele deve viajar por 7 épocas coletando fragmentos que restauram sua própria máquina do tempo — na esperança de desfazer o que foi feito.

**A Anomalia (regra central do mundo):** viajar no tempo adapta automaticamente roupas, ferramentas e armas de quem viaja ao padrão daquele período histórico. Essa mesma anomalia é a origem de uma linhagem de guerreiras (ver Naiara, seção 3.3) que nasce em cada época marcada por uma sensibilidade inexplicável contra a tirania de Voss.

---

## 3. Personagens Principais

Bíblias completas em `personagens/theo.md`, `personagens/voss.md`, `personagens/naiara.md`.

### 3.1 Theo (Protagonista)
Cientista, não-combatente no início do jogo. Jornada de reação — sempre um passo atrás do que já aconteceu. Evolui de "investigador em fuga" (Era Zero, sem armas, stealth) para "guerreiro adaptado" em cada época seguinte, através da Anomalia. Elementos fixos que o identificam em qualquer era: óculos de proteção na testa, munhequeira cronométrica.

### 3.2 Voss (Vilão)
Ex-parceiro de Theo, agora ditador através de múltiplas linhas do tempo. Não se vê como tirano — se vê como o único disposto a fazer o necessário. Presente em toda época de duas formas: fisicamente (raro, reservado a momentos-chave) e ambientalmente (estátuas, retratos, propaganda — sempre estilizado na linguagem de arte nativa daquela cultura, com o rosto dele reconhecível). Sua evolução pessoal é de acúmulo: quanto mais avançada a era, mais ostentosa e tecnológica sua forma.

### 3.3 Naiara (Linhagem)
Guerreira de resistência local, uma versão diferente em cada época, todas descendentes de uma linhagem marcada pela anomalia temporal criada no momento em que Voss rompeu a timeline. Não sabe a extensão completa de sua natureza até o fim do jogo. Nunca jogável — aparece em momentos-chave, ajuda indiretamente, mas é plenamente capaz de combate por conta própria. Elemento fixo: uma marca/objeto herdado (Ivory Mark) na mesma posição em toda geração.

---

## 4. Estrutura de Mundo — As 7 Épocas

Detalhamento completo em `game-design/epocas.md`.

| # | Época | Tirania | Arma característica |
|---|---|---|---|
| 1 | Egito Antigo | Faraó como deus vivo | Khopesh, lança, escudo de junco |
| 2 | Grécia Antiga | Berço da palavra "tirano" | Xiphos + Hoplon |
| 3 | Medieval | Feudalismo naturalizado | Arco, espada, escudo |
| 4 | Piratas | Poder tomado pela força | Sabre, pistola de pederneira |
| 5 | Segunda Guerra Mundial | Totalitarismo industrial | Fuzil, granadas |
| 6 | Início da Internet | Controle de informação disfarçado de progresso | Ferramentas de hacking, dispositivos de choque |
| 7 | Era Moderna/Futuro Próximo | Controle tecnológico pleno, fecha o ciclo | Armas de energia |

Cada época soma: identidade arquitetônica única, inimigos = população local corrompida/comprada por Voss, presença ambiental obrigatória de Voss (estátua/propaganda/etc.), e uma versão própria de Naiara.

---

## 5. Modelo de Jogo (Estrutura, Progressão, Diálogo)

Detalhamento completo em `game-design/modelo-de-jogo.md`.

- **Estrutura de fases:** lock-and-key não-linear dentro de cada época (referência: Hollow Knight, Lost Crown), com progressão mais linear entre épocas via fragmentos coletados.
- **Evolução de personagem:** dupla — habilidades obrigatórias (abrem áreas) + customização opcional. Figurino e armamento evoluem por época, não só por pontos de habilidade (diferencial do projeto frente às referências).
- **Diálogo:** protagonista mudo, narrativa ambiental (referência: Blasphemous, Ori). Naiara aparece pontualmente com peso narrativo alto (referência: Maria Renard, SOTN).
- **Cutscenes:** a introdução (explosão no laboratório) é jogável, não cortada — ensina comandos em um momento emocionalmente carregado (referência: Blasphemous, Hades).
- **Cenário:** parallax multicamadas, cada época com paleta e arquitetura distintas.
- **Referência de ritmo:** Split Fiction (cada capítulo com mecânica única + evolução de equipamento), com a ressalva de manter a exploração recompensada (ao contrário da linearidade do Split Fiction).

---

## 6. Direção de Arte

Detalhamento completo em `game-design/linha-visual.md` (personagens) e `game-design/linha-visual-cenario.md` (cenário).

- **Estilo:** pixel art autêntico — baixa resolução efetiva, sem anti-aliasing, sombreamento por dithering, paleta estritamente limitada por personagem/cena, uma fonte de luz forte como âncora visual de cada composição.
- **Pipeline técnico:** 2D puro via Unity (Tilemap + pacote 2D Animation), sprites com parallax em camadas (fundo distante quase estático, camada de jogo com maior densidade de detalhe e variação, camada de frente em silhueta).
- **Cor de identidade tecnológica:** cobre/laranja, reservado a elementos ligados à máquina do tempo — discreto em Theo, quase invisível em Naiara, ostentado em Voss.

---

## 7. Status de Produção

- ✅ Modelo de jogo, narrativa, timeline e regra da Anomalia definidos.
- ✅ 3 personagens principais com bíblia completa.
- ✅ 7 épocas definidas com identidade temática, visual e de combate.
- ✅ Direção de arte validada (pixel art) para personagens e primeiro teste de cenário (Egito Antigo).
- 🔄 Em andamento: concepts de Voss e Naiara em pixel art; retroaplicação do estilo às épocas ainda não testadas.
- ⏳ Pendente: nomes definitivos (jogo, protagonista, vilão, linhagem); bosses/representantes locais de Voss por época; inimigos comuns detalhados; mecânica exata de fragmentos; pipeline de produção 3D/importação de assets (avaliar quando modelagem entrar em pauta).

---

## 8. Índice de Documentos do Repositório

- `game-design/modelo-de-jogo.md` — estrutura, progressão, diálogo, cutscenes, referências de mercado
- `game-design/epocas.md` — as 7 épocas jogáveis
- `game-design/linha-visual.md` — direção de arte de personagens (pixel art)
- `game-design/linha-visual-cenario.md` — direção de arte de cenário + pipeline técnico
- `narrativa/premissa-e-timeline.md` — premissa, timeline, regra da Anomalia
- `personagens/theo.md`, `personagens/voss.md`, `personagens/naiara.md` — bíblias de personagem
- `nomes/candidatos.md` — candidatos a nome do jogo e personagens
