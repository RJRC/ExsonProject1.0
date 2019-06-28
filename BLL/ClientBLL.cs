using System;
using System.Data;
using System.Windows.Forms;
using ADL;
using System.Text.RegularExpressions;

namespace BLL
{
    public class ClientBLL
    {
        public bool deleteClientBLL(string id)
        {
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
            return new ClientADL().getClientsFromDB();
        }

        public DataTable searchClients(string search)
        {
            return new ClientADL().searchClientsInDB(search);
        }




        public void addOrEditClient(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email, String id)
        {
            try
            {
                if (phoneNumber2.Trim().Equals(""))
                    phoneNumber2 = "0";

                if (email.Trim().Equals(""))
                    email = "Sin Correo";

                new ClientADL().addOrEditClientToDB(name, lastName1, lastName2, int.Parse(phoneNumber1), int.Parse(phoneNumber2), email, int.Parse(id));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable showSearchClients(String search)
        {
            int searchId;
            int.TryParse(search, out searchId);
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

        public bool validationEmptyTxt(String name, String fLastName, String sLastName, String phone)
        {

            if (name.Trim().Equals("") || fLastName.Trim().Equals("") || sLastName.Trim().Equals("") ||
                phone.Trim().Equals(""))
                return true;


            return false;
        }

        public bool validationEmailFormat(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
