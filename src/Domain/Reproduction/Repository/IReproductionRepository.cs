using HerdManagement.Domain.Reproduction.Entities;
using System;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IReproductionRepository
    {
        Calving GetCalvingByParentsIdsdAndDate(int femaleId, int maleId, DateTime datetime);
    }
}