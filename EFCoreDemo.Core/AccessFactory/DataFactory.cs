using EFCoreDemo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Core.AccessFactory
{
    public class DataFactory
    {
        public static IReportRepository GetReportRepository()
        {
            return new ReportRepository();
        }
    }
}
