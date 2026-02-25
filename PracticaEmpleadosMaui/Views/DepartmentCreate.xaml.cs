using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class DepartmentCreate : ContentPage
{
    public DepartmentCreate(DepartmentCreateViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
