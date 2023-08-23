using Cultris_II.ViewModels;
using Cultris_II.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Cultris_II
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnLogout_Clicked(object sender, EventArgs e)
        {
             await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
