using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalOrderFulfillment.Views
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Inventory : System.Windows.Controls.UserControl
    {
        public Inventory()
        {
            InitializeComponent();
        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            //Set a filter to display only csv files
            openFileDlg.Filter = "csv files (*.csv)| *csv| All files(*.*)|*.*";
            //Get file path and display in text box
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDlg.FileName;
            }

        }

        private void Import_Click(object sender, EventArgs e)
        {
            BindDataCSV(txtFilePath.Text);
        }
        private void BindDataCSV(string filePath)
        {
            DataTable dt = new DataTable();

            string[] lines = System.IO.File.ReadAllLines(filePath);
            //Convert to a string to manipulate and add headers.
            List<string> newLines = lines.ToList();
            newLines.Insert(0,"Item ID,Warehouse LocatiomID,Quantity in Location");
            newLines.TrimExcess();
            lines = newLines.ToArray();

            // created hearders from the first line of CSV
            string firstLine = lines[0];
            string[] headerLabel = firstLine.Split(',');
             foreach (string word in headerLabel)
             {
                dt.Columns.Add(new DataColumn(word));
             }

            // Add data
            for (int i = 1; i < lines.Length; i++)
            {
                string[] dataWords = lines[i].Split(',');
                DataRow datarow = dt.NewRow();
                int columnIndex = 0;
                    foreach (string word in headerLabel)
                    {
                        datarow[word] = dataWords[columnIndex++];
                    }
                dt.Rows.Add(datarow);
            }

            if (dt.Rows.Count > 0)
            {
                dgvInventory.DataContext = dt;

            }
        }
       
    }
}
