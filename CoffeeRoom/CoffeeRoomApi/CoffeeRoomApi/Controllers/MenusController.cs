using CoffeeRoomApi.Data;
using System.Linq;
using System.Web.Http;

namespace CoffeeRoomApi.Controllers
{
    public class MenusController : ApiController
    {
        private CoffeeRoomDbContext _dbContext = new CoffeeRoomDbContext();

        [HttpGet]
        public IHttpActionResult GetMenus()
        {
            var menus = _dbContext.Menus.Include("SubMenus");
            return Ok(menus);
        }

        [HttpGet]
        public  IHttpActionResult GetMenuById(int id)
        {
            var menu = _dbContext.Menus.Include("SubMenus").SingleOrDefault(m => m.Id == id);
            if (menu == null)
                return NotFound();

            return Ok(menu);
        }
    }
}
