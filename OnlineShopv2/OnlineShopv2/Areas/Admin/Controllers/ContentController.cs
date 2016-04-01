﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShopv2.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        
        public ActionResult Index(string searchString,int page = 1, int pageSize=10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model as IPagedList<Content>);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[Common.CommonConstants.USER_SESSION];
                model.CreatedBy = session.UserName;
                new ContentDao().Create(model);
                return RedirectToAction("Index", "Content");

            }
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);
            SetViewBag(content.CategoryID);
            return View(content);
        }
       
        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                //var result = dao.Update(content);
                var result = dao.Edit(content);
                if (result != null)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức thất bại !!!");
                }
            }
            SetViewBag(content.CategoryID);
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new ContentDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long ? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(),"ID","Name",selectedId);
        }
    }
}