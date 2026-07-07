# Unity Export Pipeline
## Fragmentos do Amanhã / Era Zero

Pipeline recomendado para levar sprites, animações, cenários e UI para Unity.

---

## 1. Configuração inicial do projeto

Recomendação:

- Unity 2D URP ou Unity 2D Built-in, a decidir após teste;
- Pixel Perfect Camera;
- Tilemap para cenários;
- Cinemachine para câmera;
- 2D Animation apenas se o projeto optar por rigging em alguns elementos;
- Input System novo para controle moderno.

---

## 2. Configurações de importação de sprite

Para cada sprite:

- Texture Type: Sprite (2D and UI);
- Sprite Mode: Multiple para sprite sheets;
- Pixels Per Unit: conforme decisão do projeto;
- Filter Mode: Point (no filter);
- Compression: None;
- Generate Mip Maps: Off;
- Max Size: suficiente para manter o arquivo sem redução.

---

## 3. Organização de pastas no Unity

Estrutura recomendada:

```txt
Assets/
├── Art/
│   ├── Characters/
│   ├── Enemies/
│   ├── NPCs/
│   ├── Tilesets/
│   ├── Props/
│   ├── FX/
│   └── UI/
├── Animations/
│   ├── Characters/
│   ├── Enemies/
│   └── FX/
├── Prefabs/
│   ├── Characters/
│   ├── Enemies/
│   ├── Items/
│   └── Level/
├── Scenes/
├── Scripts/
├── ScriptableObjects/
├── Audio/
└── Settings/
```

---

## 4. Nomeação de assets

Padrão recomendado:

`categoria_personagem_epoca_animacao_versao`

Exemplos:

- `char_theo_egypt_idle_v01.png`
- `char_theo_egypt_run_v01.png`
- `char_naiara_egypt_portrait_angry_v01.png`
- `enemy_guard_egypt_idle_v01.png`
- `tileset_egypt_temple_v01.png`
- `fx_time_fragment_collect_v01.png`

---

## 5. Pivôs

Todos os sprites humanoides devem usar pivô padronizado nos pés.

Recomendação:

- pivot X: centro do corpo;
- pivot Y: base dos pés;
- manter alinhamento entre todos os frames.

---

## 6. Sorting Layers

Sugestão inicial:

1. Background Far
2. Background Mid
3. Background Near
4. Level Back
5. Gameplay
6. Characters
7. Enemies
8. Projectiles
9. FX
10. Foreground
11. UI World
12. UI Screen

---

## 7. Tilemaps

Separar tilemaps por função:

- Ground Collision;
- Platforms;
- Decoration Back;
- Decoration Front;
- Hazards;
- One Way Platforms;
- Interactive.

Colisão nunca deve depender de tiles decorativos.

---

## 8. Prefab do player

O prefab do Theo deve ser modular:

- controlador de movimento;
- sistema de combate;
- detector de chão;
- sprite renderer;
- animator;
- hitbox controller;
- hurtbox;
- equipamento atual;
- sistema de habilidade;
- sistema temporal.

---

## 9. Vertical slice técnico

Antes de produzir todas as épocas, validar:

- escala do personagem;
- PPU;
- câmera pixel perfect;
- tilemap;
- colisões;
- animações básicas;
- ataque;
- inimigo simples;
- coleta de fragmento;
- transição de área;
- UI mínima.

---

## 10. Checklist de importação

Todo asset importado deve passar por:

- sem blur;
- escala correta;
- pivô correto;
- nome correto;
- pasta correta;
- animação testada em cena;
- sorting layer correta;
- prefab criado quando necessário.

