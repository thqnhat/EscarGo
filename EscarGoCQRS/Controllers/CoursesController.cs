﻿using EscarGoLibrary.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EscarGoCQRS.Controllers
{
    public class CoursesController : CustomControllerCQRS
    {
        #region Index
        // GET: Courses
        public ActionResult Index(int? currentPage)
        {
            var vm = UnitOfWork.RaceRepository.GetRaces();
            return View(vm);
        }
        #endregion

        #region Details
        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id.Value == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = Builder.GetDetailCourseViewModel(id.Value);
            if (vm.Course == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }
        #endregion

        #region Bet
        public async Task<ActionResult> Bet(int idCourse, int idConcurrent)
        {
            if (idConcurrent == 0 || idConcurrent == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            await Builder.SetBetAsync(idCourse, idConcurrent);
            return Redirect("Details/" + idCourse.ToString());
        }
        #endregion

        #region Edit
        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Create
        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public async Task<ActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await Builder.CreateAsync(course);
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Like
        // GET: Default/Like/5
        public async Task<ActionResult> Like(int id)
        {
            await UnitOfWork.RaceRepository.LikeAsync(id);
            await UnitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
