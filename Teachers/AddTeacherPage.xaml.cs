using System;
using System.Collections.Generic;
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

            DateTime birthDate = (DateTime)(datePickerBirthDate.SelectedDate);

            TeacherInformation teacher = new TeacherInformation();
            int age = teacher.CalculateAge(birthDate);

            if (age < 7 || age > 100)
            {
                isCorrect = false;
                MessageBox.Show("You need to be between 7 and 100 age!");
            }

            if (isCorrect)
            {
                try
                {
                    List<TeacherInformation> teachers = ReadXml<TeacherInformation>.ReadData(@"C:\Users\User\Desktop\19.08.2019\c#\Practice\UniversityApp\Teachers.xml"); // add path 

                    teacher.Id = teachers.Count + 1;
                    teacher.FirstName = textBoxFirstName.Text.ToString();
                    teacher.LastName = textBoxLastName.Text.ToString();
                    teacher.BirthDate = (DateTime)(datePickerBirthDate.SelectedDate);
                    teacher.Age = age;
                    teacher.EGN = long.Parse(textBoxEGN.Text.ToString());
                    teacher.Subject = textBoxSubject.Text.ToString();
                    teacher.Gender = gender;

                    teachers.Add(teacher);

                    SaveXml<TeacherInformation>.SaveData(teachers, @"C:\Users\User\Desktop\19.08.2019\c#\Practice\UniversityApp\Teachers.xml"); // add path

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
