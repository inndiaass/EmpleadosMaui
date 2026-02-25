using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class EmployeeDetailPage : ContentPage
{

	public EmployeeDetailPage(EmpleadoDetalleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (BindingContext is EmpleadoDetalleViewModel vm && vm.Employee != null)
        {
            await Shell.Current.GoToAsync("employeeUpdatePage", new ShellNavigationQueryParameters { { "Empleado", vm.Employee } });
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is EmpleadoDetalleViewModel vm && vm.Employee != null)
        {
            var ok = await DisplayAlert("Eliminar empleado", "Esta accion no se puede deshacer. Deseas continuar?", "Eliminar", "Cancelar");
            if (!ok)
            {
                return;
            }

            await vm.DeleteAsync();
        }
    }
}
