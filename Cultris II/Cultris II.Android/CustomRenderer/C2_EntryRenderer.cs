using Android.Content;
using Android.Content.Res;
using Cultris_II.Droid.CustomRenderer;
using Cultris_II.Views.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(C2_Entry), typeof(C2_EntryRenderer))]
namespace Cultris_II.Droid.CustomRenderer
{
    public class C2_EntryRenderer : EntryRenderer
    {
        public C2_EntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Entry entry = e.NewElement;
                Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
                Control.SetTextCursorDrawable(Resource.Color.accent_material_dark);
            }
        }
    }
}