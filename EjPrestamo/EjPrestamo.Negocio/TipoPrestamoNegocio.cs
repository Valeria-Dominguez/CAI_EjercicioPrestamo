using EjPrestamo.Datos;
using EjPrestamo.Entidades.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Negocio
{
    public class TipoPrestamoNegocio
    {
        TipoPrestamoMapper _tipoPrestamoMapper;
        List<TipoPrestamo> _listaTipoPrestamos;

        public TipoPrestamoNegocio()
        {
            this._tipoPrestamoMapper = new TipoPrestamoMapper();
            this._listaTipoPrestamos = new List<TipoPrestamo>();
        }

        public List<TipoPrestamo> Traer()
        {
            this._listaTipoPrestamos = this._tipoPrestamoMapper.TraerTodos();
            return this._listaTipoPrestamos;
        }
    }
}
