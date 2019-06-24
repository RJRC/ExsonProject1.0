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


namespace BLL
{
    public class ReportsBLL
    {

        public List<string> getStatusValues()
        {

            return new ReportsADL().getStatusValuesFromDB();
        }


        public bool downloadReport10(DataGridView dataGridView_ShowAllData) {

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
            else {
                return false;
            }


           


        }
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