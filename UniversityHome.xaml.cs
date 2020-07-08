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

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for UniversityHome.xaml
    /// </summary>
    public partial class UniversityHome : Page
    {
        public UniversityHome()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (optionListBox.SelectedValue == null)
            {
                MessageBox.Show("Select one!");
            }

            string selectedItem = optionListBox.SelectedValue.ToString();

            switch (selectedItem)
            {
                case "Add Student":
                    AddStudentPage addStudentPage = new AddStudentPage();
                    this.NavigationService.Navigate(addStudentPage);
                    break;
                case "All Students":
                    AllStudentsPage allStudentsPage = new AllStudentsPage();
                    this.NavigationService.Navigate(allStudentsPage);
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }

    }
}
