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
    public partial class Agregartrabajadorform : Form
    {
        public Agregartrabajadorform()
        {
            InitializeComponent();
        }

        private void Agregartrabajadorform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            if (textBox1.Text == "")
            {
                contador++;
                errorProvider1.SetError(textBox1, "No puede ser un valor nulo o vacio");

            }
            if (textBox2.Text == "")
            {
                contador++;
                errorProvider1.SetError(textBox2, "No puede ser un valor nulo o vacio");
            }
            if (comboBox1.Text == "")
            {
                contador++;
                errorProvider1.SetError(comboBox1, "No puede ser un valor nulo o vacio");
            }
            if (comboBox2.Text == "")
            {
                contador++;
                errorProvider1.SetError(comboBox2, "No puede ser un valor nulo o vacio");
            }



            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere Agregar el Trabajador.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int a = int.Parse((this.sucursalTableAdapter.ScalarCodigo(comboBox2.Text)).ToString());
                    //insertar
                    this.trabajadorTableAdapter.Insert(textBox1.Text, textBox2.Text, dateTimePicker1.Value.Date, comboBox1.Text, dateTimePicker2.Value.Date, a);
                    //actualizar datagridview
                    this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                else
                {
                    MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
