using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class EmployeeDeletePage : ContentPage
{
    public EmployeeDeletePage(EmployeeDeleteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is not EmployeeDeleteViewModel vm)
        {
            return;
        }

        var ok = await DisplayAlert("Eliminar empleado", "Esta accion no se puede deshacer. Deseas continuar?", "Eliminar", "Cancelar");
        if (!ok)
        {
            return;
        }

        await vm.DeleteAsync();
    }
}
