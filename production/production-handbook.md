# Production Handbook v1.0

## Objetivo

Transformar a direcao criativa de *Fragmentos do Amanha / Era Zero* em um pipeline pratico de producao independente, com apoio de IA, Unity e validacao manual.

Este documento e a ponte entre GDD, arte, animacao, pipeline tecnico e execucao diaria.

## Principio central

**IA-first, human-directed.**

A IA acelera tarefas repetitivas, gera alternativas e apoia documentacao/codigo. A direcao criativa, aprovacao final e criterio de qualidade continuam humanos.

## Divisao de responsabilidades

### Direcao humana

- Decisoes criativas finais.
- Validacao de arte e gameplay.
- Escolha de escopo.
- Priorizacao do vertical slice.
- Testes jogaveis e aprovacao de sensacao de controle.

### ChatGPT / Direcao de producao

- GDD e documentacao.
- World bible.
- Art bible.
- Pipeline de IA.
- Prompts.
- Arquitetura de sistemas.
- Revisao de consistencia.

### Codex / Implementacao

- Scripts C#.
- Refatoracao.
- Estrutura de projeto Unity.
- Sistemas base.
- Ferramentas editoriais.
- Organizacao de arquivos.
- Testes e automacoes.

### IA de imagem

- Concepts.
- Variacoes de roupa.
- Estudos de paleta.
- Sprites conceituais.
- Poses-chave.
- Referencias de animacao.

## Pipeline oficial

1. Pesquisa historica.
2. World building.
3. Concept art / artbook.
4. Character construction.
5. Pixel layout.
6. Curadoria manual.
7. Pixel polish.
8. Rig 2D ou spritesheet.
9. Unity.
10. Gameplay test.
11. Refinamento.

## Departamentos de IA

### IA 01 — Visual Development

Responsavel por:

- Concepts.
- Turnarounds.
- Color keys.
- Estudos de materiais.
- Equipment callouts.
- Mood visual por epoca.

### IA 02 — Pixel Assistant

Responsavel por:

- Traducao de concept para pixel layout.
- Estudos de clusters.
- Variacoes de paleta.
- Sprites conceituais.
- Leitura de silhueta.

Validacao sempre no tamanho real de jogo.

### IA 03 — Animation Assistant

Responsavel por:

- Poses-chave.
- Ciclos de caminhada/corrida.
- Variacoes de ataque.
- Referencias de timing.
- Sugestoes de breakdowns.

Validacao sempre dentro da Unity.

### IA 04 — Programming Assistant

Responsavel por:

- Arquitetura de sistemas.
- C#.
- State machines.
- ScriptableObjects.
- Animator Controller.
- Editor tools.
- Save, inventario, dialogo e AI quando chegarem ao escopo.

## Regra de animacao

Nao finalizar visual de personagem antes de entender como ele se move.

Ordem recomendada:

1. Funcao de gameplay.
2. Movimento base.
3. Poses-chave.
4. Silhueta.
5. Sprite final.
6. Animacao.
7. Teste jogavel.

## Living Character System

Personagens principais devem ser pensados como kits modulares:

```text
Personagem =
  Corpo
  + Roupa
  + Equipamento
  + Arma
  + Animacao
  + FX
  + Sons
  + Comportamentos
```

Isso reduz retrabalho quando Theo muda de epoca e ajuda a manter consistencia entre versoes de Naiara e Voss.

### Theo

- Corpo base.
- Oculos.
- Cronometro temporal.
- Roupa por epoca.
- Arma/ferramenta por epoca.
- FX temporal.

### Naiara

- Base de postura agil.
- Marca/objeto herdado.
- Roupa local por epoca.
- Arma ou ferramenta de resistencia.
- Presenca narrativa.

### Voss

- Silhueta vertical.
- Dispositivo central.
- Linguagem preta/dourada.
- Versoes ambientais por epoca.
- Manifestacoes fisicas raras e controladas.

## Ordem tecnica futura na Unity

Quando o projeto Unity real existir, a implementacao deve seguir esta ordem:

1. Character Controller.
2. Input System.
3. Camera.
4. Combat.
5. Health/Damage.
6. Enemy AI simples.
7. Save/checkpoints.
8. Dialogue.
9. Inventory/equipment.
10. Timeline/fragmentos.
11. Boss AI.

## Base Unity recomendada

- Unity 6 LTS ou versao LTS vigente definida antes do inicio.
- URP 2D.
- Input System.
- Pixel Perfect Camera.
- Cinemachine.
- Tilemap.
- 2D Animation.
- Git LFS para imagens grandes, audio e binarios de Unity quando o projeto real entrar no repositorio.

## Checklist para novo personagem

- [ ] Funcao narrativa definida.
- [ ] Funcao de gameplay definida.
- [ ] DNA visual registrado.
- [ ] Prompt de concept salvo.
- [ ] Concept art aprovado.
- [ ] Construction sheet aprovado.
- [ ] Prompt de pixel salvo.
- [ ] Pixel layout testado em escala real.
- [ ] Poses-chave aprovadas.
- [ ] Animacao testada em gameplay.
- [ ] Asset salvo em pasta correta.
- [ ] Metadados registrados em asset index.

## Checklist para nova epoca

- [ ] Identidade visual.
- [ ] Paleta.
- [ ] Tileset minimo.
- [ ] Presenca ambiental de Voss.
- [ ] Versao de Naiara.
- [ ] Inimigos comuns.
- [ ] Arma/ferramenta de Theo.
- [ ] Fragmento da maquina do tempo.
- [ ] Mecanica exclusiva da era.
- [ ] Cena de teste.

## Proxima meta

Produzir o vertical slice Era Zero + Egito com o menor escopo capaz de validar controle, combate, camera, tileset, dano, inimigo simples e pipeline de arte.
