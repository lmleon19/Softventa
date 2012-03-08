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
    public partial class Realizarventaform : Form
    {
        int final = 0;
        
        public Realizarventaform()
        {
            InitializeComponent();
            
        }

        private void Realizarventaform_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.detalle' Puede moverla o quitarla según sea necesario.
            this.detalleTableAdapter.Fill(this.distribuidoraDataSet.detalle);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.distribuidoraDataSet.venta);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.distribuidoraDataSet.cliente);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.distribuidoraDataSet.producto);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.stock' Puede moverla o quitarla según sea necesario.
            this.stockTableAdapter.Fill(this.distribuidoraDataSet.stock);
            // TODO: esta línea de código carga datos en la tabla 'distribuidoraDataSet.trabajador' Puede moverla o quitarla según sea necesario.
            this.trabajadorTableAdapter.Fill(this.distribuidoraDataSet.trabajador);
            
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse((this.trabajadorTableAdapter.Scalarsucursal(comboBox2.Text)).ToString()); //Codigo Sucursal
            int b = int.Parse((this.productoTableAdapter.Scalarcodigo(comboBox1.Text)).ToString()); //codigo Producto
            int c = int.Parse((this.stockTableAdapter.Scalarstock(b,a )).ToString()); //Stock disponible
            
            if (numericUpDown1.Value < c)
            {
                int d;
                if (numericUpDown1.Value > 6)
                {
                    d = int.Parse((this.productoTableAdapter.Scalarpreciomayor(b)).ToString());
                }
                else 
                {
                    d = int.Parse((this.productoTableAdapter.Scalarpreciomenor(b)).ToString());
                }
                final = final + int.Parse((numericUpDown1.Value).ToString()) * d;

                dataGridView1.Rows.Add(comboBox1.Text, numericUpDown1.Value, d , d * numericUpDown1.Value , final);
                string valor;
                valor = Convert.ToString(final);
                label6.Text = valor;
            }
            else
            {
                MessageBox.Show(this, "El stock en esta sucursal no es suficiente solo tiene: " + c + " Unidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int contador = 0;
            if (comboBox5.Text == "Efectivo" || comboBox5.Text == "Cheque")
            {
            }
            else
            {
                contador++;
                if (comboBox5.Text == "" || comboBox5.Text == "")
                {
                    errorProvider1.SetError(comboBox5, "El Modo de Pago se encuentra vacio");
                }
                else
                {
                    errorProvider1.SetError(comboBox5, "Agrege el Modo de Pago correctamente");
                }
            }
            if (comboBox4.Text == "Factura" || comboBox4.Text == "Boleta")
            {
            }
            else
            {
                contador++;
                if (comboBox4.Text == "" || comboBox4.Text == "")
                {
                    errorProvider1.SetError(comboBox4, "El Combrobante de Pago se encuentra vacio");
                }
                else
                {
                    errorProvider1.SetError(comboBox4, "Agrege el Combrobante de Pago correctamente");
                }
            }
            if (comboBox3.Text == "")
            {
            }
            else
            {
                if (0 == int.Parse((this.clienteTableAdapter.Scalarexiste(comboBox3.Text)).ToString()))
                {
                    errorProvider1.SetError(comboBox3, "Agrege el Cliente correctamente");
                }
            }


            if(null == this.trabajadorTableAdapter.Scalarverifcod(comboBox2.Text))
            {
                contador++;
                errorProvider1.SetError(comboBox2, "El Rut del trabajador es incorrecto");
            }

            if (null == this.productoTableAdapter.Scalarcodigo(comboBox1.Text)) 
            {
                contador++;
                errorProvider1.SetError(comboBox1, "El Nombre de producto no existe");
            }
            if (contador == 0)
            {
                int H;
                H = dataGridView1.RowCount;
                if (H > 0)
                {
                    DialogResult result;
                    result = MessageBox.Show(this, "Realizar  venta \n - " + label6.Text, "Confirmacion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {

                        //Llenar Venta
                        int codigo = int.Parse((this.ventaTableAdapter.Scalarcontar()).ToString()) + 1;
                        int montofinal = int.Parse((label6.Text).ToString());
                        string comprobante = comboBox4.Text;
                        string mediopago = comboBox5.Text;
                        DateTime hora = DateTime.Now;
                        int sucursal = int.Parse((this.trabajadorTableAdapter.Scalarsucursal(comboBox2.Text)).ToString());
                        string trabajador = comboBox2.Text;
                        string cliente;
                        if (comboBox3.Text == "")
                        {
                            cliente = "none";
                        }
                        else {
                            cliente = comboBox3.Text;
                        }
                        this.ventaTableAdapter.Insert(codigo, montofinal, comprobante, mediopago, hora, sucursal, trabajador, cliente);


                        for (int i = 0; i < H; i++)
                        {
                            //agrega a detalle
                            string nombre = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                            int cantidad = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                            int preciocosto = int.Parse(this.productoTableAdapter.Scalarpreciocosto(nombre).ToString());
                            int precioventa = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            this.detalleTableAdapter.Insert(codigo, nombre, cantidad, preciocosto, precioventa);

                            //disminuir stock
                            int codprod = int.Parse((this.productoTableAdapter.Scalarcodigo(nombre)).ToString());
                            int f = int.Parse((this.stockTableAdapter.Scalarstock(codprod, sucursal)).ToString());
                            f = f - cantidad;
                            this.stockTableAdapter.Updatestock2(codprod, sucursal, f, codprod, sucursal);
                        }

                        //borra todo!
                        int s;
                        s = dataGridView1.RowCount;
                        if (s > 0)
                        {
                            for (int j = 0; j < H; j++)
                            {
                                int fila = dataGridView1.CurrentRow.Index;
                                dataGridView1.Rows.RemoveAt(fila);
                            }
                            label5.Text = "0";
                            final = 0;
                            MessageBox.Show(this, " Venta Realizada Correctamente", "Gracias!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No a agregado Adquirido productos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los Datos de venta");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int H;
            H = dataGridView1.RowCount;
            if (H > 0)
            {
                for (int i = 0; i < H; i++)
                {
                    int fila = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.RemoveAt(fila);
                }
                label6.Text = "0";
            }
            else
            {
                MessageBox.Show(this, "No hay producto agregados a la Venta.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int H;
            H = dataGridView1.RowCount;
            if (H > 0)
            {
                int fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(fila);


                int a, b, c;
                a = dataGridView1.RowCount;
                final = 0;
                for (int i = 0; i < a; i++)
                {
                    b = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    c = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    final = final + (b * c);
                    dataGridView1.Rows[i].Cells[4].Value = final;
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
