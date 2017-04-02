using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MainConsole.Classes;

namespace CardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            chkIsCollectible.Checked += CheckBox_Checked;
            chkIsCollectible.Unchecked += CheckBox_Unchecked;

            WebServiceManager.RegularImagesFilePath = @"file:///C:\HS_RegularCardsTemp\";
            WebServiceManager.GoldImagesFilePath = @"file:///C:\HS_GoldCardsTemp\";

            WebServiceManager.GetAllCards(Convert.ToInt32(chkIsCollectible.IsChecked.Value)); // use 1 to get only collectible cards
            List<MainConsole.Classes.Card> listCards = WebServiceManager.ProvideCardList();

            dataGrid.ItemsSource = listCards;

            //myGrid.ItemsSource = null;
            //myGrid.ItemsSource = myDataSource;
        }

        private void ImgWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (dataGrid != null)
            {
                dataGrid.Columns[1].Width = _zoomX.Value;
                dataGrid.Columns[2].Width = _zoomX.Value;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            WebServiceManager.GetAllCards(1); // use 1 to get only collectible cards
            List<MainConsole.Classes.Card> listCards = WebServiceManager.ProvideCardList();

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listCards;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            WebServiceManager.GetAllCards(0); // use 1 to get only collectible cards
            List<MainConsole.Classes.Card> listCards = WebServiceManager.ProvideCardList();

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listCards;
        }

        void HandleCheckbox(CheckBox checkBox)
        {
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;

            // Assign Window Title.
            this.Title = "IsChecked = " + flag.ToString();
        }
    }
}
