using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;

namespace PracticaMaui.ViewModels
{
    [QueryProperty(nameof(Department), "Departamento")]
    public partial class DepartmentUpdateViewModel(IRepositoryService<Department> departmentService) : ObservableObject
    {
        [ObservableProperty]
        private Department department = new();

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (Department == null || Department.Id == 0)
            {
                return;
            }

            await departmentService.UpdateAsync(Department);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
