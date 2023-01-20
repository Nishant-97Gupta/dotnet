using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ormapp.Models;
using BOL;
using BLL;

namespace ormapp.Controllers;

public class productcontroller : Controller
{
    private readonly ILogger<productcontroller> _logger;

    public productcontroller(ILogger<productcontroller> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> products=new List<Product>();
        logic logic=new logic();
        
        products=logic.productList();
        this.ViewData["product"]=products;

        return View();
    }

    [HttpPost]
     public ActionResult AddProduct(){
        int pid=Convert.ToInt32(Request.Form["pid"]);
        string pname=Request.Form["pname"].ToString();
        decimal price=Convert.ToDecimal(Request.Form["price"]);
        int stock=Convert.ToInt32(Request.Form["stock"]);
        
        Product prod=new Product();
        prod.pid=pid;
        prod.pname=pname;
        prod.price=price;
        prod.stock=stock;

        logic logic=new logic();
         Product savedProd= logic.insertone(prod);

         this.ViewData["savedProduct"]=savedProd;
         return RedirectToAction("Index");
     }

      [HttpPost]
      public ActionResult DeleteProduct(){
        int pid=Convert.ToInt32(Request.Form["pid"]);
        logic logic =new logic();
        logic.Delete(pid);
         return RedirectToAction("Index");

      }
      [HttpPost]
      public ActionResult Updateproduct(){
         
         int pid=Convert.ToInt32(Request.Form["pid"]);
         String pname=Request.Form["pname"].ToString();
         Decimal price=Convert.ToDecimal(Request.Form["price"]);
         int stock=Convert.ToInt32(Request.Form["stock"]);
      
         Product prod=new Product();
         prod.pid=pid;
         prod.pname=pname;
         prod.price=price;
         prod.stock=stock;
        
         logic log=new logic();
          Product Savedata=log.updateprod(prod);
         //this.ViewData["savedproduct"]=Savedata;
        return RedirectToAction("Index");
      }

}

