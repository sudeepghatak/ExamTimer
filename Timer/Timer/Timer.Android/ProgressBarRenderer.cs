using Android.Graphics;
using Timer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(ExamProgressBarRenderer))]
namespace Timer.Droid
{

    public class ExamProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ScaleY = 4.0f;
                Control.ProgressDrawable.SetColorFilter(Android.Graphics.Color.Rgb(0, 255, 0), PorterDuff.Mode.SrcIn);
            }
        }
    }
}