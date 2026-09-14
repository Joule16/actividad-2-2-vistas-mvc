# SistemaBiblioteca1
Sistema de préstamo de libros - Actividad 2.1 Modelos

# Integrantes
//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2

## Descripción del proyecto
Sistema de gestión de préstamos de libros para una biblioteca escolar,
desarrollado en C# con Windows Forms siguiendo el patrón de arquitectura MVC.

El sistema controla el préstamo de ejemplares a usuarios, aplicando sanciones
automáticas por retrasos o daños en la devolución. Un usuario que acumula 5
sanciones queda baneado permanentemente. Las cuentas sancionadas se reactivan
al cumplirse el tiempo de desactivación, o antes si el usuario paga la multa
correspondiente.

Esta actividad se enfoca exclusivamente en la capa de Modelo (Model): 10
clases de entidad (Usuario, Administrador, Libro, Autor, Categoria, Editorial,
Ejemplar, Prestamo, Sancion, Pago) con encapsulamiento, constructores
sobrecargados, propiedades con validación, métodos de negocio sobrecargados
y ToString().

## Cómo ejecutar las pruebas
1. Abrir el archivo SistemaBiblioteca1.sln con Visual Studio.
2. Presionar F5 (o el botón Iniciar) para compilar y ejecutar el proyecto.
3. Al arrancar, se abre automáticamente la ventana Resultados de Pruebas
   Sistema Biblioteca, que muestra:
   - Creación de un usuario con datos válidos.
   - Intento de creación de un usuario con datos inválidos (excepción capturada).
   - Cálculo de días de retraso de un préstamo.
   - Cálculo del porcentaje de penalización de un ejemplar dañado.
   - Generación y recálculo de una sanción.
   - Acumulación de sanciones hasta alcanzar el baneo (regla de 5 sanciones).
   - Registro de un pago y verificación de cobertura de una sanción.

## Estructura del proyecto

SistemaBiblioteca1
├── Program.cs
├── Form1.cs
├── FrmPruebas.cs          (formulario con las pruebas de los modelos)
└── Models
    ├── Usuario.cs
    ├── Administrador.cs
    ├── Autor.cs
    ├── Categoria.cs
    ├── Editorial.cs
    ├── Libro.cs
    ├── Ejemplar.cs
    ├── Prestamo.cs
    ├── Sancion.cs
    └── Pago.cs
