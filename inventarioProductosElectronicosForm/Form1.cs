using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventarioProductosElectronicosForm
{
    public partial class Form1 : Form
    {
        clsInventario objInventario = new clsInventario(null, 0, 0, null);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                objInventario.clsAgregarProducto(txtNombre.Text, Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text), listBoxProductos);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            objInventario.clsBuscarProducto(txtBuscarProducto.Text, listBoxProductos);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            objInventario.clsVenderProducto(txtNombreProductoVender.Text, int.Parse(txtCantidadVenderProducto.Text), listBoxProductos);
        }
    }
}
