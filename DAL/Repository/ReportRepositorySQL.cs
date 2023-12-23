using DomainModel;
using Interfaces.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private zContext db;
        //private class SPResult
        //{
        //    public string Customer { get; set; }
        //    public string Brand_name { get; set; }
        //    public DateTime Date { get; set; }
        //}
        public class SPResult
        {
            public int general_budget { get; set; }
            public string executor_NAME { get; set; }

            public string client_NAME { get; set; }

            //public string Brand_name { get; set; }
            //public string Model_name { get; set; }
            //public int Cost { get; set; }
            //public int Credit_On { get; set; }

        }
        public ReportRepositorySQL(zContext dbcontext)
        {
            this.db = dbcontext;
        }

        //выполнить ХП
        public List<SQLzapros> ExecuteSP(int count, int nalichie)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@count", count);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@nalichie", nalichie);

            var result = db.Database.SqlQuery<SPResult>("sqlzaprosLAB1 @count,@nalichie", new object[] { param1, param2 }).ToList();
            var data = result.GroupBy(i => new { i.general_budget, i.executor_NAME, i.client_NAME})
                .Select(i => new SQLzapros
                {
                   general_budget = i.Key.general_budget,
                    executor_NAME = i.Key.executor_NAME,
                    client_NAME = i.Key.client_NAME,
                }).ToList();
            return data;


        }

        public List<ReportData> MotosOfType(int typeId)
        {
            var request = db.zcontextOrder.Select(i => new ReportData() { client_ID = i.client_ID }).ToList();
             //.Join(db.Types, ph => ph.id_Type_FK, m => m.id_Type, (ph, m) => ph)
             //.Where(i => i.id_Type_FK == typeId)
             //.Select(i => new ReportSQLData() { Brand_name = i.Brand_name, Cost = i.Cost })
             //.ToList();
            return request;
        }




    }
}
