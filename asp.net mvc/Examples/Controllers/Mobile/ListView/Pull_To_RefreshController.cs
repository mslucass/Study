﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domas.Web.Mvc.UI;
using Domas.Web.Mvc.Extensions;
using Domas.Web.Mvc.Examples.Models;

namespace Domas.Web.Mvc.Examples.Controllers.Mobile
{
    public partial class ListViewController : Controller
    {       
        public ActionResult Pull_To_Refresh()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pull([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SessionProductRepository.All().OrderByDescending(product => product.ProductID).ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                SessionProductRepository.Insert(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}
