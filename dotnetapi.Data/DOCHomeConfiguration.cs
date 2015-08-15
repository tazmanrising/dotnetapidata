using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace dotnetapi.Data
{
    public class DOCHomeConfiguration : DbConfiguration
    {

        public DOCHomeConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }

    }


}
