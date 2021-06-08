using EjPrestamo.Entidades.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Entidades.Dominio
{
    public class Operador
    {
        private List<Prestamo> _prestamos;
        private double _comision;
        private double _porcentajeComision;

        public Operador()
        {
            this._prestamos = new List<Prestamo>();
        }

        public List<Prestamo> Prestamos { get => _prestamos; set => _prestamos = value; }
        public double Comision { get => _comision; set => _comision = value; }
        public double PorcentajeComision { get => _porcentajeComision; set => _porcentajeComision = value; }


    }
}
