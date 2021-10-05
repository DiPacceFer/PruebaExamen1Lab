using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        int edad;
        bool esAlfa;

        public Perro(string nombre, string raza, int edad, bool esAlfa) : this(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }
        public Perro(string nombre, string raza) : base(nombre, raza)
        {
            this.edad = 0;
            this.esAlfa = false;
        }
        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Perro - ");
            sb.Append(base.DatosCompletos());
            if(this.esAlfa)
            {
                sb.AppendFormat(", alfa de la manada, ");
            }
                sb.AppendFormat(", edad {0}",this.edad);
            
            return sb.ToString();
        }
        public static bool operator ==(Perro p1, Perro p2)
        {
            bool rta = false;
            if(p1.Nombre == p2.Nombre && p1.Raza == p2.Raza && p1.edad == p2.edad)
            {
                rta = true;
            }
            return rta;
        }
        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }
        public static explicit operator int(Perro p)
        {
            return p.edad;
        }
        public override string ToString()
        {
            return this.Ficha();
        }
        public override bool Equals(object obj)
        {
            bool rta = false;
            if (obj is Perro)
                rta = (Perro)obj == this; 
            return rta;
        }
    }
}
