using Applicattion.Data.DTO.MeasurementUnit;
using Applicattion.Data.DTO.MeasurementUnitBreed.Assembler;
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementUnitsController : ControllerBase 
    {
        private IMeasurementUnitRepository _measurementUnitRepository;

        public MeasurementUnitsController(IMeasurementUnitRepository measurementUnitRepository)
        {
            _measurementUnitRepository = measurementUnitRepository;
        }

        // GET: api/MeasurementUnits
        [HttpGet(Name = "GetAllMeasurementUnits")]
        public async Task<ActionResult<IEnumerable<MeasurementUnitDTO>>> GetAsync()
        {
            IEnumerable<MeasurementUnit> measurementUnits = await _measurementUnitRepository.GetAllMeasurementUnits();

            if (measurementUnits != null)
                return Ok(measurementUnits.ToMeasurementUnitDTOList());
            else
                return NotFound(measurementUnits);
        }

        // GET: api/MeasurementUnits/5
        [HttpGet("{id}", Name = "GetMeasurementUnitById")]
        public async Task<ActionResult> Get(int id)
        {
            MeasurementUnit measurementUnit = await _measurementUnitRepository.GetMeasurementUnitById(id);

            if (measurementUnit != null)
                return Ok(measurementUnit.ToMeasurementUnitDTO());
            else
                return NotFound();
        }

        // POST: api/MeasurementUnits
        [HttpPost]
        public async Task<ActionResult<MeasurementUnitDTO>> Post([FromBody] MeasurementUnitCreationDTO measurementUnitCreationDTO)
        {
            if (ModelState.IsValid)
            {
                MeasurementUnit createdMeasurementUnit = await _measurementUnitRepository.CreateMeasurementUnit(measurementUnitCreationDTO.ToMeasurementUnit());
                if (createdMeasurementUnit.Id > 0)
                {
                    return Ok(createdMeasurementUnit.ToMeasurementUnitDTO());
                }

                return StatusCode(StatusCodes.Status500InternalServerError, measurementUnitCreationDTO);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, measurementUnitCreationDTO);
        }

        // PUT: api/MeasurementUnits/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MeasurementUnitDTO>> Put(int id, [FromBody] MeasurementUnitUpdateDTO measurementUnitUpdateDTO)
        {
            int numerOfAffectedRows = 0;
            bool doesMeasurementUnitExist = _measurementUnitRepository.GetMeasurementUnitById(id) != null;
            MeasurementUnit updatedMeasurementUnit = measurementUnitUpdateDTO.ToMeasurementUnit(id);

            if (doesMeasurementUnitExist && ModelState.IsValid)
            {

                numerOfAffectedRows = await _measurementUnitRepository.UpdateMeasurementUnit(updatedMeasurementUnit);
            }

            if (numerOfAffectedRows > 0)
            {
                return Ok(updatedMeasurementUnit.ToMeasurementUnitDTO());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, measurementUnitUpdateDTO);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool doesMeasurementUnitExist = _measurementUnitRepository.GetMeasurementUnitById(id) != null;
            int numberOfAffectedRows;

            if (doesMeasurementUnitExist)
            {
                numberOfAffectedRows = await _measurementUnitRepository.DeleteMeasurementUnit(id);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            if (numberOfAffectedRows > 0)
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
