using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    public partial class Add : Form
    {
        private OrderBLL orderBLL = new OrderBLL();
        private ClientBLL clientBLL = new ClientBLL();
        private String orderUpdate = "";
        public Add(String idUpdate)
        {
            InitializeComponent();
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

        public Add()
        {
            InitializeComponent();
            lb_State.Visible = false;
            cb_Status.Visible = false;
            orderBLL.fillProviderComboBox(cbProvider);
            clientBLL.fillClientComboBox(cbClient);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            AddClient route = new AddClient();
            route.ShowDialog();
        
        }


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


    }
}
