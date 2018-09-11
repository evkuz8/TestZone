using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +"\\"+ "SomeText.txt"; 
            string path2 = @"C:\Users\Евгений\Downloads\TEST\"; // this works only in downloads

            using (FileStream fs = new FileStream(path, FileMode.Create,FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("!!!!");
                }
            }  

            TableWriter tableWriter = new TableWriter();
            tableWriter.Write(path2, 51, "xlsx");
            Console.WriteLine("ok");
            Console.ReadLine();

        }
    }
    class TableWriter
    {
        public void Write(string path, int idDemand, string type)
        {
            IWorkbook workbook = null;

            string filename = "SomeExcel";
            switch (type)
            {
                case "xlsx":
                    filename += ".xlsx";
                    workbook = new XSSFWorkbook();
                    break;
                case "xls":
                    filename += ".xls";
                    workbook = new HSSFWorkbook();
                    break;
                case "csv":
                    // NEEDS TO MADE
                    //break;
                default:
                    throw new Exception("Sorry we have no such format, pls try one of them : .xlsx .xls" /*+" .csv"*/ );
                    break;
            }


            string fullfilename = path + filename;
            ISheet sheet = workbook.CreateSheet("Sheet");
            ICreationHelper creationHelper = workbook.GetCreationHelper();

            using (u436263_crmContext db = new u436263_crmContext())
            {
                CrmDemands demand = db.CrmDemands.Where(d => d.Id == idDemand).FirstOrDefault();

                IRow namesRow = sheet.CreateRow(0);
                namesRow.CreateCell(0).SetCellValue(creationHelper.CreateRichTextString("FIO"));
                namesRow.CreateCell(1).SetCellValue(creationHelper.CreateRichTextString("Phone"));
                namesRow.CreateCell(2).SetCellValue(creationHelper.CreateRichTextString("City"));
                namesRow.CreateCell(3).SetCellValue(creationHelper.CreateRichTextString("Addres"));

                var font = workbook.CreateFont();
                font.IsBold = true;
                var style = workbook.CreateCellStyle();
                style.SetFont(font);

                foreach (var cell in namesRow.Cells)
                {
                    cell.CellStyle = style;
                }

                IRow valuesRow = sheet.CreateRow(1);
                valuesRow.CreateCell(0).SetCellValue(creationHelper.CreateRichTextString(demand.Fio));
                valuesRow.CreateCell(1).SetCellValue(creationHelper.CreateRichTextString(demand.Phone));
                valuesRow.CreateCell(2).SetCellValue(creationHelper.CreateRichTextString(demand.City));
                valuesRow.CreateCell(3).SetCellValue(creationHelper.CreateRichTextString(demand.Street));

            }

            using (FileStream fs = new FileStream(fullfilename, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

            //File.Copy(fullfilename, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + filename, true);
            //File.Move(fullfilename, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + filename);

            
            


        }
    }
}
