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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IMedicalBillsService _medicalBillsService;
      
        public List<MedicalBillsDTO> medicalBills { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _medicalBillsService = _serviceProvider.GetService<IMedicalBillsService>();
            medicalBills = new List<MedicalBillsDTO>(_medicalBillsService.GetAll().ToList());
            medicalBillsDataGrid.ItemsSource = medicalBills;  
            StartVisibility();
            
        }

        private void medicalBillsButton_Click(object sender, RoutedEventArgs e)
        {
            medicalBillsGrid.Visibility = Visibility.Visible;
            manufacturerGrid.Visibility = Visibility.Hidden;
            medicalBillsTypeGrid.Visibility = Visibility.Hidden;
        }

        private void manufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            manufacturerGrid.Visibility = Visibility.Visible;
            medicalBillsGrid.Visibility = Visibility.Hidden;
            medicalBillsTypeGrid.Visibility = Visibility.Hidden;
        }

        private void medicalBillsTypeButton_Click(object sender, RoutedEventArgs e)
        {
            medicalBillsTypeGrid.Visibility = Visibility.Visible;
            manufacturerGrid.Visibility = Visibility.Hidden;
            medicalBillsGrid.Visibility = Visibility.Hidden;
        }

        public void StartVisibility()
        {
            medicalBillsTypeGrid.Visibility = Visibility.Hidden;
            medicalBillsGrid.Visibility = Visibility.Hidden;
            manufacturerGrid.Visibility = Visibility.Hidden;
        }

        private void medicalBillsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (medicalBillsDataGrid.SelectedItem != null)
            {
                //MedicalBillsDTO row = (MedicalBillsDTO)medicalBillsDataGrid.SelectedItem;
                //medNameTextBox.Text = row.Name;
                //medQuantityTextBox.Text = row.Quantity.ToString();
                //medTypeTextBox.Text = row.MedicalBillsType.Type;
                //medManufacturerTextBox.Text = row.ManufactureId.ToString();
                //medDateOfManufacturePicker.SelectedDate = row.DateOfManufacture;
                //medExpirationDatePicker.SelectedDate = row.ExpirationDate;
            }
        }

        private void medAddButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalBillsTypeDTO dTO = new MedicalBillsTypeDTO();
            MedicalBillsDTO med = new MedicalBillsDTO
            {
                Name = medNameTextBox.Text,
        //        Quantity = int.Parse(medQuantityTextBox.Text),
        //        ManufactureId = int.Parse(medManufacturerTextBox.Text),
        ////        MedicalBillsType = int.Parse(medTypeTextBox.Text),
        //        DateOfManufacture = (DateTime)medDateOfManufacturePicker.SelectedDate,
        //        ExpirationDate = (DateTime)medExpirationDatePicker.SelectedDate
            };
            MedicalBillsDTO elem = _medicalBillsService.GetAll().Last();
            dTO.Id = elem.MedicalBillsType.Id;
            dTO.Type = medTypeTextBox.Text;
            med.MedicalBillsType = dTO;
            medicalBills.Add(med);
            _medicalBillsService.Add(med);
            medicalBills[medicalBills.Count - 1].Id = elem.Id; 
            medicalBillsDataGrid.Items.Refresh();
        }

        private void medDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(medicalBillsDataGrid.SelectedItem != null)
            {
                MedicalBillsDTO med = (MedicalBillsDTO)medicalBillsDataGrid.SelectedItem;
                _medicalBillsService.Remove(med);
                medicalBills.Remove(med);
                medicalBillsDataGrid.Items.Refresh();
            }
        }

        private void medUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (medicalBillsDataGrid.SelectedItem != null)
            {
                MedicalBillsTypeDTO dTO = new MedicalBillsTypeDTO();
                MedicalBillsDTO selected = (MedicalBillsDTO)medicalBillsDataGrid.SelectedItem;
                MedicalBillsDTO med = new MedicalBillsDTO
                {
                    //Name = medNameTextBox.Text,
                    //Quantity = int.Parse(medQuantityTextBox.Text),
                    //ManufactureId = int.Parse(medManufacturerTextBox.Text),
                    //DateOfManufacture = (DateTime)medDateOfManufacturePicker.SelectedDate,
                    //ExpirationDate = (DateTime)medExpirationDatePicker.SelectedDate
                };
                MedicalBillsDTO elem = _medicalBillsService.GetAll().Last();
                dTO.Id = elem.MedicalBillsType.Id;
                dTO.Type = medTypeTextBox.Text;
                med.MedicalBillsType = dTO;
                med.Id = medicalBills[medicalBills.IndexOf(selected)].Id;
                medicalBills[medicalBills.IndexOf(selected)] = med;
                _medicalBillsService.Update(med);
                medicalBillsDataGrid.Items.Refresh();
            }
        }
   
    }
}
