using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Support.V4.Content;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Timer.Droid
{
    public class NumberSlider : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ProgressDrawable.SetColorFilter(Android.Graphics.Color.Rgb(217, 0, 0), PorterDuff.Mode.SrcIn);
                Drawable myThumb = ContextCompat.GetDrawable(Context, Resource.Drawable.throttle_thumb);
                Control.SetThumb(myThumb);
            }
        }
    }
}