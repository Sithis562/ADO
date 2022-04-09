using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace _1
{
    class ConnectionSQL
    {
        public string DataSource = "(LocalDB)\\MSSQLLocalDB";

        public string InitialCatalog = "SQLDB";

        public bool IntegratedSecurity = false;

        public string UserID = "Sithis";

        public string Password = "123";

        public string SQLConnect()
        {
            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = DataSource,
                InitialCatalog = InitialCatalog,
                IntegratedSecurity = IntegratedSecurity,
                UserID = UserID,
                Password = Password
            };

            return strCon.ConnectionString.ToString();
        }
    }
}
