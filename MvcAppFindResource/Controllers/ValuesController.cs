using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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