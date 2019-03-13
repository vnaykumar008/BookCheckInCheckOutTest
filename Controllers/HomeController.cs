using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Book> books = GetBookDetails();

        [HttpGet]
        public ActionResult Index()
        {
            return View(books);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc, string submit)
        {
            int id = Convert.ToInt16(fc["id"]);
            switch (submit)
            {
                case "CheckIn":
                    books.Where(p => p.Id == id).FirstOrDefault().Status = CheckInOutStatus.CheckIn;
                    break;
                case "CheckOut":
                    books.Where(p => p.Id == id).FirstOrDefault().Status = CheckInOutStatus.CheckOut;
                    return RedirectToAction("CheckOut", books.Where(p => p.Id == id).FirstOrDefault());
                case "Details":
                    return RedirectToAction("Details", new { id = id });
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(books.Where(p => p.Id == id).FirstOrDefault());
        }

        [HttpGet]
        public ActionResult CheckOut(Book book)
        {
            return View(book);
        }

        private static List<Book> GetBookDetails()
        {
            return new List<Book>()
            {
                new Book()
                {
                     Id = 1,
                      CoverPrice = 10,
                       ISBN = "1234567890",
                        PublishYear=2016,
                         Status=CheckInOutStatus.CheckOut,
                          Title="Book1",
                           PersonDetails = new Person(){ Name = "Vinay"},
                            History = new List<CheckInOutHistory>(){ new CheckInOutHistory()
                            {
                                 PersonDetails = new Person(){Name = "Kiran" },
                                  CheckInDateTime = new DateTime(2018,01,10),
                                   CheckOutDateTime = new DateTime(2018, 01, 01)
                            }
                            }
                },
                new Book()
                {
                     Id = 2,
                      CoverPrice = 20,
                       ISBN = "1234567891",
                        PublishYear=2018,
                         Status=CheckInOutStatus.CheckIn,
                          Title="Book2",
                          PersonDetails = new Person(){ Name = "Srinu"},
                            History = new List<CheckInOutHistory>(){
                                new CheckInOutHistory()
                            {
                                 PersonDetails = new Person(){Name = "Yak" },
                                  CheckInDateTime = new DateTime(2019,02,10),
                                   CheckOutDateTime = new DateTime(2019, 02, 01)
                            }
                                }
                }
            };
        }
    }
}