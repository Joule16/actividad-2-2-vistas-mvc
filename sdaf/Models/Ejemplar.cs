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
    public class Ejemplar
    {
        private int idEjemplar;
        private int idLibro;
        private string codigoInventario;
        private string condicion;
        private bool disponible;
        private bool estado;

        public int IdEjemplar
        {
            get { return idEjemplar; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idEjemplar = value;
            }
        }

        public int IdLibro
        {
            get { return idLibro; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un libro válido.");
                idLibro = value;
            }
        }

        public string CodigoInventario
        {
            get { return codigoInventario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length > 12)
                    throw new ArgumentException("El código de inventario no puede estar vacío ni exceder 12 caracteres.");
                codigoInventario = value.Trim();
            }
        }

        public string Condicion
        {
            get { return condicion; }
            set
            {
                string v = (value ?? string.Empty).Trim();
                if (v != "Nuevo" && v != "Bueno" && v != "Regular" && v != "Dañado")
                    throw new ArgumentException("La condición debe ser: Nuevo, Bueno, Regular o Dañado.");
                condicion = v;
            }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Ejemplar()
        {
            idEjemplar = 0;
            idLibro = 0;
            codigoInventario = string.Empty;
            condicion = "Nuevo";
            disponible = true;
            estado = false;
        }

        public Ejemplar(int idEjemplar, int idLibro, string codigoInventario, string condicion,
                         bool disponible, bool estado)
        {
            IdEjemplar = idEjemplar;
            IdLibro = idLibro;
            CodigoInventario = codigoInventario;
            Condicion = condicion;
            Disponible = disponible;
            Estado = estado;
        }

        public double CalcularPorcentajePenalizacion()
        {
            switch (condicion)
            {
                case "Nuevo":
                case "Bueno":
                    return 0.0;
                case "Regular":
                    return 0.20;
                case "Dañado":
                    return 0.75;
                default:
                    return 0.0;
            }
        }

        public double CalcularPorcentajePenalizacion(double tarifaRegular, double tarifaDanado)
        {
            switch (condicion)
            {
                case "Regular":
                    return tarifaRegular;
                case "Dañado":
                    return tarifaDanado;
                default:
                    return 0.0;
            }
        }

        public override string ToString()
        {
            return $"Ejemplar #{idEjemplar} (Libro #{idLibro}) | Código: {codigoInventario} | " +
                   $"Condición: {condicion} | Disponible: {disponible} | Estado: {(estado ? "Activo" : "Inactivo")}";
        }
    }
}