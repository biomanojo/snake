using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    //Herencia cuerpo
    class morfo : cuerpo
    {
        //Constructor recibe 2 parametros (posicion X Y)
        morfo siguiente;
        public morfo(int x, int y)
        {//Variables de cuerpo
            this.x = x;
            this.y = y;
        }
        //Función graficar (cuadros de serpiente y el cuadro de juego)
        public void graficar(Graphics grafico)
        {
            if(siguiente != null)
            {
                siguiente.graficar(grafico);
            }
        //5 parametros (Color, pos X, pos Y, anchura y Alto)
            grafico.FillRectangle(new SolidBrush(Color.DarkBlue), this.x, this.y, this.anchura, this.anchura);

            
        }

        //Funcón permite mover
        public void setxy(int x, int y)
        {//3-Se le da la posicion X Y

            if(siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }

            this.x = x;
            this.y = y;
        }
        public void meter()
        {
            if(siguiente == null)
            {
                siguiente = new morfo(this.x, this.y);
            } else
            {
                siguiente.meter();
            }
        }

        //Metodo para ver valor X 
        public int leerx()
        {
            return this.x;
        }
        //Metodo para ver valor Y
        public int leery()
        {
            return this.y;
        }
        public morfo versiguiente()
        {
            return siguiente;
        }
    }

}
