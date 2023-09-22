using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace OurBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public abstract class AdminBaseController : Controller
    {

    }
}
