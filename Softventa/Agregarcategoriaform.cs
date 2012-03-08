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
    public partial class Agregarcategoriaform : Form
    {
        public Agregarcategoriaform()
        {
            InitializeComponent();
        }

        private void Agregarcategoriaform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.categoria' Puede moverla o quitarla según sea necesario.
            this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = int.Parse((this.categoriaTableAdapter.Scalarcontar()).ToString()) + 1;
            textBox1.Text = "";
            textBox2.Text = "";
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //inicio numericUpDown1 = codigo
            int contador = 0;
            int i = 0;
            bool num = int.TryParse(numericUpDown1.Text, out i);
            if (num == false)
            {
                errorProvider1.SetError(numericUpDown1, "El valor tiene que ser numerico");

                contador++;
            }
            if (null != this.categoriaTableAdapter.Scalarverifcod(int.Parse(numericUpDown1.Value.ToString())))
            {
                errorProvider1.SetError(numericUpDown1, "Este codigo ya existe, y no se puede repetir");
                contador++;
            }

            if (textBox1.Text == "")
            {
                contador++;
                errorProvider1.SetError(textBox1, "Este campo no puede estar vacio");
            }

            if (textBox2.Text == "")
            {
                contador++;
                errorProvider1.SetError(textBox2, "Este campo no puede estar vacio");
            }
            
            //**************************************************************//
            //agregar a sql!!!!!!!!!!!!!!!!!//
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar la categoria.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int t;
                    String a,b;
                    a = textBox1.Text;
                    b = textBox2.Text;
                    t = int.Parse(numericUpDown1.Value.ToString());

                    this.categoriaTableAdapter.Insert( t, a, b );//Copio en la base de datos
                    errorProvider1.SetError(textBox1, "");
                    errorProvider1.SetError(textBox2, "");
                    //Actualiza el datagripview producto.
                    this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);
                    numericUpDown1.Value = int.Parse((this.categoriaTableAdapter.Scalarcontar()).ToString()) + 1;
                    MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
