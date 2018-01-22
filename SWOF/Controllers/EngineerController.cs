using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWOF.Core.Resources;
using SWOF.Persistence;

namespace SWOF.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EngineerController : Controller
    {
        private readonly IEngineerRepository _engineerRepository;

        public EngineerController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        /// <summary>
        /// Retrieves all Engineers
        /// </summary>
        /// <returns>List of engineers</returns>
        [HttpGet]
        public IEnumerable<EngineerModel> Get()
        {
            return _engineerRepository.ReadAll();
        }

        /// <summary>
        /// Gets a single engineer with the matching id
        /// </summary>
        /// <param name="id">Identifier of the engineer to return</param>
        /// <returns>The engineer with the specified Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var engineer = _engineerRepository.Find(id);
            if (engineer == null)
            {
                return NotFound();
            }

            return new ObjectResult(engineer);
        }

        /// <summary>
        /// Adds a new engineer with the given name
        /// </summary>
        /// <remarks>Note that the name must be quoted if using Swagger</remarks>
        /// <param name="name">Name of the engineer.</param>
        /// <returns>Id of the new engineer</returns>
        [HttpPost]
        public IActionResult Post([FromBody]string name)
        {
            var engineer = new EngineerModel { Name = name };
            _engineerRepository.Add(engineer);
            return new ObjectResult(engineer.Id) { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// Removes the engineer with the given identifier from the repository
        /// </summary>
        /// <param name="id">Identifier of the engineer to delete</param>
        /// <returns>OK if deleted</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _engineerRepository.Remove(id);
            return Ok();
        }

    }
}