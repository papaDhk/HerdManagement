using HerdManagement.Domain.SpecieBreed.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Domain.SpecieBreed.Service;
using Applicattion.Data.Messages;
using Applicattion.Data.DTO.SpecieBreed;
using Applicattion.Data.DTO.SpecieBreed.Assembler;

namespace App.Controllers.SpecieBreed
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private IBreedRepository _breedRepository { get; set; }

        public ISpecieBreedService _specieBreedService { get; set; }

        public BreedsController(IBreedRepository breedRepository, ISpecieBreedService specieBreedService)
        {
            _breedRepository = breedRepository ?? throw new ArgumentNullException(nameof(IBreedRepository));
            _specieBreedService = specieBreedService ?? throw new ArgumentNullException(nameof(ISpecieBreedService));
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreedDTO>>> Get()
        {
            IEnumerable<Breed> breeds = await _breedRepository.GetAllBreeds();

            if (breeds != null && breeds.Any())
                return Ok(breeds.ToBreedDTOList());
            else
                return NotFound(breeds.ToBreedDTOList());
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BreedDTO>> Get(int id)
        {
            Breed findedBreed = await _breedRepository.GetBreedById(id);

            if (findedBreed.Id > 0)
            {
                return Ok(findedBreed.ToBreedDTO());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ByLabel", Name = "GetBreedByLabel")]
        public async Task<ActionResult<BreedDTO>> Get(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                return BadRequest(label);
            }

            IEnumerable<Breed> findedBreed = await _breedRepository.GetBreedByLabel(label);

            if (findedBreed.Any())
            {
                return Ok(findedBreed.ToBreedDTOList());
            }
            else
            {
                return NotFound();
            }
        }


        // GET: api/Breeds/5
        [HttpGet("BySpecie", Name = "GetBreedBySpecie")]
        public async Task<ActionResult<BreedDTO>> GetBySpecie(int specieId)
        {

            IEnumerable<Breed> findedBreed = await _breedRepository.GetBreedsBySpecie(specieId);

            if (findedBreed.Any())
            {
                return Ok(findedBreed.ToBreedDTOList());
            }
            else
            {
                return NotFound();
            }
        }
        //POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<BreedDTO>> Post([FromBody] BreedCreationDTO breedCreationDTO)
        {
            if (ModelState.IsValid)
            {
                Response<Breed> response = await _specieBreedService.CreateBreed(breedCreationDTO);

                if(response.IsOperationSuccessfull)
                {
                    return Ok(response.Core.ToBreedDTO());
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }         
            }
            else
            {
                return BadRequest(breedCreationDTO);
            }
        }

        // PUT: api/Breeds/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BreedDTO>> Put(int id, [FromBody] BreedUpdateDTO breedUpdateDTO)
        {           

            if (ModelState.IsValid)
            {
                Response<Breed> response = await _specieBreedService.UpdateBreed(id, breedUpdateDTO);

                if (response.IsOperationSuccessfull)
                {
                    return Ok(response.Core.ToBreedDTO());
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(breedUpdateDTO);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Breed breedToDelete = await _breedRepository.GetBreedById(id);
            bool doesBreedExists = breedToDelete.Id == id;
            if (doesBreedExists)
            {
                int numberOfAffectedRows = await _breedRepository.DeleteBreed(id);

                if (numberOfAffectedRows > 0)
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                return NotFound(id);
            }

        }
    }
}
