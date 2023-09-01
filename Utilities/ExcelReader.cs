using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Utilities
{
    public class ExcelReader
    {
        //C:\Users\SHIVARAJ GUTTEDAR\source\repos\OrangeHRM\Data\DataReader.xlsx
        //C:\\Users\\SHIVARAJ GUTTEDAR\\Desktop\\DataRead.xlsx
        public IEnumerable<Dictionary<string, string>> ReadData()
        {
            String dirs = AppDomain.CurrentDomain.BaseDirectory;
            String path = dirs.Replace("bin\\Debug\\net6.0\\", "Data\\DataReader.xlsx");
            FileInfo f = new FileInfo("C:\\Users\\SHIVARAJ GUTTEDAR\\Desktop\\DataRead.xlsx");
            ExcelPackage e = new ExcelPackage(f);

            int n = e.Workbook.Worksheets.Count;
            for (int i = 0; i < n; i++)
            {
                if (e.Workbook.Worksheets[i].ToString() == "Sheet1")
                {
                    ExcelWorksheet ew = e.Workbook.Worksheets[i];
                    int r = ew.Dimension.Rows;
                    int c = ew.Dimension.Columns;

                    List<string> columnNames = new List<string>();
                    for (int k = 1; k <= c; k++)
                    {
                        columnNames.Add(ew.Cells[1, k].Value?.ToString().Trim());
                    }

                    for (int j = 2; j <= r; j++)
                    {
                        Dictionary<string, string> rowData = new Dictionary<string, string>();
                        for (int k = 1; k <= c; k++)
                        {
                            string columnName = columnNames[k - 1];
                            string cellValue = ew.Cells[j, k].Value?.ToString().Trim();
                            rowData[columnName] = cellValue;
                        }
                        yield return rowData;
                    }
                }
            }
        }

    }

}
