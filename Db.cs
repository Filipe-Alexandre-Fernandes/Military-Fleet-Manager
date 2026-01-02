using System.Data;
using Microsoft.Data.SqlClient;


public static class Db
{
    
    private static readonly string _cs =
        "Server=.;Database=GestaoViaturasAtual;Trusted_Connection=True;TrustServerCertificate=True;";

    public static DataTable Query(string sql, params SqlParameter[] p)
    {
        using var con = new SqlConnection(_cs);
        using var cmd = new SqlCommand(sql, con);
        if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
        using var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public static int Exec(string sql, params Microsoft.Data.SqlClient.SqlParameter[] p)
    {
        using var con = new Microsoft.Data.SqlClient.SqlConnection(_cs);
        con.Open();
        using var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con);
        if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
        return cmd.ExecuteNonQuery();
    }

}
