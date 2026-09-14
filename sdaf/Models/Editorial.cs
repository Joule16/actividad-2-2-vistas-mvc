//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Text;

namespace SistemaBiblioteca1.Models
{
    public class Editorial
    {
        private int idEditorial;
        private string nombre;
        private string paisOrigen;
        private double anioFundacion;
        private bool estado;

        public int IdEditorial
        {
            get { return idEditorial; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idEditorial = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la editorial no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string PaisOrigen
        {
            get { return paisOrigen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El país de origen no puede estar vacío.");
                paisOrigen = value.Trim();
            }
        }

        public double AnioFundacion
        {
            get { return anioFundacion; }
            set
            {
                if (value < 1400 || value > DateTime.Now.Year)
                    throw new ArgumentException("El año de fundación no es válido.");
                anioFundacion = value;
            }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Editorial()
        {
            idEditorial = 0;
            nombre = string.Empty;
            paisOrigen = string.Empty;
            anioFundacion = DateTime.Now.Year;
            estado = false;
        }

        public Editorial(int idEditorial, string nombre, string paisOrigen,
                          int anioFundacion, bool estado)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
            PaisOrigen = paisOrigen;
            AnioFundacion = anioFundacion;
            Estado = estado;
        }

        public double CalcularAntiguedad()
        {
            return CalcularAntiguedad(DateTime.Now.Year);
        }

        public double CalcularAntiguedad(double anioReferencia)
        {
            if (anioReferencia < anioFundacion)
                throw new ArgumentException("El año de referencia no puede ser anterior a la fundación.");
            return anioReferencia - anioFundacion;
        }

        public override string ToString()
        {
            return $"Editorial #{idEditorial}: {nombre} | País: {paisOrigen} | " +
                   $"Antigüedad: {CalcularAntiguedad()} años | Estado: {(estado ? "Activa" : "Inactiva")}";
        }
    }
}