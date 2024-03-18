using BirthDayAPICore.Models;
using BirthDayAPICore.Services;
using Microsoft.AspNetCore.Mvc;
//este un controller ce se ocupă de requesturile necesare pentru a modifica lista de zile de nastere. 
namespace BirthDayAPICore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BirthDayController : Controller
    {
        IBirthDayCollectionService _bdCollectionService;
        public BirthDayController(IBirthDayCollectionService bdCollectionService)
        {
            _bdCollectionService = bdCollectionService;
        }
        //returnează lista de date de nastere pentru un user.
        [HttpGet("{userId}")]
        public IActionResult GetAll([FromRoute] int userId)
        {
            return Ok(_bdCollectionService.GetBirthDaysFriends(userId));

        }
        //adaugă o nouă zi de nastere in listă.
        [HttpPost]
        public IActionResult Add([FromBody] BirthDay bd)
        {
            return Ok(_bdCollectionService.AddBirthDay(bd));


        }
        //
        [HttpPut]
        public IActionResult Edit([FromBody] BirthDay bd)
        {
            return Ok(_bdCollectionService.EditBirthDay(bd));


        }
    }
}
