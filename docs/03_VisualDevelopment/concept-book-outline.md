# Concept Book Outline

## Objetivo

Organizar a producao visual de *Fragmentos do Amanha* em formato de concept book: uma referencia apresentavel para direcao criativa, arte, UI, marketing e continuidade visual do jogo.

Este documento nao substitui os arquivos de producao da Unity. Ele consolida a linguagem visual em paginas planejadas, assets-chave e lacunas de arte.

A direcao detalhada de pagina, composicao e densidade visual esta em:

```text
docs/03_VisualDevelopment/concept-book-art-direction.md
```

## Formato fisico alvo

Formato escolhido:

```text
29.46 x 1.78 x 20.57 cm
```

Interpretacao de producao:

- largura: `29.46 cm`;
- altura: `20.57 cm`;
- lombada/espessura estimada: `1.78 cm`;
- orientacao: paisagem;
- proporcao aproximada da capa/frente: `1.43:1`.

Esse formato favorece:

- spreads cinematicos de cenarios;
- comparativos entre concept art e pixel art;
- folhas de personagens com pose principal, detalhes e variacoes;
- apresentacao de UI/HUD em largura parecida com tela de jogo;
- capas com logo horizontal forte.
- paginas ricas em camadas visuais, com arte principal, estudos, notas e texturas de fundo.

Recomendacao para producao grafica futura:

- trabalhar paginas em 300 DPI;
- confirmar sangria e margens com a grafica antes de fechar arquivo final;
- manter texto longe da lombada e das bordas externas;
- preparar versoes digitais em PDF alem da versao fisica.

## Estrutura proposta

### 1. Capa e identidade

- Logo principal.
- Simbolo/marca secundaria.
- Paleta institucional.
- Aplicacoes: capa, tela inicial, thumbnail, press kit.

Status: em exploracao.

Arquivos relacionados:

```text
docs/03_VisualDevelopment/logo-exploration-prompts.md
docs/03_VisualDevelopment/concept-book-page-plan.md
art/branding/logo/
```

### 2. Premissa visual

- Theo como cientista deslocado no tempo.
- Voss como presenca historica opressiva.
- Naiara como linhagem de resistencia.
- Contraste visual: tecnologia temporal fria versus contaminacao historica de Voss.

Status: direcao inicial definida.

Arquivos relacionados:

```text
docs/00_Project/project-overview.md
docs/03_VisualDevelopment/visual-development-guide.md
docs/04_Characters/character-dna.md
```

### 3. Personagens principais

Paginas planejadas:

- Theo / Era Zero.
- Voss / tirano temporal.
- Naiara / linhagem de resistencia.
- Comparativo pixel art versus concept art.
- Silhuetas, poses, equipamentos e expressao.

Status: primeira rodada criada.

Arquivos relacionados:

```text
art/pixel/characters/
art/illustration/characters/
docs/03_VisualDevelopment/character-image-prompts.md
```

### 4. Era Zero

Paginas planejadas:

- Laboratorio inicial.
- Momento da explosao.
- Nucleo temporal.
- Propaganda/presenca de Voss.
- Props de laboratorio.
- Primeira sala jogavel.

Status: concept e pixel references criados; prototipo jogavel em andamento.

Arquivos relacionados:

```text
art/pixel/environments/era-zero-lab/
art/illustration/environments/era-zero-lab/
art/pixel/environments/era-zero-explosion/
art/illustration/environments/era-zero-explosion/
unity/FragmentosDoAmanha/Assets/Scenes/Prototype_Theo_Controller.unity
```

### 5. Primeira era: Egito Antigo

Paginas planejadas:

- Camara do templo.
- Iconografia corrompida por Voss.
- Marcas de resistencia de Naiara.
- Props: cartucho, altar, tochas, portas, plataformas.
- Tileset placeholder.

Status: concept e pixel references criados; ainda falta integracao Unity.

Arquivos relacionados:

```text
art/pixel/environments/egypt-temple/
art/illustration/environments/egypt-temple/
```

### 6. Sistema visual de gameplay

Paginas planejadas:

- Theo em escala de gameplay.
- Fragmento temporal.
- Dano, perigo e zona de queda.
- Inimigo placeholder e futura direcao visual de inimigos.
- HUD temporario versus HUD final.

Status: prototipo funcional placeholder; arte final pendente.

Arquivos relacionados:

```text
docs/08_UnityPipeline/prototype-theo-controller.md
unity/FragmentosDoAmanha/Assets/Scripts/
```

### 7. UI e HUD

Paginas planejadas:

- HUD de vida.
- Contador de fragmentos.
- Objetivo temporario.
- Molduras e iconografia temporal.
- Tipografia e legibilidade.

Status: HUD temporario criado na Unity; direcao visual final pendente.

### 8. Marketing e apresentacao

Paginas planejadas:

- Key art.
- Logo em fundo claro e escuro.
- Capa no formato `29.46 x 20.57 cm`.
- Banner horizontal.
- Capsule art.
- Screenshots mockadas do vertical slice.

Status: pendente.

## Ordem recomendada de producao visual

1. Explorar logotipo e simbolo.
2. Definir paleta de marca.
3. Criar props essenciais da Era Zero.
4. Criar tileset placeholder da Era Zero.
5. Criar props essenciais do Egito.
6. Criar tileset placeholder do Egito.
7. Criar sprite base do Theo.
8. Criar inimigo visual do Egito.
9. Criar HUD final inicial.
10. Montar primeira versao exportavel do concept book.

## Regras de consistencia

- A arte de apresentacao pode ser detalhada, mas sempre deve apontar para uma traducao jogavel.
- Pixel art precisa priorizar leitura, colisao e animacao.
- A presenca de Voss deve aparecer tambem no ambiente, nao apenas como personagem.
- Naiara/resistencia deve aparecer por sinais discretos antes de aparecer como personagem completo.
- Evitar excesso de roxo/azul generico de sci-fi; usar contraste frio/cobre, com variacoes por era.
- Logos e simbolos devem funcionar em silhueta antes de ganhar textura.
- Paginas devem parecer material visual de artista, nao catalogo de cards.
- Conteudo tecnico deve entrar como estudo integrado a composicao, nao como bloco separado por padrao.
