using HerdManagement.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Common.Repositories
{
    public interface IMeasurementUnitRepository
    {
        Task<MeasurementUnit> GetMeasurementUnitById(int id);
        Task<MeasurementUnit> GetMeasurementUnitByLabel(string label);
        Task<IEnumerable<MeasurementUnit>> GetAllMeasurementUnits();
        Task<int> UpdateMeasurementUnit(MeasurementUnit measurementUnit);
        Task<int> DeleteMeasurementUnit(int measurementUnitId);
        Task<MeasurementUnit> CreateMeasurementUnit(MeasurementUnit measurementUnit);

        IEnumerable<MeasurementUnit> GetMeasurementUnitsByCategory(
            MeasurementUnitCategory measurementUnitCategory);
    }
}
