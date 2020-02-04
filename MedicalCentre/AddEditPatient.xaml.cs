using MedicalCentre.Models;
using MedicalCentre.WindowsCallBack;
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
using System.Windows.Shapes;

namespace MedicalCentre
{


    /// <summary>
    /// Interaction logic for AddEdit.xaml
    /// </summary>
    public partial class AddEditPatient : Window
    {
        IAddEditVisitParent main_;
        PATIENT patientToEdit;

        public AddEditPatient(IAddEditVisitParent main, PATIENT patient)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            AddEditPatientLabel.Text = "Edit Patient";
            main_ = main;
            patientToEdit = patient;
            loadData();

        }

        public AddEditPatient(IAddEditVisitParent main)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            AddEditPatientLabel.Text = "Create Patient";
            main_ = main;

        }

        private void loadData()
        {
            TextBoxFirstName.Text = patientToEdit.NAME;
            TextBoxLastName.Text = patientToEdit.SURNAME;
            TextBoxAddress.Text = patientToEdit.ADDRESS;
            cldSample.SelectedDate = patientToEdit.DATEOFBIRTH;

            if (patientToEdit.GENDER == "F")
            {
                FemaleCheckBox.IsChecked = true;
            }
            else if (patientToEdit.GENDER == "M")
            {
                MaleCheckBox.IsChecked = true;
            }
            else{}
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            if (TextBoxFirstName.Text != "" && TextBoxLastName.Text != "" && TextBoxAddress.Text != "" && cldSample.SelectedDate != null)
            {

                string gender = "";
                if (FemaleCheckBox.IsChecked == true)
                {
                    gender = "F";
                }
                else if (MaleCheckBox.IsChecked == true)
                {
                    gender = "M";
                }
                else
                {
                    MessageBox.Show("Select your gender", "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (AddEditPatientLabel.Text == "Create Patient")
                {
                    patientToEdit = new PATIENT
                    {
                        NAME = TextBoxFirstName.Text,
                        SURNAME = TextBoxLastName.Text,
                        ADDRESS = TextBoxAddress.Text,
                        GENDER = gender,
                        DATEOFBIRTH = cldSample.SelectedDate.Value
                    };
                    main_.AddFinished(patientToEdit);
                    this.Close();

                }
                else if (AddEditPatientLabel.Text == "Edit Patient")
                {
                    patientToEdit.NAME = TextBoxFirstName.Text;
                    patientToEdit.SURNAME = TextBoxLastName.Text;
                    patientToEdit.ADDRESS = TextBoxAddress.Text;
                    patientToEdit.GENDER = gender;
                    patientToEdit.DATEOFBIRTH = cldSample.DisplayDate;
                    main_.EditFinished(patientToEdit);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error. Choose all the properties for the patient");
            }

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FemaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (MaleCheckBox.IsChecked == true)
            {
                MaleCheckBox.IsChecked = false;
            }
        }

        private void MaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FemaleCheckBox.IsChecked == true)
            {
                FemaleCheckBox.IsChecked = false;
            }
        }

        public void SampleMethod()
        {
            throw new NotImplementedException();
        }
    }
}
