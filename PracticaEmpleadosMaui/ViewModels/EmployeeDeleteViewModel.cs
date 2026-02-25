using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;

namespace PracticaMaui.ViewModels
{
    [QueryProperty(nameof(Employee), "Empleado")]
    public partial class EmployeeDeleteViewModel(IRepositoryService<Employee> employeeService) : ObservableObject
    {
        [ObservableProperty]
        private Employee employee = new();

        [RelayCommand]
        public async Task DeleteAsync()
        {
            if (Employee?.Id == null)
            {
                return;
            }

            await employeeService.DeleteAsync(Employee.Id.Value);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
