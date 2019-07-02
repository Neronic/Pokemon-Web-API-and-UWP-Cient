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
    public sealed partial class RouteDetailsPage : Page
    {
        Route View;

        public RouteDetailsPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            PopulateRegions();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            View = (Route)e.Parameter;
            this.DataContext = View;

            if(View.ID == 0)
            {
                btnDelete.IsEnabled = false;
            }
        }

        private void PopulateRegions()
        {
            try
            {
                App thisApp = Application.Current as App;
                List<Region> regions = thisApp.ActiveRegions;
                RegionCombo.ItemsSource = regions.Where(r => r.ID > 0).OrderBy(r => r.RegionName);
            }
            catch (Exception)
            {
                ProfessorOak.ShowMessage("Error", "No Regions available. Refresh and try again.");
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                View.Region = null;
                RouteRepository r = new RouteRepository();
                if(View.ID == 0)
                {
                    await r.AddRoute(View);
                }
                else
                {
                    await r.UpdateRoute(View);
                }
                Frame.GoBack();
            }
            catch(AggregateException ex)
            {
                string errorMsg = "";
                foreach(var exception in ex.InnerExceptions)
                {
                    errorMsg += Environment.NewLine + exception.Message;
                }
                ProfessorOak.ShowMessage("One or more exceptions have occured:", errorMsg);
            }
            catch(ApiException apiEx)
            {
                var sbuilder = new StringBuilder();
                //sbuilder.AppendLine(string.Format("HTTP Status Code: {0}", apiEx.StatusCode.ToString()));
                sbuilder.AppendLine("Errors:");
                foreach(var error in apiEx.Errors)
                {
                    sbuilder.AppendLine("-" + error);
                }
                ProfessorOak.ShowMessage("There was a problem saving the Route:", sbuilder.ToString());
            }
            catch(Exception ex)
            {
                if(ex.InnerException.Message.Contains("Connection with the server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with the server");
                }
                else
                {
                    ProfessorOak.ShowMessage("Error", "Could not complete operation");
                }
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string sTitle = "Confirm Delete";
            string sMsg = "Are you certain you want to delete " + View.RouteName + "?";
            ContentDialogResult result = await ProfessorOak.ConfirmDialog(sTitle, sMsg);
            if(result == ContentDialogResult.Secondary)
            {
                try
                {
                    View.Region = null;
                    RouteRepository r = new RouteRepository();
                    await r.DeleteRoute(View);
                    Frame.GoBack();
                }
                catch(AggregateException ex)
                {
                    string errorMsg = "";
                    foreach(var exception in ex.InnerExceptions)
                    {
                        errorMsg += Environment.NewLine + exception.Message;
                    }
                    ProfessorOak.ShowMessage("One or more exceptions have occured:", errorMsg);
                }
                catch (ApiException apiEx)
                {
                    var sbuilder = new StringBuilder();
                    sbuilder.AppendLine("Errors:");
                    foreach(var error in apiEx.Errors)
                    {
                        sbuilder.AppendLine("-" + error);
                    }
                    ProfessorOak.ShowMessage("Problem deleting Route:", sbuilder.ToString());
                }
                catch (Exception)
                {
                    ProfessorOak.ShowMessage("Error", "Error deleting Route");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
