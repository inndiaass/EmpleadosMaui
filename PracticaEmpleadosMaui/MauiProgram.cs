using PracticaMaui.Models;
using PracticaMaui.Service;
using PracticaMaui.ViewModels;
using PracticaMaui.Views;
using Microsoft.Extensions.Logging;
using LiveChartsCore.SkiaSharpView.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace PracticaMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseLiveCharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    //Añadimos esta fuente para poder poner los iconos en el menu lateral y en las cards. En WPF era con SEGOE pero en MAUI no funciona, asi que he buscado una alternativa y es esta.
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome 6 Free Solid");
                });


            builder.Logging.AddDebug();
            builder.Services.AddSingleton<IRepositoryService<Department>, DepartmentService>();
            builder.Services.AddTransient<DepartamentoViewModel>();
            builder.Services.AddTransient<DepartmentsPage>();
            builder.Services.AddTransient<GraficaPage>();
            builder.Services.AddTransient<DepartmentDetailViewModel>();
            builder.Services.AddTransient<DepartmentDetailPage>();
            builder.Services.AddTransient<DepartmentDeleteViewModel>();
            builder.Services.AddTransient<DepartmentDeletePage>();
            builder.Services.AddTransient<DepartmentCreateViewModel>();
            builder.Services.AddTransient<DepartmentCreate>();

            builder.Services.AddSingleton<IRepositoryService<Employee>, EmployeeService>();
            builder.Services.AddTransient<EmployeeViewModel>();
            builder.Services.AddTransient<EmployeesPage>();

            builder.Services.AddTransient<EmpleadoDetalleViewModel>();
            builder.Services.AddTransient<EmployeeDetailPage>();

            builder.Services.AddTransient<EmployeeUpdateViewModel>();
            builder.Services.AddTransient<EmployeeUpdate>();
            builder.Services.AddTransient<EmployeeCreateViewModel>();
            builder.Services.AddTransient<EmployeeCreate>();
            builder.Services.AddTransient<EmployeeDeleteViewModel>();
            builder.Services.AddTransient<EmployeeDeletePage>();

            builder.Services.AddTransient<DepartmentUpdateViewModel>();
            builder.Services.AddTransient<DepartmentUpdate>();

            return builder.Build();
        }

    }
}
