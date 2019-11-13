using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;

namespace Estapar.Api.Service
{
    public class VehicleService : BaseService<Vehicle, VehicleDTO, IVehicleRepository>, IVehicleService
    {
        public VehicleService(IMapper mapper, IVehicleRepository repository) : base(mapper, repository)
        {
        }

        public VehicleDTO GetByPlate(string plate)
        {
            return _mapper.Map<VehicleDTO>(_repository.GetByPlate(plate));
        }

        public bool HasAssociation(VehicleDTO dto)
        {
            var model = _mapper.Map<Vehicle>(dto);
            return _repository.HasAssociation(model);
        }
    }
}
