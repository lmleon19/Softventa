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
    public partial class Listarclienteform : Form
    {
        public Listarclienteform()
        {
            InitializeComponent();
        }

        private void Listarclienteform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);

        }
    }
}
