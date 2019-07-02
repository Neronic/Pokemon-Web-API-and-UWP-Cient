using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
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
using PokemonClient.Data;
using PokemonClient.Models;
using PokemonClient.Utilities;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TypesPage : Page
    {
        public TypesPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            showTypes(null);
        }

        private async void showTypes(string typeName)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            TypesRepository t = new TypesRepository();
            try
            {
                List<Types> types;
                if (!string.IsNullOrEmpty(typeName))
                {
                    types = await t.GetTypesContains(typeName.ToString());
                }
                else
                {
                    types = await t.GetTypess();
                }
                TypesList.ItemsSource = types.OrderBy(e => e.TypeName);
            }
            catch(ApiException apiEx)
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

        private void TypesList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(TypesDetailsPage), (Types)e.ClickedItem);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            showTypes(null);
            typesSearchBar.QueryText = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Types newType = new Types();
            Frame.Navigate(typeof(TypesDetailsPage), newType);
        }

        private void TypesSearchBar_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            string selectType = typesSearchBar.QueryText.ToString();
            showTypes(selectType);
        }
    }
}
