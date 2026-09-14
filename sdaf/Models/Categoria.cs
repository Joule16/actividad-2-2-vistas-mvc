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
    public class Categoria
    {
        private int idCategoria;
        private string nombre;
        private string descripcion;
        private bool restringidaMenores;
        private bool estado;

        public int IdCategoria
        {
            get { return idCategoria; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idCategoria = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value ?? string.Empty; }
        }

        public bool RestringidaMenores
        {
            get { return restringidaMenores; }
            set { restringidaMenores = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Categoria()
        {
            idCategoria = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            restringidaMenores = false;
            estado = false;
        }

        public Categoria(int idCategoria, string nombre, string descripcion,
                          bool restringidaMenores, bool estado)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
            Descripcion = descripcion;
            RestringidaMenores = restringidaMenores;
            Estado = estado;
        }

        public bool PermiteAcceso(int edadUsuario)
        {
            return PermiteAcceso(edadUsuario, 18);
        }

        public bool PermiteAcceso(int edadUsuario, int edadMinima)
        {
            if (!restringidaMenores)
                return true;
            return edadUsuario >= edadMinima;
        }

        public override string ToString()
        {
            return $"Categoría #{idCategoria}: {nombre} | Restringida: {restringidaMenores} | " +
                   $"Estado: {(estado ? "Activa" : "Inactiva")}";
        }
    }
}