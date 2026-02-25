using PracticaMaui.Views;

namespace PracticaMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeRouting();

        }

        private void InitializeRouting()
        {
            Routing.RegisterRoute("employeeDetailsPage", typeof(EmployeeDetailPage));
            Routing.RegisterRoute("employeeUpdatePage", typeof(EmployeeUpdate));
            Routing.RegisterRoute("employeeCreatePage", typeof(EmployeeCreate));
            Routing.RegisterRoute("employeeDeletePage", typeof(EmployeeDeletePage));
            Routing.RegisterRoute("departmentUpdatePage", typeof(DepartmentUpdate));
            Routing.RegisterRoute("departmentDetailsPage", typeof(DepartmentDetailPage));
            Routing.RegisterRoute("departmentCreatePage", typeof(DepartmentCreate));
            Routing.RegisterRoute("departmentDeletePage", typeof(DepartmentDeletePage));
        }


    }
}
