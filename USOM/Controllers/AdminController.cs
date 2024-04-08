using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USOM.Helper;
using USOM.Models;

namespace USOM.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        protected ApplicationDbContext Context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            HeaderDataCount data = new HeaderDataCount
            {
                Contacts = QueryRepository<ContactUsEntity>.GetList("SELECT TOP 5 * FROM ContactUs ORDER BY ID DESC "),
                Testimonials = QueryRepository<TestimonialEntity>.GetList("SELECT TOP 5 * FROM Testimonial  ORDER BY ID DESC "),

                EnquiryCount = QueryRepository<int>.GetSingleData("SELECT COUNT(*) FROM ContactUs"),
                ServiceCount = QueryRepository<int>.GetSingleData("SELECT COUNT(*) FROM Service"),
                GalleryCount = QueryRepository<int>.GetSingleData("SELECT COUNT(*) FROM Gallery"),
                DayWiseCollection = QueryRepository<CCAvanuePaymentResponseEntity>.GetList("SELECT \r\n    CASE \r\n        WHEN GROUPING(CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103)) = 1 THEN 'Total'\r\n        ELSE CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103)\r\n    END AS TransactionDate,\r\n    COALESCE(SUM(CONVERT(DECIMAL(18, 2), Amount)), 0) AS Amount\r\nFROM \r\n    CCAvanuePaymentResponse\r\nWHERE \r\n    TRY_CONVERT(DATETIME, TransactionDate, 103) >= CONVERT(DATE, GETDATE())\r\n    AND TRY_CONVERT(DATETIME, TransactionDate, 103) < DATEADD(DAY, 1, CONVERT(DATE, GETDATE()))\r\n    AND OrderStatus = 'Success'\r\nGROUP BY \r\n    CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103) WITH ROLLUP;\r\n"),
                MonthWiseCollection = QueryRepository<CCAvanuePaymentResponseEntity>.GetList(" SELECT \r\n    CASE \r\n        WHEN GROUPING(CONVERT(VARCHAR(7), TRY_CONVERT(DATETIME, TransactionDate, 103), 23)) = 1 THEN 'Total'\r\n        ELSE CONVERT(VARCHAR(7), TRY_CONVERT(DATETIME, TransactionDate, 103), 23)\r\n    END AS TransactionDate,\r\n    COALESCE(SUM(CONVERT(DECIMAL(18, 2), Amount)), 0) AS Amount\r\nFROM \r\n    CCAvanuePaymentResponse\r\nWHERE \r\n    TRY_CONVERT(DATETIME, TransactionDate, 103) >= DATEADD(MONTH, -1, CONVERT(DATE, GETDATE()))\r\n    AND TRY_CONVERT(DATETIME, TransactionDate, 103) < CONVERT(DATE, GETDATE())\r\n    AND OrderStatus = 'Success'\r\nGROUP BY \r\n    CONVERT(VARCHAR(7), TRY_CONVERT(DATETIME, TransactionDate, 103), 23) WITH ROLLUP;\r\n"),
                WeekWiseCollection = QueryRepository<CCAvanuePaymentResponseEntity>.GetList("SELECT \r\n    CASE \r\n        WHEN GROUPING(CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103)) = 1 THEN 'Total'\r\n        ELSE CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103)\r\n    END AS TransactionDate,\r\n    COALESCE(SUM(CONVERT(DECIMAL(18, 2), Amount)), 0) AS Amount\r\nFROM \r\n    CCAvanuePaymentResponse\r\nWHERE \r\n    TRY_CONVERT(DATETIME, TransactionDate, 103) >= DATEADD(DAY, -7, CONVERT(DATE, GETDATE()))\r\n    AND TRY_CONVERT(DATETIME, TransactionDate, 103) < CONVERT(DATE, GETDATE())\r\n    AND OrderStatus = 'Success'\r\nGROUP BY \r\n    CONVERT(VARCHAR, TRY_CONVERT(DATETIME, TransactionDate, 103), 103) WITH ROLLUP;\r\n"),

            };
            return View(data);
        }

        public ActionResult ContactList()
        {
            return View(Context.ContactUs.OrderByDescending(a => a.Id).ToList());
        } 
        //public ActionResult DonationList()
        //{
        //    return View(Context.ContactUs.OrderByDescending(a => a.Id).ToList());
        //}
    }
}