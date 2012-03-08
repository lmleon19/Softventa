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
    public partial class Modificarclienteform : Form
    {
        public Modificarclienteform()
        {
            InitializeComponent();
        }

        private void Modificarclienteform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //agregar a sql!!!!!!!!!!!!!!!!!//
            int contador = 0;
            if (contador == 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Seguro que quiere modificiar el cliente.", "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    string a, b, c;
                    a = comboBox1.Text;
                    b = textBox2.Text;
                    DateTime hora = dateTimePicker1.Value;
                    this.clienteTableAdapter.Updatecliente(a, b, hora,a);//Copio en la base de datos

                    //Actualiza el datagripview producto.
                    this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);
                    MessageBox.Show(this, " Modificado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            comboBox1.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[fila].Cells[2].Value);
        }
    }
}
