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
    /// Interaction logic for AddEditVisit.xaml
    /// </summary>
    public partial class AddEditVisit : Window
    {
        IAddEditVisitParent main_;
        VISIT visitToEdit;

        public AddEditVisit(IAddEditVisitParent main, IEnumerable<PATIENT> pats, IEnumerable<DOCTOR> docs, VISIT visit)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            AddEditVisitLabel.Text = "Edit Visit";
            main_ = main;
            ComboBoxDoctor.ItemsSource = docs;
            ComboBoxPatient.ItemsSource = pats;
            visitToEdit = visit;
            ComboBoxPatient.IsEnabled = false;
            ComboBoxPatient.SelectedItem = visit.PATIENT1;
            ComboBoxDoctor.SelectedItem = visit.DOCTOR1;
            cldSample.SelectedDate = visit.DATEOFVISIT;
        }

        public AddEditVisit(IAddEditVisitParent main, IEnumerable<PATIENT> pats, IEnumerable<DOCTOR> docs)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            AddEditVisitLabel.Text = "Create Visit";
            main_ = main;
            ComboBoxDoctor.ItemsSource = docs;
            ComboBoxPatient.ItemsSource = pats;
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(comboBox1.Text))
                if (ComboBoxDoctor.SelectedItem != null &&  ComboBoxPatient.SelectedItem != null && cldSample.SelectedDate != null)
            {
                if (AddEditVisitLabel.Text == "Create Visit")
                {
                    visitToEdit = new VISIT
                    {
                        DOCTOR1 = (DOCTOR)ComboBoxDoctor.SelectedItem,
                        PATIENT1 = (PATIENT)ComboBoxPatient.SelectedItem,
                        DATEOFVISIT = cldSample.SelectedDate.Value
                    };
                    main_.AddFinished(visitToEdit);
                    this.Close();
                }
                else if (AddEditVisitLabel.Text == "Edit Visit")
                {
                    visitToEdit.DOCTOR1 = (DOCTOR)ComboBoxDoctor.SelectedItem;
                    visitToEdit.PATIENT1 = (PATIENT)ComboBoxPatient.SelectedItem;
                    visitToEdit.DATEOFVISIT = cldSample.SelectedDate.Value;
                    main_.EditFinished(visitToEdit);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error. Choose all the properties for the visit");
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
