using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Entidades.Dominio
{
    [DataContract]
    public class TipoPrestamo
    {
        string _linea;
        double _tNA;
        int _iD;

        [DataMember(Name = "linea")]
        public string Linea { get => _linea; set => _linea = value; }

        [DataMember(Name = "tna")]
        public double TNA { get => _tNA; set => _tNA = value; }

        [DataMember(Name = "id")]
        public int id { get => _iD; set => _iD = value; }

        public TipoPrestamo()
        {
        }

        public TipoPrestamo(string linea, double tNA, int iD)
        {
            _linea = linea;
            _tNA = tNA;
            _iD = iD;
        }

        
        public override string ToString()
        {
            return $"Linea: {this._linea} - TNA: {this._tNA} // {this._iD}";
        }
        
    }
}
