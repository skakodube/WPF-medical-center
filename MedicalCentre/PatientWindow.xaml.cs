using MedicalCentre.DAL;
using MedicalCentre.Models;
using MedicalCentre.WindowsCallBack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window, IAddEditVisitParent
    {
        ObservableCollection<PATIENT> patients;
        EntityDBService service = new EntityDBService();

        public PatientWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            patients = new ObservableCollection<PATIENT>(service.getPatients());
            PatientDataGrid.ItemsSource = service.getPatients();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PatientDataGrid.SelectedItems.Count == 1)
            {
                AddEditPatient win = new AddEditPatient((IAddEditVisitParent)this, (PATIENT)PatientDataGrid.SelectedItem);
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error. Choose single patient!");
            }
            LoadData();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PatientDataGrid.SelectedItems.Count == 1)
            {
                service.deletePatient((PATIENT)PatientDataGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("Error. Choose single patient!");
            }
            LoadData();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
                    AddEditPatient win2 = new AddEditPatient(this);
            win2.ShowDialog();
        }

        public void EditFinished(object obj)
        {
            service.updatePatient((PATIENT)PatientDataGrid.SelectedItem, (PATIENT)obj);
            LoadData();
        }

        public void AddFinished(object obj)
        {
            service.insertPatient((PATIENT)obj);
            LoadData();
        }

        private void Appointment_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void New_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddEditPatient win1 = new AddEditPatient((IAddEditVisitParent)this);
            win1.ShowDialog();
        }

    }
}
