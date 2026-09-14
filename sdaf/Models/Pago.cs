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
    public class Pago
    {
        private int idPago;
        private int idSancion;
        private double monto;
        private DateTime fechaPago;
        private string metodoPago;
        private bool estado;

        public int IdPago
        {
            get { return idPago; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id no puede ser negativo.");
                idPago = value;
            }
        }

        public int IdSancion
        {
            get { return idSancion; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe asignarse una sanción válida.");
                idSancion = value;
            }
        }

        public double Monto
        {
            get { return monto; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El monto del pago debe ser mayor a cero.");
                monto = value;
            }
        }

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }

        public string MetodoPago
        {
            get { return metodoPago; }
            set
            {
                string v = (value ?? string.Empty).Trim();
                if (v != "Efectivo" && v != "Tarjeta" && v != "Transferencia")
                    throw new ArgumentException("El método de pago debe ser: Efectivo, Tarjeta o Transferencia.");
                metodoPago = v;
            }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Pago()
        {
            idPago = 0;
            idSancion = 0;
            monto = 0.0;
            fechaPago = DateTime.Now;
            metodoPago = "Efectivo";
            estado = false;
        }

        public Pago(int idPago, int idSancion, double monto, string metodoPago, bool estado)
        {
            IdPago = idPago;
            IdSancion = idSancion;
            Monto = monto;
            FechaPago = DateTime.Now;
            MetodoPago = metodoPago;
            Estado = estado;
        }

        public bool CubreSancion(double montoSancion)
        {
            return CubreSancion(montoSancion, 0.0);
        }

        public bool CubreSancion(double montoSancion, double descuento)
        {
            double montoConDescuento = montoSancion - descuento;
            if (montoConDescuento < 0)
                montoConDescuento = 0;
            return monto >= montoConDescuento;
        }

        public override string ToString()
        {
            return $"Pago #{idPago} | Sanción #{idSancion} | Monto: ${monto:0.00} | " +
                   $"Método: {metodoPago} | Fecha: {fechaPago:d} | Estado: {(estado ? "Activo" : "Inactivo")}";
        }
    }
}