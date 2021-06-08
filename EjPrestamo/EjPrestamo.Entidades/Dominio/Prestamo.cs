using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Entidades.Dominio
{
    [DataContract]
    public class Prestamo
    {
        int _idTipo;
        int _plazo;
        double _monto;
        string _usuario;
        int _id;        

        TipoPrestamo _tipoPrestamo;

        [DataMember(Name = "idTipo")]
        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        [DataMember(Name = "plazo")]
        public int Plazo { get => _plazo; set => _plazo = value; }
        [DataMember(Name = "monto")]
        public double Monto { get => _monto; set => _monto = value; }
        [DataMember(Name = "usuario")]
        public string Usuario { get => _usuario; set => _usuario = value; }
        [DataMember(Name = "id")]
        public int id { get => _id; set => _id = value; }
        [DataMember(Name = "tipoPrest")]
        public TipoPrestamo TipoPrestamo { get => _tipoPrestamo; set => _tipoPrestamo = value; }

        public double CuotaCapital { get => this._monto / this._plazo; }
        public double CuotaInteres { get => CuotaCapital * (this._tipoPrestamo.TNA / 12 / 100); }
        public double Cuota { get => CuotaCapital + CuotaInteres; }
        public Prestamo()
        {
            _tipoPrestamo = new TipoPrestamo();
        }

        public Prestamo(int idTipo, int plazo, double monto, TipoPrestamo tipoPrestamo)
        {
            _idTipo = idTipo;
            _plazo = plazo;
            _monto = monto;
            _tipoPrestamo = tipoPrestamo;
        }

        public override string ToString()
        {
            return $"{this._id}) {this._plazo} meses - ARS {this._monto} (interés ARS {this.CuotaInteres * this._plazo} TNA {this._tipoPrestamo.TNA} - Total ARS {this._monto + this.CuotaInteres * this._plazo}";
        }

    }
}
