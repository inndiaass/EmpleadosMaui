using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaMaui.Models;
using PracticaMaui.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaMaui.ViewModels
{
    [QueryProperty(nameof(Employee), "Empleado")]
    public partial class EmpleadoDetalleViewModel(
        IRepositoryService<Department> deptService,
        IRepositoryService<Employee> employeeService) : ObservableObject
    {
        private readonly IRepositoryService<Department> departamentoService = deptService;
        private readonly IRepositoryService<Employee> empleadoService = employeeService;

        [ObservableProperty]
        private Employee employee;

        [ObservableProperty]
        private  Department departmentAsociado;

        


        private async Task CargarAsociados() 
        {
            DepartmentAsociado = await departamentoService.GetById(Employee.DepartmentId);
        }

        partial void OnEmployeeChanged(Employee value)
        {
            if (value != null)
            {
                Task.Run(async () => await CargarAsociados());
            }
        }

        [RelayCommand]
        public async Task DeleteAsync()
        {
            if (Employee?.Id == null)
            {
                return;
            }

            await empleadoService.DeleteAsync(Employee.Id.Value);
            await Shell.Current.GoToAsync("..");
        }


    }
}
