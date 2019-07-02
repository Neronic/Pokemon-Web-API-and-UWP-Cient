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
    public sealed partial class PokemonPage : Page
    {
        public PokemonPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            showPokemon(null);
            sortPokemon(null);
            //ddlPopulate();
        }
        public bool searchBarBool;

        /*private void ddlPopulate()
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {
                App thisApp = Application.Current as App;
                List<Types> types = thisApp.ActiveTypes;
                //Bind to the ComboBox
                //TypesCombo.ItemsSource = types.OrderBy(ty => ty.TypeOne);
                btnAdd.IsEnabled = true;
                showPokemon(null);
                sortPokemon(null);
            }
            catch(ApiException apiEx)
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
                    ProfessorOak.ShowMessage("Error", "No connection with server. Ensure you have the proper connections and try again.");
                }
                else
                {
                    ProfessorOak.ShowMessage("Error", "Could not complete operation.");
                }
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }*/

        private async void sortPokemon(string name)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            PokemonRepository p = new PokemonRepository();
            try
            {
                List<Pokemon> pokemon;
                if (!string.IsNullOrEmpty(name))
                {
                    pokemon = await p.GetPokemonsContains(name.ToString());
                }
                else
                {
                    pokemon = await p.GetPokemons();
                }
                pokemonList.ItemsSource = pokemon.OrderBy(e => e.Number);
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

        private async void showPokemon(/*int? TypesID*/ string typesName)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;
            

            PokemonRepository p = new PokemonRepository();
            try
            {
                List<Pokemon> pokemon;
                if(/*TypesID.GetValueOrDefault() > 0*/!string.IsNullOrEmpty(typesName))
                {
                        //pokemon = await p.GetPokemonsByTypes(TypesID.GetValueOrDefault());
                    pokemon = await p.GetPokemonsTypeIs(typesName.ToString());
                }
                else
                {
                    pokemon = await p.GetPokemons();
                }
                pokemonList.ItemsSource = pokemon.OrderBy(e => e.Number);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pokemon newPokemon = new Pokemon();

            Frame.Navigate(typeof(PokemonDetailsPage), newPokemon);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //ddlPopulate();
            PokemonDetailsPanel.Visibility = Visibility.Collapsed;
            pokemonSearchBar.QueryText = "";
            typeSearchBar.QueryText = "";
            showPokemon(null);
            sortPokemon(null);
        }

        /*private void TypesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Types selectTypes = (Types)TypesCombo.SelectedItem;
            showPokemon(selectTypes?.ID);
            PokemonDetailsPanel.Visibility = Visibility.Collapsed;
        }*/

        //View Details of pokemon
        private void PokemonList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedPokemon = (Pokemon)e.ClickedItem;

            pokemonNameField.Text = selectedPokemon.Name;
            pokemonNumberField.Text = selectedPokemon.Number.ToString();
            pokemonRoutesField.Text = selectedPokemon.Route.RouteName;

            if (!string.IsNullOrEmpty(selectedPokemon.Types.TypeTwo))
            {
                pokemonTypeTwoField.Text = selectedPokemon.Types.TypeTwo;
                pokemonTypeTwoField.Visibility = Visibility.Visible;
                pokemonTypeTwoTextBlock.Visibility = Visibility.Visible;
                pokemonTypeOneTextBlock.Text = "Type One:";
            }
            else
            {
                pokemonTypeTwoField.Visibility = Visibility.Collapsed;
                pokemonTypeTwoTextBlock.Visibility = Visibility.Collapsed;
                pokemonTypeOneTextBlock.Text = "Type:";
            }

            if(!string.IsNullOrEmpty(selectedPokemon.Types.TypeOne))
            {
                pokemonTypeOneField.Text = selectedPokemon.Types.TypeOne;
            }
            else
            {
                pokemonTypeOneField.Text = selectedPokemon.Types.TypeName;
            }

            if (!string.IsNullOrEmpty(selectedPokemon.Description))
            {
                pokemonDescField.Text = selectedPokemon.Description;
            }
            else
            {
                pokemonDescField.Text = "No Description Available";
            }

            PokemonDetailsPanel.Visibility = Visibility.Visible;
        }

        //Edit selected pokemon
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PokemonDetailsPage), (Pokemon)pokemonList.SelectedItem);
        }

        private void PokemonSearchBar_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            if (!string.IsNullOrEmpty(typeSearchBar.QueryText.ToString()))
            {
                typeSearchBar.QueryText = "";
                
            }
            string selectPokemon = pokemonSearchBar.QueryText.ToString();
            sortPokemon(selectPokemon);
            PokemonDetailsPanel.Visibility = Visibility.Collapsed;
        }

        private void TypeSearchBar_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            if (!string.IsNullOrEmpty(pokemonSearchBar.QueryText.ToString()))
            {
                pokemonSearchBar.QueryText = "";
                
            }
            string selectPokemon = typeSearchBar.QueryText.ToString();
            showPokemon(selectPokemon);
            PokemonDetailsPanel.Visibility = Visibility.Collapsed;
        }
    }
}
