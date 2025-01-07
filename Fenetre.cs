using System;
using System.Windows.Forms;

namespace aff
{
    public class Fenetre : Form
    {
        private Button  button  ;
        private Dessin  dessin ;
        public Fenetre()
        {   
            button = new Button();
            dessin = new Dessin();

            button.Text = "move";
            button.Location= new Point(100 , 50);
            button.Size  =  new Size(100 , 30);
            button.Click += _Click;

             dessin.Location = new Point(50, 20);
            this.Controls.Add(button);
            this.Controls.Add(dessin);


            Text = "Ma fenêtre";
            Width = 400;
            Height = 300;
        }
         private void _Click(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
            dessin.MoveCircle(10, 10);  
        }

       
    }
}
