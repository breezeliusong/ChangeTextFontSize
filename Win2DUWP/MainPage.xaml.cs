using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win2DUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        bool size_channged = false;
        Size changed_size;
        string txtToDraw = "Hello cruel world";
        CanvasTextFormat ctf;


        private void myCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            size_channged = true;
            changed_size = e.NewSize;
        }

        private void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            if (size_channged)
            {
                Update(sender, changed_size);
                size_channged = false;
            }
            args.DrawingSession.DrawText(txtToDraw, 0, 0, Colors.DodgerBlue, ctf);
        }


        private void Update(CanvasControl sender, Size NewSize)
        {
            float factor;
            float fontsize;
            using (CanvasTextFormat ctf_tmp = new CanvasTextFormat())
            using (CanvasTextLayout ctl_tmp = new CanvasTextLayout((CanvasControl)sender, txtToDraw, ctf_tmp, (float)NewSize.Width, (float)NewSize.Height))
            {
                fontsize = ctf_tmp.FontSize;
                factor = (float)System.Math.Min(NewSize.Width / ctl_tmp.LayoutBounds.Width, NewSize.Height / ctl_tmp.LayoutBounds.Height);
            }
            ctf = new CanvasTextFormat { FontSize = fontsize * factor };
        }

    }
}
