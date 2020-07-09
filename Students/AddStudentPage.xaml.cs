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

            DateTime birthDate = (DateTime)(datePickerBirthDate.SelectedDate);

            StudentInformation student = new StudentInformation();
            int age = student.CalculateAge(birthDate);

            if (age < 7 || age > 100)
            {
                isCorrect = false;
                MessageBox.Show("You need to be between 7 and 100 age!");
            }

            if (isCorrect)
            {
                try
                {
                    student.Id = MainWindow.students.Count + 1;
                    student.FirstName = textBoxFirstName.Text.ToString();
                    student.LastName = textBoxLastName.Text.ToString();
                    student.BirthDate = (DateTime)(datePickerBirthDate.SelectedDate);
                    student.Age = age;
                    student.EGN = long.Parse(textBoxEGN.Text.ToString());
                    student.FacNo = long.Parse(textBoxFacNo.Text.ToString());
                    student.Gender = gender;

                    MainWindow.students.Add(student);

                    SaveXml<StudentInformation>.SaveData(MainWindow.students, @"C:\Users\User\Desktop\19.08.2019\c#\Practice\UniversityApp\Students.xml"); // add path 
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