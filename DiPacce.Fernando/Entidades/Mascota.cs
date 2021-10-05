using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    abstract public class Mascota
    {
        string nombre;
        string raza;

        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Raza
        {
            get { return this.raza; }
        }
        protected virtual string DatosCompletos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} - {1}", this.Nombre, this.Raza);

            return sb.ToString();
        }
        protected abstract string Ficha();
        #region sobrecarga de operadores
        public static bool operator ==(Mascota m1, Mascota m2)
        {
            bool rta = false;
            if(m1.Nombre == m2.Nombre && m1.Raza == m2.Raza)
            {
                rta = true;
            }
            return rta;
        }
        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }
        #endregion
    }
}
