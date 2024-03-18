using BirthDayAPICore.Models;
using BirthDayAPICore.Services;
using Microsoft.AspNetCore.Mvc;
//controller ce se ocupă de requesturile dedicate utilizatorilor. 
namespace BirthDayAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        IUsersCollectionService _usersCollectionService;
        public UsersController(IUsersCollectionService usersCollectionService) {
            _usersCollectionService = usersCollectionService;
        }

        [HttpPost]
        // acest endpoint este folosit pentru a crea un nou user la înregistrare.
        //Acesta primeste ca body un obiect de tipul User si primeste ca response Ok(user).
        public IActionResult Create([FromBody] User user)
        {
            var result =  _usersCollectionService.AddUser(user);
            return StatusCode(result ? 200 : 400);
        }

        [HttpGet]
       
        public IActionResult GetAll()
        {
            return Ok( _usersCollectionService.GetUsers());
            
        }
        /// <summary>
        /// return an annoucement by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        //acest endpoint returnează pe baza emailului si a parolei un user sau empty, pentru autentificare.
        [HttpGet("getByEmailPass/{email}/{pass}")]
        public ActionResult<User> GetById( string email, string pass)
        {
            var result = _usersCollectionService.GetUser(email, pass);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
