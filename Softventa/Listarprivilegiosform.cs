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
    public partial class Listarprivilegiosform : Form
    {
        public Listarprivilegiosform()
        {
            InitializeComponent();
        }

        private void Listarprivilegiosform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.distribuidoraDataSet.usuario);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.distribuidoraDataSet.usuario);

        }
    }
}
