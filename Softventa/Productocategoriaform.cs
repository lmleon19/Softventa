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
    public partial class Productocategoriaform : Form
    {
        public Productocategoriaform()
        {
            InitializeComponent();
        }

        private void Productocategoriaform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cateprod' Puede moverla o quitarla según sea necesario.
            this.cateprodTableAdapter.Fill(this.distribuidoraDataSet.cateprod);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.categoria' Puede moverla o quitarla según sea necesario.
            this.categoriaTableAdapter.Fill(this.distribuidoraDataSet.categoria);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int uno = int.Parse((numericUpDown1.Value).ToString());
            int dos = int.Parse((numericUpDown2.Value).ToString());
            if(uno != this.productoTableAdapter.Scalarverifcod(uno))
            {
                errorProvider1.SetError(numericUpDown1, "Este codigo no existe, ve el cuadro al lado derecho");
                contador++;
            }
            if(dos !=this.categoriaTableAdapter.Scalarverifcod(dos))
            {
                errorProvider1.SetError(numericUpDown2, "Este codigo no existe, ve el cuadro al lado derecho");
                contador++;
            }
            if (int.Parse((this.cateprodTableAdapter.Scalarverexiste(uno,dos)).ToString()) == 1)
            {
                contador++;
                MessageBox.Show(this, "Este producto ya esta agregado a la Categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar esta categoria a el producto producto.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    uno = int.Parse((numericUpDown1.Value).ToString());
                    dos = int.Parse((numericUpDown2.Value).ToString());
                    this.cateprodTableAdapter.Insert(uno, dos);
                    numericUpDown1.Value = 1;
                    numericUpDown2.Value = 1;
                    errorProvider1.SetError(numericUpDown1, "");
                    errorProvider1.SetError(numericUpDown2, "");
                }
                else
                {
                    MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(numericUpDown2, "");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            string nombre = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);
            numericUpDown1.Value = int.Parse((nombre).ToString());
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView2.CurrentRow.Index;
            string nombre = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);
            numericUpDown2.Value = int.Parse((nombre).ToString());
        }

        

    }
}
