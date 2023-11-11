using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ConcertDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ConcertData> concerts;
        private FileHelper _fileHelper;

        public MainWindow()
        {
            _fileHelper = new FileHelper();
            concerts = new List<ConcertData>();

            InitializeComponent();

            LoadDetails(this,null);

            MainInfo.ItemsSource = concerts;
        }

        private void ShowDetails(object sender, RoutedEventArgs e)
        {
            DetailsWindow details = new DetailsWindow();
            ConcertData concertData = ((FrameworkElement)sender).DataContext as ConcertData; // pobiera dane modelu z kodu w xml
            details.LoadData(concertData, true);
            details.Show();
        }

        private void EditDetails(object sender, RoutedEventArgs e)
        {
            DetailsWindow details = new DetailsWindow(this);
            ConcertData concertData = ((FrameworkElement)sender).DataContext as ConcertData;
            details.LoadData(concertData, false);
            details.Show();
        }

        private void AddDetails(object sender, RoutedEventArgs e)
        {
            DetailsWindow details = new DetailsWindow(this);
            ConcertData concertData = new ConcertData();      // pusty obiekt    
            details.LoadData(concertData, false);
            details.Show();
        }

        public void DeleteDetails(object sender, RoutedEventArgs e)
        {
            ConcertData concertData = ((FrameworkElement)sender).DataContext as ConcertData;
            concerts.Remove(concertData);
            MainInfo.Items.Refresh();
        }

        public void LoadDetails(object sender, RoutedEventArgs e)
        {
            List<ConcertData> concertsData = _fileHelper.LoadFromFile();
            concerts = concertsData;
            MainInfo.ItemsSource = concerts;
            MainInfo.Items.Refresh();
        }

        public void SaveDetails(object sender, RoutedEventArgs e)
        {
            _fileHelper.SaveToFile(concerts);
        }
    }
}
