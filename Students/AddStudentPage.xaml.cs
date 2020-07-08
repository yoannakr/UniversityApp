using System;
using System.Windows;
using System.Windows.Controls;
using UniversityApp.Students;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        private string gender = String.Empty;

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

            try
            {
                if (textBlockFirstname.Text.Length == 0 ||
                       textBoxLastName.Text.Length == 0 ||
                       int.Parse(textBoxAge.Text.ToString()) < 0 ||
                       !datePickerBirthDate.SelectedDate.HasValue ||
                       textBoxEGN.Text.Length != 10 ||
                       textBoxFacNo.Text.Length != 9
                    )
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

                    SaveXml<StudentInformation>.SaveData(MainWindow.students, @"Students.xml"); // add path 
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