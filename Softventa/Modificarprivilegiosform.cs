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
    public partial class Modificarprivilegiosform : Form
    {
        public Modificarprivilegiosform()
        {
            InitializeComponent();
        }

        private void Modificarprivilegiosform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.distribuidoraDataSet.usuario);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.distribuidoraDataSet.usuario);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox2.Text = "";
            comboBox4.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //**************************************************************//
            //agregar a sql!!!!!!!!!!!!!!!!!//

            int contador = 0;
            if (textBox4.Text != textBox1.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                contador++;
                errorProvider1.SetError(textBox1, "La contraseña no coincide");
            }
            else
            {
                if (contador == 0)
                {
                    DialogResult result;
                    result = MessageBox.Show(this, "Seguro que quiere Agregar el privilegio.", "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        String a, b, c, d, f, g;
                        a = comboBox3.Text;
                        b = textBox2.Text;
                        c = comboBox4.Text;
                        d = textBox4.Text;
                        f = textBox1.Text;
                        g = comboBox2.Text;
                        this.usuarioTableAdapter.Updateusuario(a,b,c,f,g,a);//Copio en la base de datos
                        errorProvider1.SetError(textBox1, "");
                        comboBox3.Text = "";
                        textBox2.Text = "";
                        comboBox4.Text = "";
                        textBox4.Text = "";
                        textBox1.Text = "";
                        comboBox2.Text = "";
                        //Actualiza el datagripview producto.
                        this.usuarioTableAdapter.Fill(this.distribuidoraDataSet.usuario);
                        MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, " Error al Colocar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            comboBox3.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[1].Value);
            comboBox4.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[2].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[3].Value);
            comboBox2.Text = Convert.ToString(dataGridView1.Rows[fila].Cells[4].Value);

        }
    }
}
