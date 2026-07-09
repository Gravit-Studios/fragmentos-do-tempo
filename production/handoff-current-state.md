# Handoff Current State

Atualizado em: 2026-07-09

Use este arquivo para retomar *Fragmentos do Amanha / Era Zero* em outro computador, Codex web, tablet, celular ou nova conversa.

## Fonte principal

Repositorio GitHub:

```text
https://github.com/Gravit-Studios/fragmentos-do-amanha
```

Antes de trabalhar em outro dispositivo:

```text
git pull --ff-only origin main
```

## Leitura obrigatoria ao retomar

1. `AGENTS.md`
2. `production/current-status.md`
3. `production/roadmap.md`
4. `production/handoff-current-state.md`
5. Para Unity: `docs/08_UnityPipeline/prototype-theo-controller.md`
6. Para concept book: `docs/03_VisualDevelopment/concept-book-art-direction.md`

## Estado atual resumido

O projeto ja tem:

- projeto Unity real em `unity/FragmentosDoAmanha`;
- cena jogavel `Prototype_Theo_Controller`;
- Theo placeholder com movimento, pulo, camera, vida, dano e respawn;
- ataque basico placeholder;
- inimigo placeholder;
- fragmento temporal coletavel;
- HUD temporario de vida, fragmento e objetivo;
- primeira sala curta de laboratorio Era Zero;
- portal temporal placeholder preparado para carregar cena alvo;
- menu de editor para gerar `VS_Egypt_Blockout`;
- concept book em producao;
- direcao de artbook definida para paginas ricas, nao blocadas;
- capa/logotipo em exploracao com simbolo temporal, ciano e textura sutil.

Ainda precisa:

- testar no Play Mode no PC principal;
- gerar e testar a cena `VS_Egypt_Blockout` pela Unity;
- validar portal Era Zero -> Egito;
- instalar/confirmar Git LFS;
- instalar/confirmar Cinemachine e Pixel Perfect;
- criar sprites/tilesets finais;
- refazer pagina 002 do concept book com a nova direcao visual.

## Unity

Versao registrada:

```text
Unity 6000.5.3f1
```

Abrir pelo Unity Hub:

```text
unity/FragmentosDoAmanha
```

Nao abrir a raiz do repositorio como projeto Unity.

### Cena atual

```text
Assets/Scenes/Prototype_Theo_Controller.unity
```

### Menu novo

No Unity:

```text
Fragmentos do Amanha > Create VS Egypt Blockout Scene
```

Esse menu gera:

```text
Assets/Scenes/VS_Egypt_Blockout.unity
```

## Teste recomendado no PC principal

1. Fazer `git pull --ff-only origin main`.
2. Abrir `unity/FragmentosDoAmanha` no Unity Hub.
3. Esperar recompilar.
4. Rodar `Fragmentos do Amanha > Create VS Egypt Blockout Scene`.
5. Abrir `Assets/Scenes/Prototype_Theo_Controller.unity`.
6. Rodar Play Mode.
7. Testar movimento, pulo, camera, dano, respawn, ataque, inimigo, fragmento e HUD.
8. Coletar o fragmento e entrar no marcador final para testar carregamento do Egito.
9. Abrir/testar `Assets/Scenes/VS_Egypt_Blockout.unity` diretamente.
10. Enviar feedback na conversa.

## Concept book

Direcao atual:

```text
docs/03_VisualDevelopment/concept-book-art-direction.md
```

Principio principal:

```text
Artbook visual rico, com imagem principal dominante, estudos orbitando, line art em baixa opacidade, props, notas curtas, paletas integradas e informacao visual em camadas. Evitar paginas blocadas em cards ou colunas rigidas.
```

Proximo passo recomendado:

```text
Refazer a pagina 002 como abertura narrativa de premissa, conectando Theo, Voss e Naiara por ruptura temporal, em vez de usar tres colunas separadas.
```

## Ultimos commits relevantes

```text
0815427 docs: define concept book art direction
9b86a5f feat: add Egypt blockout scene builder
b1acf44 art: simplify concept book cover frame
97b9046 art: refine concept book frame language
e370ec5 art: refine concept book cover direction
899fb72 art: add concept book and logo explorations
18d21d2 docs: add Codex project guide
51b3ad6 feat: add prototype objective hud feedback
```

## Prompt para nova conversa

```text
Estamos trabalhando no projeto Fragmentos do Amanha / Era Zero.
Use o repositorio GitHub https://github.com/Gravit-Studios/fragmentos-do-amanha como fonte principal.
Leia AGENTS.md, production/current-status.md, production/roadmap.md, production/handoff-current-state.md e, se for trabalhar no artbook, docs/03_VisualDevelopment/concept-book-art-direction.md.
Continue do estado atual.
Se estiver no Codex web ou em dispositivo sem Unity, nao assuma Play Mode; prepare mudancas versionadas e marque teste local como pendente.
Se estiver no PC principal com Unity, priorize testar Prototype_Theo_Controller, gerar VS_Egypt_Blockout pelo menu da Unity e validar o portal Era Zero -> Egito.
```
