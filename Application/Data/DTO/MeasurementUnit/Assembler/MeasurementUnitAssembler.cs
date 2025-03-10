﻿using System.Collections.Generic;
using System.Linq;
using MeasurementUnitEntity  = HerdManagement.Domain.Common.Entities.MeasurementUnit;

namespace Applicattion.Data.DTO.MeasurementUnit.Assembler
{
    public static class MeasurementUnitAssembler
    {
        public static MeasurementUnitDTO ToMeasurementUnitDTO(this MeasurementUnitEntity measurementUnit)
        {
            return measurementUnit != null ?
                    new MeasurementUnitDTO
                    {
                        Id = measurementUnit.Id,
                        Label = measurementUnit.Label,
                        Symbol = measurementUnit.Symbol,
                        Commentary = measurementUnit.Commentary,
                        MeasurementUnitCategory = measurementUnit.Category
                    } :
                    null;
        }

        public static MeasurementUnitEntity ToMeasurementUnit(this MeasurementUnitDTO measurementUnitDTO)
        {
            return measurementUnitDTO != null ?
                    new MeasurementUnitEntity
                    {
                        Id = measurementUnitDTO.Id,
                        Label = measurementUnitDTO.Label,
                        Symbol = measurementUnitDTO.Symbol,
                        Commentary = measurementUnitDTO.Commentary,
                        Category = measurementUnitDTO.MeasurementUnitCategory
                    } :
                    null;
        }

        public static MeasurementUnitEntity ToMeasurementUnit(this MeasurementUnitUpdateDTO measurementUnitUpdateDTO, int id)
        {
            return measurementUnitUpdateDTO != null ?
                    new MeasurementUnitEntity
                    {
                        Id = id,
                        Label = measurementUnitUpdateDTO.Label,
                        Symbol = measurementUnitUpdateDTO.Symbol,
                        Commentary = measurementUnitUpdateDTO.Commentary
                    } :
                    null;
        }

        public static IEnumerable<MeasurementUnitDTO> ToMeasurementUnitDTOList(this IEnumerable<MeasurementUnitEntity> measurementUnits)
        {
            return measurementUnits != null && measurementUnits.Any() ?
                   measurementUnits.Select(measurementUnit => measurementUnit?.ToMeasurementUnitDTO()) :
                   new List<MeasurementUnitDTO>();

        }

        public static MeasurementUnitEntity ToMeasurementUnit(this MeasurementUnitCreationDTO measurementUnitCreationDTO)
        {
            return measurementUnitCreationDTO != null ?
                    new MeasurementUnitEntity
                    {
                        Label = measurementUnitCreationDTO.Label,
                        Symbol = measurementUnitCreationDTO.Symbol,
                        Commentary = measurementUnitCreationDTO.Commentary
                    } :
                    null;
        }
    }
}
