# Fragmentos do Amanha

Documentacao de producao de *Fragmentos do Amanha* / *Era Zero*, um metroidvania 2D de acao-plataforma sobre viagem no tempo, desenvolvido na Unity com apoio de IA em documentacao, arte, animacao, pipeline e programacao.

O objetivo deste repositorio e manter a visao criativa, o planejamento de producao e a futura base Unity organizados desde o inicio, sem misturar material conceitual, arquivos de jogo e entregas de planejamento.

## Visao rapida

Theo, um cientista inicialmente nao-combatente, foge pelo tempo para desfazer o golpe de Voss, seu ex-parceiro, que reescreveu a historia para se tornar um tirano absoluto. Em cada epoca, uma versao da linhagem de Naiara atua como resistencia contra essa tirania.

O jogo usa duas camadas de arte:

- **Artbook e apresentacao:** ilustracoes detalhadas para lore, direcao visual e comunicacao.
- **In-game:** pixel art limpa, legivel, animavel e otimizada para gameplay.

## Estrutura do repositorio

- `docs/` - Documentacao viva do projeto, organizada por area de producao.
- `production/` - Planejamento pratico, vertical slice, pipeline com IA e roadmap.
- `art/` - Estrutura para concepts, pixel art, animacao, UI, FX e marketing.
- `unity/` - Local reservado para o projeto Unity real quando ele for criado.
- `GDD.md` - Documento de game design existente, mantido como referencia historica e criativa.
- `game-design/`, `narrativa/`, `personagens/`, `nomes/` - Documentos iniciais ja existentes no repositorio remoto, preservados.

## Documentos principais

- [Project Overview](docs/00_Project/project-overview.md)
- [Visual Development Guide](docs/03_VisualDevelopment/visual-development-guide.md)
- [Pixel Art Bible](docs/03_VisualDevelopment/pixel-art-bible.md)
- [Character Image Prompts](docs/03_VisualDevelopment/character-image-prompts.md)
- [Character DNA](docs/04_Characters/character-dna.md)
- [Animation Bible](docs/06_Animation/animation-bible.md)
- [Unity Production Pipeline](docs/08_UnityPipeline/unity-production-pipeline.md)
- [Unity Base Project Setup](docs/08_UnityPipeline/unity-base-project-setup.md)
- [Production Handbook](production/production-handbook.md)
- [Roadmap](production/roadmap.md)
- [AI-Assisted Production Pipeline](production/ai-assisted-production-pipeline.md)
- [Vertical Slice Plan](production/vertical-slice-plan.md)

## Escopo inicial

O primeiro objetivo de producao e um vertical slice com:

- Era Zero e Egito Antigo.
- Theo jogavel.
- Movimento basico, camera e leitura de plataforma.
- Combate basico.
- Um inimigo simples.
- Sistema de vida e dano.
- Tileset inicial.
- Prefabs modulares quando o projeto Unity existir.

## Unity

O projeto Unity ainda nao deve ser simulado por arquivos falsos. Quando for criado, ele deve ficar em:

`unity/FragmentosDoAmanha/`

A estrutura esperada para o projeto Unity esta documentada em [Unity Production Pipeline](docs/08_UnityPipeline/unity-production-pipeline.md).

## Uso de IA

A IA deve atuar como assistente de producao, nao como diretora criativa. Ela pode apoiar pesquisa, documentacao, concepts, variacoes, sprites base, poses-chave, scripts e revisao de pipeline. A validacao final permanece manual.
