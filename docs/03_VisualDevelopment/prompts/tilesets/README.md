# Tileset Prompts (arquivos individuais)

Cada `.txt` aqui e um prompt pronto, sem placeholder, pra colar ou anexar direto no ChatGPT. Mesmo conteudo documentado em `docs/03_VisualDevelopment/tileset-image-prompts.md`, so que separado em arquivo por tile pra facilitar envio em lote.

- `era-zero-ground.txt`, `era-zero-platform.txt`, `era-zero-wall.txt`, `era-zero-border.txt`
- `egypt-ground.txt`, `egypt-platform.txt`, `egypt-wall.txt`, `egypt-border.txt`

Salve cada imagem gerada de volta em `art/pixel/environments/<epoca>/`, avise no chat com o nome do arquivo, e o `asset-index.md` correspondente e o `roadmap.md` sao atualizados.

Se pedir mais arte no futuro (props, sprites, FX), o mesmo padrao se aplica: um arquivo de prompt por asset, numa subpasta nova aqui dentro de `docs/03_VisualDevelopment/prompts/`.
