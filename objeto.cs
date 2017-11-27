using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class cuerpo
    {
        protected int x, y, anchura;
        public cuerpo()
        {
            anchura = 20;
        }
        //Función que permita reconocer colisiones
        public Boolean interseccion (cuerpo obj)
        {
            //Se calcula la diferencia de la posición X y Y
            //determinando si hay colisión obj no
            int distanciax = Math.Abs(this.x - obj.x);
            int distanciay = Math.Abs(this.y - obj.y);
            if (distanciax>=0 && distanciax<anchura && distanciay >= 0 && distanciay < anchura)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
