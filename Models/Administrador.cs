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
    public class Administrador
    {
        private int idAdministrador;
        private string nombre;
        private string apellido;
        private string usuarioAcceso;
        private string contrasena;
        private int nivelAcceso;
        private bool estado;

        public int IdAdministrador
        {
            get { return idAdministrador; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idAdministrador = value;
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

        public string UsuarioAcceso
        {
            get { return usuarioAcceso; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 4)
                    throw new ArgumentException("El usuario de acceso debe tener al menos 4 caracteres.");
                usuarioAcceso = value.Trim();
            }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                    throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
                contrasena = value;
            }
        }

        public int NivelAcceso
        {
            get { return nivelAcceso; }
            set
            {
                if (value < 1 || value > 3)
                    throw new ArgumentException("El nivel de acceso debe estar entre 1 y 3.");
                nivelAcceso = value;
            }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Administrador()
        {
            idAdministrador = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            usuarioAcceso = string.Empty;
            contrasena = string.Empty;
            nivelAcceso = 1;
            estado = false;
        }

        public Administrador(int idAdministrador, string nombre, string apellido, string usuarioAcceso,
                      string contrasena, int nivelAcceso, bool estado)
        {
            IdAdministrador = idAdministrador;
            Nombre = nombre;
            Apellido = apellido;
            UsuarioAcceso = usuarioAcceso;
            Contrasena = contrasena;
            NivelAcceso = nivelAcceso;
            Estado = estado;
        }

        public bool TienePermiso()
        {
            return TienePermiso(3);
        }

        public bool TienePermiso(int nivelRequerido)
        {
            return Estado && nivelAcceso >= nivelRequerido;
        }

        public override string ToString()
        {
            return $"Administrador #{idAdministrador}: {nombre} {apellido} | Usuario: {usuarioAcceso} | " +
                   $"Nivel: {nivelAcceso} | Estado: {(estado ? "Activo" : "Inactivo")}";
        }
    }
}
