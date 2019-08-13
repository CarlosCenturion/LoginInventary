using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Vista
{
    public partial class fInventory : Form
    {
        string Usuario = null;

        CC_Productos prod = new CC_Productos();

        bool EditMod = false;
        string EditID = null;

        // Funciones Princiaples


        // Inicializacion

        public fInventory(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }        

        // Primera Carga
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Usuario numero " + Usuario;
            CC_Productos prod2 = new CC_Productos();
            dataGridView1.DataSource = prod2.RefrescarProductos();
            dataGridView1.Columns["Id"].Visible = false;
        }

        // Agregar prodcuto
        public void AgregarProd()
        {
            prod.AgregarProducto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            MostrarProductos();
        }

        // Eliminar Producto
        public void EliminarProd()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                prod.EliminarProducto(id);
            }
            else
            {
                MessageBox.Show("Seleccione al menos un producto", "Error");
            }
        }
        
        // Mostrar Prodcutos

            public void MostrarProductos()
        {
            CC_Productos prod2 = new CC_Productos();
            dataGridView1.DataSource = prod2.RefrescarProductos();
        }

        // Modificar Productos
        
            public void EditarProd()
        {

            if (!EditMod)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    EditMod = true;
                    button3.Text = "Guardar";

                    EditID = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells["producto"].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();

                }
                else
                {
                    MessageBox.Show("Por favor seleccione el producto a editar", "Error");
                }
            }
            else if (EditMod)
            {
                EditMod = false;
                button3.Text = "Editar";
                prod.EditarProducto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, EditID);
                
            }
           
        }

        // Botones

        //Boton Agrega productos
        private void Button1_Click(object sender, EventArgs e)
        {
            AgregarProd();
            MostrarProductos();           
        }

        //Boton Elimina Productos
        private void Button2_Click(object sender, EventArgs e)
        {
            EliminarProd();
            MostrarProductos();
        }

        // Boton Editar
        private void Button3_Click(object sender, EventArgs e)
        {
            EditarProd();
            MostrarProductos();           
        }
    }
}
