using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Estapar.Api.Repository
{
    public class ValetParkingVehicleDetailRepository : BaseRepository<ValetParkingVehicleDetail>, IValetParkingVehicleDetailRepository
    {
        public ValetParkingVehicleDetailRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }

        public ValetParkingVehicleDetail Get(ValetParkingVehicleDetail model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@valetParkingVehicleId", model.Id }
            };
            string query = @"select
	                            t1.ValetParkingVehicleId
	                            ,t1.InclusionDate
	                            ,t1.Active
	                            ,t3.Name as ValetParkingName
	                            ,t4.Name as VahicleModelName
	                            ,t5.Name as VahicleBrandName
	                            ,t2.VehicleLicensePlate
                            from
	                            TB_ValetParkingVehicle t1 (nolock)
                            inner join
	                            TB_Vehicle t2 (nolock) on t1.VehicleId = t2.VehicleId
                            inner join
	                            TB_ValetParking t3 (nolock) on t1.ValetParkingId = t3.ValetParkingId
                            inner join	
	                            TB_VehicleModel t4 (nolock) on t2.VehicleModelId = t4.VehicleModelId
                            inner join
	                            TB_VehicleBrand t5 (nolock) on t4.VehicleBrandId = t5.VehicleBrandId
                            where
                                t1.ValetParkingVehicleId = @valetParkingVehicleId";
            return ExecuteCommandObject(query, parameters);
        }

        public IEnumerable<ValetParkingVehicleDetail> GetActives()
        {
            return GetAllDetails();
        }

        public IEnumerable<ValetParkingVehicleDetail> GetAllDetails()
        {
            string query = @"select
	                            t1.ValetParkingVehicleId
	                            ,t1.InclusionDate
	                            ,t1.Active
	                            ,t3.Name as ValetParkingName
	                            ,t4.Name as VahicleModelName
	                            ,t5.Name as VahicleBrandName
	                            ,t2.VehicleLicensePlate
                            from
	                            TB_ValetParkingVehicle t1 (nolock)
                            inner join
	                            TB_Vehicle t2 (nolock) on t1.VehicleId = t2.VehicleId
                            inner join
	                            TB_ValetParking t3 (nolock) on t1.ValetParkingId = t3.ValetParkingId
                            inner join	
	                            TB_VehicleModel t4 (nolock) on t2.VehicleModelId = t4.VehicleModelId
                            inner join
	                            TB_VehicleBrand t5 (nolock) on t4.VehicleBrandId = t5.VehicleBrandId";
            return ExecuteCommandList(query, null);
        }

        public ValetParkingVehicleDetail GetDetail(ValetParkingVehicleDetail model)
        {
            return Get(model);
        }
    }
}
