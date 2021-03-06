﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UniversityApp.DataSettings;
using UniversityApp.Students;
using static UniversityApp.DataSettings.DataSetting;

namespace UniversityApp
{
    /// <summary>
    /// Interaction logic for AllStudentsPage.xaml
    /// </summary>
    public partial class AllStudentsPage : Page
    {
        private readonly List<StudentInformation> students = ReadXml<StudentInformation>.ReadData(StudentsXml);

        public AllStudentsPage()
        {
            InitializeComponent();
            GetList();
        }

        private void GetList()
        {
            foreach (var student in students)
            {
                allStudentsListBox.Items.Add($"{student.Id}. {student.FirstName} {student.LastName}");
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            UniversityHome universityHome = new UniversityHome();
            this.NavigationService.Navigate(universityHome);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            if (allStudentsListBox.SelectedValue == null)
            {
                MessageBox.Show("Select one!");
            }

            int studentId = Convert.ToInt32(allStudentsListBox.SelectedValue.ToString()[0].ToString());

            StudentInformation studentInformation = students[studentId - 1];

            StudentInformationPage studentInformationPage = new StudentInformationPage();

            studentInformationPage.textBoxFirstName.Text = studentInformation.FirstName;
            studentInformationPage.textBoxLastName.Text = studentInformation.LastName;
            studentInformationPage.datePickerBirthDate.Text = studentInformation.BirthDate.ToString();
            studentInformationPage.textBoxAge.Text = studentInformation.Age.ToString();
            studentInformationPage.textBoxEGN.Text = studentInformation.EGN.ToString();
            studentInformationPage.textBoxFacNo.Text = studentInformation.FacNo.ToString();
            studentInformationPage.textBoxGender.Text = studentInformation.Gender;

            this.NavigationService.Navigate(studentInformationPage);
        }
    }
}
