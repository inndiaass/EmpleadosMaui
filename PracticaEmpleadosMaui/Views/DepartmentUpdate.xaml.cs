using PracticaMaui.Models;
using PracticaMaui.ViewModels;

namespace PracticaMaui.Views;

public partial class DepartmentUpdate : ContentPage, IQueryAttributable
{
	public DepartmentUpdate(DepartmentUpdateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is DepartmentUpdateViewModel vm
            && query.TryGetValue("Departamento", out var depto)
            && depto is Department department)
        {
            vm.Department = department;
        }
    }
}
