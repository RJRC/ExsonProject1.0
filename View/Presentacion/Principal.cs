using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Presentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PicClose_Click(object sender, EventArgs e)
        {

            const string message= "Está a punto de cerrar. ¿Está seguro de que quiere continuar?";
            const string title= "¿Cerrar?";
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult==DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        
        }

        private void LbMenu_Click(object sender, EventArgs e)
        {

        }

        private void PicRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picRestore.Visible = false;
            picMaximize.Visible = true;
        }

        private void PicMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picRestore.Visible = true;
            picMaximize.Visible = false;
        }

        private void newPanel(object newForm) {
            if (this.panelFill.Controls.Count>0)
            {
                this.panelFill.Controls.RemoveAt(0);
            }

            Form form = newForm as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelFill.Controls.Add(form);
            this.panelFill.Tag = form;
            form.Show();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            newPanel(new Add());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            newPanel(new Reports());
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            newPanel(new Customer());
        }

        private void PanelBottonBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            newPanel(new Home());
        }
    }
}
