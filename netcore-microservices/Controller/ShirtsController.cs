using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using netcore_microservices.Filters.Action;
using netcore_microservices.Filters.ExcepctionFilter;
using netcore_microservices.Model;
using netcore_microservices.Model.Validation;
using netcore_microservices.Repository;
using netcore_microservices.Service;

namespace netcore.microservices
{
    [ApiController]
    [Route("/shirts")]
    public class ShirtsController: ControllerBase
    {
        // private ShirtRepository shirtRepository;
        private ShirtService shirtService;

        public ShirtsController(ShirtService shirtService)
        {
            this.shirtService = shirtService;
        }
        [HttpGet]
        // [Route("/shirts")]
        public IActionResult GetShirts(){
            return Ok(this.shirtService.GetAllShirts());
            // return "Reading all the shirts!!";
        }

        [HttpGet("/{id}")]
        //[Route("/{id}")]
        [ShirtValidateCorretSize]
        public IActionResult GetShirtsbyId(int id){
            // if(id == 0)
            // {
            //     return BadRequest(id);
            // }
            // var shirt = this.shirtRepository.GetShirtsbyId(id);
            // if(shirt == null)
            // {
            //     return NotFound();
            // }
            // else
            return Ok(this.shirtService.GetShirtsbyId(id));
            // return $"Reading the shirt: {id}";
        }
        
        [HttpPost]
        [ShirtValidateCreate()]
        public IActionResult CreateShirts([FromBody] Shirt shirt) 
        {
            var _shirt = this.shirtService.CreateShirts(shirt);
            return CreatedAtAction(nameof(GetShirtsbyId), 
            new {id = _shirt.ShirtId}, 
            _shirt);
           //Ok(this.shirtRepository.CreateShirts(shirt))
        }

        [HttpPut]
        [Route("/{id}")]
        [ShirtValidateId]
        [ShirtValidateUpdate]
        [ShirtHandleExceptionUpdate]
        public IActionResult UpdateShirts(int id, Shirt shirt){
            return Ok(this.shirtService.UpdateShirts(shirt));
            // return $"Updating the shirt: {id}";
        }
        [HttpDelete]
        [Route("/{id}")]
        [ShirtValidateId]
        public IActionResult DeleteShirts(int id){
            return Ok(this.shirtService.DeleteShirts(id));
            // return $"Deleting the shirt: {id}";
        }

        // app.MapGet("/shirts", () => {
        //     return "Reading all the shirts!!";
        // });

        // app.MapGet("/shirts/{id}", (int id) => {
        //     return $"Reading the shirt: {id}";
        // });

        // app.MapPost("/shirts", () => {
        //     return "Creating the shirts!!";
        // });

        // app.MapPut("/shirts/{id}", (int id) => {
        //     return $"Updating the shirt: {id}";
        // });

        // app.MapDelete("/shirts/{id}", (int id) => {
        //     return $"Deleting the shirt: {id}";
        // });


    }

}