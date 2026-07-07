# Asset Pipeline
## Fragmentos do Amanhã / Era Zero

Fluxo de produção de assets para arte, animação e integração.

---

## 1. Fluxo geral

```txt
Briefing
↓
Concept
↓
Sprite test
↓
Aprovação de estilo
↓
Sprite final
↓
Animação
↓
Exportação
↓
Importação Unity
↓
Teste em cena
↓
Prefab final
```

---

## 2. Etapas

### Briefing

Definir:

- função do asset;
- época;
- personagem/inimigo/cenário;
- escala;
- animações necessárias;
- referências internas;
- restrições técnicas.

### Concept

Pode ser mais detalhado que o sprite final, desde que o artista saiba o que será simplificado.

### Sprite test

Criar um sprite único em escala real para validar leitura.

### Sprite final

Aplicar paleta final, outline, sombra e pivô.

### Animação

Criar frames mantendo consistência de volume e proporção.

### Exportação

Exportar em PNG sem compressão, sem blur e com fundo transparente.

### Importação Unity

Configurar como sprite, point filter, compression none.

### Teste em cena

Testar em ambiente real, com câmera, iluminação e cenário.

---

## 3. Controle de versão

Cada asset deve ter versão:

- v01: primeira versão utilizável;
- v02: ajustes após teste;
- final: somente quando aprovado para produção.

Evitar sobrescrever arquivos sem histórico.

---

## 4. Critérios de aprovação

Um asset está aprovado quando:

- cumpre função de gameplay;
- segue estilo visual;
- funciona na escala correta;
- está nomeado corretamente;
- foi testado dentro do Unity;
- não depende de ajustes manuais não documentados.

