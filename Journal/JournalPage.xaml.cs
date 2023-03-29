// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Journal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JournalPage : Page
    {
        public JournalPage()
        {
            this.InitializeComponent();
            LayoutDesign();
        }

        private void LayoutDesign()
        {
            JournalManager instance = JournalManager.GetInstance();
            SortedDictionary<DateTime, Entry> entries = instance.Entries();

            foreach (KeyValuePair<DateTime, Entry> entry in JournalManager.GetInstance().Entries())
            {
                StackPanel EntryPanel = new StackPanel();
                EntryPanel.HorizontalAlignment = HorizontalAlignment.Left;
                EntryPanel.Background = new SolidColorBrush(Colors.White);

                Border border = new Border();
                border.Background = new SolidColorBrush(Colors.White);
                border.BorderBrush = new SolidColorBrush(Colors.Black);
                border.CornerRadius = new CornerRadius(5);
                border.Padding = new Thickness(5);
                border.Width = 600;
                border.Child = EntryPanel;
                border.Margin = new Thickness(10);
                JournalStack.Children.Add(border);

                TextBlock Date = new TextBlock();
                Date.Text = entry.Value.Date.ToString();
                Date.HorizontalAlignment = HorizontalAlignment.Left;
                EntryPanel.Children.Add(Date);

                TextBlock EntryText = new TextBlock();
                EntryText.Text = entry.Value.Text;
                EntryPanel.Children.Add(EntryText);
            }

            
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).Navigate(typeof(MainPage));
        }
    }
}
