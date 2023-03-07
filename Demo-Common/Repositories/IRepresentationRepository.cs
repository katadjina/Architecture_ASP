using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IRepresentationRepository<TEntity, TId> : IRepository<TEntity,TId> where TEntity : IRepresentation
    {
        IEnumerable<TEntity> GetBySpectacle(int idSpec);
        IEnumerable<TEntity> GetByDate(DateTime date);
    }
}
