﻿using Microsoft.EntityFrameworkCore;
using PS.Template.AccessData.cualquiera;
using PS.Template.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData.Commands
{
    public class GenericsRepository<E> : IGenericsRepository<E> where E : class
    {
        private readonly UsuarioDBContext _context;
        public GenericsRepository(UsuarioDBContext dbContext)
        {
            _context = dbContext;
        }

        public virtual E Add(E entity) 
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual void AddRange(IEnumerable<E> entity)
        {
            _context.Set<E>().AddRange(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(E entity)
        {
            _context.Set<E>().Attach(entity);
            _context.Set<E>().Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            E entity = FindById(id);
            Delete(entity);
        }
        public virtual void DeleteRange(IEnumerable<E> entity)
        {
            _context.Set<E>().RemoveRange(entity);
            _context.SaveChanges();
        }
        public virtual void Edit(E entity)
        {
            _context.Set<E>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual void EditRange(IEnumerable<E> entity)
        {
            _context.Set<E>().UpdateRange(entity);
            _context.SaveChanges();
        }
        public virtual E FindById(int id)
        {
            return _context.Set<E>().Find(id);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
