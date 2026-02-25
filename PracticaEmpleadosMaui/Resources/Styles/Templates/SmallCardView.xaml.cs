namespace PracticaMaui.Resources.Styles.Templates;

public partial class SmallCardView : ContentView
{
    public static readonly BindableProperty NombreProperty = BindableProperty.Create(nameof(Nombre), typeof(string), typeof(CardView), string.Empty);
    public static readonly BindableProperty IconoProperty = BindableProperty.Create(nameof(Icono), typeof(string), typeof(CardView), string.Empty);

    public string Nombre { get => (string)GetValue(NombreProperty); set => SetValue(NombreProperty, value); }
    public string Icono { get => (string)GetValue(IconoProperty); set => SetValue(IconoProperty, value); }
    public SmallCardView()
	{
		InitializeComponent();
	}
}