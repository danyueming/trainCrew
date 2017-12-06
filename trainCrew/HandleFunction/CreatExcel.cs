using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop;

namespace trainCrew.HandleFunction
{
    public class CreatExcel
    {
        public CreatExcel() { }

        public static void Creat()
        {
           
            // 文件保存路径及名称
            string fileName = @"F:\trainCrew\test" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".xlsx";
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelDoc = ExcelApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = ExcelDoc.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelApp.DisplayAlerts = false;

            // 单元格下标是从[1，1]开始的
            xlSheet.Cells[1, 1] = "fitness";

            for (int i = 2; i < Common.fitData.Count(); i++)
            {
                xlSheet.Cells[i, 1] = Common.fitData[i-2];

            }

            // 文件保存
            xlSheet.SaveAs(fileName);
            ExcelDoc.Close(Type.Missing, fileName, Type.Missing);
            ExcelApp.Quit();

        }

    }
}