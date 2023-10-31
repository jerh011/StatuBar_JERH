using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.CurrentActivity;
using StatuBar_JERH.Droid.statusbar;
using StatuBar_JERH.VistaModelo;
using Xamarin.Forms;
[assembly:Dependency(typeof(StatusBar))]

namespace StatuBar_JERH.Droid.statusbar
{
    internal class StatusBar : VMstatusbar
    {
        WindowManagerFlags _OriginalFlags;
        Window GetCrurrentwindo() 
        { 
        var window=CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
        public void MostrarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _OriginalFlags;
            activity.Window.Attributes = attrs;
        }
        public void CambiarColor()
        {
            MostrarStatusBar();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(()=>
                { 
                var currentWindow=GetCrurrentwindo();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(18, 18, 18));
                
                });
            
            }
        }

       

        public void OcultarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs= activity.Window.Attributes;
            _OriginalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;


        }

        public void Trasparente()
        {
            MostrarStatusBar();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCrurrentwindo();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);

                });
            }
        }
        public void Traslucido()
        {
            MostrarStatusBar();
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _OriginalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.TranslucentStatus;
            activity.Window.Attributes = attrs;
        }
    }
}