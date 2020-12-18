using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Applicattion.Data.DTO.Herd;
using Applicattion.Data.DTO.Herd.Assembler;
using Applicattion.Data.Messages;
using HerdManagement.Domain.Herd.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Domain.SpecieBreed.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Herds
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerdsController : ControllerBase
    {
        private IHerdRepository _herdRepository { get; set; }

        private ISpecieBreedService _specieBreedService { get; set; }

        public HerdsController(IHerdRepository herdRepository, ISpecieBreedService specieBreedService)
        {
            _herdRepository = herdRepository ?? throw new ArgumentNullException(nameof(IHerdRepository));
            _specieBreedService = specieBreedService ?? throw new ArgumentNullException(nameof(ISpecieBreedService));
        }

        // GET: api/Herds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerdDTO>>> Get()
        {
            IEnumerable<Herd> herds = await _herdRepository.GetAllHerds();

            if (herds != null && herds.Any())
                return Ok(herds.ToHerdDTOList());
            else
                return NotFound(herds);        
        }

        // GET: api/Herds/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<HerdDTO>> Get(int id)
        {
            Herd findedHerd = await _herdRepository.GetHerdById(id);

            if (findedHerd.Id > 0)
            {
                return Ok(findedHerd.ToHerdDTO());
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Herds/5
        [HttpGet("ByName", Name = "GetHerdByName")]
        public async Task<ActionResult<HerdDTO>> Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(name);
            }

            IEnumerable<Herd> findedHerd = await _herdRepository.GetHerdByName(name);

            if (findedHerd.Any())
            {
                return Ok(findedHerd.ToHerdDTOList());
            }
            else
            {
                return NotFound();
            }
        }

        //POST: api/Herds
        [HttpPost]
        public async Task<ActionResult<HerdDTO>> Post([FromBody] HerdCreationDTO herdCreationDTO)
        {
            if (ModelState.IsValid)
            {
                Response<Herd> response = await _specieBreedService.CreateHerd(herdCreationDTO);

                if (response.IsOperationSuccessfull)
                {
                    return Ok(response.Core.ToHerdDTO());
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(herdCreationDTO);
            }
        }

        // PUT: api/Herds/5
        [HttpPut("{id}")]
        public async Task<ActionResult<HerdDTO>> Put(int id, [FromBody] HerdUpdateDTO herdUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                Response<Herd> response = await _specieBreedService.UpdateHerd(id, herdUpdateDTO);

                if (response.IsOperationSuccessfull)
                {
                    return Ok(response.Core.ToHerdDTO());
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(herdUpdateDTO);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Herd herdToDelete = await _herdRepository.GetHerdById(id);
            bool doesHerdExists = herdToDelete.Id == id;
            if (doesHerdExists)
            {
                int numberOfAffectedRows = await _herdRepository.DeleteHerd(id);

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
