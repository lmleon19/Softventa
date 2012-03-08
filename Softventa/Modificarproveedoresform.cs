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
    public partial class Modificarproveedoresform : Form
    {
        public Modificarproveedoresform()
        {
            InitializeComponent();
        }

        private void Modificarproveedoresform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            int V = int.Parse(numericUpDown1.Value.ToString());
            if (this.proveedorTableAdapter.Scalarverifcod(V) == null)
            {
                MessageBox.Show("No existe producto, vea cuadro al lado derecho", "Aviso");
            }
            else
            {
                int contador = 0;
                int i = 0;
                bool num;

                //inicio texbox2 = Telefono
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
                    result = MessageBox.Show(this, "Seguro que quiere Modificar el proveedor.", "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        int a, c;
                        String b, d, g, f;
                        a = int.Parse(numericUpDown1.Value.ToString());
                        b = textBox1.Text;
                        c = int.Parse((textBox2.Text).ToString());
                        d = textBox3.Text;
                        g = textBox4.Text;
                        f = textBox5.Text;

                        this.proveedorTableAdapter.Updateproveedor( a , b , c , d , g , f , a );
                        errorProvider1.SetError(textBox2, "");
                        errorProvider1.SetError(textBox3, "");
                        errorProvider1.SetError(textBox4, "");
                        errorProvider1.SetError(textBox5, "");
                        //Actualiza el datagripview producto.
                        this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);
                        MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}
