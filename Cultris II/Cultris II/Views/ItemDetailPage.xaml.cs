using Cultris_II.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cultris_II.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}