using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        //morfo que va a ser la serpiente
        morfo vibora;
        //Cola cabeza;
        Comida Comida;
        Graphics grafico;
        
        int puntaje = 0;
        //Creación variables para la creación de la serpiente
        int direccionx = 0, direcciony = 0;
        //Variables para controlar los ejes (no diagonal, no reversa)
        Boolean ejex = true, ejey = true;
        public Form1()
        {
            InitializeComponent();
            vibora = new morfo(10,10);
            Comida = new Comida();
            //Creación entorno grafico
            grafico = pantalla.CreateGraphics();
        }
        //Función para movimiento
        public void movimiento()
        {
            vibora.setxy(vibora.leerx() + direccionx, vibora.leery()+direcciony);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bucle_Tick(object sender, EventArgs e)
        {
            //Refrescar pantalla
            grafico.Clear(Color.YellowGreen);
            vibora.graficar(grafico);
            Comida.graficar(grafico);
            movimiento();
            choquecuerpo();
            choquePared();
            if (vibora.interseccion(Comida))
            {
                Comida.colocar();
                vibora.meter();
                puntaje++;
                puntos.Text = puntaje.ToString();
            }
        }
        public void choquePared()
        {
            if (vibora.leerx() < 0 || vibora.leerx() > 780 || vibora.leery() < 0 || vibora.leery() > 390)
            {
                findejuego();
            }
        }
        public void findejuego()
        {
            puntaje = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            direccionx = 0;
            direcciony = 0;
            vibora = new morfo(10,10);
            Comida = new Comida();
            MessageBox.Show("Perdiste");

        }
        public void choquecuerpo()
        {
          morfo temp;
          try
          {
              temp =vibora.versiguiente().versiguiente();
              }
            catch (Exception )
            {
                temp = null;

              } 
              while(temp != null)
              {
                  if(vibora.interseccion(temp))
                  {
                      findejuego();

                  }
                  else
                  {
                      temp = temp.versiguiente();

                  }
              }
              
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if(e.KeyCode==Keys.Up)
                {
                    direcciony = -20;
                    direccionx = 0;
                    ejex = false;
                    ejey = true;
                }
                if(e.KeyCode==Keys.Down)
                {
                    direcciony = 20;
                    direccionx = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if(e.KeyCode == Keys.Right)
                {
                    direcciony = 0;
                    direccionx = 20;
                    ejex = true;
                    ejey = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    direcciony = 0;
                    direccionx = -20;
                    ejex = true;
                    ejey = false;  
                }
            }
        }
    }
}
