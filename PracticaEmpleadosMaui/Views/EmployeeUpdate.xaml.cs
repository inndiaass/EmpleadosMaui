using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class EmployeeUpdate : ContentPage
{
	public EmployeeUpdate(EmployeeUpdateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}

    
}
