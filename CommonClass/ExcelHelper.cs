using Entity;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonClass
{
    public class ExcelHelper
    {
        /// <summary>
        /// Excel导入成Datable
        /// </summary>
        /// <param name="file">导入路径(包含文件名与扩展名)</param>
        /// <returns></returns>
        public static List<DtsClass> ExcelToTable(string file, Action<string> errFun = null)
        {
            List<DtsClass> dataList = new List<DtsClass>();
            try
            {
                IWorkbook workbook;
                string fileExt = System.IO.Path.GetExtension(file).ToLower();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    if (fileExt == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (fileExt == ".xls")
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        workbook = null;
                        return null;
                    }
                    ISheet sheet = workbook.GetSheetAt(0);
                    //表头  
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();

                    if (header.LastCellNum < 14)
                    {
                        if (errFun != null)
                        {
                            errFun.Invoke("excel格式不正确");
                        }
                        return null;
                    }

                    //数据  
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DtsClass dts = new DtsClass();
                        Type tp = dts.GetType();
                        PropertyInfo[] piArry = tp.GetProperties();
                        for (int j = 0; j < 14; j++)
                        {
                            object data = GetValueType(sheet.GetRow(i).GetCell(j));
                            if (data == null)
                            {
                                tp.GetProperty(piArry[j + 1].Name).SetValue(dts, null);
                            }
                            else
                            {
                                tp.GetProperty(piArry[j + 1].Name).SetValue(dts, data.ToString());
                            }
                        }
                        dts.DTSId = Guid.NewGuid().ToString();
                        dataList.Add(dts);
                    }
                }
            }
            catch (Exception err)
            {
                if (errFun != null)
                {
                    errFun.Invoke(err.ToString());
                }
                return null;
            }
            return dataList;
        }
        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }
        public static bool expotrDataToExcel(string TemplatePath, string exportPath)
        {
            try
            {
                XSSFWorkbook wk = null;
                using (FileStream fs = File.Open(TemplatePath, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite))
                {
                    //把xls文件读入workbook变量里，之后就可以关闭了
                    wk = new XSSFWorkbook(fs);
                    fs.Close();
                }
                XSSFSheet sheet1 = (XSSFSheet)wk.GetSheetAt(0);
                List<DtsClass> list = new List<DtsClass>();
                DtsClass st1 = new DtsClass() { DTSId = Guid.NewGuid().ToString(), DTSNo = "123456" };
                list.Add(st1);
                if (list != null)
                {
                    int nRow = 3;
                    string nextFirstTxt = string.Empty;

                    foreach (DtsClass item in list)
                    {
                        IRow row = sheet1.CreateRow(nRow);
                        Type tp = item.GetType();
                        PropertyInfo[] piArry = tp.GetProperties();
                        for (int i = 1; i < piArry.Length; i++)
                        {
                            ICell cell = row.CreateCell(i - 1);
                            if (i == 1)
                            {
                                //创建一个超链接对象
                                XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Url);
                                link.Address = "https://www.baidu.com";
                                cell.Hyperlink = link;
                            }
                            object filedValue = tp.GetProperty(piArry[i].Name).GetValue(item, null);
                            if (filedValue == null)
                            {
                                cell.SetCellValue("");
                            }
                            else
                            {
                                cell.SetCellValue(filedValue.ToString());
                            }
                        }
                        nRow++;
                    }
                }
                //创建文件
                using (FileStream files = new FileStream(exportPath, FileMode.Create))
                {
                    wk.Write(files);
                }
            }
            catch (Exception err)
            {

                return false;
            }
            return true;
        }
    }
}
