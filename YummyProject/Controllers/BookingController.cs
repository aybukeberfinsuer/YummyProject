using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
	public class BookingController : Controller
	{
		YummyContext _context= new YummyContext();

		// Rezervasyonları listeleme (Admin paneli)
		public ActionResult Index()
		{
			var bookings = _context.Bookings.ToList();
			return View(bookings);
		}

		[HttpPost]
		public ActionResult Create(Booking booking, string date, string time)
		{
			try
			{
				// Tarih ve saat birleştir
				DateTime parsedDate = DateTime.Parse(date);
				TimeSpan parsedTime = TimeSpan.Parse(time);
				booking.BookingDate = parsedDate.Date + parsedTime;

				// Veritabanına kaydet
				using (var context = new YummyContext())
				{
					context.Bookings.Add(booking);
					context.SaveChanges();
				}

				return RedirectToAction("Index", "Default");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred: " + ex.Message);
				return View(booking);
			}
		}


		public PartialViewResult Form()
		{
			return PartialView();
		}
		[HttpPost]
		public ActionResult ApproveReservation(int[] approvedBookings)
		{
			try
			{
				using (var context = new YummyContext())
				{
					// Tüm rezervasyonları al
					var allBookings = context.Bookings.ToList();

					// İşaretli rezervasyonları güncelle
					foreach (var booking in allBookings)
					{
						// Eğer `approvedBookings` null değil ve rezervasyon checkbox işaretlenmişse
						if (approvedBookings != null && approvedBookings.Contains(booking.BookingId))
						{
							booking.IsApproved = true; // Onayla
						}
						else
						{
							booking.IsApproved = false; // Onayı kaldır
						}
					}

					context.SaveChanges(); // Veritabanına kaydet
				}

				
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
				return RedirectToAction("Index");
			}
		}
		public ActionResult ShowApproved()
		{
			var bookings = _context.Bookings.Where(x=>x.IsApproved==true).ToList();
			return View(bookings);
		}
		public ActionResult ShowUnApproved()
		{
			var bookings = _context.Bookings.Where(x=>x.IsApproved==false).ToList();
			return View(bookings);
		}
	}

}


	
