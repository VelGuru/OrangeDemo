using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Config
{
    public class ExcelReader
    {
        public static string FileConnection()
        {
            string conStrContainer = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties ='Excel 8.0;HDR={1}';";
            string path = ConfigurationManager.AppSettings["TestDatapath"];
            string connectionString = String.Format(conStrContainer, path, "Yes");
            return connectionString;
        }

        public static string GetTestData(string sheetname,string columnname) 
        {
            OleDbConnection con = new OleDbConnection(FileConnection());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = $"select * from [{sheetname}$]";
            dataAdapter.SelectCommand = cmd;
            
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt.Rows[0][columnname].ToString();
        }


        public static string GetTestDataByRow(int row,string sheetname, string columnname)
        {
            OleDbConnection con = new OleDbConnection(FileConnection());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = $"select * from [{sheetname}$]";
            dataAdapter.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt.Rows[row][columnname].ToString();
        }
    }
}
