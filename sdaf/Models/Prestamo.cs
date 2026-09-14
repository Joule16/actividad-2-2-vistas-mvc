//Suñiga Maciel Joule Alexander
//Villa Olivarez Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca1.Models
{
    public class Prestamo
    {
        private int idPrestamo;
        private int idUsuario;
        private int idEjemplar;
        private DateTime fechaPrestamo;
        private DateTime fechaLimite;
        private DateTime? fechaDevolucionReal;
        private bool devuelto;
        private bool estado;

        public int IdPrestamo
        {
            get { return idPrestamo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idPrestamo = value;
            }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un usuario válido.");
                idUsuario = value;
            }
        }

        public int IdEjemplar
        {
            get { return idEjemplar; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse un ejemplar válido.");
                idEjemplar = value;
            }
        }

        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }

        public DateTime FechaLimite
        {
            get { return fechaLimite; }
            set
            {
                if (value.Date < fechaPrestamo.Date)
                    throw new ArgumentException("La fecha límite no puede ser anterior a la fecha de préstamo.");
                fechaLimite = value;
            }
        }

        public DateTime? FechaDevolucionReal
        {
            get { return fechaDevolucionReal; }
            set { fechaDevolucionReal = value; }
        }

        public bool Devuelto
        {
            get { return devuelto; }
            set
            {
                devuelto = value;
                if (devuelto && !fechaDevolucionReal.HasValue)
                {
                    fechaDevolucionReal = DateTime.Now;
                }
                else if (!devuelto)
                {
                    fechaDevolucionReal = null;
                }
            }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Prestamo()
        {
            idPrestamo = 0;
            idUsuario = 0;
            idEjemplar = 0;
            fechaPrestamo = DateTime.Now;
            fechaLimite = DateTime.Now;
            fechaDevolucionReal = null;
            devuelto = false;
            estado = false;
        }

        public Prestamo(int idPrestamo, int idUsuario, int idEjemplar, DateTime fechaPrestamo,
                         DateTime fechaLimite, bool estado)
        {
            IdPrestamo = idPrestamo;
            IdUsuario = idUsuario;
            IdEjemplar = idEjemplar;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            fechaDevolucionReal = null;
            devuelto = false;
            Estado = estado;
        }

        public int CalcularDiasRetraso()
        {
            DateTime fechaComparacion = fechaDevolucionReal ?? DateTime.Now;
            return CalcularDiasRetraso(fechaComparacion);
        }

        public int CalcularDiasRetraso(DateTime fechaDevolucion)
        {
            TimeSpan diferencia = fechaDevolucion.Date - fechaLimite.Date;
            return diferencia.Days > 0 ? diferencia.Days : 0;
        }

        public void RegistrarDevolucion(DateTime fecha)
        {
            if (fecha.Date < fechaPrestamo.Date)
                throw new ArgumentException("La fecha de devolución no puede ser anterior al préstamo.");
            fechaDevolucionReal = fecha;
            devuelto = true;
        }

        public override string ToString()
        {
            string devolucionTexto = fechaDevolucionReal.HasValue
                ? fechaDevolucionReal.Value.ToShortDateString()
                : "Pendiente";
            return $"Préstamo #{idPrestamo} | Usuario #{idUsuario} | Ejemplar #{idEjemplar} | " +
                   $"Límite: {fechaLimite:d} | Devolución: {devolucionTexto} | Retraso: {CalcularDiasRetraso()} días";
        }
    }
}