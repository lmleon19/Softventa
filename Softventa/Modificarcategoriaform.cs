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
    public partial class Modificarcategoriaform : Form
    {
        public Modificarcategoriaform()
        {
            InitializeComponent();
        }

        private void Modificarcategoriaform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.categoria' Puede moverla o quitarla según sea necesario.
            this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            textBox1.Text = "";
            textBox2.Text = "";
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int V = int.Parse(numericUpDown1.Value.ToString());
            if (this.categoriaTableAdapter.Scalarverifcod(V) == null)
            {
                MessageBox.Show("No existe producto, vea cuadro al lado derecho", "Aviso");
            }
            else
            {
                int contador = 0;
               
                if (textBox1.Text == "")
                {
                    errorProvider1.SetError(textBox1, "Tiene que tener un valor obligatorio");
                    contador++;
                }
                if (textBox2.Text == "")
                {
                    errorProvider1.SetError(textBox2, "Tiene que tener un valor obligatorio");
                    contador++;
                }
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
                        int c;
                        String a, b;
                        a = textBox1.Text;
                        b = textBox2.Text;
                        c = int.Parse(numericUpDown1.Value.ToString());

                        this.categoriaTableAdapter.Updatecategoria(c, a, b, c);
                        errorProvider1.SetError(textBox1, "");
                        errorProvider1.SetError(textBox2, "");

                        //Actualiza el datagripview producto.
                        this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);
                        MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";

                    }
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            string nombre = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);

            numericUpDown1.Value = int.Parse((dataGridView1.Rows[fila].Cells[0].Value).ToString());
            textBox1.Text =Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[2].Value);
        }
    }
}
