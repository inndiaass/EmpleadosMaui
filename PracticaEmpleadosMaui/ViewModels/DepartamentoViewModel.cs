using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PracticaMaui.Models;
using PracticaMaui.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PracticaMaui.ViewModels
{
    public partial class DepartamentoViewModel(
        IRepositoryService<Department> departmentService,
        IRepositoryService<Employee> employeeService) : ObservableObject

    {
        [ObservableProperty]
        private ObservableCollection<Department> departments = new();
        

        [RelayCommand]
        public async Task LoadDepartamentosAsync()
        {
            var lista = await departmentService.GetAllAsync();
            var empleados = await employeeService.GetAllAsync();
            Departments.Clear();
            foreach (var department in lista)
            {
                Departments.Add(department);
            }

            ConfigurePieSeries(empleados);
        }

        public ObservableCollection<ISeries> PieSeries { get; } = new();
        public void ConfigurePieSeries(IReadOnlyCollection<Employee> empleados)
        {
            var groupedDepartments = Departments
                .Select(d => new
                {
                    Name = d.Name,
                    Count = empleados.Count(e => e.DepartmentId == d.Id)
                });
            PieSeries.Clear();
            foreach (var group in groupedDepartments)
            {
                PieSeries.Add(new PieSeries<int>
                {
                    Name = group.Name,
                    Values = new[] { group.Count }
                });
            }

        }

    }
}
