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
    public partial class Agregarproveedoresform : Form
    {
        public Agregarproveedoresform()
        {
            InitializeComponent();
        }

        private void Agregarproveedoresform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = int.Parse((this.proveedorTableAdapter.Scalarcontar()).ToString()) + 1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(textBox5, "");
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
            if (null != this.proveedorTableAdapter.Scalarverifcod(int.Parse(numericUpDown1.Value.ToString())))
            {
                errorProvider1.SetError(numericUpDown1, "Este codigo ya existe, y no se puede repetir");
                contador++;
            }

            //inicio texbox1 = precio costo
            i = 0;
            num = int.TryParse(textBox2.Text, out i);
            if (num == false)
            {
                errorProvider1.SetError(textBox2, "El valor tiene que ser numerico");
                contador++;
            }
            

            //**************************************************************//
            //agregar a sql!!!!!!!!!!!!!!!!!//
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar el proveedor.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int a,c;
                    String b,d,g,f ;
                    a = int.Parse(numericUpDown1.Value.ToString());
                    b = textBox1.Text;
                    c = int.Parse((textBox2.Text).ToString());
                    d = textBox3.Text;
                    g = textBox4.Text;
                    f = textBox5.Text;

                    this.proveedorTableAdapter.Insert( a , b , c, d , g , f );//Copio en la base de datos
                    errorProvider1.SetError(textBox1, "");
                    errorProvider1.SetError(textBox2, "");
                    errorProvider1.SetError(textBox3, "");
                    errorProvider1.SetError(textBox4, "");
                    errorProvider1.SetError(textBox5, "");
                    //Actualiza el datagripview producto.
                    this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);
                    numericUpDown1.Value = int.Parse((this.proveedorTableAdapter.Scalarcontar()).ToString()) + 1;
                    MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
