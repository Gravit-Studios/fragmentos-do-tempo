# Pixel Art Bible

## Objetivo

Definir regras iniciais para que sprites, tilesets, FX e UI mantenham consistencia visual e sejam viaveis para animacao em uma producao independente.

## Documentos De Apoio

- docs/03_VisualDevelopment/sprite-prompt-guide.md - guia operacional para prompts de sprites, tiles e ciclo de corrida.
- docs/03_VisualDevelopment/tileset-image-prompts.md - prompts oficiais de tilesets por era.
- docs/03_VisualDevelopment/character-image-prompts.md - prompts de personagens em concept art e pixel art.

## Padroes iniciais

- **Personagem base:** canvas sugerido de 64x96 px.
- **PPU sugerido:** 32.
- **Tile grid:** 32x32 px.
- **Luz:** superior esquerda, aproximadamente 45 graus.
- **Outline:** colorido e contextual, evitando preto puro.
- **Dithering:** moderado.
- **Detalhe:** nunca deve competir com animacao.

## Prioridades

1. Silhueta.
2. Leitura em movimento.
3. Contraste funcional.
4. Animabilidade.
5. Consistencia de paleta.
6. Detalhe secundario.

## Personagens

Sprites de personagens devem ser criados primeiro como pose neutra legivel, depois como poses-chave. Antes de animar, validar:

- Altura visual relativa.
- Centro de massa.
- Volume de cabeca, tronco e membros.
- Elementos recorrentes do personagem.
- Cores que precisam ser preservadas em todas as epocas.

## Tilesets

Tilesets devem ser planejados por funcao:

- Chao principal.
- Plataformas.
- Paredes.
- Bordas.
- Props de leitura.
- Props narrativos.
- Elementos destrutiveis ou interativos.
- Elementos de fundo sem colisao.

Cada tileset deve ter uma versao minima para prototipo antes de receber detalhes finais.

## Paleta

Cada epoca deve ter:

- Paleta de ambiente.
- Paleta de inimigos.
- Paleta de Theo adaptado.
- Paleta de Naiara local.
- Acentos de Voss.
- Acentos de tecnologia temporal.

O cobre/laranja deve ser reservado para tecnologia temporal sempre que possivel. Preto/dourado deve ser usado com cuidado para marcar Voss e sua influencia.

## Outline e contraste

Evitar contorno preto puro como padrao. O outline deve responder ao material e ao ambiente:

- Roxos ou azuis escuros para sombra fria.
- Marrons escuros para materiais naturais.
- Vermelhos escuros para acentos quentes.
- Dourado escuro ou preto suavizado para elementos de Voss.

## Regras de limpeza

- Remover pixels isolados que tremam durante animacao.
- Evitar ruido em areas de pele e rosto.
- Manter clusters claros.
- Testar sempre em escala real de jogo.
- Verificar leitura contra fundo claro e fundo escuro.

## Checklist de sprite pronto

- [ ] Silhueta aprovada em preto solido.
- [ ] Paleta limitada e registrada.
- [ ] Luz consistente.
- [ ] Outline contextual.
- [ ] Sem detalhe excessivo nas articulacoes.
- [ ] Funciona parado e em movimento.
- [ ] Exportado com escala e pivot documentados.
