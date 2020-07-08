using System.Windows;
using System.Windows.Controls;

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
                case "Add Teacher":
                    AddTeacherPage addTeacherPage = new AddTeacherPage();
                    this.NavigationService.Navigate(addTeacherPage);
                    break;
                case "All Students":
                    AllStudentsPage allStudentsPage = new AllStudentsPage();
                    this.NavigationService.Navigate(allStudentsPage);
                    break;
                case "All Teachers":
                    AllTeachersPage allTeachersPage = new AllTeachersPage();
                    this.NavigationService.Navigate(allTeachersPage);
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }

    }
}
