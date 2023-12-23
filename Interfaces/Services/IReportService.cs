using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IReportService
    {
        List<SQLzapros> ExecuteSP(int cost, int nalichie);
        List<ReportData> MotosOfType(int typeId);
    }
}
