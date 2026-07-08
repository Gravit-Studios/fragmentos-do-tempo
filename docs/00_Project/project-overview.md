# Project Overview

## Identidade do projeto

**Nome de trabalho:** Fragmentos do Amanha / Era Zero  
**Genero:** metroidvania 2D de acao-plataforma  
**Engine principal:** Unity  
**Estilo in-game:** pixel art  
**Arte de apresentacao:** ilustracao detalhada, nao pixel art  
**Modelo de producao:** independente, com apoio estruturado de IA

## Pitch

Um cientista foge pelo tempo para desfazer o golpe de seu ex-parceiro, que reescreveu a historia para se tornar um tirano absoluto. Em cada epoca, uma versao da linhagem de Naiara atua como resistencia contra essa tirania.

## Pilares

1. **Viagem no tempo como estrutura de mundo:** cada epoca deve mudar visual, armas, inimigos, leitura de fase e presenca de Voss.
2. **Metroidvania legivel:** exploracao, retorno a areas anteriores e habilidades que abrem caminhos precisam ser claros para o jogador.
3. **Combate fluido e responsivo:** o ritmo deve favorecer decisao rapida, leitura de ataques e sensacao de evolucao.
4. **Narrativa ambiental:** Voss deve ser sentido no mundo por propaganda, estatuas, arquitetura, simbolos e alteracoes culturais.
5. **Producao independente inteligente:** escopo controlado, assets modulares, documentacao clara e IA usada para acelerar iteracoes.

## Personagens centrais

### Theo

Protagonista. Cientista, inicialmente nao-combatente, que se adapta visual e mecanicamente a cada era. Seus elementos recorrentes sao oculos de protecao, dispositivo temporal, cobre/laranja como cor tecnologica e visual funcional assimetrico.

### Voss

Vilao e ex-parceiro de Theo. Reescreveu a historia para se instalar como tirano em diferentes epocas. Sua linguagem visual usa verticalidade, simetria, preto/dourado, imponencia e presenca ambiental constante.

### Naiara

Linhagem de guerreiras de resistencia. Cada epoca possui uma Naiara diferente, ligada simbolicamente a anterior por marca, objeto herdado, postura agil e identidade de legado.

## Epocas jogaveis

1. Era Zero / laboratorio futurista introdutorio
2. Egito Antigo
3. Grecia Antiga
4. Medieval
5. Piratas
6. Segunda Guerra Mundial
7. Inicio da Internet
8. Futuro proximo / era tecnologica final

Cada epoca deve ter identidade visual, armas, inimigos, versao de Naiara, presenca de Voss, fragmento da maquina do tempo, paleta e tileset proprios.

## Prioridade atual

A prioridade e construir um vertical slice com Era Zero e Egito Antigo. O objetivo nao e provar todo o jogo, mas validar sensacao de controle, pipeline de arte, tileset, camera, combate basico, dano, inimigo simples e modularidade para expansao.

## Regra de organizacao

Este repositorio deve separar:

- Documentacao de design e producao em `docs/`.
- Planejamento executavel em `production/`.
- Assets e estudos visuais em `art/`.
- Projeto Unity real em `unity/FragmentosDoAmanha/`, somente quando criado pela Unity.
