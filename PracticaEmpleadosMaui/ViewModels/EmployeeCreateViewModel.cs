using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;
using System.Collections.ObjectModel;

namespace PracticaMaui.ViewModels
{
    public partial class EmployeeCreateViewModel(
        IRepositoryService<Employee> employeeService,
        IRepositoryService<Department> departmentService) : ObservableObject
    {
        [ObservableProperty]
        private Employee employee = new();

        [ObservableProperty]
        private ObservableCollection<Department> departments = new();

        [ObservableProperty]
        private Department? selectedDepartment;

        [RelayCommand]
        public async Task LoadDepartmentsAsync()
        {
            var lista = await departmentService.GetAllAsync();
            Departments.Clear();
            foreach (var department in lista)
            {
                Departments.Add(department);
            }
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (Employee == null)
            {
                return;
            }

            if (SelectedDepartment != null)
            {
                Employee.DepartmentId = SelectedDepartment.Id;
            }

            await employeeService.CreateAsync(Employee);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
