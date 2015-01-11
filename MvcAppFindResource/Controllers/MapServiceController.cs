using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using MvcAppFindResource.Models;
using Newtonsoft.Json;

namespace MvcAppFindResource.Controllers
{
    public class MapServiceController : ApiController
    {

        // WebReq 
        public string AllReqPorxy()
        {
            var URL = Request.RequestUri.PathAndQuery;
            //URL = String.Format("http://{0}/{1}", DynIp.serviceIp, URL);

            string result = webrequest(URL);
            return result;
        }

        //
        public string webrequest(string url)
        {
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

            return responseFromServer;

        }
    }
}
