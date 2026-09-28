using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom7.Models;

namespace Nhom7.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // HIỂN THỊ DANH SÁCH XE
        // =========================
        public async Task<IActionResult> Index()
        {
            var danhSachXe = await _context.Xes.ToListAsync();

            return View(danhSachXe);
        }


        // =========================
        // CREATE - THÊM XE
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("MaXe,TenXe,TenHang,LoaiXeMay,PhanKhoi,NamSanXuat,MauSac,MaLoaiXe")]
            Xe xe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xe);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(xe);
        }


        // =========================
        // EDIT - SỬA XE
        // =========================
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes.FindAsync(id);

            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            [Bind("MaXe,TenXe,TenHang,LoaiXeMay,PhanKhoi,NamSanXuat,MauSac,MaLoaiXe")]
            Xe xe)
        {
            if (id != xe.MaXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xe);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XeExists(xe.MaXe))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(xe);
        }


        // =========================
        // DELETE - XÓA XE
        // =========================
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xe = await _context.Xes
                .FirstOrDefaultAsync(x => x.MaXe == id);

            if (xe == null)
            {
                return NotFound();
            }

            return View(xe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var xe = await _context.Xes.FindAsync(id);

            if (xe != null)
            {
                _context.Xes.Remove(xe);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool XeExists(string id)
        {
            return _context.Xes.Any(x => x.MaXe == id);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}