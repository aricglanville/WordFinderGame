using System.Net;
using FinalProject.Models;
using Newtonsoft.Json;


namespace FinalProject.Services
{
    public class ApiClass
    {

        public Boolean check = false;
        public int sz = 0;
        public string temp;

        public ApiClass(string word)
        {

            var apiRequest = $"https://www.dictionaryapi.com/api/v3/references/collegiate/json/{word}?key=055759de-1dbe-41f4-abdf-88515b530cbd";
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
            // var DeserializedObject = JsonConvert.DeserializeObject<Word>(responseFromServer);
            sz = responseFromServer.Length;
            temp = responseFromServer.Split("\"")[1].Split("\"")[0];
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            if(temp == "meta")
            {
                check = true;
            }
        }
    }
}
