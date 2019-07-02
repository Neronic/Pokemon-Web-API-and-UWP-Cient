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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokemonClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            PopulateLists();
        }

        private async void PopulateLists()
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            TypesRepository t = new TypesRepository();
            RouteRepository r = new RouteRepository();
            RegionRepository re = new RegionRepository();
            try
            {
                List<Types> types = await t.GetTypess();
                List<Route> route = await r.GetRoutes();
                List<Region> region = await re.GetRegions();
                types.Add(new Types { ID = 0, TypeName = " - All Types" });
                route.Add(new Route { ID = 0, RouteName = " - All Routes" });
                region.Add(new Region { ID = 0, RegionName = " - All Regions" });
                App thisApp = Application.Current as App;
                thisApp.ActiveTypes = types;
                thisApp.ActiveRoutes = route;
                thisApp.ActiveRegions = region;
            }
            catch(ApiException apiEx)
            {
                var sbuilder = new StringBuilder();
                sbuilder.AppendLine("Errors: ");
                foreach (var error in apiEx.Errors)
                {
                    sbuilder.AppendLine("-" + error);
                }
                ProfessorOak.ShowMessage("Could not complete operation:", sbuilder.ToString());
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Connection with the server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with server. Ensure you have the proper connections and try again.");
                }
                else
                {
                    ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                }
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnPokemon_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PokemonPage));
        }

        private void BtnTypes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TypesPage));
        }

        private void BtnRoute_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RoutePage));
        }

        private void BtnRegion_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegionPage));
        }
    }
}
