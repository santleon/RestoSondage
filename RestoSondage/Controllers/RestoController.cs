﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestoSondage.Models;

namespace RestoSondage.Controllers
{
    public class RestoController : ApiController
    {
        private RestoSondageContext db = new RestoSondageContext();

        // GET: api/Resto
        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        // GET: api/Resto/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Resto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Resto
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Resto/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }
    }
}