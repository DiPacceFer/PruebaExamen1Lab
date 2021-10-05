using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETipoManada { Unica, Mixta};
    public class Grupo
    {
        List<Mascota> manada;
        string nombre;
        static ETipoManada tipo;

        static Grupo()
        {
            Grupo.Tipo = ETipoManada.Unica;
        }
        private Grupo()
        {
            this.manada = new List<Mascota>();
        }
        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public Grupo(string nombre, ETipoManada tipo) : this(nombre)
        {
            Grupo.Tipo = tipo;
        }
        public static ETipoManada Tipo
        {
            set { tipo = value; }
        }
        #region sobrecarga de Operadores
        public static bool operator ==(Grupo g1, Mascota m2)
        {
            bool rta = false;
            foreach (Mascota item in g1.manada)
            {
                if(m2.Equals(item))
                {
                    rta = true;
                    break;
                }
            }

            return rta;
        }
        public static bool operator !=(Grupo g1, Mascota m2)
        {
            return !(g1 == m2);
        }
        public static Grupo operator +(Grupo g1, Mascota m2)
        {
            if (g1 != m2)
                g1.manada.Add(m2);
            else
                Console.WriteLine("Ya esta '"+ m2 +"' en el grupo");
            return g1;
        }
        public static Grupo operator -(Grupo g1, Mascota m2)
        {
            if (g1 == m2)
                g1.manada.Remove(m2);
            else
                Console.WriteLine("No esta el " + m2.ToString() + "en el grupo.");
            return g1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Grupo: {0} - tipo: {1}\n", this.nombre, Grupo.tipo);
            sb.AppendLine("Integrantes: " + this.manada.Count);
            foreach (Mascota item in this.manada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
