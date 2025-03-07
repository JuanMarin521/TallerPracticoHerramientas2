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
        //Juan Pablo Marin - Diego Henao

        //Atributos
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        private static List<clsInventario> productos = new List<clsInventario>();

        //Constructor
        public clsInventario(string nombre, double precio, int cantidad, ListBox listBox)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        //funcion para mostrar los productos - Metodos
        public override string ToString()
        {
            return "Nombre: " + nombre + " Precio: " + precio + " Cantidad: " + cantidad;
        }

        //Metodos
        //Metodo para agregar un producto
        public bool clsAgregarProducto(string nombre, double precio, int cantidad, ListBox listBox)
        {
            try
            {
                //si el nombre esta vacio muestra un mensaje de error
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //si el precio es menor o igual a 0 muestra un mensaje de error
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad del producto debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //si el producto ya existe muestra un mensaje de error
                if (productos.Any(e => e.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("El producto ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //crea un nuevo producto y lo agrega a la lista de productos
                var producto = new clsInventario(nombre, precio, cantidad, listBox);
                //agrega el producto a la lista de productos
                productos.Add(producto);
                //agrega el producto a la lista de productos en el listBox
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
                // Busca el producto en la lista de productos por nombre ignorando mayúsculas y minúsculas
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


                MessageBox.Show($"Producto encontrado: {producto.nombre}, Precio: {producto.precio}, Cantidad: {producto.cantidad}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Busca el producto en la lista de productos por nombre ignorando mayúsculas y minúsculas
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

                // Resta la cantidad vendida a la cantidad del producto
                producto.cantidad -= cantidad;

                // Actualiza la cantidad del producto en la lista
                int index = listBox.Items.IndexOf(producto.ToString());
                //si index es mayor o igual a 0, significa que el producto ya existe en la lista
                if (index >= 0)
                {
                    listBox.Items[index] = producto.ToString();
                }
                else
                {
                    listBox.Items.Add(producto.ToString());
                }

                MessageBox.Show($"Producto vendido: {producto.nombre}, Precio: {producto.precio}, Cantidad: {producto.cantidad}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
