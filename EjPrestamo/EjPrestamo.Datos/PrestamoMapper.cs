using EjPrestamo.Entidades.Dominio;
using EjPrestamo.Entidades.Modelos;
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
    public class PrestamoMapper
    {
        static string rutaPrestamo;
        static string registro;
        TipoPrestamoMapper _tipoPrestamoMapper;

        public PrestamoMapper()
        {
            rutaPrestamo = ConfigurationManager.AppSettings["URL_PRESTAMO"];
            registro = ConfigurationManager.AppSettings["REGISTRO"];
            this._tipoPrestamoMapper = new TipoPrestamoMapper();
        }

        public List<Prestamo> TraerTodos()
        {
            string json = WebHelper.Get(rutaPrestamo + registro);
            List<Prestamo> resultado = MapList(json);
            return resultado;
        }

        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lista = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lista;
        }

        
        public ResultadoTransaccion Agregar(Prestamo prestamo)
        {
            NameValueCollection parametros = ReverseMap(prestamo);
            string json = WebHelper.Post(rutaPrestamo, parametros);
            ResultadoTransaccion resultado = JsonConvert.DeserializeObject<ResultadoTransaccion>(json);
            return resultado;
        }

        
        private NameValueCollection ReverseMap(Prestamo prestamo)
        {
            NameValueCollection n = new NameValueCollection();
            
            n.Add("id", "0");
            n.Add("TNA", prestamo.TipoPrestamo.TNA.ToString("0.00"));
            n.Add("Linea", prestamo.TipoPrestamo.Linea);
            n.Add("Plazo", prestamo.Plazo.ToString());
            n.Add("idCliente", "0");
            n.Add("idTipo", prestamo.IdTipo.ToString());
            n.Add("Monto", prestamo.Monto.ToString("0.00"));
            n.Add("Cuota", prestamo.Cuota.ToString("0.00"));
            n.Add("Usuario", registro);
            n.Add("TipoPrest.TNA", "0");
            n.Add("TipoPrest.Linea", "0");
            n.Add("TipoPrest.id", "0");
            
            return n;
        }
        
    }
}
