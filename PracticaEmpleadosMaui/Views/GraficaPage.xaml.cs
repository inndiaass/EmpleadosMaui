using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class GraficaPage : ContentPage
{
    private readonly DepartamentoViewModel _departamentoViewModel;

    public GraficaPage(DepartamentoViewModel departamentoViewModel)
	{
		InitializeComponent();
		_departamentoViewModel = departamentoViewModel;
		BindingContext = departamentoViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _departamentoViewModel.LoadDepartamentosAsync();
    }
}
