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
    public partial class Listarventasform : Form
    {
        public Listarventasform()
        {
            InitializeComponent();
        }

        private void Listarventasform_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.detalle' Puede moverla o quitarla según sea necesario.
            this.detalleTableAdapter.Fill(this.distribuidoraDataSet.detalle);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.distribuidoraDataSet.venta);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = ""; 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
            errorProvider1.SetError(comboBox2, "");
            errorProvider1.SetError(comboBox3, "");
            errorProvider1.SetError(comboBox4, "");
            int contador = 0;
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "%";
            }
            else{
                if (null == this.productoTableAdapter.Scalarcodigo(comboBox1.Text))
                {
                    errorProvider1.SetError(comboBox1, "El nombre de producto no existe");
                    contador++;
                }
                
            }
            //**************
            if (comboBox2.Text == "")
            {
                comboBox2.Text = "%";
            }
            else
            {
                if (null == this.sucursalTableAdapter.ScalarCodigo(comboBox2.Text))
                {
                    errorProvider1.SetError(comboBox2, "El nombre de Sucursal no existe");
                    contador++;
                }
               
            }
            //**************
            if (comboBox3.Text == "")
            {
                comboBox3.Text = "%";
            }
            else
            {
                if (null == this.trabajadorTableAdapter.Scalarsucursal(comboBox3.Text))
                {
                    errorProvider1.SetError(comboBox3, "El nombre de trabajador no existe");
                    contador++;
                }
            }
            //**************
            if (comboBox4.Text == "")
            {
                comboBox4.Text = "%";
            }
            else
            {
                if (0 == this.clienteTableAdapter.Scalarexiste(comboBox4.Text))
                {
                    errorProvider1.SetError(comboBox4, "El nombre de cliente no existe");
                    contador++;
                }
                
            }
            //**********
            DateTime mifecha1;
            DateTime mifecha2;
            if (checkBox1.Checked == false)
            {
                string hora1 = "15-01-1900 0:00:00";
                string hora2 = "15-01-3000 0:00:00";
                mifecha1 = Convert.ToDateTime(hora1);
                mifecha2 = Convert.ToDateTime(hora2);
            }
            else /*15-01-2000 0:00:00*/
            {
                mifecha1 = dateTimePicker1.Value.Date;
                mifecha2 = dateTimePicker2.Value.Date;
                mifecha2 = mifecha2.AddDays(+1);
            }
            //**********
            
            //*******************************************
            if (contador == 0)
            {
                this.dataGridView1.DataSource = this.ventaTableAdapter.GetDataBy3(comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox1.Text, mifecha1, mifecha2);
                
                
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            int codigo = int.Parse((dataGridView1.Rows[fila].Cells[0].Value).ToString());
            this.dataGridView2.DataSource = this.detalleTableAdapter.GetDataBy1(codigo);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        

        


    }
}
