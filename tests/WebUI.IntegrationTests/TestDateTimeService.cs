using Accounting.Application.Common.Interfaces;
using System;

namespace Accounting.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
