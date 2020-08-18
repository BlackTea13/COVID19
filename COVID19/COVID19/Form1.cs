using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms.VisualStyles;

namespace COVID19
{
    public partial class Form1 : Form
    {
        string filepath;
        List<Country> Countries = new List<Country>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void extractData()
        {
            //find filepath from file dialog
            string selectedFileName = "";
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = ofd.FileName;
            }
            filepath = selectedFileName;


            //turns .xlsx file into temp .csv
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            string tempfilepath = @"C:\Temp\output.csv"; //FIND SOMEWHERE BETTER TO STORE THIS
            xlWorkbook.SaveAs(tempfilepath, Excel.XlFileFormat.xlCSVWindows);
            xlWorkbook.Close(false);
            xlApp.Quit();

            //iterate over rows in temp .csv
            string countryName = "";
            string date = "";
            string newCases = "";
            string newDeaths = "";
            string newCasesPerMil = "";
            string newDeathsPerMil = "";

            int[] indexes = new int[] { 6, 8, 10, 11 };
            string[] values = new string[4];


            using (TextFieldParser csvParser = new TextFieldParser(tempfilepath))
            {
                csvParser.SetDelimiters(new string[] { "," });

                csvParser.ReadLine();

                string[] tempFields;
                while(!csvParser.EndOfData)
                {
                    int i = 0;
                    string[] fields = csvParser.ReadFields();
                    countryName = fields[3];
                    date = fields[4];

                    foreach(int index in indexes)
                    {
                        if(fields[index] != null)
                        {
                            values[i] = fields[index];
                        }
                        else
                        {
                            values[i] = "";
                        }
                        i++;
                    }
                    newCases = values[0];
                    newDeaths = values[1];
                    newCasesPerMil = values[2];
                    newDeathsPerMil = values[3];

                    Day d = new Day(date, Int16.Parse(newCases), Int16.Parse(newDeaths), Double.Parse(newCasesPerMil), Double.Parse(newDeathsPerMil));


                    tempFields = fields;

                }

            }

            MessageBox.Show("Data uploaded");
        }

            private void browsebtn_Click(object sender, EventArgs e) //browse button
            {
                extractData();
            }
    }
}
