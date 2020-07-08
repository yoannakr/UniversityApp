using System.Windows;
using System.Windows.Controls;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for TeacherInformationPage.xaml
    /// </summary>
    public partial class TeacherInformationPage : Page
    {
        public TeacherInformationPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }
    }
}
