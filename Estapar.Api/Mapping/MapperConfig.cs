using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;

namespace Estapar.Api.Mapping
{
    public class MapperConfig
    {
        public static MapperConfiguration ConfigMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ValetParking, ValetParkingDTO>().ReverseMap();
                cfg.CreateMap<ValetParkingVehicle, ValetParkingVehicleDTO>().ReverseMap();
                cfg.CreateMap<VehicleBrand, VehicleBrandDTO>().ReverseMap();
                cfg.CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
                cfg.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
                cfg.CreateMap<ValetParkingVehicleDetail, ValetParkingVehicleDetailDTO>().ReverseMap();
            });

            return config;
        }
    }
}
