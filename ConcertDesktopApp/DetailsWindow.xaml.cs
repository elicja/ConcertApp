﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConcertDesktopApp
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private List<ConcertData> _concerts;
        public DetailsWindow()
        {
            InitializeComponent();
        }

        public DetailsWindow(ref List<ConcertData> concerts) : this()
        {
            _concerts = concerts;
        }

        public void LoadData(ConcertData concertData, bool disableEdtiting = true)
        {
            guid.Text = concertData.Id.ToString();
            artistName.Text = concertData.ArtistName;
            price.Text = concertData.Price.ToString();
            startDate.Text = concertData.StartDate.ToString();

            artistName.IsReadOnly = disableEdtiting;
            price.IsReadOnly = disableEdtiting;
            startDate.Focusable = disableEdtiting;            

            if (disableEdtiting)
            {
                save.Visibility = Visibility.Hidden;
                goBack.Visibility = Visibility.Hidden;
                goBackAlone.Visibility = Visibility.Visible;
            }
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            ConcertData concert = new ConcertData
            {
                ArtistName = artistName.Text,
                Price = double.Parse(price.Text),
                StartDate = DateTime.Parse(startDate.Text)
            };

            //Nie istnieje jeszcze taki obiekt
            if(Guid.Parse(guid.Text) == Guid.Empty)
            {
                concert.Id = Guid.NewGuid();
                _concerts.Add(concert);
            }
            else
            {
                Guid concertId = Guid.Parse(guid.Text);
                ConcertData concertToDelete = _concerts.FirstOrDefault(x => x.Id == concertId);
                if(concertToDelete != null)
                {
                    concert.Id = concertId;
                    _concerts.Remove(concertToDelete);
                    _concerts.Add(concert);
                }
            }           
            

            this.Close();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
