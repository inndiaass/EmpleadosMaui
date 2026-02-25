using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class EmployeesPage : ContentPage
{
    private readonly EmployeeViewModel _employeeViewModel;
    public EmployeesPage(EmployeeViewModel empleadoViewModel)
	{
		InitializeComponent();
        _employeeViewModel = empleadoViewModel;
        BindingContext = _employeeViewModel;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _employeeViewModel.LoadEmpleadosAsync();

    }

    private async void OnAddEmployeeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("employeeCreatePage");
    }
}
