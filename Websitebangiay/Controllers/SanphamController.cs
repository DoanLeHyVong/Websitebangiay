﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class SanphamController : Controller
    {
        ShopShoe db = new ShopShoe();

        // GET: Sanpham
        public ActionResult giayadidas()
        {
            var adidas = db.Sanphams.Where(n=>n.Mahang==2).Take(4).ToList();
           return PartialView(adidas);
        }
        public ActionResult giaynike()
        {
            var nike = db.Sanphams.Where(n => n.Mahang == 1).Take(4).ToList();
            return PartialView(nike);
        }
        public ActionResult giaypuma()
        {
            var puma = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();
            return PartialView(puma);
        }
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

        public ActionResult TimKiemSanPham(string q)
        {
            var giay = (from ss in db.Sanphams select ss).Where(p => p.Mota.Contains(q));

            return View(giay.ToList());
        }
    }

}