using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class DepartmentsPage : ContentPage
{
	private readonly DepartamentoViewModel _departamentoViewModel;
    public DepartmentsPage(DepartamentoViewModel departamentoViewModel)
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

    private async void OnAddDepartmentClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("departmentCreatePage");
    }

    private async void OnEditDepartmentClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Models.Department department)
        {
            await Shell.Current.GoToAsync("departmentUpdatePage", new ShellNavigationQueryParameters { { "Departamento", department } });
        }
    }
}
