// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using GameDevSimulator.Views;
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

            contentFrame.Width = m_AppWindow.Size.Width - navView.Width;
            contentFrame.Height = m_AppWindow.Size.Height - 40;
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
            int navViewWidth = m_AppWindow.TitleBar.RightInset;

            int windowNavigationViewWidthAndPadding = (int)navView.ActualWidth + (int)navView.Margin.Right;
            int dragRegionWidth = m_AppWindow.Size.Width - navViewWidth;

            Windows.Graphics.RectInt32[] dragRects = Array.Empty<Windows.Graphics.RectInt32>();
            Windows.Graphics.RectInt32 dragRect;

            dragRect.X = /*windowNavigationViewWidthAndPadding*/ 0;
            dragRect.Y = 0;
            dragRect.Height = (int)AppTitleBar.Height;
            dragRect.Width = dragRegionWidth;

            Windows.Graphics.RectInt32[] dragRectsArray = dragRects.Append(dragRect).ToArray();
            m_AppWindow.TitleBar.SetDragRectangles(dragRectsArray);
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                var selectedItem = args.SelectedItem as NavigationViewItem;
                string selectedItemTag = ((string)selectedItem.Tag);
                string pageName = "GameDevSimulator.Views." + selectedItemTag;
                Type pageType = Type.GetType(pageName);
                contentFrame.Navigate(pageType);
            }
        }
    }
}
