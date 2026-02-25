using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;

namespace PracticaMaui.ViewModels
{
    public partial class DepartmentCreateViewModel(IRepositoryService<Department> departmentService) : ObservableObject
    {
        [ObservableProperty]
        private Department department = new();

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (Department == null)
            {
                return;
            }

            await departmentService.CreateAsync(Department);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
