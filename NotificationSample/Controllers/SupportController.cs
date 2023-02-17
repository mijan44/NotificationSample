using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotificationSample.Data;
using NotificationSample.Models;

namespace NotificationSample.Controllers
{
    public class SupportController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IHubContext<NotificationHub> _hubContext;
        

        public SupportController(AppDbContext dbContext, IHubContext<NotificationHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
  
        }

        

        public IActionResult Support()
        {
            return View();
        }

        //Customer form control

        [HttpPost]
        public IActionResult Support(SupportRequest model)
        {
            _dbContext.SupportRequests.Add(model);
            _dbContext.SaveChanges();
            TempData["Message"] = "Support request submitted successfully.";
            var message = "New support request submitted.";

            _hubContext.Clients.All.SendAsync("ReceiveNotification");
            return RedirectToAction(nameof(Support));
        }


        public IActionResult Index()
        {
            return View();
        }


        //// receive notification
        //[HttpPost]
        //public async Task<IActionResult> Index(SupportRequest supportRequest)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _dbContext.SupportRequests.Add(supportRequest);
        //        await _dbContext.SaveChangesAsync();
        //        await _hubContext.Clients.All.SendAsync("ReceiveNotification");
        //        return CreatedAtAction("GetSupportRequest", new { id = supportRequest.Id }, supportRequest);

        //    }
        //    return View(supportRequest);
        //}









    }
}
