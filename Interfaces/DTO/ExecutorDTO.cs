using DomainModel;

namespace Interfaces.DTO
{
    public class ExecutorDTO
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string e_mail { get; set; }
        public float? rating { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string telephone_number { get; set; }
        //public virtual Organization Organization { get; set; }
        //public virtual Private_Face Private_Face { get; set; }
        public ExecutorDTO() { }
        public ExecutorDTO(Executor executor )
        {
            Id = executor.Id;
            login = executor.login;
            password = executor.password;
            e_mail = executor.e_mail;
            rating = executor.rating;
            surname = executor.surname;
            name = executor.name;
            middle_name = executor.middle_name;
            telephone_number = executor.telephone_number;
        }
    }
}
