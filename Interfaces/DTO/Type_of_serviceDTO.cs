using DomainModel;

namespace Interfaces.DTO
{
    public class Type_of_serviceDTO
    {
        public int Id { get; set; }
        public string description_of_service { get; set; }
        public int? cost_of_m { get; set; }
        public int? cost_of_m2 { get; set; }


        public Type_of_serviceDTO () { }
        public Type_of_serviceDTO(Type_of_service type_Of_Service)
        {
            Id= type_Of_Service.Id;
            description_of_service = type_Of_Service.description_of_service;
            cost_of_m = type_Of_Service.cost_of_m;
            cost_of_m2 = type_Of_Service.cost_of_m2;

        }
    }
}
