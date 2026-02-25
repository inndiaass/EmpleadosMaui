using System.Windows.Input;

namespace PracticaMaui.Resources.Styles.Templates;

    public partial class CardView : ContentView
    {
    public static readonly BindableProperty NombreProperty = BindableProperty.Create(nameof(Nombre), typeof(string), typeof(CardView), string.Empty);
    public static readonly BindableProperty ApellidosProperty = BindableProperty.Create(nameof(Apellidos), typeof(string), typeof(CardView), string.Empty);
    public static readonly BindableProperty NombreDptoProperty = BindableProperty.Create(nameof(NombreDpto), typeof(string), typeof(CardView), string.Empty);
    public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(CardView), string.Empty);

    // Propiedades para el estilo
    public static readonly BindableProperty CardColorProperty = BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardView), Colors.White);
    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardView), Colors.Black);
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CardView), Colors.Gray);

    public static readonly BindableProperty DetallesCommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CardView));

    public string Nombre { get => (string)GetValue(NombreProperty); set => SetValue(NombreProperty, value); }
    public string Apellidos { get => (string)GetValue(ApellidosProperty); set => SetValue(ApellidosProperty, value); }
    public string NombreDpto { get => (string)GetValue(NombreDptoProperty); set => SetValue(NombreDptoProperty, value); }
    public string ImageUrl { get => (string)GetValue(ImageUrlProperty); set => SetValue(ImageUrlProperty, value); }
    public Color CardColor { get => (Color)GetValue(CardColorProperty); set => SetValue(CardColorProperty, value); }
    public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }
    public Color IconBackgroundColor { get => (Color)GetValue(IconBackgroundColorProperty); set => SetValue(IconBackgroundColorProperty, value); }

    public CardView()
    {
        InitializeComponent();
    }

    private async void OnLinkDetailtapped(Object sender, TappedEventArgs e) 
    { 
        if (BindingContext is Models.Employee empleado)
        {
            await Shell.Current.GoToAsync("employeeDetailsPage",
                new ShellNavigationQueryParameters { { "Empleado", empleado } });
            return;
        }

        if (BindingContext is Models.Department department)
        {
            await Shell.Current.GoToAsync("departmentDetailsPage",
                new ShellNavigationQueryParameters { { "Departamento", department } });
        }
    }
}
