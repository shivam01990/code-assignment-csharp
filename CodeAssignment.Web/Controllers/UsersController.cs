using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using CodeAssgnment.Shared;
using CodeAssignment.Web.Models;

namespace CodeAssignment.Web.Controllers
{
    public class UsersController : Controller
    {
        private ServiceRepository _serviceRepository;

        public UsersController()
        {
            _serviceRepository = new ServiceRepository();
        }

        // GET: Users
        public ActionResult Index()
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/user");
            response.EnsureSuccessStatusCode();
            List<UserEntity> users = response.Content.ReadAsAsync<List<UserEntity>>().Result;
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = _serviceRepository.GetResponse("api/user?id="+id.ToString());
            response.EnsureSuccessStatusCode();
            UserEntity user = response.Content.ReadAsAsync<UserEntity>().Result;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ForeNames,SurName,Dob,Gender,HomeNo,WorkNo,MobileNo,CreatedOn,UpdatedOn")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _serviceRepository.PostResponse("api/user", user.ConvertToEntity(user));
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            HttpResponseMessage response = _serviceRepository.GetResponse("api/user?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            UserEntity user = response.Content.ReadAsAsync<UserEntity>().Result;

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserModel(user));
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ForeNames,SurName,Dob,Gender,HomeNo,WorkNo,MobileNo,CreatedOn,UpdatedOn")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _serviceRepository.PutResponse("api/user", user.ConvertToEntity(user));
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = _serviceRepository.GetResponse("api/user?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            UserEntity user = response.Content.ReadAsAsync<UserEntity>().Result;

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/user?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            UserEntity user = response.Content.ReadAsAsync<UserEntity>().Result;
            //db.Users.Remove(user);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
