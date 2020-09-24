using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20200921.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20200921.Controllers
{
    public class ItemsController : Controller
    {

        public static List<Item> Items = new List<Item>
        {
            new Item
            {
                Name = "Item 1",
                Description = "One",
                Price = 123.45m,
                Id = Guid.Parse("12345678-0000-0000-0000-000000000001")

            },
            new Item
            {
                Name = "Item 2",
                Description = "Two",
                Price = 678.90m,
                Id = Guid.Parse("12345678-0000-0000-0000-000000000002")
            },
        };

        // GET: Items
        public ActionResult Index()
        {
            return View(Items);
        }

        // GET: Items/Details/5
        public ActionResult Details(Guid id)
        {
            return View(Items.Find(item => item.Id == id));
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
                Items.Add(newItem);
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
            return View(Items.Find(item => item.Id == id));
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
                var itemToEdit = Items.Find(item => item.Id == id);
                itemToEdit.Name = name;
                itemToEdit.Description = description;
                itemToEdit.Price = price;
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
            return View(Items.Find(item => item.Id == id));
        }

        // POST: Items/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Items.RemoveAll(item => item.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}