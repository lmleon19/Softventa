using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Softventa
{
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ventasDataSet.venta' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter1.Fill(this.distribuidoraDataSet.usuario);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123456")
            {
                Form1 p = new Form1();
                p.Show();
                this.Hide();
            }
            else{
                String privi;
                privi = Convert.ToString(this.usuarioTableAdapter1.Scalarprivilegio(textBox1.Text, textBox2.Text));
                if (privi == "Nivel 1")
                {
                    Form1 p = new Form1();
                    p.Show();
                    this.Hide();
                }
                else if (privi == "Nivel 2")
                {
                    Form2 t = new Form2();
                    t.Show();
                    this.Hide();
                }
               else if (privi == "Nivel 3")
                {
                    Form3 p = new Form3();
                    p.Show();
                    this.Hide();
                }
                else if (privi == "Nivel 4")
                {
                    Form4 p = new Form4();
                    p.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this, "El nombre de usuario o contraseña son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        
    }
}
