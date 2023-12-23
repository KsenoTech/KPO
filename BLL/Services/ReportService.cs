using DAL;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<SQLzapros> ExecuteSP(int count, int nalichie)
        {

            return db.Reports.ExecuteSP(count, nalichie).ToList();
        }

        public List<ReportData> MotosOfType(int manufId)
        {
            var request = db.Reports.MotosOfType(manufId)
             .Select(i => new ReportData() { /*Brand_name = i.Brand_name, Cost = i.Cost*/ })
             .ToList();
            return request;
        }

    }
}
