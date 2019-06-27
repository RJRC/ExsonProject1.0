using System;
using System.Data;
using System.Windows.Forms;
using ADL;

namespace BLL
{
    public class ClientBLL
    {
        public bool deleteClientBLL(string id) {
            try
            {
                int.TryParse(id, out int intId);
                return new ClientADL().deleteClientADL(intId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable showClients()
        {
            return  new ClientADL().getClientsFromDB();
        }

        public DataTable searchClients(string search)
        {
            return new ClientADL().searchClientsInDB(search);
        }

        


        public void addOrEditClient(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email, String id)
        {


            new ClientADL().addOrEditClientToDB(name, lastName1, lastName2, int.Parse(phoneNumber1), int.Parse(phoneNumber2), email, int.Parse(id));

        }

        public DataTable showSearchClients(String search)
        {
            int searchId;
            int.TryParse(search, out searchId );
            return new ClientADL().serchClientsInDB(searchId);
        }

        public void fillClientComboBox(ComboBox comboBox)
        {
            DataTable dt = showClients(); ;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
