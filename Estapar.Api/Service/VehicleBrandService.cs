using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;

namespace Estapar.Api.Service
{
    public class VehicleBrandService : BaseService<VehicleBrand, VehicleBrandDTO, IVehicleBrandRepository>, IVehicleBrandService
    {
        public VehicleBrandService(IMapper mapper, IVehicleBrandRepository repository) : base(mapper, repository)
        {
        }

        public VehicleBrandDTO GetByName(VehicleBrandDTO dto)
        {
            var model = _mapper.Map<VehicleBrand>(dto);
            return _mapper.Map<VehicleBrandDTO>(_repository.GetByName(model));
        }

        public bool HasAssociation(VehicleBrandDTO dto)
        {
            var model = _mapper.Map<VehicleBrand>(dto);
            return _repository.HasAssociation(model);
        }
    }
}
