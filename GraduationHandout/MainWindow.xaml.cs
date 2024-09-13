using System;
using System.Collections.Generic;
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

namespace GraduationHandout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isEverythingGood = true;

            if (string.IsNullOrWhiteSpace(txtCity.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid city!");
            }

            if (string.IsNullOrWhiteSpace(txtFName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid first name!");
            }

            double gpa;

            if (double.TryParse(txtGPA.Text, out gpa) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid gpa!");
            }

            if (string.IsNullOrWhiteSpace(txtLName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid last name!");
            }

            if (string.IsNullOrWhiteSpace(txtMajor.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid major!");
            }

            if (string.IsNullOrWhiteSpace(txtState.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid state!");
            }

            if (string.IsNullOrWhiteSpace(txtStreetName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid street name!");
            }

            int streetNumber, zipCode;

            if (int.TryParse(txtStreetNum.Text, out streetNumber) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid street number!");
            }

            if (int.TryParse(txtZipcode.Text, out zipCode) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid zipcode!");
            }

            if (isEverythingGood == false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = txtFName.Text,
                GPA = gpa,
                LastName = txtLName.Text,
                Major = txtMajor.Text
            };
            student.SetAddress(streetNumber, txtStreetName.Text, txtState.Text, txtCity.Text, zipCode);

            lstGraduationHandout.Items.Add(student);

            txtCity.Clear();
            txtFName.Clear();
            txtGPA.Clear();
            txtLName.Clear();
            txtMajor.Clear();
            txtState.Clear();
            txtStreetName.Clear();
            txtStreetNum.Clear();
            txtZipcode.Clear();
        }
    }
}
