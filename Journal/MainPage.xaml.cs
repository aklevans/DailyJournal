// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.XPath;
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
            Entry entry = JournalManager.GetInstance().GetEntry(DateTime.Now);
            if (entry != null)
            {
                journalInput.Text = entry.Text;
            }
            
        }

        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            

            if(journalInput.Text.Length > 0)
            {
                JournalManager instance = JournalManager.GetInstance();
                Entry entry = new Entry(journalInput.Text, DateTime.Now);

                //Already exists?
                if (instance.Entries().ContainsKey(DateTime.Now.Date))
                {
                    ContentDialogResult result = await existingEntryDialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        instance.ReplaceEntryText(DateTime.Now.Date, journalInput.Text);
                        //journalInput.Text = string.Empty;
                    }

                }
                else
                {
                    instance.AddEntry(entry);
                    //journalInput.Text = string.Empty;
                }
            }
            
        }




        private void ReadClick(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).NavigateDrill(typeof(JournalPage));
        }
        private async void SettingsClick(object sender, RoutedEventArgs e)
        {
            colorPicker.Color = (Windows.UI.Color)Application.Current.Resources["ApplicationPageBackgroundThemeBrush"];
            ContentDialogResult result = await settingsDialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                Application.Current.Resources["ApplicationPageBackgroundThemeBrush"] = colorPicker.Color;
                ((App)App.Current).NavigateDrill(typeof(MainPage));
            }
        }
    }
}
