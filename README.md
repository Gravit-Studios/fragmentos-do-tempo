# Fragmentos do Amanha

Documentacao de producao de *Fragmentos do Amanha* / *Era Zero*, um metroidvania 2D de acao-plataforma sobre viagem no tempo, desenvolvido na Unity com apoio de IA em documentacao, arte, animacao, pipeline e programacao.

O objetivo deste repositorio e manter a visao criativa, o planejamento de producao e a futura base Unity organizados desde o inicio, sem misturar material conceitual, arquivos de jogo e entregas de planejamento.

## Visao rapida

Theo, um cientista inicialmente nao-combatente, foge pelo tempo para desfazer o golpe de Voss, seu ex-parceiro, que reescreveu a historia para se tornar um tirano absoluto. Em cada epoca, uma versao da linhagem de Naiara atua como resistencia contra essa tirania.

O jogo usa duas camadas de arte:

- **Artbook e apresentacao:** ilustracoes detalhadas para lore, direcao visual e comunicacao.
- **In-game:** pixel art limpa, legivel, animavel e otimizada para gameplay.

## Estrutura do repositorio

- `unity/FragmentosDoAmanha/` - o projeto Unity real. Tudo que e necessario para o jogo funcionar vive aqui, incluindo sprites/tilesets ja em `Assets/Art/` (mesmo os ainda nao configurados/importados). Nao existe mais uma pasta `art/` separada na raiz -- assets novos (incluindo os gerados por IA) devem ser salvos direto dentro de `unity/FragmentosDoAmanha/Assets/Art/...`.
- `artbook/` - tudo que NAO entra diretamente no jogo: concept art, ilustracao, branding, PDFs do concept book e material de referencia/estudo (inclui `pixel-reference/`, com sheets e crops usados como referencia de pose/estilo, nao como arte final).
- `docs/` - Documentacao viva do projeto, organizada por area de producao.
- `production/` - Planejamento pratico, vertical slice, pipeline com IA e roadmap.
- `GDD.md` - Documento de game design existente, mantido como referencia historica e criativa.
- `game-design/`, `narrativa/`, `personagens/`, `nomes/` - Documentos iniciais ja existentes no repositorio remoto, preservados.

## Documentos principais

- [Codex Project Guide](AGENTS.md)
- [Current Status](production/current-status.md)
- [Project Overview](docs/00_Project/project-overview.md)
- [Visual Development Guide](docs/03_VisualDevelopment/visual-development-guide.md)
- [Concept Book Outline](docs/03_VisualDevelopment/concept-book-outline.md)
- [Concept Book Page Plan](docs/03_VisualDevelopment/concept-book-page-plan.md)
- [Pixel Art Bible](docs/03_VisualDevelopment/pixel-art-bible.md)
- [Character Image Prompts](docs/03_VisualDevelopment/character-image-prompts.md)
- [Environment Image Prompts](docs/03_VisualDevelopment/environment-image-prompts.md)
- [Logo Exploration Prompts](docs/03_VisualDevelopment/logo-exploration-prompts.md)
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
