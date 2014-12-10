using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using MvcAppFindResource.Models;

namespace MvcAppFindResource.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public positions_selectct_by_id_Result Get(string id)
        {

            var dbent = new positionDBEntities();

            var result = dbent.positions_selectct_by_id(id);


            return result.FirstOrDefault();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        public void Add2(int id )
        {
            var i = 0;
        }

        [HttpGet]
        public int Insert([FromUri] position request)
        {
            var dbent = new positionDBEntities();
            var pos = new position
            {
                Id = 0,
                keyName = request.keyName,
                Lat = request.Lat,
                Lng = request.Lng,
                dateStamp = request.dateStamp
            };
            try
            {
                var result = dbent.positions_add(pos.Id, pos.keyName, pos.Lat, pos.Lng, pos.dateStamp);
                result = (result == 0) ? 1 : 0;
            }
            catch (Exception)
            {
                //error process
                throw;
            }


            return 1;
        }

        [HttpGet]
        public string visitorIPAddress()
        {
            var ipAdress = GetVisitorIPAddress(false);
            return ipAdress;
        }
        /// <summary>
        /// method to get Client ip address
        /// </summary>
        /// <param name="GetLan"> set to true if want to get local(LAN) Connected ip address</param>
        /// <returns></returns>
        public string GetVisitorIPAddress(bool GetLan = false)
        {
            string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (String.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
            {
                GetLan = true;
                visitorIPAddress = string.Empty;
            }

            if (GetLan)
            {
                if (string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = Dns.GetHostName();
                    //Get Ip Host Entry
                    IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                    //Get Ip Address From The Ip Host Entry Address List
                    IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                    try
                    {
                        visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                    }
                    catch
                    {
                        try
                        {
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            try
                            {
                                arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                visitorIPAddress = arrIpAddress[0].ToString();
                            }
                            catch
                            {
                                visitorIPAddress = "127.0.0.1";
                            }
                        }
                    }
                }
            }


            return visitorIPAddress;

            /*
             string browserInfo =
             "RemoteUser=" + context.Request.ServerVariables["REMOTE_USER"] + ";\n"
            + "RemoteHost=" + context.Request.ServerVariables["REMOTE_HOST"] + ";\n"
            + "Type=" + context.Request.Browser.Type + ";\n"
            + "Name=" + context.Request.Browser.Browser + ";\n"
            + "Version=" + context.Request.Browser.Version + ";\n"
            + "MajorVersion=" + context.Request.Browser.MajorVersion + ";\n"
            + "MinorVersion=" + context.Request.Browser.MinorVersion + ";\n"
            + "Platform=" + context.Request.Browser.Platform + ";\n"
            + "SupportsCookies=" + context.Request.Browser.Cookies + ";\n"
            + "SupportsJavaScript=" + context.Request.Browser.EcmaScriptVersion.ToString() + ";\n"
            + "SupportsActiveXControls=" + context.Request.Browser.ActiveXControls + ";\n"
            + "SupportsJavaScriptVersion=" + context.Request.Browser["JavaScriptVersion"] + "\n";
             */
        }

        public static CultureInfo ResolveCulture()
        {
            string[] languages = HttpContext.Current.Request.UserLanguages;

            if (languages == null || languages.Length == 0)
                return null;

            try
            {
                string language = languages[0].ToLowerInvariant().Trim();
                return CultureInfo.CreateSpecificCulture(language);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static RegionInfo ResolveCountry()
        {
            CultureInfo culture = ResolveCulture();
            if (culture != null)
                return new RegionInfo(culture.LCID);

            return null;
        }
        /*
        [GET("HotelRooms"), HttpGet]
        public virtual HotelRoomAvailability GetHotelRooms([FromUri] HotelRoomRequest request)
        {
            return searchService.GetHotelRooms(request);
        }

        [POST("MakeBook"), HttpPost]
        public virtual HotelBookResult MakeBook(HotelBookRequest request)
        {
            return bookService.MakeBook(request);
        }

         */
    }
}