using PokemonClient.Data;
using PokemonClient.Models;
using PokemonClient.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegionPage : Page
    {
        public RegionPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            showRegion();
        }

        private async void showRegion()
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            RegionRepository r = new RegionRepository();
            try
            {
                List<Region> region;
                region = await r.GetRegions();
                RegionList.ItemsSource = region.OrderBy(e => e.RegionName);
            }
            catch(ApiException apiEx)
            {
                var sbuilder = new StringBuilder();
                sbuilder.AppendLine("Errors:");
                foreach(var error in apiEx.Errors)
                {
                    sbuilder.AppendLine("-" + error);
                }
                ProfessorOak.ShowMessage("Could not complete operation:", sbuilder.ToString());
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with server.");
                }
                else
                {
                    ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }

        private void RegionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(RegionDetailsPage), (Region)e.ClickedItem);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            showRegion();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Region newRegion = new Region();
            Frame.Navigate(typeof(RegionDetailsPage), newRegion);
        }
    }
}
