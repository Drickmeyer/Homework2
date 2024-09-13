using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace FulfillData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<Data>> DataSet = new Dictionary<string, List<Data>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads"; //This will get the path to their downloads directory

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Seperated Value documents (.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                PopulateData(ofd.FileName);

                /*
                 * Identify the following:
                    The state that feels most fulfilled for Males, Females, and Both.
                    All the states that have a mean greater than or equal to 8 for Both. 
                 */

                PopulateListBox("Male", lstMales);
                PopulateListBox("Female", lstFemale);
                PopulateListBox("Both", lstBoth);
                PopulateListBoxForMeanGreaterThan();
            }
        }

        private void PopulateListBox(string gender, ListBox lst)
        {
            double maxMean = 0;

            foreach (var item in DataSet.Keys)
            {
                foreach (var gend in DataSet[item])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean > maxMean)
                        {
                            maxMean = gend.Mean;
                        }
                    }
                }
            }

            foreach (var state in DataSet.Keys)
            {
                foreach (var gend in DataSet[state])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean == maxMean)
                        {
                            lst.Items.Add(state);
                        }
                    }
                }
            }

        }
        private void PopulateListBoxForMeanGreaterThan()
        {
            double mean = 8;

            foreach (var state in DataSet.Keys)
            {
                foreach (var gend in DataSet[state])
                {
                    if ("both".ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean >= mean)
                        {
                            lstMean.Items.Add(state);
                        }
                    }
                }
            }

        }

        private void PopulateData(string file)
        {
            var lines = File.ReadAllLines(file);
            //State	Gender	Mean	N=
            //AL    MALE
            //      FEMALE
            //      BOTH

            string state = "";

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var pieces = line.Split(',');
                if (string.IsNullOrWhiteSpace(pieces[0]) == false)
                {
                    state = pieces[0];
                }
                double mean;
                int n;

                if (double.TryParse(pieces[2], out mean) == false)
                {
                    continue;
                }

                if (int.TryParse(pieces[3], out n) == false)
                {
                    continue;
                }


                if (DataSet.ContainsKey(state) == false)
                {
                    DataSet.Add(state, new List<Data>());
                }

                DataSet[state].Add(new Data()
                {
                    State = state,
                    Gender = pieces[1],
                    Mean = mean,
                    N = n
                });
            }
        }
    }
}
