# Concept Book Page Plan

## Formato

Formato fisico alvo:

```text
29.46 x 1.78 x 20.57 cm
```

Para layout de pagina:

- largura: `29.46 cm`;
- altura: `20.57 cm`;
- orientacao: paisagem;
- proporcao aproximada: `1.43:1`;
- lombada/espessura estimada: `1.78 cm`.

## Primeiro lote de validacao

Objetivo: validar linguagem visual, densidade de informacao, uso do logo, equilibrio entre concept art e pixel art, e formato das paginas antes de produzir o concept book completo.

## Direcao de arte para o livro

O concept book deve parecer um artbook do jogo, nao apenas um catalogo tecnico de assets. A estrutura pode usar fichas e estudos quando necessario, mas cada pagina deve ter um ponto de vista narrativo.

Referencia principal de direcao:

```text
docs/03_VisualDevelopment/concept-book-art-direction.md
```

Referencias externas devem ser recebidas em lotes pequenos e triadas antes de virar pagina final:

```text
docs/03_VisualDevelopment/concept-book-reference-intake.md
```

Prioridades:

- abrir cada bloco com uma imagem ou composicao que conte algo do mundo;
- usar detalhes tecnicos como apoio, nao como centro da pagina;
- deixar a historia aparecer no layout: ruptura temporal, arquivos de laboratorio, propaganda de Voss, marcas de resistencia, fragmentos e contaminacao das eras;
- alternar paginas de atmosfera com paginas de estudo;
- evitar repetir o mesmo grid de fichas em todas as paginas;
- evitar conteudo muito blocado, com cards ou colunas rigidas;
- compor como material visual de artista, com imagem principal, estudos, line art, props, notas e textura em camadas;
- permitir assimetria, sobreposicao controlada e fundos com desenhos quase apagados;
- usar bastante informacao visual, mas em camadas orbitando a arte principal;
- usar o azul/ciano como assinatura de ruptura temporal;
- usar cobre/laranja como energia do nucleo, alerta ou tecnologia ativa;
- usar grafite/marfim como base editorial;
- preservar respiro e margens de livro fisico.

Tipos de pagina recomendados:

- **Abertura narrativa:** imagem grande, pouca tipografia, atmosfera forte.
- **Dossie de personagem:** retrato/pose principal, silhueta, equipamentos e notas curtas.
- **Ambiente contextual:** concept art grande com recortes de props, pixel art e leitura de gameplay.
- **Documento in-world:** pagina que parece arquivo, relatorio, propaganda ou artefato encontrado no universo do jogo.
- **Estudo tecnico:** pagina limpa para validar sprite, tileset, HUD ou sistema.

## Sistema de moldura e energia

A moldura pode seguir como assinatura editorial do concept book: uma estrutura fina, limpa e recorrente, com area de respiro e rodape discreto. Ela deve funcionar como pagina de arquivo/artbook, mas sem dominar a arte.

Direcao:

- usar a moldura como elemento constante para dar unidade ao livro;
- variar cor, intensidade e pequenos detalhes conforme era, faccao ou tom da pagina;
- substituir linhas retas demais da borda por feixes falhados, brilhos curtos e fagulhas inspirados no logo;
- evitar molduras com cara de grade tecnica quando a pagina for mais narrativa;
- usar texturas de simbolo em escala grande como fundo centralizado, quase imperceptivel, sem repetir como padrao;
- manter a energia mais concentrada no nucleo, nos rasgos temporais e em pontos de foco da composicao;
- usar particulas ciano para ruptura temporal e particulas cobre/laranja para energia ativa, alerta ou instabilidade.

Paleta por contexto:

- **Era Zero / laboratorio:** grafite, ciano frio, cobre controlado.
- **Explosao temporal:** ciano intenso, branco queimado, cobre/laranja em fagulhas.
- **Primeira era:** base mais mineral/terrosa com ciano como elemento invasor do tempo.
- **Voss / propaganda:** preto, dourado envelhecido, vermelho ou cobre autoritario, ciano usado como contaminacao/controle.
- **Resistencia / Naiara:** tons naturais, tecido, pedra, luz quente moderada, ciano como sinal raro de ruptura.

### Pagina 001 — Capa / Identidade

Objetivo:

- Testar o impacto do logo no formato paisagem.
- Validar a direcao preferida: nucleo temporal fraturado com detalhes azul/ciano.
- Definir uma capa mais editorial e atmosferica, com logo centralizado e espaco de respiro.

Assets base:

```text
art/branding/logo/round-02/logo-a-temporal-core-cyan-cover-v01.png
art/branding/logo/round-02/logo-a-temporal-core-cyan-refinement-v01.png
```

Composicao proposta:

- fundo escuro grafite com textura integrada ao proprio logo;
- logo menor, centralizado e com respiro;
- remover simbolo secundario no canto inferior;
- nucleo temporal como foco discreto;
- usar moldura como fecho de luz falhado, com fagulhas e brilhos nas bordas;
- evitar bordas retas demais ou grade tecnica dominante;
- usar um simbolo ampliado e centralizado no fundo como textura quase invisivel;
- acento azul/ciano mais forte que o laranja;
- textura sutil, sem poluir;
- sem textos secundarios narrativos nesta primeira versao.

Perguntas para validar:

- O logo parece jogo ou livro de arte?
- O azul/ciano deve dominar mais?
- O cobre deve ficar apenas no nucleo?
- O titulo deve ser mais limpo ou mais desgastado?

### Pagina 002 — Premissa Visual

Objetivo:

- Explicar visualmente o contraste central do projeto: ciencia, ruptura temporal, tirania historica e resistencia.
- Servir como pagina de abertura depois da capa.

Assets base:

```text
art/illustration/characters/theo/theo-era-zero-concept-v02.png
art/illustration/characters/voss/voss-tyrant-concept-v02.png
art/illustration/characters/naiara/naiara-lineage-concept-v01.png
art/branding/logo/round-02/logo-a-temporal-core-cyan-refinement-v01.png
```

Composicao proposta:

- abertura narrativa, nao ficha de tres colunas;
- Theo, Voss e Naiara devem aparecer conectados por ruptura temporal, escala, direcao de olhar ou sobreposicao;
- usar o simbolo temporal como textura/fenda central, nao como bloco grafico isolado;
- fundo com line art quase invisivel de laboratorio, propaganda de Voss e marcas de resistencia;
- notas curtas de conceito/historia em pontos de respiro;
- pequenos estudos orbitais: equipamento de Theo, ornamento de Voss, sinal de Naiara, fragmento;
- paleta: grafite, marfim, cobre, azul/ciano.

Perguntas para validar:

- A relacao Theo/Voss/Naiara esta clara?
- O estilo esta serio demais ou na medida certa?
- O concept book deve usar mais texto ou mais imagem?

### Pagina 003 — Era Zero / Laboratorio

Objetivo:

- Validar como as paginas de cenario devem misturar concept art, pixel art e leitura jogavel.
- Usar o laboratorio como primeira pagina de ambiente.

Assets base:

```text
art/illustration/environments/era-zero-lab/era-zero-lab-concept-v01.png
art/pixel/environments/era-zero-lab/era-zero-lab-pixel-environment-v01.png
art/illustration/environments/era-zero-explosion/era-zero-explosion-concept-v01.png
art/pixel/environments/era-zero-explosion/era-zero-explosion-pixel-environment-v01.png
```

Composicao proposta:

- imagem concept art grande como hero, ocupando a maior parte da pagina;
- line art do laboratorio no fundo em baixa opacidade;
- recortes menores com pixel art, props e leitura de camadas;
- detalhes orbitais: nucleo temporal, monitores, Voss ambiental, luz fria, sinal de perigo;
- pequenas amostras de cor integradas, nao como tabela isolada;
- texto como anotacao curta de artista/direcao, nao bloco explicativo.

Perguntas para validar:

- A pagina deve ser mais cinematica ou mais tecnica?
- O pixel art deve aparecer na mesma pagina ou em pagina separada?
- O laboratorio deve abrir antes ou depois da pagina de personagens?

## Segundo lote sugerido

Depois de validar as tres primeiras:

1. Pagina 004 — Momento da explosao.
2. Pagina 005 — Theo / personagem jogavel.
3. Pagina 006 — Voss / presenca e propaganda.
4. Pagina 007 — Naiara / resistencia.
5. Pagina 008 — Egito Antigo / camara do templo.
6. Pagina 009 — Fragmentos, HUD e objetivos.

Cada pagina do segundo lote deve nascer de um micro-brief aprovado a partir das referencias recebidas.

## Regras visuais para paginas

- Evitar paginas muito cheias.
- Usar titulos curtos.
- Texto sempre secundario a imagem.
- Manter margens generosas para o formato fisico.
- Nao usar blocos longos de lore nas primeiras paginas.
- Priorizar composicoes ilustradas/contextuais quando a pagina for de abertura ou historia.
- Usar fichas tecnicas apenas quando elas forem o melhor formato para validacao.
- Evitar grids rigidos como solucao padrao.
- Misturar pintura final, line art, estudos menores, props, notas e paleta na mesma composicao.
- Fazer a informacao parecer descoberta visual, nao planilha.
- Repetir azul/ciano como linguagem temporal.
- Usar cobre/laranja como energia, nao como cor dominante.
- Adaptar a cor da moldura conforme era, faccao ou clima da pagina.
- Usar feixes falhados e fagulhas nas molduras como linguagem de ruptura temporal, evitando linhas rigidas demais.
- Manter Voss como presenca visual recorrente, mesmo em paginas de ambiente.
