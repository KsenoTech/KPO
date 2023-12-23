using DomainModel;

namespace Interfaces.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string e_mail { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string telephone_number { get; set; }


        public ClientDTO() { }

        public ClientDTO(Client client)
        {
            Id = client.Id;
            surname = client.surname;
            name = client.name;
            middle_name = client.middle_name;
            e_mail = client.e_mail;
            login = client.login;
            password = client.password;
            address = client.address;
            telephone_number = client.telephone_number;
        }
    }
}
