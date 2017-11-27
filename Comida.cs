using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Comida : cuerpo 
    {
        private string convertfromImagen;

        public Comida()
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public void graficar(Graphics grafica)
        {
            grafica.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.anchura, this.anchura);

            

        }

        public void dibujar(Graphics grafico)
        {
            grafico.FillRectangle(new SolidBrush(Color.Yellow), this.x, this.y, this.anchura, this.anchura);
        }
        public void colocar()
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}
