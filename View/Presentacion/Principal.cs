using System;
using System.Linq;
using System.Windows.Forms;

namespace View.Presentacion
{

    /// <summary>
    /// The Principal class 
    /// Contains all methods for the menu in the View Layer.
    /// </summary>
    public partial class Principal : Form
    {

        /// <summary>
        /// Builder of Principal class.
        /// </summary>
        public Principal()
        {

            InitializeComponent();
            openForm<Home>();


        }

        /// <summary>
        /// The PicClose_Click method 
        /// Close the window and the application.
        /// </summary>
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

        /// <summary>
        /// The PicMinimize_Click method 
        /// Minimize the window.
        /// </summary>
        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        
        }

        /// <summary>
        /// The PicRestore_Click method 
        /// Minimize the window.
        /// </summary>
        private void PicRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picRestore.Visible = false;
            picMaximize.Visible = true;
        }

        /// <summary>
        /// The PicMaximize_Click method 
        /// Maximize the window.
        /// </summary>
        private void PicMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picRestore.Visible = true;
            picMaximize.Visible = false;
        }


        /// <summary>
        /// The BtnAdd_Click method 
        /// Open a window to add an order.
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            openForm<Add>();
        }

        /// <summary>
        /// The BtnReports_Click method 
        /// Open a tab with the report options.
        /// </summary>
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

        /// <summary>
        /// The BtnClient_Click method 
        /// Open a window with the customers information.
        /// </summary>
        private void BtnClient_Click(object sender, EventArgs e)
        {
            openForm<Customer>();
        }

        /// <summary>
        /// The BtnHome_Click method 
        /// Open a window with the orders information.
        /// </summary>
        private void BtnHome_Click(object sender, EventArgs e)
        {
            openForm<Home>();
        }


        /// <summary>
        /// The BtnGeneralReport_Click method 
        /// Open a window with the orders information.
        /// </summary>
        private void BtnGeneralReport_Click(object sender, EventArgs e)
        {
            openForm<Reports>();
        }


        /// <summary>
        /// The openForm method 
        /// Open a form.
        /// </summary>
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

                if (formPanel.Name=="Home"|| formPanel.Name == "Customer"|| formPanel.Name == "DashBoard" || formPanel.Name == "Reports")
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
                    else if (formPanel.Name == "DashBoard")
                    {
                        openForm<DashBoard>();
                    }
                    else if (formPanel.Name == "Reports")
                    {
                        openForm<Reports>();
                    }



                }
                else
                {
                    formPanel.BringToFront();
                }
            }
        }

        /// <summary>
        /// The btnDashboard_Click method 
        /// Open a window with the dashboard information.
        /// </summary>
        private void btnDashboard_Click(object sender, EventArgs e)
        {

            openForm<DashBoard>();
        }

   
    }
}
