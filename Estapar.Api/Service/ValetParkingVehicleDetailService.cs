using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;
using System.Collections.Generic;

namespace Estapar.Api.Service
{
    public class ValetParkingVehicleDetailService : BaseService<ValetParkingVehicleDetail, ValetParkingVehicleDetailDTO, IValetParkingVehicleDetailRepository>, IValetParkingVehicleDetailService
    {
        public ValetParkingVehicleDetailService(IMapper mapper, IValetParkingVehicleDetailRepository repository) : base(mapper, repository)
        {
        }

        public IEnumerable<ValetParkingVehicleDetailDTO> GetAllDetails()
        {
            return _mapper.Map<IEnumerable<ValetParkingVehicleDetailDTO>>(_repository.GetAllDetails());
        }

        public ValetParkingVehicleDetailDTO Get(int id)
        {
            var model = new ValetParkingVehicleDetail();
            model.Id = id;
            return _mapper.Map<ValetParkingVehicleDetailDTO>(_repository.GetDetail(model));
        }
    }
}
