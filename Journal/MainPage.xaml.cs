// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Journal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            HeaderText.Text = "Entry for " + DateOnly.FromDateTime(DateTime.Now);
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            Entry entry = new Entry(journalInput.Text, DateTime.Now);
            JournalManager.GetInstance().AddEntry(entry);
            
        }

        private void ReadClick(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).Navigate(typeof(JournalPage));
        }
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).Navigate(typeof(SettingsPage));
        }
    }
}
