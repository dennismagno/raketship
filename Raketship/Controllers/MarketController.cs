using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Raketship.Models;

namespace Raketship.Controllers
{
    public class MarketController : ApiController
    {
        private MarketPlaceContext db = new MarketPlaceContext();

        // GET api/Market
        public IEnumerable<MarketPlace> GetMarketPlaces()
        {
            return db.MarketPlace.AsEnumerable();
        }

		// GET api/Market/5
		public MarketPlace GetMarketPlace(int id)
        {
            MarketPlace marketplace = db.MarketPlace.Find(id);
            if (marketplace == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return marketplace;
        }

		// PUT api/Market/5
		public HttpResponseMessage PutMarketPlace(int id, MarketPlace marketplace)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != marketplace.InvId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(marketplace).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

		// POST api/Market
		public HttpResponseMessage PostMarketPlace(MarketPlace marketplace)
        {
            if (ModelState.IsValid)
            {
                db.MarketPlace.Add(marketplace);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, marketplace);
                response.Headers.Location = new Uri(Url.Link("MarketApi", new { id = marketplace.InvId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteMarketPlace(int id)
        {
            MarketPlace marketplace = db.MarketPlace.Find(id);
            if (marketplace == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.MarketPlace.Remove(marketplace);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, marketplace);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}