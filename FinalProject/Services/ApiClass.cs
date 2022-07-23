using System.Net;
using Newtonsoft.Json;


namespace FinalProject.Services
{
    public class ApiClass
    {

        public Boolean check = false;

        public ApiClass(string word)
        {

            var apiRequest = $"https://api.polygon.io/v1/open-close/{word}0d";
            WebRequest request = WebRequest.Create(apiRequest);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }catch(Exception e)
            {
                check = false;
                return;
            }

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var DeserializedObject = JsonConvert.DeserializeObject<var>(responseFromServer);

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            check = true;
        }
    }
}
