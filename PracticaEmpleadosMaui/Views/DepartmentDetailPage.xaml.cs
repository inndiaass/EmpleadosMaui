using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class DepartmentDetailPage : ContentPage
{
    public DepartmentDetailPage(DepartmentDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (BindingContext is DepartmentDetailViewModel vm && vm.Department != null)
        {
            await Shell.Current.GoToAsync("departmentUpdatePage",
                new ShellNavigationQueryParameters { { "Departamento", vm.Department } });
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is DepartmentDetailViewModel vm && vm.Department != null)
        {
            var ok = await DisplayAlert("Eliminar departamento", "Esta accion no se puede deshacer. Deseas continuar?", "Eliminar", "Cancelar");
            if (!ok)
            {
                return;
            }

            await vm.DeleteAsync();
        }
    }
}
