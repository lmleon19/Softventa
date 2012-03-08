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
    public partial class Modificartrabajadorform : Form
    {
        public Modificartrabajadorform()
        {
            InitializeComponent();
        }

        private void Modificartrabajadorform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            errorProvider1.SetError(comboBox3, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(comboBox1, "");
            errorProvider1.SetError(comboBox2, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            if (comboBox3.Text == "")
            {
                contador++;
                errorProvider1.SetError(comboBox3, "No puede ser un valor nulo o vacio");

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
                if (this.trabajadorTableAdapter.Scalarverifcod(comboBox3.Text) != null)
                {
                    DialogResult result;
                    result = MessageBox.Show(this, "Seguro que quiere Modificar el Trabajador.", "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        int a = int.Parse((this.sucursalTableAdapter.ScalarCodigo(comboBox2.Text)).ToString());
                        //insertar
                        this.trabajadorTableAdapter.Updatetrabajador(comboBox3.Text, textBox2.Text, dateTimePicker1.Value.Date, comboBox1.Text, dateTimePicker2.Value.Date, a, comboBox3.Text);
                        //actualizar datagridview
                        this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);
                        comboBox3.Text = "";
                        textBox2.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    MessageBox.Show(this, " Este usuario no existe vea la tabla a la derecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            comboBox3.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[fila].Cells[2].Value);
            comboBox1.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[3].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[fila].Cells[4].Value);
            comboBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[5].Value);
        }
    }
}
