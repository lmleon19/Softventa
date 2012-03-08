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
    public partial class Listarproductoform : Form
    {
        public Listarproductoform()
        {
            InitializeComponent();
        }

        private void Listarproductoform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
