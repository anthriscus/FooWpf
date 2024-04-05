using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FooWpf
{
    class ScratchWeb
    {
        public class WebRequestGetExample
        {
            public static void Fetch(string url)
            {
                // This is WebRequest is deprecated so, actually use HttpClient instead!
                // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-7.0

                // Create a request for the URL. 		
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                Console.WriteLine(response.StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
    }
}

