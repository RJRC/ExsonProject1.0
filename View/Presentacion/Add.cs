﻿using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    /// <summary>
    /// The Customer class 
    /// Contains all methods for the Customer in the View Layer.
    /// </summary>
    public partial class Add : Form
    {
        /// <summary>
        /// Variable with the instance of OrderBLL.
        /// </summary>
        private OrderBLL orderBLL = new OrderBLL();

        /// <summary>
        /// Variable with the instance of ClientBLL.
        /// </summary>
        private ClientBLL clientBLL = new ClientBLL();

        /// <summary>
        /// Variable with the order id.
        /// </summary>
        private String orderUpdate = "";

        /// <summary>
        /// Builder of Add class.
        /// </summary>
        public Add(String idUpdate)
        {
            InitializeComponent();

            cbClient.MaxLength = 20;
            txtOrderNum.MaxLength = 20;
            txtDescription.MaxLength = 50;
            cbProvider.MaxLength = 30;
            cb_Status.MaxLength = 20;
            txtLink.MaxLength = 200;
            txtAnnotation.MaxLength = 500;


            orderBLL.fillProviderComboBox(cbProvider);
            clientBLL.fillClientComboBox(cbClient);
            orderBLL.fillStatusComboBox(cb_Status);

            this.orderUpdate = idUpdate;

            if(!orderUpdate.Equals(""))
            {

                DataTable dataTableOrder = new DataTable();
                DataTable dataTableAllState = new DataTable();

                dataTableOrder = orderBLL.showOrderByID(orderUpdate);

                DataRow dataRow = dataTableOrder.Rows[0];

                txtOrderNum.Text = dataRow["N. Orden"].ToString();
                cbClient.Text = dataRow["Cliente"].ToString();
                txtDescription.Text = dataRow["Descripción"].ToString();
                txtCostPrice.Text = dataRow["Costo Precio"].ToString();
                txtlbSalePrice.Text = dataRow["Costo Venta"].ToString();
                cbProvider.Text = dataRow["Proveedor"].ToString();
                txtLink.Text = dataRow["Link"].ToString();
                txtAnnotation.Text = dataRow["Comentario"].ToString();
                String fecha = dataRow["Fecha"].ToString();
                dtOrderDate.Value = DateTime.Parse(dataRow["Fecha"].ToString());
            }
            
        }

        /// <summary>
        /// Builder of Add class.
        /// </summary>
        public Add()
        {
            InitializeComponent();
            cbClient.MaxLength = 20;
            txtOrderNum.MaxLength = 20;
            txtDescription.MaxLength = 50;
            cbProvider.MaxLength = 30;
            cb_Status.MaxLength = 20;
            txtLink.MaxLength = 200;
            txtAnnotation.MaxLength = 500;

            lb_State.Visible = false;
            cb_Status.Visible = false;
            orderBLL.fillProviderComboBox(cbProvider);
            clientBLL.fillClientComboBox(cbClient);
        }


        /// <summary>
        /// The Button1_Click method 
        /// Open a window to add a client.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            AddClient route = new AddClient();
            route.ShowDialog();
        
        }

        /// <summary>
        /// The btnSave_Click method 
        /// Save an Order.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtOrderNum.Text.Trim().Equals("") && !cbClient.Text.Trim().Equals("") && !txtOrderNum.Text.Trim().Equals("") && !txtDescription.Text.Trim().Equals("") && !txtCostPrice.Text.Trim().Equals("") && !txtlbSalePrice.Text.Trim().Equals("") &&
                !cbProvider.Text.Trim().Equals("") && !txtLink.Text.Trim().Equals(""))
            {
                String orderID = txtOrderNum.Text;
                String nameClient = cbClient.Text;
                String orderNumber = txtOrderNum.Text;
                String description = txtDescription.Text;
                String costPrice = txtCostPrice.Text;
                String salePrice = txtlbSalePrice.Text;
                String provider = cbProvider.Text;
                String linkProduct = txtLink.Text;
                String annotation = txtAnnotation.Text;
                DateTime dateOrder = dtOrderDate.Value.Date;
                string status = cb_Status.Text;

                double costPriceNumber = 0;
                double SalePriceNumber = 0;


                if (!double.TryParse(txtCostPrice.Text, out costPriceNumber))
                {
                    MessageBox.Show("Ingrese solo números en el campo precio de costo");
                    txtCostPrice.Text = "";
                }
                else if (!double.TryParse(txtlbSalePrice.Text, out SalePriceNumber))
                {
                    MessageBox.Show("Ingrese solo números en el campo precio de venta");
                    txtlbSalePrice.Text = "";
                }
                else
                {
                    orderBLL.addOrder(int.Parse(orderID), provider, nameClient, dateOrder, linkProduct, description, annotation, costPriceNumber, SalePriceNumber, status);
                    txtOrderNum.Text = "";
                    cbClient.Text = "";
                    txtDescription.Text = "";
                    txtCostPrice.Text = "";
                    txtlbSalePrice.Text = "";
                    cbProvider.Text = "";
                    txtLink.Text = "";
                    txtAnnotation.Text = "";

                    
                    MessageBox.Show("¡Guardado con éxito!");

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese todos los datos que se solicitan");
            }
        }

        /// <summary>
        /// The btnCancel_Click method 
        /// Cancel an Order.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!txtOrderNum.Text.Trim().Equals("") || !cbClient.Text.Trim().Equals("") || !txtOrderNum.Text.Trim().Equals("") 
                || !txtDescription.Text.Trim().Equals("") || !txtCostPrice.Text.Trim().Equals("") || !txtlbSalePrice.Text.Trim().Equals("") ||
               !cbProvider.Text.Trim().Equals("") || !txtLink.Text.Trim().Equals("")) {

                const string message = "Si continua perderá todos los datos sin guardar. " +
                "\n¿Está seguro de que quiere continuar?";
                const string title = "¿Cerrar?";
                DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    txtOrderNum.Text = "";
                    cbClient.Text = "";
                    txtDescription.Text = "";
                    txtCostPrice.Text = "";
                    txtlbSalePrice.Text = "";
                    cbProvider.Text = "";
                    txtLink.Text = "";
                    txtAnnotation.Text = "";

                    this.Close();
                }

            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// The txtCostPrice_KeyPress method 
        /// Validate the price.
        /// </summary>
        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtlbSalePrice_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The txtlbSalePrice_KeyPress method 
        /// Validate the price.
        /// </summary>
        private void txtlbSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// The cbClient_KeyPress method 
        /// Validate the client name.
        /// </summary>
        private void cbClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
