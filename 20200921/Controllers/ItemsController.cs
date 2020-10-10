using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20200921.Data;
using _20200921.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _20200921.Controllers
{
    public class ItemsController : Controller
    {        

        private StoreContext context;
        private UserManager<IdentityUser> userManager;

        public ItemsController(StoreContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: Items
        public ActionResult Index(decimal? priceFrom, decimal? priceTo)
        {
            return View(context.Items.Where(item => item.Price >= (priceFrom ?? 0m) 
                && item.Price <= (priceTo ?? Decimal.MaxValue)));
        }

        // GET: Items/Details/5
        public ActionResult Details(Guid id)
        {
            return View(context.Items.Where(item => item.Id == id).First());
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection["Name"];
                string description = collection["Description"];
                decimal price = Decimal.Parse(collection["Price"]);
                Item newItem = new Item
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Id = Guid.NewGuid()
                };
                context.Items.Add(newItem);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(context.Items.Where(item => item.Id == id).First());
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection["Name"];
                string description = collection["Description"];
                decimal price = Decimal.Parse(collection["Price"]);
                var itemToEdit = context.Items.Where(item => item.Id == id).First();
                itemToEdit.Name = name;
                itemToEdit.Description = description;
                itemToEdit.Price = price;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(context.Items.Where(item => item.Id == id).First());
        }

        // POST: Items/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Item itemToDelete = context.Items.Where(item => item.Id == id).First();
                context.Items.Remove(itemToDelete);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Items/AddReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(Guid id, IFormCollection collection)
        {
            try
            {
                int score = Int32.Parse(collection["Score"]);
                string text = collection["Text"];
                Review review = new Review {
                    Id = Guid.NewGuid(),
                    Item = context.Items.First(item => item.Id == id),
                    Text = text,
                    Score = score,
                    User = await userManager.GetUserAsync(User)
                };
                context.Reviews.Add(review);
                context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id });
            }
            catch(Exception ex)
            {
                //return RedirectToAction(nameof(Details), new { id });
                return BadRequest(ex);
            }
        }
    }
}