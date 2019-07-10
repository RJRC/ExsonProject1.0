using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADL;

using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace BLL
{
    /// <summary>
    /// The ReportsBLL class 
    /// Contains all methods for the reports in the Business Logic Layer.
    /// </summary>
    public class ReportsBLL
    {

        /// <summary>
        /// The getStatusValues method 
        /// Get the status from the ReportsADL class.
        /// </summary>
        ///<return>
        /// Returns a list with the status information.
        ///</return>
        public List<string> getStatusValues()
        {

            return new ReportsADL().getStatusValuesFromDB();
        }

        

        /// <summary>
        /// The downloadReport method 
        /// Download a report with the orders information.
        /// </summary>
        ///<return>
        /// Returns true if the download is success and false if don't .
        ///</return>
        ///<param name="dataGridView_ShowAllData">
        /// This is the gridview with the information to download.
        ///</param>
        public bool downloadReport(DataGridView dataGridView_ShowAllData)
        {

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            for (int x = 1; x < dataGridView_ShowAllData.Columns.Count + 1; x++)
            {
                xlWorkSheet.Cells[1, x] = dataGridView_ShowAllData.Columns[x - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView_ShowAllData.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_ShowAllData.Columns.Count; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = dataGridView_ShowAllData.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Reporte Compuelecta";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {

                xlWorkBook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                return true;
            }
            else
            {
                return false;
            }





        }

        /// <summary>
        /// The totalCostsYear method
        /// Returns the total cost in years
        /// </summary>
        /// <returns>
        /// Returns the total cost in years
        /// </returns>
        public DataTable totalCostsYear()
        {
            return new ReportsADL().totalCostsYear();
        }


        /// <summary>
        /// The showComparativeCostsAndSalesMonth method
        /// Show comparative cost and sales
        /// </summary>
        /// <returns>
        /// Returns a datatable with comparative information. 
        /// </returns>
        public DataTable showComparativeCostsAndSalesMonth()
        {
            return new ReportsADL().showComparativeCostsAndSalesMonth();
        }



        /// <summary>
        /// The releaseObject method 
        /// Try if the download has an error.
        /// </summary>
        ///<param name="obj">
        /// This is the obj to try.
        ///</param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("ERROR " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }

}