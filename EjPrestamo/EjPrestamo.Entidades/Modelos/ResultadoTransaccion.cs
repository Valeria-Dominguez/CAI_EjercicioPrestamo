using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EjPrestamo.Entidades.Modelos
{
    [DataContract]
    public class ResultadoTransaccion
    {
        [DataMember]
        bool IsOk { set; get; }
        [DataMember]

        int ID { set; get; }
        [DataMember]

        string Error { set; get; }

        public override string ToString()
        {
            if (IsOk)
                return $"Operación exitosa. ID:{this.ID}";
            else
                return $"La operación no pudo realizarse: {this.Error}";
        }
    }
}
