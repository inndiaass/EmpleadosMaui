namespace PracticaMaui.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}
	void OnThemeChanged(object sender, EventArgs e)
	{
        //Usamos el evento que manda el picker para saber que opcion ha pulsado el usuario y cambiar el tema de la aplicacion
		//primero pasamos el objeto sender a picker porque por defecto en los argumentos se pasas como object pero hay que convertirlo.
		//y la opcion SelectedIndex nos da el numero como si fuese un array de la posicion que ha pulsado el usuario. 
        var picker = (Picker) sender;
		int posi= picker.SelectedIndex;

		switch (posi) 
		{
			case 0:
				App.Current.UserAppTheme = AppTheme.Unspecified;
				break;
			case 1:
				Application.Current.UserAppTheme = AppTheme.Light;
				break;
			case 2:
				Application.Current.UserAppTheme = AppTheme.Dark;
				break;
        }
    }
}