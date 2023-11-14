using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB3.Models;

namespace DemoDB3.Controllers
{
    public class CustomerController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> lstCustomer = database.Customers.ToList();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.Customers.Where(s => s.IDCus == cus.IDCus).FirstOrDefault();
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.Customers.Add(cus);
                    try
                    {
                        database.SaveChanges();
                        return RedirectToAction("Create_Success");
                    }
                    catch (Exception ex)
                    {
                        
                        throw;
                    }
                    return RedirectToAction("Create_Success");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View("Create_Failed");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Create_Failed()
        {
            return View();
        }
        public ActionResult Create_Success()
        {
            return View();
        }
    }
}