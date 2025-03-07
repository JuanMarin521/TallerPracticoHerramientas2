using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace inventarioProductosElectronicosForm
{
    internal class clsInventario
    {
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        private static List<clsInventario> productos = new List<clsInventario>();

        public clsInventario(string nombre, double precio, int cantidad, ListBox listBox)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public override string ToString()
        {
            return "Nombre: " + nombre + " Precio: " + precio + " Cantidad: " + cantidad;
        }

        public bool clsAgregarProducto(string nombre, double precio, int cantidad, ListBox listBox)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad del producto debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (productos.Any(e => e.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("El producto ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var producto = new clsInventario(nombre, precio, cantidad, listBox);
                productos.Add(producto);
                listBox.Items.Add(producto.ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool clsBuscarProducto(string nombre, ListBox listBox)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var producto = productos.Find(p => p.nombre == nombre);
                if (producto == null)
                {
                    MessageBox.Show("El producto no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (producto.cantidad < cantidad)
                {
                    MessageBox.Show("No hay suficiente cantidad de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                      
                MessageBox.Show("Producto encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool clsVenderProducto(string nombre, int cantidad, ListBox listBox)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad del producto debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (listBox == null)
                {
                    MessageBox.Show("La lista está vacía, ingrese un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Esta linea 
                var producto = productos.FirstOrDefault(e => e.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (producto == null)
                {
                    MessageBox.Show("El producto no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (producto.cantidad < cantidad)
                {
                    MessageBox.Show("No hay suficiente cantidad de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                producto.cantidad -= cantidad;
                listBox.Items[listBox.Items.IndexOf(producto.ToString())] = producto.ToString();
                MessageBox.Show("Producto vendido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }
}
