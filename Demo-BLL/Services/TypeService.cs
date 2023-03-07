using DAL = Demo_DAL.Entities;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class TypeService : ITypeRepository<Type, int>
    {
        private readonly ITypeRepository<DAL.Type, int> _repository;

        public TypeService(ITypeRepository<DAL.Type, int> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Type> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Type Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }
    }
}
