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
    public partial class Listarproveedoresform : Form
    {
        public Listarproveedoresform()
        {
            InitializeComponent();
        }

        private void Listarproveedoresform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);

        }
    }
}
