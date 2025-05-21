# VIDEOJUEGO PONTE A CONDUCIR

Ponte a Conducir es un videojuego desarrollado en Unity (2D) como proyecto del tercer trimestre de PMDM. El objetivo del juego es conducir una ambulancia a través de un circuito con peatones, conos en medio, cumplir objetivos y evitar atropellar peatones. 

## Objetivo del proyecto: 

Desarrollar un videojuego funcional en Unity que demuestre las habilidades adquiridas, incluyendo:

- Programación de mecánicas básicas.
- Elementos visuales y de sonido.
- Mecánicas e interacción entre elementos.
- Escenas y UI.
- Integración de audio y animaciones.
- Estructura clara y organizada de escenas.
  
## Requisitos Técnicos:
- **Mecánicas del Juego**:
  - Movimiento de las personas: se desplazan automáticamente a través del circuito.
  - Movimiento de la ambulancia: el jugador es el que la maneja a través del circuito con la finalidad de conseguir los objetivos propuestos, sin atropellar a ninguna de las personas que circulan.

- **Implementación de interacción entre elementos**: 
  - colisiones con árboles y lago que no permiten proseguir (bloquean el paso). 
  - conos, que se pueden arrastrar. 
  - colisión con las personas, que acaban muertas y con ellas el fin del juego.
  - triggers:
    - bordes: al pasar por el césped, activan efectos sonoros.
    - paradas: activan las medallas y activan la Pantalla de Victoria.
    - chocar con la persona: activa la pantalla de Game Over
  
- **Animaciones**:
  - Movimiento de las personas a través del circuito. 
  - Efectos de muerte en caso de colisión.
  - Cambio de sentido del personaje.
  
- **Escenas y UI**:
  - Escenas principales: 
    - Pantalla de Inicio.
    - Pantalla Principal del juego.
    - Pantalla de Victoria.
    - Pantalla de Game Over.
  
  - Elementos de UI: 
    - Consecución de medallas al conseguir llegar a una parada.
    - Texto informativo de objetivos a alcanzar que se actualiza al conseguir alguno.
    - Botón de pausa/reinicio.

- **Ajustes del juego**: 
    - Modificación de la velocidad de la ambulancia en ajustes.
    - Pausa/reinicio del juego.

- **Sonido y Música**:
  - Música de fondo sin copyright: durante el juego, ruido del motor, al pasar por el césped.
  - Efectos de sonido: al chocar con una persona.