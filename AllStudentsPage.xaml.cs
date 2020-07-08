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
    /// Interaction logic for AllStudentsPage.xaml
    /// </summary>
    public partial class AllStudentsPage : Page
    {
        public AllStudentsPage()
        {
            InitializeComponent();
            GetList();
        }

        private void GetList()
        {
            foreach (var student in MainWindow.students)
            {
                allStudentsListBox.Items.Add($"{student.Id}. {student.FirstName} {student.LastName}");
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            if (allStudentsListBox.SelectedValue == null)
            {
                MessageBox.Show("Select one!");
            }

            int studentId = Convert.ToInt32(allStudentsListBox.SelectedValue.ToString()[0]);
            StudentInformationPage studentInformationPage = new StudentInformationPage();
            studentInformationPage.textBoxAge.Text = "20";
            this.NavigationService.Navigate(studentInformationPage);
        }
    }
}
