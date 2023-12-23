namespace Interfaces.DTO
{
    public class SQLzapros
    {
        //тут че будет в хранилке
        public int general_budget { get; set; }
        public string executor_NAME { get; set; }
        public string client_NAME { get; set; }
    }

    public class ReportData
    {
        public string Feedback { get; set; }
        public int general_budget { get; set; }
        public string executor_NAME { get; set; }
        public string client_NAME { get; set; }
        public int client_ID { get; set; }
        public int executor_ID { get; set; }
    }
}
