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
    public partial class Listartrabajadorform : Form
    {
        public Listartrabajadorform()
        {
            InitializeComponent();
        }

        private void Listartrabajadorform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);

        }
    }
}
