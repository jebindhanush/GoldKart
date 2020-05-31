using System;
interface IDataAccess
{
    System.Data.SqlClient.SqlConnection CloseSqlConnection();
    System.Data.SqlClient.SqlConnection CloseSqlConnection2();
    System.Data.SqlClient.SqlConnection CloseSqlConnection3();
    System.Data.SqlClient.SqlConnection OpenSqlConnectionRDS_Finance_Final();
    System.Data.SqlClient.SqlConnection OpenSqlConnectionRDSFinal();
    System.Data.SqlClient.SqlConnection OpenSqlConnectionRemote();
}
