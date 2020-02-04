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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalCentre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAddEditVisitParent
    {
        ObservableCollection<VISIT> visits;
        EntityDBService service = new EntityDBService();

        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            visits = new ObservableCollection<VISIT>(service.getVisits());
            VisitDataGrid.ItemsSource = visits;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you already a client?", "Add Box", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    AddEditVisit win1 = new AddEditVisit((IAddEditVisitParent)this, (List<PATIENT>)service.getPatients(), (List<DOCTOR>)service.getDoctors());
                    win1.ShowDialog();
                    break;

                case MessageBoxResult.No:
                    AddEditPatient win2 = new AddEditPatient(this);
                    win2.ShowDialog();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        public void insertPatient(PATIENT patient)
        {
            service.insertPatient(patient);
            
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (VisitDataGrid.SelectedItems.Count == 1)
            {
                service.deleteVisit((VISIT)VisitDataGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("Error. Choose single visit!");
            }
            LoadData();

        }


        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (VisitDataGrid.SelectedItems.Count == 1)
            {
                AddEditVisit win = new AddEditVisit((IAddEditVisitParent)this, (List<PATIENT>)service.getPatients(), (List<DOCTOR>)service.getDoctors(), (VISIT)VisitDataGrid.SelectedItem);
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error. Choose single visit!");
            }
            LoadData();
        }

        public void EditFinished(object obj)
        {
            service.updateVisit((VISIT)VisitDataGrid.SelectedItem, (VISIT)obj);
            LoadData();
        }

        public void AddFinished(object obj)
        {
            service.insertVisit((VISIT)obj);
            LoadData();
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
            AddEditVisit win1 = new AddEditVisit((IAddEditVisitParent)this, (List<PATIENT>)service.getPatients(), (List<DOCTOR>)service.getDoctors());
            win1.ShowDialog();
        }

        private void Patient_Button_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow win = new PatientWindow();
            win.Show();
            this.Close();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
