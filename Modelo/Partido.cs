using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Modelo
{
    [Serializable()]
    public class Partido : ISerializable
    {
        private int Id { get; }
        public Equipo Local { get; }
        public Equipo Visitante { get; }
        public string Resultado { get; }
        private DateTime Fecha { get; }
        private string Arbitro { get; }

        private Partido(int id, Equipo local, Equipo visitante, string resultado, DateTime fecha, string arbitro)
        {
            Id = id;
            Local = local;
            Visitante = visitante;
            Resultado = resultado;
            Fecha = fecha;
            Arbitro = arbitro;
        }

        public static Partido CreatePartido(int id, Equipo local, Equipo visitante, string resultado, DateTime fecha, string arbitro)
        {
            return new Partido(id, local, visitante, resultado, fecha, arbitro);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ID: {0}",Id);
            sb.AppendFormat(" Equipo Local: {0}", Local != null ? Local.Nombre : "---");
            sb.AppendFormat(" Equipo Visitante: {0}", Visitante != null ? Visitante.Nombre : "---");
            sb.AppendFormat(" Resultado: {0}", Resultado);
            sb.AppendFormat(" Fecha: {0}", Fecha);
            sb.AppendFormat(" Arbitro: {0}", Arbitro);

            return sb.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Local", Local);
            info.AddValue("Visitante", Visitante);
            info.AddValue("Resultado", Resultado);
            info.AddValue("Fecha", Fecha);
            info.AddValue("Arbitro", Arbitro);
        }

        public Partido(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Local = (Equipo)info.GetValue("Local", typeof(Jugador));
            Visitante = (Equipo)info.GetValue("Visitante", typeof(Jugador));
            Resultado = (string)info.GetValue("Resultado", typeof(string));
            Fecha = (DateTime)info.GetValue("Fecha", typeof(DateTime));
            //Arbitro = 
        }
    }
}
