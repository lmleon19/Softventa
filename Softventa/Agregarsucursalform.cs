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
    public partial class Agregarsucursalform : Form
    {
        public Agregarsucursalform()
        {
            InitializeComponent();
        }

        private void Agregarsucursalform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
            numericUpDown1.Value = int.Parse((this.sucursalTableAdapter.Scalarcontar()).ToString()) + 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = int.Parse((this.sucursalTableAdapter.Scalarcontar()).ToString()) + 1;
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
            if (null != this.sucursalTableAdapter.Scalarverifcod(int.Parse(numericUpDown1.Value.ToString())))
            {
                errorProvider1.SetError(numericUpDown1, "Este codigo ya existe, y no se puede repetir");
                contador++;
            }

            num = int.TryParse(textBox2.Text, out i);
            if(num == false)
            {
                errorProvider1.SetError(textBox2, "El valor tiene que ser numerico");
                contador++;
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
                    int t,b;
                    String a;
                    a = textBox1.Text;
                    b = int.Parse((textBox2.Text).ToString());
                    t = int.Parse(numericUpDown1.Value.ToString());

                    this.sucursalTableAdapter.Insert(t,a,b);//Copio en la base de datos
                    errorProvider1.SetError(textBox1, "");
                    errorProvider1.SetError(textBox2, "");
                    //Actualiza el datagripview producto.
                    this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
                    numericUpDown1.Value = int.Parse((this.sucursalTableAdapter.Scalarcontar()).ToString()) + 1;
                    MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}
