﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
            day_Name.IsChecked = true;
        }

        private void Day_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                day_Name.IsChecked = true;
                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Bar_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Sport_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/SportStatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}