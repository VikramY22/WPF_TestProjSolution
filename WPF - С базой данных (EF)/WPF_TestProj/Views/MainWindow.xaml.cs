using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_TestProj.Data;
using WPF_TestProj.Models;

namespace WPF_TestProj.Views
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        //подгрузка из БД
        private void LoadData()
        {
            CityComboBox.ItemsSource = _context.Cities
                .OrderBy(n => n.Name)
                .ToList();
            CityComboBox.SelectedIndex = -1;

            WorkshopComboBox.ItemsSource = null;
            WorkshopComboBox.IsEnabled = false;

            EmployeeComboBox.ItemsSource = null;
            EmployeeComboBox.IsEnabled = false;

            BrigadeComboBox.ItemsSource = _context.Brigades
                .OrderBy(n => n.Name)
                .ToList();
            BrigadeComboBox.SelectedIndex = -1;
        }

        //Флаги для полей ввода, если не выбран предыдущий пункт
        private void CitySelector_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (CityComboBox.SelectedItem is City selectedCity)
            {
                WorkshopComboBox.ItemsSource = _context.Workshops
                    .Where(w => w.CityId == selectedCity.Id)
                    .OrderBy(n => n.Name)
                    .ToList();

                WorkshopComboBox.SelectedIndex = -1;
                WorkshopComboBox.IsEnabled = true;

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

        private void WorkshopSelector_Changed(object sender, SelectionChangedEventArgs p)
        {
            if (WorkshopComboBox.SelectedItem is Workshop selectedWorkshop)
            {
                EmployeeComboBox.ItemsSource = _context.Employees
                    .Where(w => w.WorkshopId == selectedWorkshop.Id)
                    .OrderBy(n => n.Name)
                    .ToList();

                EmployeeComboBox.SelectedIndex = -1;
                EmployeeComboBox.IsEnabled = true;
            }
            else
            {
                EmployeeComboBox.ItemsSource = null;
                EmployeeComboBox.IsEnabled = false;
            }

        }
        //Открытие вьюшки AddEmployee
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeWindow().ShowDialog();
            LoadData();
        }
        //Открытие вьюшки Delete
        private void OpenDeleteWindow_Click(object sender, RoutedEventArgs e)
        {
            new DeleteWindow().ShowDialog();
            LoadData();
        }
    }
}
