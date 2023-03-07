using DAL = Demo_DAL.Entities;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class RepresentationService : IRepresentationRepository<Representation, int>
    {
        private readonly IRepresentationRepository<DAL.Representation, int> _repository;

        public RepresentationService(IRepresentationRepository<DAL.Representation, int> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Representation> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Representation Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Representation> GetByDate(DateTime date)
        {
            return _repository.GetByDate(date).Select(e => e.ToBLL());
        }

        public IEnumerable<Representation> GetBySpectacle(int idSpec)
        {
            return _repository.GetBySpectacle(idSpec).Select(e => e.ToBLL());
        }

        public int Insert(Representation entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Representation entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
