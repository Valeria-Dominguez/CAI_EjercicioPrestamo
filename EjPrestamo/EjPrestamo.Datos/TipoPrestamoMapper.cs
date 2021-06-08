using EjPrestamo.Entidades.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Datos
{
    public class TipoPrestamoMapper
    {
        static string rutaTipoPrestamo;

        public TipoPrestamoMapper()
        {
            rutaTipoPrestamo = ConfigurationManager.AppSettings["URL_TIPO_PRESTAMO"];
        }

        public List<TipoPrestamo> TraerTodos()
        {
            string json = WebHelper.Get(rutaTipoPrestamo);
            List<TipoPrestamo> resultado = MapList(json);
            return resultado;
        }

        private List<TipoPrestamo> MapList(string json)
        {
            List<TipoPrestamo> lista = JsonConvert.DeserializeObject<List<TipoPrestamo>>(json);
            return lista;
        }

        /*
        public NameValueCollection ReverseMap(TipoPrestamo tipoPrestamo)
        {
            NameValueCollection resultado = new NameValueCollection();
            resultado.Add("tna", tipoPrestamo.TNA.ToString("0.00"));
            resultado.Add("linea", tipoPrestamo.Linea);
            resultado.Add("id", tipoPrestamo.id.ToString());
            return resultado;
        }
        */
    }
}
