using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class DepartmentDeletePage : ContentPage
{
    public DepartmentDeletePage(DepartmentDeleteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is not DepartmentDeleteViewModel vm)
        {
            return;
        }

        var ok = await DisplayAlert("Eliminar departamento", "Esta accion no se puede deshacer. Deseas continuar?", "Eliminar", "Cancelar");
        if (!ok)
        {
            return;
        }

        await vm.DeleteAsync();
    }
}
