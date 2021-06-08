using EjPrestamo.Datos;
using EjPrestamo.Entidades.Dominio;
using EjPrestamo.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Negocio
{
    public class PrestamoNegocio
    {
        PrestamoMapper _prestamoMapper;
        Operador _operador;
        List<Prestamo> _listaPrestamos;

        public PrestamoNegocio()
        {
            this._prestamoMapper = new PrestamoMapper();
            this._listaPrestamos = new List<Prestamo>();
            this._operador = new Operador();
        }

        public Operador Traer()
        {
            this._operador.Prestamos = TraerPrestamos();
            this._operador.PorcentajeComision = 15;
            this._operador.Comision = CalcularComision();
            return this._operador;
        }

        private double CalcularComision()
        {
           double comisionTotal = 0;
           foreach (Prestamo prestamo in this._operador.Prestamos)
            {
                comisionTotal = comisionTotal + prestamo.CuotaInteres * prestamo.Plazo;
            }
            return comisionTotal;
        }

        private List<Prestamo> TraerPrestamos()
        {
            this._listaPrestamos = this._prestamoMapper.TraerTodos();
            return this._listaPrestamos;
        }
        public ResultadoTransaccion Agregar (Prestamo prestamo)
        {
            ResultadoTransaccion resultado = this._prestamoMapper.Agregar(prestamo);
            return resultado;
        }

    }
}
