using Dapper;
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.Common.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class MeasurementUnitRepository : IMeasurementUnitRepository
    {
        private readonly IConfiguration _configuration;

        public MeasurementUnitRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create a measurementUnit
        /// </summary>
        /// <param name="MeasurementUnit"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> CreateMeasurementUnit(MeasurementUnit MeasurementUnit)
        {
            // MeasurementUnit to be validated
            if (MeasurementUnit == null)
                return MeasurementUnit;

            int createdMeasurementUnitId;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                DynamicParameters parameters = new DynamicParameters(new
                {
                    MeasurementUnit.Label,
                    MeasurementUnit.Symbol,
                    MeasurementUnit.Commentary,
                });
                createdMeasurementUnitId = await dbConnection.QuerySingleOrDefaultAsync<int>("dbo.InsertNewMeasurementUnit",
                                                                  param: parameters,
                                                                  commandType: CommandType.StoredProcedure);
            }
            if (createdMeasurementUnitId > 0)
            {
                MeasurementUnit.Id = createdMeasurementUnitId;
            }

            return MeasurementUnit;
        }

        public IEnumerable<MeasurementUnit> GetMeasurementUnitsByCategory(MeasurementUnitCategory measurementUnitCategory)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete a measurementUnit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteMeasurementUnit(int id)
        {
            int numberOfAffectedRows = 0;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                numberOfAffectedRows = await dbConnection.ExecuteAsync("DeleteMeasurementUnit", new { Id = id }, commandType: CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        /// <summary>
        /// Get a measurementUnit by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> GetMeasurementUnitById(int id)
        {
            MeasurementUnit result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QuerySingleOrDefaultAsync<MeasurementUnit>("GetMeasurementUnitById", new { Id = id }, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Get a measurementUnit by its label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> GetMeasurementUnitByLabel(string label)
        {
            MeasurementUnit result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryFirstOrDefaultAsync<MeasurementUnit>("GetMeasurementUnitByLabel", new { Label = label }, commandType: CommandType.StoredProcedure) ?? new MeasurementUnit();
            }

            return result;
        }

        /// <summary>
        /// Get all measurementUnits
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MeasurementUnit>> GetAllMeasurementUnits()
        {
            IEnumerable<MeasurementUnit> result = new List<MeasurementUnit>();
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
            {
                result = await dbConnection.QueryAsync<MeasurementUnit>("GetAllMeasurementUnits", commandType: CommandType.StoredProcedure);
            }

            return result.ToList();
        }


        /// <summary>
        /// Update a measurementUnit
        /// </summary>
        /// <param name="measurementUnit"></param>
        /// <returns></returns>
        public async Task<int> UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            int numberOfAffectedRows = 0;
            if (measurementUnit != null)
            {
                DynamicParameters parameters = new DynamicParameters(new
                {
                    measurementUnit.Id,
                    measurementUnit.Label,
                    measurementUnit.Symbol,
                    measurementUnit.Commentary,
                });

                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("HERD_CATALOG")))
                {
                    numberOfAffectedRows = await dbConnection.ExecuteAsync("UpdateMeasurementUnit", parameters, commandType: CommandType.StoredProcedure);
                }
            }

            return numberOfAffectedRows;
        }
    }
}
