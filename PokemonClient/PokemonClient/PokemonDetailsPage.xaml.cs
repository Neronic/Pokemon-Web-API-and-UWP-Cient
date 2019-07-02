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
    public sealed partial class PokemonDetailsPage : Page
    {
        Pokemon View;

        public PokemonDetailsPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            populateTypes();
            populateRoute();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            View = (Pokemon)e.Parameter;
            this.DataContext = View;

            if(View.ID == 0)
            {
                btnDelete.IsEnabled = false;
            }
        }

        private void populateTypes()
        {
            try
            {
                App thisApp = Application.Current as App;
                List<Types> types = thisApp.ActiveTypes;
                TypesCombo.ItemsSource = types.Where(t => t.ID > 0).OrderBy(t => t.TypeName);
                
            }
            catch(Exception)
            {
                ProfessorOak.ShowMessage("Error", "No Types available. Refresh and try again.");
            }
        }

        private void populateRoute()
        {
            try
            {
                App thisApp = Application.Current as App;
                List<Route> route = thisApp.ActiveRoutes;
                RouteCombo.ItemsSource = route.Where(r => r.ID > 0).OrderBy(r => r.RouteName);
            }
            catch (Exception)
            {
                ProfessorOak.ShowMessage("Error", "No Routes Available. Refresh and try again.");
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(pokemonNumberTextBox.Text) > 807 || Convert.ToInt32(pokemonNumberTextBox.Text) < 1)
            {
                ProfessorOak.ShowMessage("Error", "Pokemon Number is out of range. Must be between 1 and 807.");
            }
            else
            {
                try
                {
                    View.Route = null;
                    View.Types = null;
                    PokemonRepository pr = new PokemonRepository();
                    if (View.ID == 0)
                    {
                        await pr.AddPokemon(View);
                    }
                    else
                    {
                        await pr.UpdatePokemon(View);
                    }
                    Frame.GoBack();
                }
                catch (AggregateException ex)
                {
                    string errorMsg = "";
                    foreach (var exception in ex.InnerExceptions)
                    {
                        errorMsg += Environment.NewLine + exception.Message;
                    }
                    ProfessorOak.ShowMessage("One or more exceptios have occured:", errorMsg);
                }
                catch (ApiException apiEx)
                {
                    var sbuilder = new StringBuilder();
                    sbuilder.AppendLine(string.Format("HTTP Status Code: {0}", apiEx.StatusCode.ToString()));
                    sbuilder.AppendLine("Errors:");
                    foreach (var error in apiEx.Errors)
                    {
                        sbuilder.AppendLine("-" + error);
                    }
                    ProfessorOak.ShowMessage("There was a problem saving the Pokemon:", sbuilder.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("Connection with the server"))
                    {
                        ProfessorOak.ShowMessage("Error", "No connection with the server.");
                    }
                    else
                    {
                        ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                    }
                }
            }
            
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string sTitle = "Confirm Delete";
            string sMsg = "Are you certain you want to delete " + View.Name + "?";
            ContentDialogResult result = await ProfessorOak.ConfirmDialog(sTitle, sMsg);
            if(result == ContentDialogResult.Secondary)
            {
                try
                {
                    View.Route = null;
                    View.Types = null;
                    PokemonRepository pr = new PokemonRepository();
                    await pr.DeletePokemon(View);
                    Frame.GoBack();
                }
                catch(AggregateException ex)
                {
                    string errorMsg = "";
                    foreach (var exception in ex.InnerExceptions)
                    {
                        errorMsg += Environment.NewLine + exception.Message;
                    }
                    ProfessorOak.ShowMessage("One or more exceptions have occured:", errorMsg);
                }
                catch(ApiException apiEx)
                {
                    var sbuilder = new StringBuilder();
                    sbuilder.AppendLine("Errors:");
                    foreach(var error in apiEx.Errors)
                    {
                        sbuilder.AppendLine("-" + error);
                    }
                    ProfessorOak.ShowMessage("PRoblem deleting the Pokemon:", sbuilder.ToString());
                }
                catch (Exception)
                {
                    ProfessorOak.ShowMessage("Error", "Error deleting Pokemon");
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
