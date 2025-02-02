﻿using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PreviewWindowDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CameraPage : Page
    {
        public CameraPage()
        {
            this.InitializeComponent();
            OpenCamera();
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
