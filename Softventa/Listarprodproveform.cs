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
    public partial class Listarprodproveform : Form
    {
        public Listarprodproveform()
        {
            InitializeComponent();
        }

        private void Listarprodproveform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.prodproveedor' Puede moverla o quitarla según sea necesario.
            this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);

        }
    }
}
