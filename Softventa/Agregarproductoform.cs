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
    public partial class Agregarproductoform : Form
    {
        public Agregarproductoform()
        {
            InitializeComponent();
            numericUpDown1.Value = int.Parse((this.productoTableAdapter.Scalarcontar()).ToString()) + 1;
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
            if (null != this.productoTableAdapter.Scalarverifcod(int.Parse(numericUpDown1.Value.ToString())))
            {
                errorProvider1.SetError(numericUpDown1, "Este codigo ya existe, y no se puede repetir");
                contador++;
            }

            // combobox2 = Nombre
            if(this.prodproveedorTableAdapter.Scalarprecio(comboBox2.Text) ==null)
            {
                errorProvider1.SetError(comboBox2, "Este codigo ya existe, y no se puede repetir");
                contador++;
            }



            //inicio texbox2 = precio costo
            i = 0;
            num = int.TryParse(textBox2.Text, out i);
            if (num == false)
            {
                errorProvider1.SetError(textBox2, "El valor tiene que ser numerico");
                contador++;
            }
            //inicio texbox3 = precio mayor
            i = 0;
            num = int.TryParse(textBox3.Text, out i);
            if (num == false)
            {
                errorProvider1.SetError(textBox3, "El valor tiene que ser numerico");
                contador++;
            }
            //inicio texbox2 = precio menor
            i = 0;
            num = int.TryParse(textBox4.Text, out i);
            if (num == false)
            {
                errorProvider1.SetError(textBox4, "El valor tiene que ser numerico");
                contador++;
            }
            if (this.proveedorTableAdapter.Scalarcodigo(comboBox1.Text) == null)
            {
                errorProvider1.SetError(comboBox1, "Esta sucursal no existe");
                contador++;

            }

            //**************************************************************//
            //agregar a sql!!!!!!!!!!!!!!!!!//
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar el producto.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int a, b, c , s, t;
                    String d;
                    a = int.Parse((textBox2.Text).ToString());
                    b = int.Parse((textBox3.Text).ToString());
                    c = int.Parse((textBox4.Text).ToString());
                    d = comboBox2.Text;
                    s = int.Parse(numericUpDown1.Value.ToString());
                    t = int.Parse((this.proveedorTableAdapter.Scalarcodigo(comboBox1.Text)).ToString());

                    this.productoTableAdapter.Insert(s, d , a, b , c , t);//Copio en la base de datos
                    errorProvider1.SetError(comboBox2, "");
                    errorProvider1.SetError(textBox2, "");
                    errorProvider1.SetError(textBox3, "");
                    errorProvider1.SetError(textBox4, "");
                    comboBox2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    //Actualiza el datagripview producto.
                    this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
                    numericUpDown1.Value = int.Parse((this.productoTableAdapter.Scalarcontar()).ToString()) + 1;
                    MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Agregarproductoform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.prodproveedor' Puede moverla o quitarla según sea necesario.
            this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.categoria' Puede moverla o quitarla según sea necesario.
            this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = int.Parse((this.productoTableAdapter.Scalarcontar()).ToString()) + 1;
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            errorProvider1.SetError(comboBox2, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(comboBox1, "");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                if (this.prodproveedorTableAdapter.Scalarproveedor(comboBox2.Text) != null)
                {
                    textBox2.Text = Convert.ToString(this.prodproveedorTableAdapter.Scalarprecio(comboBox2.Text));
                    int a = int.Parse((this.prodproveedorTableAdapter.Scalarproveedor(comboBox2.Text)).ToString());
                    comboBox1.Text = this.proveedorTableAdapter.ScalarNombre(a);
                }
            }
        }

        
    }
}
