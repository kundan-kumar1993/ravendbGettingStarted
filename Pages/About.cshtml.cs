using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ravendb_getting_started.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Hibernating Rhinos, a global provider of database infrastructure solutions, " +
            "empowers Fortune 500 companies and enterprises across the globe to process online transactions through an open source platform." +
            "RavenDB is the industry’s first fully-transactional, NoSQL ACID database that combines scalability, high-availability, speed and performance." +
            "The company produces two ORM tools, NHibernate and Entity Framework Profilers, that inspect, analyze and suggest improvements to database access patterns in applications." +
            "Hibernating Rhinos is headquartered in Hadera, Israel with offices in the U.S. and Poland and extends its reach through over 1500+ customers worldwide..";
        }
    }
}