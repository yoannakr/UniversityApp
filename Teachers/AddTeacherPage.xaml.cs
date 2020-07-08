using System;
using System.Windows;
using System.Windows.Controls;
using UniversityApp.Teachers;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        private string gender = String.Empty;

        public AddTeacherPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            bool isCorrect = true;

            try
            {
                if (textBlockFirstname.Text.Length == 0 ||
                       textBoxLastName.Text.Length == 0 ||
                       int.Parse(textBoxAge.Text.ToString()) < 0 ||
                       !datePickerBirthDate.SelectedDate.HasValue ||
                       textBoxEGN.Text.Length != 10 ||
                       textBoxSubject.Text.Length == 0
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
                    TeacherInformation teacher = new TeacherInformation()
                    {
                        Id = MainWindow.teachers.Count + 1,
                        FirstName = textBoxFirstName.Text.ToString(),
                        LastName = textBoxLastName.Text.ToString(),
                        BirthDate = (DateTime)(datePickerBirthDate.SelectedDate),
                        Age = int.Parse(textBoxAge.Text.ToString()),
                        EGN = long.Parse(textBoxEGN.Text.ToString()),
                        Subject = textBoxSubject.Text.ToString(),
                        Gender = gender
                    };

                    MainWindow.teachers.Add(teacher);

                    SaveXml<TeacherInformation>.SaveData(MainWindow.teachers, @"Teachers.xml"); // add path

                    MessageBox.Show($"Teacher with last name {teacher.LastName} was added!");
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
