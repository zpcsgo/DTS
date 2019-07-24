using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Windows.Forms;
using System.Diagnostics;
using CommonClass;
using Entity;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //当前目录的基本路径
        private static readonly string BASE_Path = Environment.CurrentDirectory.Split(new string[] { "bin" }, StringSplitOptions.RemoveEmptyEntries)[0];
        private static readonly string XML_PATH = BASE_Path + @"data/dataOfDiscover.xml";
        private static readonly string JSON_PATH = BASE_Path + @"data/cacheData.json";
        private static readonly string TEMPLATE_PATH = BASE_Path + @"template/DTS.xlsx";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls";

            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            Nullable<bool> result = ofd.ShowDialog();
            List<DtsClass> list = new List<DtsClass>();
            if (result == true)
            {
                list= ExcelHelper.ExcelToTable(ofd.FileName);
            }
            jsonHelper.WriteJsonFile(JSON_PATH, list);
        }
        string modelExlPath = "";
        private void CreateExcel()
        {
            //创建一个excel对象
            HSSFWorkbook hssfworkbookDown;
            //读入刚复制的要导出的excel文件 
            //路径，打开权限，读取权限
            using (FileStream file = new FileStream(modelExlPath, FileMode.Open, FileAccess.Read))
            {
                hssfworkbookDown = new HSSFWorkbook(file);
                file.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str2 = Environment.CurrentDirectory;
            string[] arr = str2.Split(new string[] { "bin" }, StringSplitOptions.RemoveEmptyEntries);
            modelExlPath = arr[0] + @"template/DTS.xlsx";
            
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";  //文件名
            sfd.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls";  //文件类型
            sfd.ShowDialog();
            ExcelHelper.expotrDataToExcel(modelExlPath, sfd.FileName);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string str2 = Environment.CurrentDirectory;
            string[] arr = str2.Split(new string[] { "bin" }, StringSplitOptions.RemoveEmptyEntries);
            string path = arr[0] + @"data/dataOfDiscover.xml";
            //List<ActiveClass> list= XMLHelper.ReadXMLByPath(path);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string str2 = Environment.CurrentDirectory;
            string[] arr = str2.Split(new string[] { "bin" }, StringSplitOptions.RemoveEmptyEntries);
            string path = arr[0] + @"data/cacheData.json";
             XMLHelper.ReadXMLByPath(arr[0] + @"data/dataOfDiscover.xml");
            //jsonHelper.WriteJsonFile(path,list);
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
