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
    public partial class Modificarstockform : Form
    {
        public Modificarstockform()
        {
            InitializeComponent();
        }

        private void Modificarstockform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.stock' Puede moverla o quitarla según sea necesario.
            this.stockTableAdapter.Fill(this.distribuidoraDataSet.stock);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int contador=0;
            if (null == this.productoTableAdapter.Scalarpreciomayor(int.Parse((numericUpDown1.Value).ToString())))
            {
                errorProvider1.SetError(numericUpDown1, "Este producto no existe");
                contador++;
            }
            if (null == this.sucursalTableAdapter.Scalarverifcod(int.Parse((numericUpDown2.Value).ToString())))
            {
                errorProvider1.SetError(numericUpDown2, "Este sucursal no existe");
                contador++;
            }
            if (contador == 2)
            {
                if (null == this.stockTableAdapter.Scalarstockcritico(int.Parse((numericUpDown1.Value).ToString()), int.Parse((numericUpDown2.Value).ToString())))
                {
                    MessageBox.Show(this, "Este producto no tiene stock en esta sucursal");
                    contador++;
                }
            }

            if (contador == 0)
            {
                int a= int.Parse((numericUpDown1.Value).ToString());
                int b= int.Parse((numericUpDown2.Value).ToString());
                int c= int.Parse((numericUpDown3.Value).ToString());
                this.stockTableAdapter.Updatestockcritico(c, a, b);
                this.stockTableAdapter.Fill(this.distribuidoraDataSet.stock);
                MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDown1.Value = 1;
                numericUpDown2.Value = 1;
                numericUpDown3.Value = 1;
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(numericUpDown2, "");
            errorProvider1.SetError(numericUpDown3, "");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            numericUpDown1.Value = int.Parse((dataGridView1.Rows[fila].Cells[0].Value).ToString());
            numericUpDown2.Value = int.Parse((dataGridView1.Rows[fila].Cells[1].Value).ToString());
            numericUpDown3.Value = int.Parse((dataGridView1.Rows[fila].Cells[3].Value).ToString());
        }

        
    }
}
