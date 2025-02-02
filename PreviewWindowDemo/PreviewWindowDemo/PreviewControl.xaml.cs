﻿using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PreviewWindowDemo
{
    public sealed partial class PreviewControl : UserControl
    {
        public PreviewControl()
        {
            this.InitializeComponent();
        }

        public async void OpenCamera()
        {
            CPTest.PreviewFailed += CPTest_PreviewFailed;
            await CPTest.StartAsync();
            CPTest.CameraHelper.FrameArrived += CPTest_FrameArrived;
        }
        private void CPTest_FrameArrived(object sender, FrameEventArgs e)
        {
            var videoFrame = e.VideoFrame;
            var softwareBitmap = videoFrame.SoftwareBitmap;
        }
        private void CPTest_PreviewFailed(object sender, PreviewFailedEventArgs e)
        {
            var errorMessage = e.Error;
        }
    }
}
