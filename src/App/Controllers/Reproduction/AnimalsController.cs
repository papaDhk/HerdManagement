using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.DTO.Reproduction;
using Application.Data.Messages;
using Application.Services;
using HerdManagement.Domain.Reproduction.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Reproduction
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IAnimalRepository _animalRepository { get; set; }
        private IReproductionService _reproductionService { get; set; }

        public AnimalsController(IAnimalRepository animalRepository, IReproductionService reproductionService)
        {
            _animalRepository = animalRepository ?? throw new ArgumentNullException(nameof(animalRepository));
            _reproductionService = reproductionService ?? throw new ArgumentNullException(nameof(reproductionService));
        }

        [HttpPost("AddNewAnimal")]
        public async Task<Animal> AddNewAnimalAsync(AnimalDTO animalDTO)
        {
            return await _reproductionService.AddNewAnimalAsync(animalDTO);

        }

        [HttpPut("UpdateAnimal")]
        public async Task<Animal> UpdateAnimalAsync(Animal animal, int motherId, int fatherId)
        {
            return await _reproductionService.UpdateAnimalAsync(animal, motherId, fatherId);
        }

        [HttpGet(Name = "GetFemalesByHerdId")]
        public  IEnumerable<Female> GetFemalesByHerdIdAsync(int herdId)
        {
            return _animalRepository.GetFemalesByHerdId(herdId);

        }

        [HttpGet("GetFemaleByNumber")]
        public Female GetFemaleByNumber(int femaleNumber)
        {
            return  _animalRepository.GetFemaleByNumber(femaleNumber);

        }

        [HttpGet("GetFemaleById")]
        public Female GetFemaleById(int femaleId)
        {
            return _animalRepository.GetFemaleById(femaleId);

        }

        [HttpGet("GetFemaleWithReproductionsById")]
        public Female GetFemaleWithReproductionsById(int femaleId)
        {
            return _animalRepository.GetFemaleWithReproductionsById(femaleId);

        }

        [HttpGet("GetMalesByHerdId")]
        public IEnumerable<Male> GetMalesByHerdId(int herdId)
        {
            return _animalRepository.GetMalesByHerdId(herdId);

        }

        [HttpGet("GetMaleByNumber")]
        public Male GetMaleByNumber(int maleNumber)
        {
            return _animalRepository.GetMaleByNumber(maleNumber);

        }

        [HttpGet("GetMaleById")]
        public Male GetMaleById(int maleId)
        {
            return  _animalRepository.GetMaleById(maleId);

        }

        [HttpGet("GetYoungAnimalsByHerdId")]
        public IEnumerable<YoungAnimal> GetYoungAnimalsByHerdId(int herdId)
        {
            return _animalRepository.GetYoungAnimalsByHerdId(herdId);

        }

        [HttpGet("GetYoungAnimalByNumber")]
        public YoungAnimal GetYoungAnimalByNumber(int youngAnimalNumber)
        {
            return _animalRepository.GetYoungAnimalByNumber(youngAnimalNumber);
        }

        [HttpPut("CreateOrUpdateReproduction")]
        public async Task<ReproductionCreationResponse> CreateOrUpdateReproductionAsync(HerdManagement.Domain.Reproduction.Entities.Reproduction reproduction)
        {
            return await _reproductionService.CreateOrUpdateReproductionAsync(reproduction);
        }
    }
}
