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
    public partial class fMain : Form
    {
        CC_Usuarios user = new CC_Usuarios();

        public fMain()
        {
            InitializeComponent();
        }

        //Login Clic
        private void Button1_Click(object sender, EventArgs e)
        {
           
             
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           

        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text.Length <= 0)
            {
                textBox1.Text = "Usuario";
            }
        }

        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 0)
            {
                textBox2.Text = "Contraseña";
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                user.AgregarUsuario(textBox1.Text, textBox2.Text);
                MessageBox.Show("Usuario Creado Exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario! " + ex);
            }

            textBox1.Clear();
            textBox2.Clear();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Pasando a segundo plano...";
            notifyIcon1.ShowBalloonTip(50);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = user.LogIn(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = dt;
            //dataGridView.Rows[4].Cells["Name"].Value.ToString();

            if (dt.Rows.Count > 0)
            {
                fInventory frm = new fInventory(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                frm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos");
            }
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
