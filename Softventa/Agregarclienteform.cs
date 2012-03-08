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
    public partial class Agregarclienteform : Form
    {
        public Agregarclienteform()
        {
            InitializeComponent();
        }

        private void Agregarclienteform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //agregar a sql!!!!!!!!!!!!!!!!!//
            int contador = 0;
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar el cliente.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    string a,b;
                    a = textBox1.Text;
                    b = textBox2.Text;
                    DateTime hora = DateTime.Now;
                    this.clienteTableAdapter.Insert(a, b , hora );//Copio en la base de datos

                    //Actualiza el datagripview producto.
                    this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);
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
