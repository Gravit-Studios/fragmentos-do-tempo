# Theo - Lote ChatGPT 2026-07-17

Nove imagens recebidas do usuario (geradas no ChatGPT, seguindo `docs/03_VisualDevelopment/sprite-prompt-guide.md`), organizadas aqui como referencia de pose/estilo. **Nenhuma foi importada no jogo.**

## Por que ficam so como referencia

Analise tecnica (medicao por script Python/PIL, mesma verificacao usada no resto do projeto):

- Nenhuma das 9 imagens tem canal alpha real. Todas sao `RGB` puro; o "fundo transparente" pedido no prompt saiu como um xadrez cinza-claro (~246-254) achatado na propria imagem, nao como transparencia de verdade -- mesmo problema que o sprite idle original teve no inicio do projeto.
- Nas duas folhas de ciclo dedicadas (`theo-run-cycle-v01.png`, `theo-jump-cycle-poster-v01.png`), os frames nao ficam numa grade uniforme: alguns frames vizinhos se tocam/sobrepoem sem coluna de fundo entre eles (confirmado por deteccao de coluna de conteudo), entao nao da pra recortar cada frame por algoritmo sem risco de cortar o personagem.
- A escala do personagem varia entre os conjuntos (medida pela altura do personagem em pixels): ~500px em `theo-idle-poses-v01.png`, ~325px em `theo-run-cycle-v01.png`, ~521px em `theo-jump-cycle-poster-v01.png`. Cada um foi gerado numa chamada separada, entao a proporcao nao bate entre poses -- o mesmo problema que o idle/corrida v01/v02 tiveram antes de serem regerados juntos (ver `theo-idle-and-run-reference-sheet.txt`).

## O que sao, entao

Excelente referencia de **direcao de arte e consistencia de design** (traje, paleta, silhueta, ferramentas do Theo continuam identicos entre todas as 9 imagens), e uteis para copiar poses especificas (principalmente o ciclo de pulo, que o jogo ainda nao tem) na hora de escrever um novo prompt de geracao isolada.

## Arquivos

- `theo-jump-cycle-poster-v01.png` -- ciclo de pulo rotulado (Start 3 / Ascend 3 / Apex 1 / Fall 2 / Land 2 = 10 frames), com especificacao tecnica (64x96px por frame, pivot no centro dos pes, sempre virado para a direita). Melhor referencia de pose para o pulo.
- `theo-idle-poses-v01.png` -- 6 poses paradas lado a lado.
- `theo-run-cycle-v01.png` -- 8 frames de corrida lado a lado.
- `theo-character-sheet-v01.png` a `v06.png` -- variacoes da mesma "ficha de personagem" (turnaround, paleta, detalhes de equipamento, mini-ciclos de idle/corrida/pulo/agachar/cair/pouso/ataque com lanterna). `v02` inclui tambem interagir/acionar alavanca/empurrar caixa/examinar objeto -- acoes que o jogo ainda nao implementa.

## Proximo passo recomendado

Nao recriar do zero: usar `theo-jump-cycle-poster-v01.png` como referencia de pose para gerar o ciclo de pulo do Theo isoladamente (poses unicas ou um pequeno grupo relacionado numa unica geracao), com `art/pixel/characters/theo/theo-sprite-v03.png` como ancora de identidade/escala -- o mesmo metodo que funcionou para o idle+corrida v03. Ver `docs/03_VisualDevelopment/prompts/characters/theo-v03-jump-cycle-reference-sheet.txt`.
