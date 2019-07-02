using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PokemonClient.Utilities
{
    public static class ProfessorOak
    {
        public static Uri DBUri = new Uri("http://localhost:52638//"); //Make sure localhost number is the same

        //public static Uri DBUri = new Uri(); ------- In case azure hosting

        internal async static void ShowMessage(string strTitle, string Msg)
        {
            ContentDialog diag = new ContentDialog()
            {
                Title = strTitle,
                Content = Msg,
                PrimaryButtonText = "Ok"
            };
            await diag.ShowAsync();
        }

        //Secondary version for MsgBox functionality
        internal async static Task<ContentDialogResult> ConfirmDialog(string strTitle, string Msg)
        {
            ContentDialog diag = new ContentDialog()
            {
                Title = strTitle,
                Content = Msg,
                PrimaryButtonText = "No",
                SecondaryButtonText = "Yes"
            };
            ContentDialogResult result = await diag.ShowAsync();
            return result;
        }

        //WEB Api HTTP error result unwrapping
        //Source:
        //http://www.codeproject.com/Articles/825274/ASP-NET-Web-Api-Unwrapping-HTTP-Error-Results-and#Unwrapping-and-Handling-Errors-and-Exceptions-in-Web-Api
        public static ApiException CreateApiException(HttpResponseMessage response)
        {
            var httpErrorObject = response.Content.ReadAsStringAsync().Result;

            //Anonymous object to use as the template for deserialization
            var anonymousErrorObject = new Dictionary<string, string[]>();

            //Deserialize
            var deserializedErrorObject = JsonConvert
                .DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);

            //Wrap into exception
            var ex = new ApiException(response);

            var errors = deserializedErrorObject.Select(kvp => string.Join(". ", kvp.Value));
            for(int i = 0; i < errors.Count(); i++)
            {
                //wrap errors into base exception.data dictionary
                ex.Data.Add(i, errors.ElementAt(i));
            }
            return ex;
        }
    }
}
