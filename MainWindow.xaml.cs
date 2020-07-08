using System.Collections.Generic;
using System.Windows.Navigation;


namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public static List<StudentInformation> students = new List<StudentInformation>(); // public field??
        public static List<TeacherInformation> teachers = new List<TeacherInformation>(); // public field??

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
