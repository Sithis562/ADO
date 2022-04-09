using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace _1
{
    class ItemsTable
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        static ConnectionSQL SQL = new ConnectionSQL();
        SqlConnection conSQL = new SqlConnection(SQL.SQLConnect());

        public void SELECT()
        {
            var sql = @"SELECT * FROM Items Order By Items.ID";

            da.SelectCommand = new SqlCommand(sql, conSQL);
        }

        public void INSERT()
        {
            var sql = @"INSERT INTO Items (Email, ItemId, ItemName)
                                 VALUES (@Email, @ItemId, @ItemName)
                        SET @ID = @@IDENTITY;";

            da.InsertCommand = new SqlCommand(sql, conSQL);

            da.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").Direction = ParameterDirection.Output;
            da.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            da.InsertCommand.Parameters.Add("@ItemId", SqlDbType.Int, 4, "ItemId");
            da.InsertCommand.Parameters.Add("@ItemName", SqlDbType.NVarChar, 50, "ItemName");
        }

        public void UPDATE()
        {
            var sql = @"UPDATE Items SET 
                           Email = @Email,
                           ItemId = @ItemId, 
                           ItemName = @ItemName
                     WHERE ID = @ID";

            da.UpdateCommand = new SqlCommand(sql, conSQL);

            da.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").SourceVersion = DataRowVersion.Original;
            da.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            da.UpdateCommand.Parameters.Add("@ItemId", SqlDbType.Int, 4, "ItemId");
            da.UpdateCommand.Parameters.Add("@ItemName", SqlDbType.NVarChar, 50, "ItemName");
        }

        public void DELETE()
        {
            var sql = "DELETE FROM Items WHERE ID = @ID";

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
