using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UniversityApp.DataSettings;
using UniversityApp.Teachers;
using static UniversityApp.DataSettings.DataSetting;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for AllTeachersPage.xaml
    /// </summary>
    public partial class AllTeachersPage : Page
    {
        private readonly List<TeacherInformation> teachers = ReadXml<TeacherInformation>.ReadData(TeachersXml);

        public AllTeachersPage()
        {
            InitializeComponent();
            GetList();
        }

        private void GetList()
        {
            foreach (var teacher in teachers)
            {
                allTeachersListBox.Items.Add($"{teacher.Id}. {teacher.FirstName} {teacher.LastName}");
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            if (allTeachersListBox.SelectedValue == null)
            {
                MessageBox.Show("Select one!");
            }

            int teacherId = Convert.ToInt32(allTeachersListBox.SelectedValue.ToString()[0].ToString());

            TeacherInformation teacherInformation = teachers[teacherId - 1];

            TeacherInformationPage teacherInformationPage = new TeacherInformationPage();

            teacherInformationPage.textBoxFirstName.Text = teacherInformation.FirstName;
            teacherInformationPage.textBoxLastName.Text = teacherInformation.LastName;
            teacherInformationPage.datePickerBirthDate.Text = teacherInformation.BirthDate.ToString();
            teacherInformationPage.textBoxAge.Text = teacherInformation.Age.ToString();
            teacherInformationPage.textBoxEGN.Text = teacherInformation.EGN.ToString();
            teacherInformationPage.textBoxSubject.Text = teacherInformation.Subject.ToString();
            teacherInformationPage.textBoxGender.Text = teacherInformation.Gender;

            this.NavigationService.Navigate(teacherInformationPage);
        }
    }
}
