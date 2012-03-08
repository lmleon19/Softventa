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
    public partial class Modificarproductoform : Form
    {
        public Modificarproductoform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int V = int.Parse(numericUpDown1.Value.ToString());
            if (this.productoTableAdapter1.Scalarverifcod(V) == null)
            {
                MessageBox.Show("No existe producto, vea cuadro al lado derecho", "Aviso");
            }
            else
            {
                int contador = 0;
                int i = 0;
                bool num;

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
                //inicio texbox4 = precio menor
                i = 0;
                num = int.TryParse(textBox4.Text, out i);
                if (num == false)
                {
                    errorProvider1.SetError(textBox4, "El valor tiene que ser numerico");
                    contador++;
                }

                //**************************************************************//
                //agregar a sql!!!!!!!!!!!!!!!!!//
                if (contador == 0)
                {
                    DialogResult result;
                    result = MessageBox.Show(this, "Seguro que quiere Modificar el producto.", "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        int a, b, c, s, t;
                        String d;
                        a = int.Parse((textBox2.Text).ToString());
                        b = int.Parse((textBox3.Text).ToString());
                        c = int.Parse((textBox4.Text).ToString());
                        d = textBox1.Text;
                        s = int.Parse(numericUpDown1.Value.ToString());
                        t = int.Parse((this.proveedorTableAdapter1.Scalarcodigo(comboBox1.Text)).ToString());

                        this.productoTableAdapter1.Updateproducto(s, d, a, b, c, t, s);
                        errorProvider1.SetError(textBox2, "");
                        errorProvider1.SetError(textBox3, "");
                        errorProvider1.SetError(textBox4, "");

                        //Actualiza el datagripview producto.
                        this.productoTableAdapter1.Fill(this.distribuidoraDataSet.producto);
                        MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void Modificarproductoform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter1.Fill(this.distribuidoraDataSet.producto);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            int q; 

            numericUpDown1.Value = int.Parse((dataGridView1.Rows[fila].Cells[0].Value).ToString());
            textBox1.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[2].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[3].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[4].Value);
            q=int.Parse((dataGridView1.Rows[fila].Cells[5].Value).ToString());
            comboBox1.Text= this.proveedorTableAdapter1.ScalarNombre(q);
        }
    }
}
