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
    public sealed partial class RegionDetailsPage : Page
    {
        Region View;

        public RegionDetailsPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            View = (Region)e.Parameter;
            this.DataContext = View;
            if(View.ID == 0)
            {
                btnDelete.IsEnabled = false;
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string sTitle = "Confirm Delete";
            string sMsg = "Are you certain you want to delete " + View.RegionName + "?";
            ContentDialogResult result = await ProfessorOak.ConfirmDialog(sTitle, sMsg);
            if(result == ContentDialogResult.Secondary)
            {
                try
                {
                    RegionRepository r = new RegionRepository();
                    await r.DeleteRegion(View);
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
                    sbuilder.AppendLine("Errors:");
                    foreach(var error in apiEx.Errors)
                    {
                        sbuilder.AppendLine("-" + error);
                    }
                    ProfessorOak.ShowMessage("Problem deleting the Region:", sbuilder.ToString());
                }
                catch(Exception)
                {
                    ProfessorOak.ShowMessage("Error", "Error deleting Region.");
                }
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegionRepository r = new RegionRepository();
                if(View.ID == 0)
                {
                    await r.AddRegion(View);
                }
                else
                {
                    await r.UpdateRegion(View);
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
                sbuilder.AppendLine(string.Format("HTTP Status Code: {0}", apiEx.StatusCode.ToString()));
                sbuilder.AppendLine("Errors:");
                foreach(var error in apiEx.Errors)
                {
                    sbuilder.AppendLine("-" + error);
                }
                ProfessorOak.ShowMessage("There was a problem saving the Region:", sbuilder.ToString());
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("Connection with the server"))
                {
                    ProfessorOak.ShowMessage("Error", "No connection with the server.");
                }
                else{
                    ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
