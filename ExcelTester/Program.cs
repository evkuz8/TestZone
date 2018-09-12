using CsvHelper;
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

            string fullFileName = path2 + "test.csv";

            //using (FileStream fs = new FileStream(path, FileMode.Create,FileAccess.Write))
            //{
            //    using (StreamWriter writer = new StreamWriter(fs))
            //    {
            //        writer.WriteLine("!!!!");
            //    }
            //}  

            TableWriter tableWriter = new TableWriter();
            tableWriter.Write(path2, 49, "csv");
            tableWriter.Write(path2, 49, "xls");
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
            string fullFileName = "";

            string[] nameCells = new string[4];
            string[] valueCells = new string[4];

            using (u436263_crmContext db = new u436263_crmContext())
            {
                CrmDemands demand = db.CrmDemands.Where(d => d.Id == idDemand).FirstOrDefault();

                nameCells[0]= "FIO";
                nameCells[1]= "Phone";
                nameCells[2]= "City";
                nameCells[3]= "Addres";

                valueCells[0] = demand.Fio;
                valueCells[1] = demand.Phone;
                valueCells[2] = demand.City;
                valueCells[3] = demand.Street;
            }


            switch (type)
            {
                case "xlsx":
                    filename += ".xlsx";
                    workbook = new XSSFWorkbook();
                    WriteDemandExcel(workbook, fullFileName = path + filename, nameCells, valueCells);
                    break;

                case "xls":
                    filename += ".xls";
                    workbook = new HSSFWorkbook();
                    WriteDemandExcel(workbook, fullFileName = path + filename, nameCells, valueCells);
                    break;

                case "csv":
                    filename += ".csv";
                    WriteDemandCSV(fullFileName = path + filename, nameCells, valueCells);
                    break;
                default:
                    throw new Exception("Sorry we have no such format, pls try one of them : .xlsx .xls" /*+" .csv"*/ );
                    break;
            }



        }

        private void WriteDemandExcel(IWorkbook workbook, string fullFileName, string[] nameCells, string[] valueCells)
        {
            ISheet sheet = workbook.CreateSheet("Sheet");
            ICreationHelper creationHelper = workbook.GetCreationHelper();

            var font = workbook.CreateFont();
            font.IsBold = true;
            var style = workbook.CreateCellStyle();
            style.SetFont(font);

            IRow namesRow = sheet.CreateRow(0);
            for (int i = 0; i < nameCells.Length; i++)
            {
                ICell cell = namesRow.CreateCell(i);
                cell.SetCellValue(creationHelper.CreateRichTextString(nameCells[i]));
                cell.CellStyle = style;
            }

            IRow valuesRow = sheet.CreateRow(1);
            for (int i = 0; i < valueCells.Length; i++)
            {
                ICell cell = valuesRow.CreateCell(i);
                cell.SetCellValue(creationHelper.CreateRichTextString(valueCells[i]));
            }

            using (FileStream fs = new FileStream(fullFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

        }

        private void WriteDemandCSV(string fullFileName, string[] nameCells, string[] valueCells)
        {
            string names="", values="";

            for (int i = 0; i < nameCells.Length; i++)
            {
                names += nameCells[i];
                values += valueCells[i];

                if (i+1 != nameCells.Length)
                {
                    names += ',';
                    values += ',';
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(fullFileName, false, Encoding.UTF8))
            {
                streamWriter.WriteLine(names);
                streamWriter.WriteLine(values);
            }
        }
    }
}
