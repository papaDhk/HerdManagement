using Dapper;
using HerdManagement.Domain.Herd.Entities;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using HerdManagement.Domain.SpecieBreed.Entities;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using HerdManagement.Domain.SpecieBreed.Repository;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class HerdRepository : IHerdRepository
    {
        private readonly IConfiguration _configuration;
        public HerdRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Herd> CreateHerd(Herd herd)
        {
            // Herd to be validated
            int createdHerdId = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(
                    new
                    {
                        herd.Name,
                        herd.Color,
                        herd.Description,
                        SpecieId = herd.Specie?.Id ?? herd.SpecieId
                    });

                createdHerdId = await dbConnection.QuerySingleOrDefaultAsync<int>("dbo.InsertNewHerd", parameters, commandType: CommandType.StoredProcedure);
            }
            herd.Id = createdHerdId;

            return herd;
        }

        public async Task<int> DeleteHerd(int herdId)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("DeleteHerd", new { Id = herdId }, commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        public async Task<Herd> GetHerdById(int id)
        {
            Herd findedHerd;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                IEnumerable<Herd> result = await dbConnection.QueryAsync<Herd, Specie, Herd>(
                                                                "GetHerdById",
                                                                (herd, specie) => { herd.Specie = specie; return herd; },
                                                                new { Id = id },
                                                                splitOn: "SpecieId",
                                                                commandType: CommandType.StoredProcedure
                                                                );
                findedHerd = result.FirstOrDefault();
            }

            return findedHerd ?? new Herd();
        }

        public async Task<IEnumerable<Herd>> GetHerdByName(string name)
        {
            IEnumerable<Herd> findedHerds;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                findedHerds = await dbConnection.QueryAsync<Herd, Specie, Herd>(
                                                               "GetHerdByName",
                                                               (herd, specie) => { herd.Specie = specie; return herd; },
                                                               new { Name = name },
                                                               splitOn: "SpecieId",
                                                               commandType: CommandType.StoredProcedure
                                                               );
            }

            return findedHerds;
        }

        public async Task<IEnumerable<Herd>> GetAllHerds()
        {
            IEnumerable<Herd> result = new List<Herd>();
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryAsync<Herd, Specie, Herd>(
                                                                "GetAllHerds",
                                                                (herd, specie) => { herd.Specie = specie; return herd; },
                                                                splitOn: "SpecieId",
                                                                commandType: CommandType.StoredProcedure
                                                                );
            }

            return result;
        }

        public async Task<int> UpdateHerd(Herd herd)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("UpdateHerd",
                                                                       new { herd.Id, herd.Name, herd.Description, herd.Color, SpecieId = herd.Specie.Id },
                                                                       commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }
    }
}
