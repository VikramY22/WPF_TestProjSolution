using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CascadeDemo
{
    public partial class MainWindow : Window
    {
        
        private Dictionary<string, List<string>> cityWorkshops = new Dictionary<string, List<string>>()
        {
            { "Москва", new List<string> { "Цех #1", "Цех #2" } },
            { "Владивосток", new List<string> { "Цех #3", "Цех #4" } }
        };

        
        private Dictionary<string, List<string>> workshopEmployees = new Dictionary<string, List<string>>()
        {
            { "Цех #1", new List<string> { "Иванов И.И.", "Петров П.П." } },
            { "Цех #2", new List<string> { "Сидоров С.С." } },
            { "Цех #3", new List<string> { "Кузнецов К.К.", "Кондратьев К.К." } },
            { "Цех #4", new List<string> { "Пушкин А.С." } }
        };

        public MainWindow()
        {
            InitializeComponent();

            
            CityComboBox.ItemsSource = cityWorkshops.Keys;
            
            BrigadeComboBox.ItemsSource = new List<string> { "Бригада 1", "Бригада 2", "Бригада 3" };

            
            WorkshopComboBox.IsEnabled = false;
            EmployeeComboBox.IsEnabled = false;
        }

        private void City_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCity = CityComboBox.SelectedItem as string;

            if (selectedCity != null && cityWorkshops.ContainsKey(selectedCity))
            {
                
                WorkshopComboBox.ItemsSource = cityWorkshops[selectedCity];
                WorkshopComboBox.IsEnabled = true;
                WorkshopComboBox.SelectedIndex = -1;

                
                EmployeeComboBox.ItemsSource = null;
                EmployeeComboBox.IsEnabled = false;
            }
            else
            {
                
                WorkshopComboBox.ItemsSource = null;
                WorkshopComboBox.IsEnabled = false;

                EmployeeComboBox.ItemsSource = null;
                EmployeeComboBox.IsEnabled = false;
            }
        }

        private void Workshop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedWorkshop = WorkshopComboBox.SelectedItem as string;

            if (selectedWorkshop != null && workshopEmployees.ContainsKey(selectedWorkshop))
            {
                
                EmployeeComboBox.ItemsSource = workshopEmployees[selectedWorkshop];
                EmployeeComboBox.IsEnabled = true;
                EmployeeComboBox.SelectedIndex = -1;
            }
            else
            {
                
                EmployeeComboBox.ItemsSource = null;
                EmployeeComboBox.IsEnabled = false;
            }
        }
    }
}
