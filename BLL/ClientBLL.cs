using System;
using ADL;

namespace BLL
{
    public class ClientBLL
    {
        public bool deleteClientBLL(int id) {
            try
            {
                ClientADL clientADL = new ClientADL();
                return clientADL.deleteClientADL(id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
