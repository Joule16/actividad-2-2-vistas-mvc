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
    public class Libro
    {
        private int idLibro;
        private string titulo;
        private string isbn;
        private int idAutor;
        private int idCategoria;
        private int idEditorial;
        private int anioPublicacion;
        private bool estado;

        public int IdLibro
        {
            get { return idLibro; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idLibro = value;
            }
        }

        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El título no puede estar vacío.");
                titulo = value.Trim();
            }
        }

        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length != 10 && value.Length != 13))
                    throw new ArgumentException("El ISBN debe tener 10 o 13 caracteres.");
                isbn = value.Trim();
            }
        }

        public int IdAutor
        {
            get { return idAutor; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un autor válido.");
                idAutor = value;
            }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse una categoría válida.");
                idCategoria = value;
            }
        }

        public int IdEditorial
        {
            get { return idEditorial; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse una editorial válida.");
                idEditorial = value;
            }
        }

        public int AnioPublicacion
        {
            get { return anioPublicacion; }
            set
            {
                if (value < 1400 || value > DateTime.Now.Year)
                    throw new ArgumentException("El año de publicación no es válido.");
                anioPublicacion = value;
            }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Libro()
        {
            idLibro = 0;
            titulo = string.Empty;
            isbn = string.Empty;
            idAutor = 0;
            idCategoria = 0;
            idEditorial = 0;
            anioPublicacion = DateTime.Now.Year;
            estado = false;
        }

        public Libro(int idLibro, string titulo, string isbn, int idAutor, int idCategoria,
                      int idEditorial, int anioPublicacion, bool estado)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Isbn = isbn;
            IdAutor = idAutor;
            IdCategoria = idCategoria;
            IdEditorial = idEditorial;
            AnioPublicacion = anioPublicacion;
            Estado = estado;
        }

        public int CalcularAntiguedad()
        {
            return CalcularAntiguedad(DateTime.Now.Year);
        }

        public int CalcularAntiguedad(int anioReferencia)
        {
            if (anioReferencia < anioPublicacion)
                throw new ArgumentException("El año de referencia no puede ser anterior a la publicación.");
            return anioReferencia - anioPublicacion;
        }

        public override string ToString()
        {
            return $"Libro #{idLibro}: {titulo} | ISBN: {isbn} | Año: {anioPublicacion} | " +
                   $"Estado: {(estado ? "Disponible en catálogo" : "Dado de baja")}";
        }
    }
}