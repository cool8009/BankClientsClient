﻿using BankClientApi.Data;

namespace BankClientApi.Contracts
{
    public interface ICitiesRepository : IGenericRepository<City>
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
    }
}
