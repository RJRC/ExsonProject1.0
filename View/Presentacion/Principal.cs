using System;
using System.Linq;
using System.Windows.Forms;

namespace View.Presentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            openForm<Home>();

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


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            openForm<Add>();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            if (pnDashboard.Visible)
            {
                pnDashboard.Visible = false;
                pnGeneralReport.Visible = false;
                btnGeneralReport.Visible = false;
                btnDashboard.Visible = false;
            }
            else
            {
                pnDashboard.Visible = true;
                pnGeneralReport.Visible = true;
                btnGeneralReport.Visible = true;
                btnDashboard.Visible = true;
            }
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            openForm<Customer>();
        }


        private void BtnHome_Click(object sender, EventArgs e)
        {
            openForm<Home>();
        }

        private void BtnGeneralReport_Click(object sender, EventArgs e)
        {
            openForm<Reports>();
        }


        //open a new form in the panelFiil
        private void openForm<myForm>()where myForm:Form,new () {
            //find in the colection the form
            Form formPanel=panelFill.Controls.OfType<myForm>().FirstOrDefault();
            //if the form does not exist, a new instance is created
            if (formPanel == null)
            {
                formPanel = new myForm();
                formPanel.TopLevel = false;
                formPanel.Dock = DockStyle.Fill;
                panelFill.Controls.Add(formPanel);
                panelFill.Tag = formPanel;
                formPanel.Show();
                formPanel.BringToFront();
            }
            //If the form exists, it is bring to the front
            else
            {

                if (formPanel.Name=="Home"|| formPanel.Name == "Customer"|| formPanel.Name == "dashBoard")
                {
                    // close the panel and open a new panel with the new data
                    formPanel.Close();

                    if (formPanel.Name == "Home")
                    {
                        openForm<Home>();
                    }
                    else if (formPanel.Name == "Customer")
                    {
                        openForm<Customer>();
                    }
                    else if (formPanel.Name == "dashBoard")
                    {
                        openForm<dashBoard>();
                    }

                   

                }
                else
                {
                    formPanel.BringToFront();
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            openForm<dashBoard>();
            //dashBoard dashBoard = new dashBoard();
            //dashBoard.Show();
        }
    }
}
