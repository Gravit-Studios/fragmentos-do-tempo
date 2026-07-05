# Linha Visual — Personagens
*(documento de direção de arte)*

> **✅ ESTILO OFICIAL DEFINIDO** — após testes com moodboard cel-shading duro, techwear semi-realista e referência "Survivor" (ArtStation), o estilo abaixo foi validado com o primeiro concept aprovado do Theo e passa a ser o padrão obrigatório para todos os personagens do projeto.

## Histórico de referências (contexto de decisão)

- **Moodboard Zinkase/Bee Square:** silhueta em primeiro lugar, paleta reduzida, textura implícita na silhueta (não pintada). Testes internos via SVG não atingiram o nível de acabamento desejado.
- **Teste techwear semi-realista:** descartado — render pictórico, gradiente suave, rim light e textura de tecido pintada não combinam com a direção do projeto.
- **Referência "Survivor" (ArtStation):** aproveitado o formato de apresentação (turnaround frente/costas + color script + variações de rosto/acessório), descartado o render pictórico.
- **Concept aprovado do Theo (versão com traço definido):** validou a direção final — contorno forte e definido, shading em blocos, elementos fixos legíveis, paleta de produção documentada.

## Definição de estilo (fechada e aprovada)

| Aspecto | Definição |
|---|---|
| **Contorno** | Linha de contorno forte e definida ao redor de cada forma — não é traço solto nem desfocado. |
| **Shading** | Duro, em blocos — 1-2 tons de sombra por superfície, sem gradiente, sem oclusão ambiental pintada, sem rim light, sem brilho especular. |
| **Nível de detalhe** | Baixo-médio: peças de roupa/equipamento como formas limpas e reconhecíveis. Máximo 1–2 acessórios por área do corpo. |
| **Proporção** | Semi-estilizada: ~6,5–7 cabeças de altura. Nem realista, nem cartoon/chibi. Rosto simplificado mas com estrutura óssea legível (maxilar, sobrancelha). |
| **Paleta** | 4–6 cores por personagem, 1 de destaque/saturada (cor de identidade — cobre para tecnologia), resto neutro e dessaturado. Sempre com barra de "production color" documentada. |
| **Expressão facial** | Contida, séria, resolvida em poucas formas. Atenção: evitar deriva para "carrancudo/hostil" quando o personagem deveria ler como cauteloso/investigativo, não agressivo. |
| **Estrutura de entrega** | Turnaround frente/costas + barra de paleta nomeada (ex: Jacket, Pants, Vest, Boots, Hardware, Copper) + variações de acessório quando fizer sentido. |

**Resumo em uma frase:** *Concept art de personagem estilo jogo, com contorno forte e definido, shading plano em blocos duros, silhueta limpa e paleta documentada — nunca pintura texturizada, nunca traço fofo/cartoon.*

## Prompt-base reutilizável (Gemini / Midjourney)

```
Full character reference sheet, front and back view, standing neutral pose.
Illustration style: bold defined line art / clean flat cel-shading with hard-edged shadows (1-2 tones per surface — base color + shadow tone), no soft gradients, no ambient occlusion painting, no specular highlights, no glossy reflections, no painted fabric texture. Strong, clean outline around every shape.
Proportions: semi-stylized, not realistic and not cartoonish/chibi — approx. 6.5-7 heads tall, believable adult anatomy but simplified, clean facial structure with minimal expression detail (2-3 shapes resolve the face).
Silhouette: bold, clean, easily readable at a distance. Maximum 1-2 accessories per body area, avoid visual clutter of straps, pouches, or loose gear.
Color palette: 4-6 colors total, one saturated accent color as the character's "signature," the rest muted/neutral. Include a labeled flat color swatch bar in the corner (production color script style, e.g. "Jacket / Pants / Vest / Boots / Hardware / Accent").
Overall mood: serious, grounded, adult tone — not shiny, not cute, not overly rendered.
Background: plain flat neutral gray background, no scene, no gradient.
```

> **Dica de produção:** ao gerar os próximos personagens, usar a imagem aprovada do Theo como *image reference* direta (não só o prompt em texto) no Gemini/Midjourney, para herdar o traço e o nível de acabamento exatos, além da descrição.

## Prompts aplicados aos personagens principais

### Theo (protagonista) — APROVADO
```
[ver prompt completo no histórico da conversa — cientista jovem 20-e-poucos anos, postura cautelosa, jaqueta terracota, colete preto, calça verde-azulada, óculos na testa, munhequeira cronométrica tipo relógio, satchel cruzando o peito, botas marrom-couro]
```
Resultado aprovado. Usar como referência de imagem para os próximos personagens.

### Voss (vilão)
```
[ver prompt completo no histórico da conversa — postura imponente ereta, casaco cerimonial vermelho-vinho/preto/dourado, dispositivo cronométrico ostentado no peito, expressão calma e controlada]
```

### Naiara (linhagem)
```
[ver prompt completo no histórico da conversa — postura alerta observadora, traje de época com tom terroso neutro, marca herdada sutil em tom marfim, azul-acinzentado frio como cor base]
```

## Status
- Estilo visual definido e validado com o Theo.
- Próximo passo: gerar Voss e Naiara usando a imagem do Theo como referência visual direta + prompts acima.
- Após os três personagens principais, aplicar a mesma linha visual a cenários e HUD.
