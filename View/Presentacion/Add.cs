using BLL;
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
    public partial class Add : Form
    {

        private OrderBLL bll = new OrderBLL();
        private String orderUpdate = "";
        public Add(String idUpdate)
        {
            InitializeComponent();
            this.orderUpdate = idUpdate;

            if(!orderUpdate.Equals(""))
            {
                DataTable dataTableOrder = new DataTable();
                DataTable dataTableAllState = new DataTable();

                dataTableOrder = bll.showOrderByID(orderUpdate);
                dataTableAllState = bll.showAllState();

                cb_State.DataSource = dataTableAllState;
                cb_State.DisplayMember = "DesceiptionState";
                cb_State.ValueMember = "StateID";

                DataRow dataRow = dataTableOrder.Rows[0];

                txtOrderNum.Text = dataRow["N. Orden"].ToString();
                txtClient.Text = dataRow["Cliente"].ToString();
                txtDescription.Text = dataRow["Descripción"].ToString();
                txtCostPrice.Text = dataRow["Costo Precio"].ToString();
                txtlbSalePrice.Text = dataRow["Costo Venta"].ToString();
                txtCompany.Text = dataRow["Proveedor"].ToString();
                txtLink.Text = dataRow["Link"].ToString();
                richTextBox1.Text = dataRow["Comentario"].ToString();
                String fecha = dataRow["Fecha"].ToString();
                dtOrderDate.Value = DateTime.Parse(dataRow["Fecha"].ToString());
            }
            
        }

        public Add()
        {
            InitializeComponent();
            lb_State.Visible = false;
            cb_State.Visible = false;
        }
        private BusinessLogicLayer businessLogicLayer = new BusinessLogicLayer();

        private void Button1_Click(object sender, EventArgs e)
        {
            AddClient route = new AddClient();
            route.ShowDialog();
        
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(txtOrderNum.Text.Trim().Equals("") && txtClient.Text.Trim().Equals("") && txtOrderNum.Text.Trim().Equals("") && txtDescription.Text.Trim().Equals("") && txtCostPrice.Text.Trim().Equals("") && txtlbSalePrice.Text.Trim().Equals("") &&
                txtCompany.Text.Trim().Equals("") && txtLink.Text.Trim().Equals("") && richTextBox1.Text.Trim().Equals("")))
            {
                String orderID = txtOrderNum.Text;
                String nameClient = txtClient.Text;
                String orderNumber = txtOrderNum.Text;
                String description = txtDescription.Text;
                String costPrice = txtCostPrice.Text;
                String salePrice = txtlbSalePrice.Text;
                String provider = txtCompany.Text;
                String linkProduct = txtLink.Text;
                String annotation = richTextBox1.Text;
                DateTime dateOrder = dtOrderDate.Value.Date;

                double costPriceNumber = 0;
                double SalePriceNumber = 0;


                if (double.TryParse(txtCostPrice.Text, out costPriceNumber) && double.TryParse(txtlbSalePrice.Text, out SalePriceNumber))
                {
                    if(this.orderUpdate.Equals(""))
                    {
                        bll.addOrder(int.Parse(orderID), provider, nameClient, dateOrder, linkProduct, description, annotation, costPriceNumber, SalePriceNumber);
                        txtOrderNum.Text = "";
                        txtClient.Text = "";
                        txtDescription.Text = "";
                        txtCostPrice.Text = "";
                        txtlbSalePrice.Text = "";
                        txtCompany.Text = "";
                        txtLink.Text = "";
                        richTextBox1.Text = "";
                    } else
                    {
                        int state = Convert.ToInt32(cb_State.SelectedValue);
                        bll.addOrder(int.Parse(orderID), provider, state, nameClient, dateOrder, linkProduct, description, annotation, costPriceNumber, SalePriceNumber);
                        txtOrderNum.Text = "";
                        txtClient.Text = "";
                        txtDescription.Text = "";
                        txtCostPrice.Text = "";
                        txtlbSalePrice.Text = "";
                        txtCompany.Text = "";
                        txtLink.Text = "";
                        richTextBox1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese solo numero en los campos de costo y precio venta");
                    txtCostPrice.Text = "";
                    txtlbSalePrice.Text = "";
                }


            }
            else
            {
                MessageBox.Show("Por favor ingrese todos los datos que se solicitan");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOrderNum.Text = "";
            txtClient.Text = "";
            txtDescription.Text = "";
            txtCostPrice.Text = "";
            txtlbSalePrice.Text = "";
            txtCompany.Text = "";
            txtLink.Text = "";
            richTextBox1.Text = "";

            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
