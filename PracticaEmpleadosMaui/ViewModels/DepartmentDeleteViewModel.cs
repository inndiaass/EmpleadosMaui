using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;

namespace PracticaMaui.ViewModels
{
    [QueryProperty(nameof(Department), "Departamento")]
    public partial class DepartmentDeleteViewModel(IRepositoryService<Department> departmentService) : ObservableObject
    {
        [ObservableProperty]
        private Department department = new();

        [ObservableProperty]
        private int employeesCount;

        partial void OnDepartmentChanged(Department value)
        {
            EmployeesCount = value?.Employees?.Count ?? 0;
        }

        [RelayCommand]
        public async Task DeleteAsync()
        {
            if (Department == null)
            {
                return;
            }

            await departmentService.DeleteAsync(Department.Id);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
