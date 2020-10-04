﻿namespace StarForums.Services.Data
{
    using System.Collections.Generic;

    using StarForums.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        T GetByName<T>(string name);
    }
}
