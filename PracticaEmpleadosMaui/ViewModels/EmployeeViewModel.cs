using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PracticaMaui.ViewModels
{
    public partial class EmployeeViewModel(IRepositoryService<Employee> employeeService, IRepositoryService<Department> departmentService ) : ObservableObject

    {
        [ObservableProperty]
        private ObservableCollection<Employee> empleados = new();

        [ObservableProperty]
        private Employee selectedEmpleado = new();

        [ObservableProperty]
        private string departamento;

        [RelayCommand]
        public async Task LoadEmpleadosAsync()
        {
            var lista = await employeeService.GetAllAsync();
            Empleados.Clear();
            foreach (var employee in lista)
            {
                Empleados.Add(employee);
            }
        }

        [RelayCommand]
        public async Task OnDetailLinkTapped()
        { 
            await Shell.Current.GoToAsync("employeeDetailsPage", new ShellNavigationQueryParameters { {"Empleado", SelectedEmpleado } });
        }

    }
}
