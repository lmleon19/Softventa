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
    public partial class Modificarsucursalform : Form
    {
        public Modificarsucursalform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 1;
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(numericUpDown1, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int V = int.Parse(numericUpDown1.Value.ToString());
            if (this.sucursalTableAdapter.Scalarverifcod(V) == null)
            {
                MessageBox.Show("No existe producto, vea cuadro al lado derecho", "Aviso");
                errorProvider1.SetError(numericUpDown1, "No existe producto, vea cuadro al lado derecho");
            }
            else
            {
                int i = 0;
                bool num = int.TryParse(textBox2.Text, out i);
                int contador=0;
                if(num == false)
                {
                    errorProvider1.SetError(textBox2, "El valor tiene que ser numerico");
                    contador++;
                    
                }

                if (textBox1.Text == "")
                {
                    errorProvider1.SetError(textBox1, "Tiene que tener un valor obligatorio");
                    contador++;
                }
                //**************************************************************//
                //agregar a sql!!!!!!!!!!!!!!!!!//
                if (contador == 0)
                {
                    //**************************************************************//
                    //agregar a sql!!!!!!!!!!!!!!!!!//

                    DialogResult result;
                    result = MessageBox.Show(this, "Seguro que quiere Modificar la categoria.", "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        int c,b;
                        String a;
                        a = textBox1.Text;
                        b = int.Parse((textBox2.Text).ToString());
                        c = int.Parse(numericUpDown1.Value.ToString());

                        this.sucursalTableAdapter.Updatesucursal(c, a, b, c);
                        errorProvider1.SetError(numericUpDown1, "");
                        errorProvider1.SetError(textBox1, "");
                        errorProvider1.SetError(textBox2, "");

                        //Actualiza el datagripview producto.
                        this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
                        MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Modificarsucursalform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            numericUpDown1.Value = int.Parse((dataGridView1.Rows[fila].Cells[0].Value).ToString());
            textBox1.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[2].Value);
        }
    }
}
