using System.Windows;
using System.Windows.Controls;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for StudentInformationPage.xaml
    /// </summary>
    public partial class StudentInformationPage : Page
    {
        public StudentInformationPage()
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
