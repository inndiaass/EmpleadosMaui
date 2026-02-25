using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaMaui.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool systemTheme;
        [ObservableProperty]
        private bool lightTheme;
        [ObservableProperty]
        private bool darkTheme;

        [RelayCommand]
        private void ChangeTheme(string theme)
        { 

        }
    }
}
