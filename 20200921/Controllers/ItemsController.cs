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
        public ItemsController()
        {
            Items = new List<Item>
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
        }

        public List<Item> Items { get; private set; }

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
            return View();
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Items/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}