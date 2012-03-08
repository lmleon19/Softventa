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
    public partial class Agregarprodproveform : Form
    {
        public Agregarprodproveform()
        {
            InitializeComponent();
        }

        private void Agregarprodproveform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.prodproveedor' Puede moverla o quitarla según sea necesario.
            this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.distribuidoraDataSet.proveedor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //agregar a sql!!!!!!!!!!!!!!!!!//
            int contador = 0;
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar el producto al proveedor.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int b,c;
                    string a;
                    a = textBox1.Text;
                    b = int.Parse((textBox2.Text).ToString());
                    c= int.Parse((this.proveedorTableAdapter.Scalarcodigo(comboBox1.Text)).ToString());
                    DateTime hora = DateTime.Now;
                    this.prodproveedorTableAdapter.Insert(a, b, c);//Copio en la base de datos
                   
                    //Actualiza el datagripview producto.
                    this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);
                    MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
