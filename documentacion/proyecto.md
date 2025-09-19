# Proyecto de Gestión de Campeonato de Fútbol

## Descripción General

Este proyecto es una aplicación MAUI (Multi-platform App UI) desarrollada para gestionar campeonatos de fútbol. Permite administrar equipos, jugadores, partidos y clasificaciones de una manera intuitiva y eficiente.

## Estructura del Proyecto

### Modelos (`Models/`)
- **ObservableObject**: Clase base que implementa `INotifyPropertyChanged` para la actualización de la interfaz.
- **Championship**: Representa el campeonato con sus equipos y grupos.
- **Team**: Contiene la información del equipo, incluyendo:
  - Nombre y descripción
  - Logo
  - Lista de jugadores
  - Delegado del equipo
  - Estadísticas (puntos, goles, etc.)
- **Player**: Información del jugador (DNI, nombre, número, etc.)
- **Delegate**: Información del delegado del equipo
- **Match**: Representa un partido con:
  - Equipos local y visitante
  - Fecha y lugar
  - Marcador
  - Goles y tarjetas
- **RegistrationPayment**: Gestión de pagos de inscripción

### Vistas (`Views/`)
1. **PaginaPrincipal**: Página de inicio con acceso a todas las funciones.
2. **PaginaEquipos**: Lista de equipos participantes.
3. **PaginaRegistroEquipo**: Formulario para registrar nuevos equipos.
4. **PaginaDetalleEquipo**: Detalles de un equipo específico.
5. **PaginaPartidos**: Calendario y resultados de partidos.
6. **PaginaClasificacion**: Tabla de posiciones.
7. **PaginaPago**: Gestión de pagos de inscripción.

### ViewModels (`ViewModels/`)
Cada vista tiene su correspondiente ViewModel que implementa la lógica de negocio:
- **PaginaPrincipalViewModel**: Navegación principal.
- **PaginaEquiposViewModel**: Gestión de la lista de equipos.
- **PaginaRegistroEquipoViewModel**: Lógica para registro de equipos.
- **PaginaDetalleEquipoViewModel**: Manejo de detalles y jugadores.
- **PaginaPartidosViewModel**: Gestión de partidos y resultados.
- **PaginaClasificacionViewModel**: Cálculo y visualización de la tabla.
- **PaginaPagoViewModel**: Procesamiento de pagos.

## Características Principales

### Gestión de Equipos
- Registro de nuevos equipos
- Asignación de delegados
- Gestión de plantilla de jugadores
- Carga de logos de equipo

### Gestión de Partidos
- Programación de encuentros
- Registro de resultados
- Control de goles y tarjetas
- Actualización automática de estadísticas

### Sistema de Clasificación
- Tabla de posiciones actualizada
- Estadísticas por equipo
- Diferencia de goles
- Puntos acumulados

### Sistema de Pagos
- Registro de pagos de inscripción
- Múltiples métodos de pago
- Verificación de pagos
- Historial de transacciones

## Tecnologías Utilizadas
- **.NET MAUI**: Framework de desarrollo multiplataforma
- **C#**: Lenguaje de programación principal
- **XAML**: Lenguaje de marcado para interfaces
- **MVVM**: Patrón de diseño Model-View-ViewModel

## Seguridad y Validación
- Validación de datos en formularios
- Verificación de DNI y números de contacto
- Control de acceso a funciones administrativas
- Protección de datos sensibles

## Interfaz de Usuario
- Diseño intuitivo y responsive
- Navegación fluida entre páginas
- Feedback visual para acciones del usuario
- Soporte para temas claro/oscuro

## Mejores Prácticas Implementadas
1. **Arquitectura MVVM**
   - Separación clara de responsabilidades
   - Código mantenible y testeable
   - Reutilización de componentes

2. **Compiled Bindings**
   - Mejor rendimiento en tiempo de ejecución
   - Detección temprana de errores
   - Optimización de recursos

3. **Null Safety**
   - Uso de tipos que no aceptan valores nulos
   - Manejo explícito de casos nulos
   - Prevención de excepciones en tiempo de ejecución

4. **Patrones de Diseño**
   - Observable para actualizaciones de UI
   - Command para acciones de usuario
   - Navigation Service para gestión de rutas

## Estado Actual del Proyecto
El proyecto se encuentra en fase de desarrollo con las siguientes funcionalidades implementadas:
- ✅ Estructura básica MVVM
- ✅ Modelos de datos principales
- ✅ Interfaces de usuario base
- ✅ Navegación entre páginas
- ✅ Gestión básica de equipos y jugadores
- ✅ Sistema de clasificación

## Próximos Pasos
1. Implementar persistencia de datos
2. Añadir autenticación de usuarios
3. Mejorar la gestión de partidos
4. Implementar notificaciones
5. Agregar reportes y estadísticas avanzadas