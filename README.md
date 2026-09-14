# Sistema de Préstamo de Libros - Biblioteca

## Actividad 2.2 - Vistas (MVC)
Equipo 2

## Integrantes
- APELLIDO1, Nombre1
- APELLIDO2, Nombre2

## Descripción
Vistas en Windows Forms para nuestro sistema de préstamo de libros de biblioteca. Todo está en FrmPrincipal, con una sección por cada una de las 10 entidades (Usuario, Administrador, Autor, Categoria, Editorial, Libro, Ejemplar, Prestamo, Sancion y Pago). Cada sección tiene sus controles de captura, un botón para procesar los datos, y muestra el resultado junto con los métodos de negocio del modelo (edad calculada, antigüedad, penalización, días de retraso, etc.).

## Cómo ejecutarlo
Abre el `.sln` en Visual Studio y presiona F5. Se abre FrmPrincipal con todas las secciones disponibles.

## Manejo de errores
Cada botón de proceso valida los datos con try/catch: captura ArgumentException (errores de validación del modelo), FormatException (si escriben texto donde va un número) y muestra el mensaje correspondiente en un MessageBox.
