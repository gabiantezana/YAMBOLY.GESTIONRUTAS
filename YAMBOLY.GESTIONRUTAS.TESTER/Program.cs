using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation;

namespace YAMBOLY.GESTIONRUTAS.TESTER
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new MapViewModel();

        }

        private void SaveReport(MapViewModel model)
        {
            IWorkbook workbook = new HSSFWorkbook();
            MemoryStream memoryStream = new MemoryStream();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow headerRow = sheet.CreateRow(0);

            headerRow.CreateCell(0).SetCellValue("Celda 1");
            headerRow.CreateCell(0).SetCellValue("Celda 2");
            headerRow.CreateCell(0).SetCellValue("Celda 3");
            headerRow.CreateCell(0).SetCellValue("Celda 4");
            headerRow.CreateCell(0).SetCellValue("Celda 5");


            /*
            // handling header.
            foreach (DataColumn column in sourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in sourceTable.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }*/

            workbook.Write(memoryStream);
            memoryStream.Flush();

            
        }
    }
}
