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
    public partial class userManager : Form
    {
        CC_Usuarios user = new CC_Usuarios();

        public userManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarTablas();
            DG1.Columns["Id"].Visible = false;
        }

        private void BtnADD_Click(object sender, EventArgs e)
        {
            AgregarUsuario();
            RefrescarTablas();
            LimpiarTextBoxes();
        }

        private void LimpiarTextBoxes()
        {
            TB1.Clear();
            TB2.Clear();
        }

        void AgregarUsuario ()
        {
            
            user.AgregarUsuario(TB1.Text, TB2.Text);
        }

        void EliminarUsuario (string id)
        {

            MessageBox.Show("eliminando");
           user.EliminarUsuario(id);
           
        }

        void RefrescarTablas()
        {
            CC_Usuarios user = new CC_Usuarios();
            DG1.DataSource = user.RefrescarUsuarios();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (DG1.SelectedRows.Count > 0)
            {
                string value = DG1.CurrentRow.Cells["Id"].Value.ToString();
                EliminarUsuario(value);
            }
            else
            {
                MessageBox.Show("nada");
            }

            RefrescarTablas();
                      
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fMain frm = new fMain();
            frm.Show();
        }
    }
}
