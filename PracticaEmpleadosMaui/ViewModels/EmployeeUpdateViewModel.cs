using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace PracticaMaui.ViewModels
{
    [QueryProperty(nameof(Employee), "Empleado")]
    public partial class EmployeeUpdateViewModel(
        IRepositoryService<Employee> employeeService,
        IRepositoryService<Department> departmentService) : ObservableObject
    {
        [ObservableProperty]
        private Employee employee = new();

        [ObservableProperty]
        private ObservableCollection<Department> departments = new();

        [ObservableProperty]
        private Department? selectedDepartment;

        partial void OnEmployeeChanged(Employee value)
        {
            if (value == null)
            {
                return;
            }

            if (Departments.Count > 0)
            {
                SelectedDepartment = Departments.FirstOrDefault(d => d.Id == value.DepartmentId);
            }
        }

        [RelayCommand]
        public async Task LoadDepartmentsAsync()
        {
            var lista = await departmentService.GetAllAsync();
            Departments.Clear();
            foreach (var department in lista)
            {
                Departments.Add(department);
            }

            if (Employee != null)
            {
                SelectedDepartment = Departments.FirstOrDefault(d => d.Id == Employee.DepartmentId);
            }
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (Employee?.Id == null)
            {
                return;
            }

            if (SelectedDepartment != null)
            {
                Employee.DepartmentId = SelectedDepartment.Id;
            }

            await employeeService.UpdateAsync(Employee);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
