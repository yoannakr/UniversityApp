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
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        string gender = String.Empty;

        public AddStudentPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            bool isCorrect = true;

            if (textBlockFirstname.Text.Length == 0 || textBoxLastName.Text.Length == 0)
            {
                isCorrect = false;
                MessageBox.Show("Please fill in all fields!");
            }

            try
            {
                if (int.Parse(textBoxAge.Text.ToString()) < 0)
                {
                    isCorrect = false;
                    MessageBox.Show("Please fill in all fields!");
                }
            }
            catch (Exception)
            {
                isCorrect = false;
                MessageBox.Show("Please fill in all fields!");
            }

            if (!datePickerBirthDate.SelectedDate.HasValue)
            {
                isCorrect = false;
                MessageBox.Show("Please fill in all fields!");
            }

            if (textBoxEGN.Text.Length == 0 && textBoxEGN.Text.Length < 10) // check
            {
                isCorrect = false;
                MessageBox.Show("Please fill in all fields!");
            }

            if (textBoxFacNo.Text.Length == 0 || textBoxFacNo.Text.Length < 9)
            {
                isCorrect = false;
                MessageBox.Show("Please fill in all fields!");
            }

            if (isCorrect)
            {
                try
                {
                    StudentInformation student = new StudentInformation()
                    {
                        Id = MainWindow.students.Count + 1,
                        FirstName = textBoxFirstName.Text.ToString(),
                        LastName = textBoxLastName.Text.ToString(),
                        BirthDate = (DateTime)(datePickerBirthDate.SelectedDate),
                        Age = int.Parse(textBoxAge.Text.ToString()),
                        EGN = long.Parse(textBoxEGN.Text.ToString()),
                        FacNo = long.Parse(textBoxFacNo.Text.ToString()),
                        Gender = gender
                    };

                    MainWindow.students.Add(student);

                    SaveXml<StudentInformation>.SaveData(MainWindow.students, @"C:\Users\User\Desktop\19.08.2019\c#\Practice\UniversityApp\Students.xml");
                    // to delete 
                    MessageBox.Show($"Student with Fac No: {student.FacNo} was added!");
                }
                catch (Exception ex)
                {
                    isCorrect = false;
                    MessageBox.Show(ex.Message);
                }

                if (isCorrect)
                {
                    UniversityHome universityHome = new UniversityHome();
                    this.NavigationService.Navigate(universityHome);
                }
            }
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton == null)
                return;
            gender = radioButton.Content.ToString();
        }

    }
}