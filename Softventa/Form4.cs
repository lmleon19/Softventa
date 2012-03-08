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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarproductoform a = new Agregarproductoform();
            a.MdiParent = this;
            a.Show();
        }

        

        private void modificiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarproductoform c = new Modificarproductoform();
            c.MdiParent = this;
            c.Show();
        }

        private void listarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarproductoform d = new Listarproductoform();
            d.MdiParent = this;
            d.Show();
        }

        private void agregarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarcategoriaform r = new Agregarcategoriaform();
            r.MdiParent = this;
            r.Show();
        }

        private void modificarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarcategoriaform f = new Modificarcategoriaform();
            f.MdiParent = this;
            f.Show();
        }

        private void agregarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarsucursalform g = new Agregarsucursalform();
            g.MdiParent = this;
            g.Show();
        }

        

        private void modificarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarsucursalform i = new Modificarsucursalform();
            i.MdiParent = this;
            i.Show();
        }

        private void listarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarsucursalform j = new Listarsucursalform();
            j.MdiParent = this;
            j.Show();
        }

        private void agregarProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Agregarproveedoresform k = new Agregarproveedoresform();
            k.MdiParent = this;
            k.Show();
        }

        

        private void modificarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarproveedoresform m = new Modificarproveedoresform();
            m.MdiParent = this;
            m.Show();
        }

        private void listarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarproveedoresform n = new Listarproveedoresform();
            n.MdiParent = this;
            n.Show();
        }

        private void agregarPrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarprivilegiosform n = new Agregarprivilegiosform();
            n.MdiParent = this;
            n.Show();
        }

        

        private void modificarPrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarprivilegiosform n = new Modificarprivilegiosform();
            n.MdiParent = this;
            n.Show();
        }

        private void listarPrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarprivilegiosform n = new Listarprivilegiosform();
            n.MdiParent = this;
            n.Show();
        }

        private void agregarTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregartrabajadorform n = new Agregartrabajadorform();
            n.MdiParent = this;
            n.Show();
        }

        

        private void modificarTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificartrabajadorform n = new Modificartrabajadorform();
            n.MdiParent = this;
            n.Show();
        }

        private void listarTrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listartrabajadorform n = new Listartrabajadorform();
            n.MdiParent = this;
            n.Show();
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarclienteform n = new Agregarclienteform();
            n.MdiParent = this;
            n.Show();
        }

        

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarclienteform n = new Modificarclienteform();
            n.MdiParent = this;
            n.Show();
        }

        private void listarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarclienteform n = new Listarclienteform();
            n.MdiParent = this;
            n.Show();
        }

        private void agregarProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Agregarprodproveform n = new Agregarprodproveform();
            n.MdiParent = this;
            n.Show();
        }

        

        private void modificarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarprodproveform n = new Modificarprodproveform();
            n.MdiParent = this;
            n.Show();
        }

        private void listarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listarprodproveform n = new Listarprodproveform();
            n.MdiParent = this;
            n.Show();
        }

        private void agregarAlStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregarstockform n = new Agregarstockform();
            n.MdiParent = this;
            n.Show();
        }

        private void modificacionesDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificarstockform n = new Modificarstockform();
            n.MdiParent = this;
            n.Show();
        }

        private void realizarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Realizarventaform n = new Realizarventaform();
            n.MdiParent = this;
            n.Show();
        }

        private void productoACategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productocategoriaform n = new Productocategoriaform();
            n.MdiParent = this;
            n.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Desarrollado por: Luis Miguel Leon (about.me/luiscleverboy)");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Realizarventaform d = new Realizarventaform();
            d.MdiParent = this;
            d.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Listarproductoform d = new Listarproductoform();
            d.MdiParent = this;
            d.Show();
        }
    }
}
