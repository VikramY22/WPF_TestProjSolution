using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_TestProj.Data;
using WPF_TestProj.Models;

namespace WPF_TestProj.Views;

public partial class DeleteWindow : Window
{
    private readonly AppDbContext _context = new();

    public DeleteWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        CityComboBox.ItemsSource = _context.Cities
            .OrderBy(n => n.Name)
            .ToList();
        WorkshopComboBox.ItemsSource = _context.Workshops
            .OrderBy(n => n.Name)
            .ToList();
        BrigadeComboBox.ItemsSource = _context.Brigades
            .OrderBy(n => n.Name)
            .ToList();
        EmployeeComboBox.ItemsSource = _context.Employees
            .OrderBy(n => n.Name)
            .ToList();
    }
    private void DeleteEntity<T>(ComboBox comboBox, string entityName, Func<T, string> nameSelector, Action<T> removeAction) where T : class
    {
        if (comboBox.SelectedItem is not T entity) return;

        var name = nameSelector(entity);
        if (MessageBox.Show($"Удалить {entityName} {name}?", "Подтверждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

        removeAction(entity);
        _context.SaveChanges();
        LoadData();
        comboBox.SelectedItem = null;
    }
    private void DeleteCity_Click(object sender, RoutedEventArgs e)
    {
        DeleteEntity<City>(CityComboBox, "город", n => n.Name, n => _context.Cities.Remove(n));
    }

    private void DeleteWorkshop_Click(object sender, RoutedEventArgs e)
    {
        DeleteEntity<Workshop>(WorkshopComboBox, "цех", n => n.Name, n => _context.Workshops.Remove(n));
    }

    private void DeleteBrigade_Click(object sender, RoutedEventArgs e)
    {
        DeleteEntity<Brigade>(BrigadeComboBox, "бригаду", n => n.Name, n => _context.Brigades.Remove(n));
    }

    private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
    {
        DeleteEntity<Employee>(EmployeeComboBox, "сотрудника", n => n.Name, n => _context.Employees.Remove(n));
    }
}
