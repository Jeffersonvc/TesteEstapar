using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;

namespace Estapar.Api.Service
{
    public class ValetParkingService : BaseService<ValetParking, ValetParkingDTO, IValetParkingRepository>, IValetParkingService
    {
        public ValetParkingService(IMapper mapper, IValetParkingRepository repository) : base(mapper, repository)
        {
        }

        public ValetParkingDTO GetByDocument(string document)
        {
            return _mapper.Map<ValetParkingDTO>(_repository.GetByDocument(document));
        }

        public bool HasAssociation(ValetParkingDTO dto)
        {
            var model = _mapper.Map<ValetParking>(dto);
            return _repository.HasAssociation(model);
        }
    }
}
