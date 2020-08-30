using Accounting.Application.Common.Interfaces;
using System;

namespace Accounting.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
