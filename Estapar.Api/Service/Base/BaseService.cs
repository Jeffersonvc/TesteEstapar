using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Repository.Interfaces.Base;
using Estapar.Api.Service.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Estapar.Api.Service.Base
{
    public class BaseService<TModel, TDTO, TRepository> : IBaseService<TDTO> where TRepository : IRepository<TModel> where TDTO : BaseDTO
    {
        protected TRepository _repository;
        protected IMapper _mapper;
        public BaseService(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public bool Delete(TDTO dto)
        {
            return _repository.Delete(_mapper.Map<TModel>(dto));
        }

        public IEnumerable<TDTO> GetAll()
        {
            var list = _repository.GetAll();
            return _mapper.Map<IEnumerable<TDTO>>(list);
        }

        public TDTO GetById(int id)
        {
            var dto = Activator.CreateInstance<TDTO>();
            dto.Id = id;
            var model = _mapper.Map<TModel>(dto);
            return _mapper.Map<TDTO>(_repository.GetById(model));
        }

        public bool Update(TDTO dto)
        {
            var model = _mapper.Map<TModel>(dto);
            return _repository.Update(model);
        }

        public bool Insert(TDTO dto)
        {
            var model = _mapper.Map<TModel>(dto);
            return _repository.Insert(model);
        }

        public IEnumerable<TDTO> GetActives()
        {
            var list = _repository.GetActives();
            return _mapper.Map<IEnumerable<TDTO>>(list);
        }
    }
}
