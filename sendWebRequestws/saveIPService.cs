using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace sendWebRequestws
{
    public partial class saveIPService : ServiceBase
    {
        public saveIPService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Create a request for the URL. 		
            var appreader = new AppSettingsReader();

            var urlSetting = appreader.GetValue("requestURL", typeof(string));
            var timeLen = appreader.GetValue("sleepTimeLen", typeof(int));


                //Console.WriteLine(string.Format("start: {0}", timeLen));
                WebRequest request = WebRequest.Create(urlSetting.ToString());
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                //Console.WriteLine(response.StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content. 
                string responseFromServer = reader.ReadToEnd();
                //Console.WriteLine(string.Format("IPaddress: {0}", responseFromServer));
                SaveIp(responseFromServer);
                // Display the content.
                //Console.WriteLine(responseFromServer);
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
                System.Threading.Thread.Sleep((int)timeLen);

                //Console.WriteLine(string.Format("sleep: {0}", timeLen));
          
            
        }

        protected override void OnStop()
        {
        }

        //add here
        private static void SaveIp(string ipAddress)
        {


            SqlConnection con = null;

            string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlDataReader rdr = null;

            try
            {

                con = new SqlConnection(conectionString);

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IpAddress_addIp";
                cmd.Connection = con;

                var sp = new SqlParameter("@ip", ipAddress);
                cmd.Parameters.Add(sp);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                ;
            }
            finally
            {

                if (rdr != null)
                    rdr.Close();

                if (con != null)
                {
                    con.Close();
                    con = null;
                }

            }
        }
        //end add here
    }
}
