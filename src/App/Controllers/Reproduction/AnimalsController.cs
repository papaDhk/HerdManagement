using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Reproduction
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IAnimalRepository _animalRepository { get; set; }

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository ?? throw new ArgumentNullException(nameof(animalRepository));
        }

        [HttpPost]
        public async Task<Female> AddNewFemaleAsync(Female female)
        {
            return await _animalRepository.AddNewFemaleAsync(female);

        }

        [HttpPut]
        public async Task<Female> UpdateFemaleAsync(Female female)
        {
            return await _animalRepository.UpdateFemaleAsync(female);
        }

        [HttpGet]
        public  IEnumerable<Female> GetFemalesByHerdIdAsync(int herdId)
        {
            return _animalRepository.GetFemalesByHerdId(herdId);

        }

        [HttpGet]
        public Female GetFemaleByNumber(int femaleNumber)
        {
            return  _animalRepository.GetFemaleByNumber(femaleNumber);

        }

        [HttpGet]
        public Female GetFemaleById(int femaleId)
        {
            return _animalRepository.GetFemaleById(femaleId);

        }

        [HttpGet]
        public Female GetFemaleWithReproductionsById(int femaleId)
        {
            return _animalRepository.GetFemaleWithReproductionsById(femaleId);

        }

        [HttpPost]
        public async Task<Male> AddNewMaleAsync(Male male)
        {
            return await _animalRepository.AddNewMaleAsync(male);

        }

        [HttpPut]
        public async Task<Male> UpdateMaleAsync(Male male)
        {
            return await _animalRepository.UpdateMaleAsync(male);

        }

        [HttpGet]
        public IEnumerable<Male> GetMalesByHerdId(int herdId)
        {
            return _animalRepository.GetMalesByHerdId(herdId);

        }

        [HttpGet]
        public Male GetMaleByNumber(int maleNumber)
        {
            return _animalRepository.GetMaleByNumber(maleNumber);

        }

        [HttpGet]
        public Male GetMaleById(int maleId)
        {
            return  _animalRepository.GetMaleById(maleId);

        }

        [HttpPost]
        public async Task<YoungAnimal> AddNewYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            return await _animalRepository.AddNewYoungAnimalAsync(youngAnimal);
        }

        [HttpPut]
        public async Task<YoungAnimal> UpdateYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            return await _animalRepository.UpdateYoungAnimalAsync(youngAnimal);
        }

        [HttpGet]
        public IEnumerable<YoungAnimal> GetYoungAnimalsByHerdId(int herdId)
        {
            return _animalRepository.GetYoungAnimalsByHerdId(herdId);

        }

        [HttpGet]
        public YoungAnimal GetYoungAnimalByNumber(int youngAnimalNumber)
        {
            return _animalRepository.GetYoungAnimalByNumber(youngAnimalNumber);

        }

    }
}
