//Suñiga Maciel Joule Alexander 
//Villa Olivares Ariel 
//Nuñes Martinez Marco Antonio 
//Equipo 2 
//============================= 
using System; 
using System.Collections.Generic; 
using System.Security.Cryptography.Pkcs; 
using System.Text; 
 
namespace SistemaBiblioteca1.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string apellido;
        private string email;
        private string telefono;
        private string idUniversitario;
        private DateTime fechaRegistro;
        private int contadorSanciones;
        private bool estaBaneado;
        private bool estado;

        private const int LIMITE_SANCIONES_BANEO = 5;

        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id de usuario no puede ser negativo.");
                idUsuario = value;
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

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                    throw new ArgumentException("El correo electrónico no tiene un formato válido.");
                email = value.Trim();
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length != 10)
                    throw new ArgumentException("El teléfono debe contener 10 dígitos.");
                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                        throw new ArgumentException("El teléfono solo debe contener números.");
                }
                telefono = value.Trim();
            }
        }

        public string IdUniversitario
        {
            get { return idUniversitario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El id universitario no puede estar vacío.");
                idUniversitario = value.Trim();
            }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public int ContadorSanciones
        {
            get { return contadorSanciones; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El contador de sanciones no puede ser negativo.");
                contadorSanciones = value;
            }
        }

        public bool EstaBaneado
        {
            get { return estaBaneado; }
            set { estaBaneado = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Usuario()
        {
            idUsuario = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            email = string.Empty;
            telefono = string.Empty;
            idUniversitario = string.Empty;
            fechaRegistro = DateTime.Now;
            contadorSanciones = 0;
            estaBaneado = false;
            estado = false;
        }

        public Usuario(int idUsuario, string nombre, string apellido, string email,
                        string telefono, string idUniversitario, bool estado)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            IdUniversitario = idUniversitario;
            FechaRegistro = DateTime.Now;
            ContadorSanciones = 0;
            EstaBaneado = false;
            Estado = estado;
        }

        public void RegistrarSancion()
        {
            RegistrarSancion(1, LIMITE_SANCIONES_BANEO);
        }

        public void RegistrarSancion(int cantidadASumar, int limiteBaneo)
        {
            if (cantidadASumar <= 0)
                throw new ArgumentException("La cantidad a sumar debe ser mayor a cero.");

            ContadorSanciones += cantidadASumar;

            if (ContadorSanciones >= limiteBaneo)
            {
                EstaBaneado = true;
                Estado = false;
            }
        }

        public bool PuedeSolicitarPrestamo()
        {
            return Estado && !EstaBaneado;
        }

        public bool PuedeSolicitarPrestamo(int prestamosActivos, int limitePrestamos)
        {
            return PuedeSolicitarPrestamo() && prestamosActivos < limitePrestamos;
        }

        public override string ToString()
        {
            return $"Usuario #{idUsuario}: {nombre} {apellido} | ID Universitario: {idUniversitario} | " +
                   $"Email: {email} | Sanciones: {contadorSanciones} | Baneado: {estaBaneado} | " +
                   $"Estado: {(estado ? "Activo" : "Inactivo")}";
        }
    }
}