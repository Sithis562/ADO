using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace _1
{
    class ClientsTable
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        static ConnectionSQL SQL = new ConnectionSQL();
        SqlConnection conSQL = new SqlConnection(SQL.SQLConnect());

        public void SELECT()
        {
            var sql = @"SELECT * FROM Clients Order By Clients.ID";

            da.SelectCommand = new SqlCommand(sql, conSQL);
        }

        public void INSERT()
        {
            var sql = @"INSERT INTO Clients (LastName, FirstName, Patronymic, PhoneNumber, Email)
                                 VALUES (@LastName, @FirstName, @Patronymic, @PhoneNumber, @Email)
                        SET @ID = @@IDENTITY;";

            da.InsertCommand = new SqlCommand(sql, conSQL);

            da.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").Direction = ParameterDirection.Output;
            da.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            da.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            da.InsertCommand.Parameters.Add("@Patronymic", SqlDbType.NVarChar, 50, "Patronymic");
            da.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 50, "PhoneNumber");
            da.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
        }

        public void UPDATE()
        {
            var sql = @"UPDATE Clients SET
                           LastName = @LastName,
                           FirstName = @FirstName,
                           Patronymic = @Patronymic,
                           PhoneNumber = @PhoneNumber,
                           Email = @Email
                      WHERE ID = @ID";

            da.UpdateCommand = new SqlCommand(sql, conSQL);

            da.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").SourceVersion = DataRowVersion.Original;
            da.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            da.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            da.UpdateCommand.Parameters.Add("@Patronymic", SqlDbType.NVarChar, 50, "Patronymic");
            da.UpdateCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 50, "PhoneNumber");
            da.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
        }

        public void DELETE()
        { 
            var sql = "DELETE FROM Clients WHERE ID = @ID";

            da.DeleteCommand = new SqlCommand(sql, conSQL);

            da.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
        }

        public DataTable Fill()
        {
            da.Fill(dt);

            return dt;
        }

        public DataTable Update()
        {
            da.Update(dt);

            return dt;
        }
    }
}
