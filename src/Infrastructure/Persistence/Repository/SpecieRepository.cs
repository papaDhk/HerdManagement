using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using HerdManagement.Domain.SpecieBreed.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using HerdManagement.Domain.SpecieBreed.Repository;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class SpecieRepository : ISpecieRepository
    {
        private readonly IConfiguration _configuration;
        public SpecieRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create a specie
        /// </summary>
        /// <param name="Specie"></param>
        /// <returns></returns>
        public async Task<Specie> CreateSpecie(Specie Specie)
        {
            // Specie to be validated
            if (Specie == null)
                return Specie;

            int createdSpecieId;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                DynamicParameters parameters = new DynamicParameters(new
                {
                    Specie.Label,
                    Specie.ChildhoodDurationInDays,
                    Specie.PregnancyDurationInDays,
                    Specie.MinimumTimeSpanBetweenCalvingAndHeatInDays
                });
                createdSpecieId = await dbConnection.QuerySingleOrDefaultAsync<int>("dbo.InsertNewSpecie",
                                                                  param: parameters,
                                                                  commandType: CommandType.StoredProcedure);
            }
            if (createdSpecieId > 0)
            {
                Specie.Id = createdSpecieId;
            }

            return Specie;
        }

        /// <summary>
        /// Delete a specie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteSpecie(int id)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("DeleteSpecie", new { Id = id }, commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        /// <summary>
        /// Get a specie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Specie> GetSpecieById(int id)
        {
            Specie result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QuerySingleOrDefaultAsync<Specie>("GetSpecieById", new { Id = id }, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Get a specie by its label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public async Task<Specie> GetSpecieByLabel(string label)
        {
            Specie result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryFirstOrDefaultAsync<Specie>("GetSpecieByLabel", new { Label = label }, commandType: CommandType.StoredProcedure) ?? new Specie();
            }

            return result;
        }

        /// <summary>
        /// Get all species
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specie>> GetAllSpecies()
        {
            IEnumerable<Specie> result = new List<Specie>();
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryAsync<Specie>("GetAllSpecies", commandType: CommandType.StoredProcedure);
            }

            return result.ToList();
        }


        /// <summary>
        /// Update a specie
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        public async Task<int> UpdateSpecie(Specie specie)
        {
            int numberOfAffectedRows = 0;
            if (specie != null)
            {
                DynamicParameters parameters = new DynamicParameters(new
                {
                    specie.Id,
                    specie.Label,
                    specie.ChildhoodDurationInDays,
                    specie.PregnancyDurationInDays,
                    specie.MinimumTimeSpanBetweenCalvingAndHeatInDays
                });

                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
                {
                    numberOfAffectedRows = await dbConnection.ExecuteAsync("UpdateSpecie", parameters, commandType: CommandType.StoredProcedure);
                }
            }

            return numberOfAffectedRows;
        }
    }
}
