using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;

namespace Estapar.Api.Service
{
    public class VehicleModelService : BaseService<VehicleModel, VehicleModelDTO, IVehicleModelRepository>, IVehicleModelService
    {
        public VehicleModelService(IMapper mapper, IVehicleModelRepository repository) : base(mapper, repository)
        {
        }

        public VehicleModelDTO GetByName(VehicleModelDTO dto)
        {
            var model = _mapper.Map<VehicleModel>(dto);
            return _mapper.Map<VehicleModelDTO>(_repository.GetByName(model));
        }

        public bool HasAssociation(VehicleModelDTO dto)
        {
            var model = _mapper.Map<VehicleModel>(dto);
            return _repository.HasAssociation(model);
        }
    }
}
