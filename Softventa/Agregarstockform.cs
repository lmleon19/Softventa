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
    public partial class Agregarstockform : Form
    {
        int final = 0;
        public Agregarstockform()
        {
            InitializeComponent();
        }

        private void Agregarstockform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.detadqui' Puede moverla o quitarla según sea necesario.
            this.detadquiTableAdapter.Fill(this.distribuidoraDataSet.detadqui);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.adquisicion' Puede moverla o quitarla según sea necesario.
            this.adquisicionTableAdapter.Fill(this.distribuidoraDataSet.adquisicion);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.stock' Puede moverla o quitarla según sea necesario.
            this.stockTableAdapter.Fill(this.distribuidoraDataSet.stock);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.sucursal' Puede moverla o quitarla según sea necesario.
            this.sucursalTableAdapter.Fill(this.distribuidoraDataSet.sucursal);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.prodproveedor' Puede moverla o quitarla según sea necesario.
            this.prodproveedorTableAdapter.Fill(this.distribuidoraDataSet.prodproveedor);
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string a;
            a = comboBox4.Text;
            int b = int.Parse((numericUpDown2.Value).ToString()); 
            int c = int.Parse((this.prodproveedorTableAdapter.Scalarprecio(a)).ToString()); 
            final = final + b * c;
            dataGridView2.Rows.Add( a , comboBox1.Text , b , c , c * b , final);
            string valor;
            valor = Convert.ToString(final);
            label6.Text = valor;   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int H;
            H = dataGridView2.RowCount;
            if (H > 0)
            {
                DialogResult result;
                result = MessageBox.Show(this, "Realizar  venta \n - " + label6.Text, "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    
                    DateTime hora =DateTime.Now;
                    for (int i = 0; i < H; i++)
                    {
                        int nombre = int.Parse(this.productoTableAdapter.Scalarcodigo(Convert.ToString(dataGridView2.Rows[i].Cells[0].Value)).ToString());
                        int sucursal = int.Parse(this.sucursalTableAdapter.ScalarCodigo(Convert.ToString(dataGridView2.Rows[i].Cells[1].Value)).ToString());
                        int cantidad = int.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());

                        //Agrego al Stock
                        int stockcrit;
                        int stock;
                        if (this.stockTableAdapter.Scalarstockcritico(nombre, sucursal) == null)
                        {
                            stockcrit = 10;
                            stock = cantidad;
                            this.stockTableAdapter.Insert(nombre, sucursal, stock, stockcrit);
                        }
                        else
                        {
                            stockcrit = int.Parse((this.stockTableAdapter.Scalarstockcritico(nombre, sucursal)).ToString());
                            stock = int.Parse((this.stockTableAdapter.Scalarstock(nombre, sucursal)).ToString());
                            stock = stock + cantidad;
                            this.stockTableAdapter.Updatestock(nombre, sucursal, stock, stockcrit, nombre);
                        }

                        //Agregar a adquisicion
                        int codigo = int.Parse((this.adquisicionTableAdapter.Scalarcontar()).ToString()) + 1;
                        int proveedor = int.Parse((this.prodproveedorTableAdapter.Scalarproveedor(Convert.ToString(dataGridView2.Rows[i].Cells[0].Value).ToString()).ToString()));
                        this.adquisicionTableAdapter.Insert(codigo, hora, proveedor);

                        //Agregar det adquisicion
                        this.detadquiTableAdapter.Insert(nombre, codigo, cantidad);
                    }
                    //borra todo!
                    int s;
                    s = dataGridView2.RowCount;
                    if (s > 0)
                    {
                        for (int j = 0; j < H; j++)
                        {
                            int fila = dataGridView2.CurrentRow.Index;
                            dataGridView2.Rows.RemoveAt(fila);
                        }
                        label6.Text = "0";
                        final = 0;
                        MessageBox.Show(this, " Agregado Correctamente", "Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No a agregado Adquirido productos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("No hay Productos que adquirir en la Lista");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int H;
            H = dataGridView2.RowCount;
            if (H > 0)
            {
                for (int i = 0; i < H; i++)
                {
                    int fila = dataGridView2.CurrentRow.Index;
                    dataGridView2.Rows.RemoveAt(fila);
                }
                label6.Text = "0";
            }
            else
            {
                MessageBox.Show(this, "No hay producto agregados a la Venta.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int H;
            H = dataGridView2.RowCount;
            if (H > 0)
            {
                int fila = dataGridView2.CurrentRow.Index;
                dataGridView2.Rows.RemoveAt(fila);


                int a, b, c;
                a = dataGridView2.RowCount;
                final = 0;
                for (int i = 0; i < a; i++)
                {
                    b = int.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
                    c = int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                    final = final + (b * c);
                    dataGridView2.Rows[i].Cells[5].Value = final;
                }
                label6.Text = Convert.ToString(final);
            }
            else
            {
                MessageBox.Show(this, "No hay producto agregados a la Venta.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

       
    }
}
