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
    public sealed partial class RoutePage : Page
    {
        public RoutePage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            ddlPopulate();
        }

        private async void showRoutes(int? RouteID)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            RouteRepository r = new RouteRepository();
            try
            {
                List<Route> routes;
                if(RouteID.GetValueOrDefault() > 0)
                {
                    routes = await r.GetRoutesByRegion(RouteID.GetValueOrDefault());
                }
                else
                {
                    routes = await r.GetRoutes();
                }
                routeList.ItemsSource = routes.OrderBy(e => e.ID);
            }
            catch (ApiException apiEx)
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
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with the server.");
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

        private void RegionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Region selectedRegion = (Region)RegionCombo.SelectedItem;
            showRoutes(selectedRegion?.ID);
            RoutePokemonListGrid.Visibility = Visibility.Collapsed;
        }

        private void ddlPopulate()
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {
                App thisApp = Application.Current as App;
                List<Region> regions = thisApp.ActiveRegions;
                RegionCombo.ItemsSource = regions.OrderBy(r => r.RegionName);
                //btnAdd.IsEnabled = true;
                showRoutes(null);
                showPokemon(null);
            }
            catch (ApiException apiEx)
            {
                var sbuilder = new StringBuilder();
                sbuilder.AppendLine("Errors: ");
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
                if(ex.InnerException.Message.Contains("Connection with the server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with the server. Ensure you have the proper connections and try again.");
                }
                else
                {
                    ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                }
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }

        private async void showPokemon(int? RouteID)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            PokemonRepository p = new PokemonRepository();
            try
            {
                List<Pokemon> pokemon;
                if (RouteID.GetValueOrDefault() > 0)
                {
                    pokemon = await p.GetPokemonsByRoute(RouteID.GetValueOrDefault());
                }
                else
                {
                    RoutePokemonListGrid.Visibility = Visibility.Collapsed;
                    return;
                    //pokemon = await p.GetPokemons();
                }
                RoutePokemonListPanel.ItemsSource = pokemon.OrderBy(e => e.Number);
            }
            catch (ApiException apiEx)
            {
                var sbuilder = new StringBuilder();
                sbuilder.AppendLine("Errors:");
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
                if (ex.InnerException.Message.Contains("server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connect with the server.");
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

        private void RouteList_ItemClick(object sender, ItemClickEventArgs e)
        {
            RoutePokemonListGrid.Visibility = Visibility.Visible;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ddlPopulate();
        }

        /*private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Route newRoute = new Route();
            Frame.Navigate(typeof(RouteDetailsPage), newRoute);
        }*/

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void RouteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Route selectRoute = (Route)routeList.SelectedItem;
            showPokemon(selectRoute?.ID);
            
        }
    }
}
