using System.Collections.Generic;
using System.Threading.Tasks;
using Applicattion.Data.DTO.SpecieBreed;
using Applicattion.Data.DTO.SpecieBreed.Assembler;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.SpecieBreed
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private ISpecieRepository _specieRepository;

        public SpeciesController(ISpecieRepository specieRepository)
        {
            _specieRepository = specieRepository;
        }

        // GET: api/Species
        [HttpGet(Name = "GetAllSpecies")]
        public async Task<ActionResult<IEnumerable<SpecieDTO>>> GetAsync()
        {
            IEnumerable<Specie> species = await _specieRepository.GetAllSpecies();

            if (species != null)
                return Ok(species.ToSpecieDTOList());
            else
                return NotFound(species);
        }

        // GET: api/Species/5
        [HttpGet("{id}", Name = "GetSpecieById")]
        public async Task<ActionResult> Get(int id)
        {
            Specie specie = await _specieRepository.GetSpecieById(id);

            if (specie != null)
                return Ok(specie.ToSpecieDTO());
            else
                return NotFound();
        }

        // POST: api/Species
        [HttpPost]
        public async Task<ActionResult<SpecieDTO>> Post([FromBody] SpecieCreationDTO specieCreationDTO)
        {
            if (ModelState.IsValid)
            {
                Specie createdSpecie = await _specieRepository.CreateSpecie(specieCreationDTO.ToSpecie());
                if(createdSpecie.Id > 0)
                {
                    return Ok(createdSpecie.ToSpecieDTO());
                }

                return StatusCode(StatusCodes.Status500InternalServerError, specieCreationDTO);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, specieCreationDTO);
        }

        // PUT: api/Species/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SpecieDTO>> Put(int id, [FromBody] SpecieUpdateDTO specieUpdateDTO)
        {
            int numerOfAffectedRows = 0;
            bool doesSpecieExist = _specieRepository.GetSpecieById(id) != null;
            Specie updatedSpecie = specieUpdateDTO.ToSpecie(id);

            if (doesSpecieExist && ModelState.IsValid)
            {
                
                numerOfAffectedRows = await _specieRepository.UpdateSpecie(updatedSpecie);
            }

            if (numerOfAffectedRows > 0)
            {
                return Ok(updatedSpecie.ToSpecieDTO());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, specieUpdateDTO);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool doesSpecieExist = _specieRepository.GetSpecieById(id) != null;
            int numberOfAffectedRows;

            if (doesSpecieExist)
            {
                numberOfAffectedRows = await _specieRepository.DeleteSpecie(id);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            

            if(numberOfAffectedRows > 0)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
