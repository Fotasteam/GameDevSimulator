// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameDevSimulator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Microsoft.UI.Windowing.AppWindow m_AppWindow;
        public MainWindow()
        {
            this.InitializeComponent();
            DrawCustomTitleBar();
        }
        private Microsoft.UI.Windowing.AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return Microsoft.UI.Windowing.AppWindow.GetFromWindowId(wndId);
        }

        private void AppTitleBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Check to see if customization is supported.
            // Currently only supported on Windows 11.
            if (AppWindowTitleBar.IsCustomizationSupported()
                && m_AppWindow.TitleBar.ExtendsContentIntoTitleBar)
            {
                // Update drag region if the size of the title bar changes.
                SetDragRegionForCustomTitleBar(m_AppWindow);
            }
        }

        private void DrawCustomTitleBar()
        {
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                m_AppWindow = GetAppWindowForCurrentWindow();
                m_AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;

                m_AppWindow.TitleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0, 100, 33, 33); //zmien kolor pozniej!

                SetDragRegionForCustomTitleBar(m_AppWindow);
            }
        }

        private void SetDragRegionForCustomTitleBar(AppWindow appWindow)
        {
            RightPaddingColumn.Width = new GridLength(appWindow.TitleBar.RightInset);
            LeftPaddingColumn.Width = new GridLength(appWindow.TitleBar.LeftInset);

            List<Windows.Graphics.RectInt32> dragRectsList = new();

            Windows.Graphics.RectInt32 dragRectL;
            dragRectL.X = (int)((LeftPaddingColumn.ActualWidth));
            dragRectL.Y = 0;
            dragRectL.Height = (int)(AppTitleBar.ActualHeight);
            dragRectL.Width = (int)(IconColumn.ActualWidth + TitleColumn.ActualWidth + LeftDragColumn.ActualWidth);
            dragRectsList.Add(dragRectL);

            Windows.Graphics.RectInt32 dragRectR;
            dragRectR.X = (int)(LeftPaddingColumn.ActualWidth + IconColumn.ActualWidth + iconTitleBar.ActualWidth + LeftDragColumn.ActualWidth + NavigationColumn.ActualWidth);
            dragRectR.Y = 0;
            dragRectR.Height = (int)(AppTitleBar.ActualHeight);
            dragRectR.Width = (int)(RightDragColumn.ActualWidth);
            dragRectsList.Add(dragRectR);

            Windows.Graphics.RectInt32[] dragRects = dragRectsList.ToArray();

            appWindow.TitleBar.SetDragRectangles(dragRects);
        }
    }
}
