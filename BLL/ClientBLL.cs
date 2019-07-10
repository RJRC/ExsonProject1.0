using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ADL;

namespace BLL
{

    /// <summary>
    /// The ClientBLL class 
    /// Contains all methods for the clients in Business Logic Layer.
    /// </summary>
    public class ClientBLL
    {

        /// <summary>
        /// The deleteClientBLL method 
        /// Delete a client by an Id.
        /// </summary>
        ///<return>
        /// Returns true if client is delete with success and false if don´t.
        ///</return>
        ///<param name="id">
        /// This is the id of the client to delete.
        ///</param>
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


        /// <summary>
        /// The showClients method 
        /// Show the clients information.
        /// </summary>
        ///<return>
        /// Returns a datatable with the clients information.
        ///</return>
        public DataTable showClients()
        {
            return new ClientADL().getClientsFromDB();
        }


        /// <summary>
        /// The searchClients method 
        /// Search clients.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search clients information.
        ///</return>
        ///<param name="search">
        /// This is what the client wants to search.
        ///</param>
        public DataTable searchClients(string search)
        {
            return new ClientADL().searchClientsInDB(search);
        }



        /// <summary>
        /// The addOrEditClient method 
        /// Add or Edit a client.
        /// </summary>
        ///<param name="name">
        /// This is the name of the client to add or edit.
        ///</param>
        ///<param name="lastName1">
        /// This is the lastName1 of the client to add or edit.
        ///</param>
        ///<param name="lastName2">
        /// This is the lastName2 of the client to add or edit.
        ///</param>
        ///<param name="phoneNumber1">
        /// This is the phoneNumber1 of the client to add or edit.
        ///</param>
        ///<param name="phoneNumber2">
        /// This is the phoneNumber2 of the client to add or edit.
        ///</param>
        ///<param name="email">
        /// This is the email of the client to add or edit.
        ///</param>
        ///<param name="id">
        /// This is the id of the client to add or edit.
        ///</param>
        public bool addOrEditClient(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email, String id)
        {
            try
            {
                if (!int.TryParse(id, out int intId))
                {
                    id += 0;
                }

              if (!int.TryParse(phoneNumber2, out int phone2) )
                {
                    return new ClientADL().addOrEditClientInDB(name, lastName1, lastName2, int.Parse(phoneNumber1), email, int.Parse(id));
                }
                else { 

                return  new ClientADL().addOrEditClientInDB(name, lastName1, lastName2, int.Parse(phoneNumber1), phone2, email, intId);

               }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Error al guardar!\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }





        }


        /// <summary>
        /// The showSearchClients method 
        /// Search clients.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search clients information.
        ///</return>
        ///<param name="search">
        /// This is what the client wants to search.
        ///</param>
        public DataTable showSearchClients(String search)
        {
            int searchId;
            int.TryParse(search, out searchId);
            return new ClientADL().serchClientsInDB(searchId);
        }


        /// <summary>
        /// The fillClientComboBox method 
        /// Fill a ComboBox with the clients information.
        /// </summary>
        ///<param name="comboBox">
        /// This is the combobox to fill.
        ///</param>
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
