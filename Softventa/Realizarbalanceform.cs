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
    public partial class Realizarbalanceform : Form
    {
        public Realizarbalanceform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime mifecha1 = dateTimePicker1.Value.Date;
            DateTime mifecha2 = dateTimePicker2.Value.Date;
            
            mifecha2 = mifecha2.AddDays(+1);
            int montototal = 0;
            int montocosto = 0;
            if (this.ventaTableAdapter.ScalarMontofecha(mifecha1, mifecha2) == null)
                MessageBox.Show(this, "No hay ventas entre estas fechas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                montototal = int.Parse(this.ventaTableAdapter.ScalarMontofecha(mifecha1, mifecha2).ToString());
                
                montocosto = int.Parse(this.detalleTableAdapter.ScalarQuery(mifecha1, mifecha2).ToString());
                label4.Text = Convert.ToString(montototal);
                label9.Text = Convert.ToString(montocosto);
                label10.Text = Convert.ToString((montototal - montocosto));
                float montototal2 = montototal;
                float montocosto2 = montocosto;
                label11.Text = Convert.ToString((100 - ((100 / montototal2) * montocosto2)));





            }
        }

        

        private void Realizarbalanceform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.detalle' Puede moverla o quitarla según sea necesario.
            this.detalleTableAdapter.Fill(this.distribuidoraDataSet.detalle);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.distribuidoraDataSet.venta);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
