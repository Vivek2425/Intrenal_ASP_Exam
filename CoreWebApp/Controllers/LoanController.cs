using CoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class LoanController : Controller
    {
        private string API_url;
        public LoanController()
        {
            API_url = @"http://localhost:21290/api/Interest";
        }
        static List<LoanClass> loanData =new List<LoanClass>();
        // GET: LoanController
        public async Task<ActionResult> Index()
        {
            List<LoanClass> data = new List<LoanClass>();
            using(var httpclient = new HttpClient())
            {
                using(var response =await httpclient.GetAsync(API_url))
                {
                    var res = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<LoanClass>>(res);   
                }
            }
            return View(data);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoanClass collection)
        {
            try
            {
                using (var httpclient = new HttpClient())
                {
                    var requestData = JsonConvert.SerializeObject(collection);
                    var data = new StringContent(requestData, System.Text.Encoding.UTF8, "Application/json");
                    using (var response = await httpclient.PostAsync(API_url, data))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
