using System.Data.SqlTypes;
using System.Threading;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

internal class Program
{
    private static async Task AsyncMain()
    {
        var connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=UPRN;Trusted_Connection=True;MultipleActiveResultSets=true");

        await connection.OpenAsync();

        var dataTable = new DataTable();

        dataTable.Columns.Add("UPRN");
        dataTable.Columns.Add("UPSN");
        dataTable.Columns.Add("OrganisationName");
        dataTable.Columns.Add("DepartmentName");
        dataTable.Columns.Add("SubBuildingName");
        dataTable.Columns.Add("BuildingName");
        dataTable.Columns.Add("BuildingNumber");
        dataTable.Columns.Add("DependentThoroughfare");
        dataTable.Columns.Add("Thoroughfare");
        dataTable.Columns.Add("DoubleDependentLocality");
        dataTable.Columns.Add("DependentLocality");
        dataTable.Columns.Add("PostTown");
        dataTable.Columns.Add("PostalAddress");
        dataTable.Columns.Add("PostCode");
        dataTable.Columns.Add("LibPostalData");

        var timer = new Stopwatch();

        timer.Start();

        Console.WriteLine(timer.Elapsed.ToString());

        for (var i = 0; i < 1000; i++)
        {
            dataTable.Rows.Add(
            "UPRN",
            "UPSN",
            "OrganisationName",
            "DepartmentName",
            "SubBuildingName",
            "BuildingName",
            "BuildingNumber",
            "DependentThoroughfare",
            "Thoroughfare",
            "DoubleDependentLocality",
            "DependentLocality",
            "PostTown",
            "PostalAddress",
            "PostCode",
            "LibPostalData");
        }

        SqlCommand command = connection.CreateCommand();
        command.CommandText = "dbo.insertAddress";
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@rows", dataTable)
        {
            TypeName = "dbo.AddressType",
            Value = dataTable
        });
        command.ExecuteNonQuery();



        Console.WriteLine(timer.Elapsed.ToString());
    }

    private static void Main(string[] args)
    {
        AsyncMain().GetAwaiter().GetResult();
    }
}