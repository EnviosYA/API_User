﻿using System.Collections.Generic;

namespace PS.Template.Domain.Commands
{
    public interface IGenericsRepository<E> where E : class
    {
        E Add(E entity);
        void Delete(E entity);
        void Delete(int id);
        void Edit(E entity);
        void EditRange(IEnumerable<E> entity);
        void Save();
        void AddRange(IEnumerable<E> entity);
        void DeleteRange(IEnumerable<E> entity);
        E FindById(int id);

    }
}
