using System.Linq;
using System.Windows;
using WPF_TestProj.Data;
using WPF_TestProj.Models;

namespace WPF_TestProj.Views
{
    public partial class AddEmployeeWindow : Window
    {
        private readonly AppDbContext _context = new();

        public AddEmployeeWindow()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        //подгрузка полей из БД
        private void LoadComboBoxData()
        {
            CityComboBox.ItemsSource = _context.Cities
                .Select(s => s.Name)
                .OrderBy(n => n)
                .ToList();
            WorkshopComboBox.ItemsSource = _context.Workshops
                .Select(s => s.Name)
                .OrderBy(n => n)
                .ToList();
            BrigadeComboBox.ItemsSource = _context.Brigades
                .Select(s => s.Name)
                .OrderBy(n => n)
                .ToList();
        }

        //сохранение с проверкой
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string cityName = CityComboBox
                .Text.Trim();
            string workshopName = WorkshopComboBox
                .Text.Trim();
            string employeeName = EmployeeTextBox
                .Text.Trim();
            string brigadeName = BrigadeComboBox
                .Text.Trim();

            if (string.IsNullOrWhiteSpace(cityName) ||
                string.IsNullOrWhiteSpace(workshopName) ||
                string.IsNullOrWhiteSpace(employeeName) ||
                string.IsNullOrWhiteSpace(brigadeName))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            //город
            var city = _context.Cities.FirstOrDefault(n => n.Name == cityName);
            if (city == null)
            {
                city = new City { Name = cityName };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            //цех
            var workshop = _context.Workshops.FirstOrDefault(w => w.Name == workshopName && w.CityId == city.Id);
            if (workshop == null)
            {
                workshop = new Workshop { Name = workshopName, CityId = city.Id };
                _context.Workshops.Add(workshop);
                _context.SaveChanges();
            }

            //сотрудник
            if (!_context.Employees.Any(e => e.Name == employeeName && e.WorkshopId == workshop.Id))
            {
                var employee = new Employee { Name = employeeName, WorkshopId = workshop.Id };
                _context.Employees.Add(employee);
            }

            // Бригада
            if (!_context.Brigades.Any(b => b.Name == brigadeName))
            {
                var brigade = new Brigade { Name = brigadeName };
                _context.Brigades.Add(brigade);
            }

            _context.SaveChanges();
            MessageBox.Show("Успешный успех");
            Close();
        }
    }
}
