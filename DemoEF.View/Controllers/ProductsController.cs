using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoEF.Backend.Bussiness.BussinessLogic;
using DemoEF.Backend.Bussiness.BussinessEntities;
namespace DemoEF.View.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            var data = ProductBL.getInstance().Listar();
            return View(data);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Product data)
        {
            ProductBL.getInstance().Insertar(data);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = ProductBL.getInstance().Detalle(id);
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = ProductBL.getInstance().Detalle(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(Product data)
        {
            ProductBL.getInstance().Actualizar(data);
            return RedirectToAction("Details", new { id = data.ProductID });
        }
        public ActionResult Delete(int id)
        {
            ProductBL.getInstance().Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}