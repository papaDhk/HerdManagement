using Dapper;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class BreedRepository : IBreedRepository
    {
        private IConfiguration _configuration;

        public BreedRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Breed> CreateBreed(Breed breed)
        {
            // Breed to be validated
            int createdBreedId = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(
                    new
                    {
                        breed.Label,
                        SpecieId = breed.Specie.Id
                    });

                createdBreedId = await dbConnection.QuerySingleOrDefaultAsync<int>("dbo.InsertNewBreed", parameters, commandType: CommandType.StoredProcedure);
            }
            breed.Id = createdBreedId;

            return breed;
        }

        public async Task<int> DeleteBreed(int breedId)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("DeleteBreed", new { Id = breedId }, commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }


        public async Task<IEnumerable<Breed>> GetAllBreeds()
        {
            IEnumerable<Breed> result = new List<Breed>();
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryAsync<Breed, Specie, Breed>(
                                                                "GetAllBreeds",
                                                                (breed, specie) => { breed.Specie = specie; return breed; },
                                                                splitOn: "SpecieId",
                                                                commandType: CommandType.StoredProcedure
                                                                );
            }

            return result;
        }


        public async Task<Breed> GetBreedById(int id)
        {
            Breed findedBreed;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                IEnumerable<Breed> result = await dbConnection.QueryAsync<Breed, Specie, Breed>(
                                                                "GetBreedById",
                                                                (breed, specie) => { breed.Specie = specie; return breed; },
                                                                new { Id = id },
                                                                splitOn: "SpecieId",
                                                                commandType: CommandType.StoredProcedure
                                                                );
                findedBreed = result.FirstOrDefault();
            }

            return findedBreed ?? new Breed();
        }


        public async Task<IEnumerable<Breed>> GetBreedByLabel(string label)
        {
            IEnumerable<Breed> findedBreeds;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                findedBreeds = await dbConnection.QueryAsync<Breed, Specie, Breed>(
                                                               "GetBreedsByLabel",
                                                               (breed, specie) => { breed.Specie = specie; return breed; },
                                                               new { Label = label },
                                                               splitOn: "SpecieId",
                                                               commandType: CommandType.StoredProcedure
                                                               );
            }

            return findedBreeds;
        }


        public async Task<IEnumerable<Breed>> GetBreedsBySpecie(int SpecieId)
        {
            IEnumerable<Breed> findedBreeds;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                findedBreeds = await dbConnection.QueryAsync<Breed, Specie, Breed>(
                                                               "GetBreedsBySpecie",
                                                               (breed, specie) => { breed.Specie = specie; return breed; },
                                                               new { SpecieId },
                                                               splitOn: "SpecieId",
                                                               commandType: CommandType.StoredProcedure
                                                               );
            }

            return findedBreeds;
        }


        public async Task<int> UpdateBreed(Breed breed)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("UpdateBreed",
                                                                       new { breed.Id, breed.Label, SpecieId = breed.Specie.Id },
                                                                       commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }
    }
}
