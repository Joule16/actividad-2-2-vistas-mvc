//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca1.Models
{
    public class Autor
    {
        private int idAutor;
        private string nombre;
        private string apellido;
        private string nacionalidad;
        private DateTime fechaNacimiento;
        private string imagen;
        private bool estado;

        public int IdAutor
        {
            get { return idAutor; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El ID no puede ser negativo.");
                idAutor = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                apellido = value.Trim();
            }
        }

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La nacionalidad no puede estar vacía.");
                nacionalidad = value.Trim();
            }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("La fecha de nacimiento no puede ser una fecha futura.");
                fechaNacimiento = value;
            }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Autor()
        {
            idAutor = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            nacionalidad = string.Empty;
            imagen = string.Empty;
            fechaNacimiento = DateTime.Now;
            estado = false;
        }

        public Autor(int idAutor, string nombre, string apellido, string nacionalidad, DateTime fechaNacimiento, bool estado)
        {
            IdAutor = idAutor;
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
            Estado = estado;
        }

        public int CalcularEdad()
        {
            return CalcularEdad(DateTime.Now);
        }

        public int CalcularEdad(DateTime fechaReferencia)
        {
            int edad = fechaReferencia.Year - fechaNacimiento.Year;
            if (fechaReferencia < fechaNacimiento.AddYears(edad))
                edad--;
            return edad;
        }

        public override string ToString()
        {
            return $"Autor #{idAutor}: {nombre} {apellido} | Nacionalidad: {nacionalidad} | " +
                   $"Edad: {CalcularEdad()} años | Estado: {(estado ? "Activo" : "Inactivo")}";
        }
    }
}