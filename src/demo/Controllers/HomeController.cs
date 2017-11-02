namespace AspNetCore20
{
    using Microsoft.AspNetCore.Mvc;

    [Route("")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToPage("/customers/index", new { pageNumber="1", itemCountPerPage="50" });
        }
    }
}