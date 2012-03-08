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
    public partial class Modificarprodproveform : Form
    {
        public Modificarprodproveform()
        {
            InitializeComponent();
        }

        private void Modificarprodproveform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.prodproveedor' Puede moverla o quitarla según sea necesario.
            this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //agregar a sql!!!!!!!!!!!!!!!!!//
            int contador = 0;
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere modificiar el producto de el proveedor.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    string a ;
                    int b,c;
                    a = comboBox1.Text;
                    b = int.Parse((textBox2.Text).ToString());
                    c = int.Parse((this.proveedorTableAdapter.Scalarcodigo(comboBox2.Text)).ToString());
                    this.prodproveedorTableAdapter.Updateprodproveedor(a,b,c,a);//Copio en la base de datos

                    //Actualiza el datagripview producto.
                    this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);
                    MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
