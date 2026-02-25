using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class EmployeeCreate : ContentPage
{
    private readonly EmployeeCreateViewModel _viewModel;

    public EmployeeCreate(EmployeeCreateViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDepartmentsAsync();
    }
}
