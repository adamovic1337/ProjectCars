using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Model.DTO.View
{
    public class CarDto : BaseViewDTO
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
