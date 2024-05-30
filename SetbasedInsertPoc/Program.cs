using System.Data.SqlTypes;
using System.Threading;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using LHDS.UPRN.Domain;
using System.Configuration;
using Microsoft.Extensions.Configuration;

internal class Program
{
    public const string Connection = "Server=(localdb)\\MSSQLLocalDB;Database=UPRN;Trusted_Connection=True;MultipleActiveResultSets=true";

    private static async Task AsyncMain()
    {
        var batchSize = 10000;

        var timer = new Stopwatch();

        timer.Start();
        //RBARTest(batchSize);
        timer.Stop();
        Console.WriteLine("RBAR: " + timer.Elapsed.ToString());

        timer.Reset();
        timer.Start();
        BatchTest(batchSize);
        timer.Stop();
        Console.WriteLine("SET: " + timer.Elapsed.ToString());

        timer.Reset();
        timer.Start();
        EFTest(batchSize);
        timer.Stop();
        Console.WriteLine("EF RBAR: " + timer.Elapsed.ToString());

        timer.Reset();
        timer.Start();
        EFBatchTest(batchSize);
        timer.Stop();
        Console.WriteLine("EF Batch: " + timer.Elapsed.ToString());

    }

    private static void EFBatchTest(int batchSize)
    {
        var configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(new Dictionary<string, string>
           {
                { "ConnectionStrings:DefaultConnection", Connection}
           })
           .Build();


        var context = new UPRNContext(configuration);
        for (var i = 0; i < batchSize; i++)
        {
            context.Addresses.Add(new LHDS.UPRN.Domain.Models.Addresses
            {
                UPRN = GetRandomString(10),
                UPSN = GetRandomString(10),
                OrganisationName = GetRandomString(10),
                DepartmentName = GetRandomString(10),
                SubBuildingName = GetRandomString(10),
                BuildingName = GetRandomString(10),
                BuildingNumber = GetRandomString(10),
                DependentThoroughfare = GetRandomString(10),
                Thoroughfare = GetRandomString(10),
                DoubleDependentLocality = GetRandomString(10),
                DependentLocality = GetRandomString(10),
                PostTown = GetRandomString(10),
                PostalAddress = GetRandomString(10),
                PostCode = GetRandomString(10),
                LibPostalData = GetRandomString(10)
            });

            if(i % 100 == 0)
            {
                Console.Write(".");
            }
        }

        context.SaveChanges();
    }

    private static void EFTest(int batchSize)
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultConnection", Connection}
            })
            .Build();


        var context = new UPRNContext(configuration);
        for (var i = 0; i < batchSize; i++)
        {
            context.Addresses.Add(new LHDS.UPRN.Domain.Models.Addresses
            {
                UPRN = GetRandomString(10),
                UPSN = GetRandomString(10),
                OrganisationName = GetRandomString(10),
                DepartmentName = GetRandomString(10),
                SubBuildingName = GetRandomString(10),
                BuildingName = GetRandomString(10),
                BuildingNumber = GetRandomString(10),
                DependentThoroughfare = GetRandomString(10),
                Thoroughfare = GetRandomString(10),
                DoubleDependentLocality = GetRandomString(10),
                DependentLocality = GetRandomString(10),
                PostTown = GetRandomString(10),
                PostalAddress = GetRandomString(10),
                PostCode = GetRandomString(10),
                LibPostalData = GetRandomString(10)
            });

            context.SaveChanges();

            if (i % 100 == 0)
            {
                Console.Write(".");
            }
        }
    }

    private static void RBARTest(int batchSize)
    {
        using (var connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=UPRN;Trusted_Connection=True;MultipleActiveResultSets=true"))
        {
            connection.Open();
            for (var i = 0; i < batchSize; i++)
            {
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


                dataTable.Rows.Add(
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10));


                SqlCommand RBAR = connection.CreateCommand();
                RBAR.CommandText = "dbo.insertAddress";
                RBAR.CommandType = CommandType.StoredProcedure;

                RBAR.Parameters.Add(new SqlParameter("@rows", dataTable)
                {
                    TypeName = "dbo.AddressType",
                    Value = dataTable
                });
                RBAR.ExecuteNonQuery();

                if (i % 100 == 0)
                {
                    Console.Write(".");
                }
            }
        }
    }

    private static void BatchTest(int batchSize)
    {
        using (var connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=UPRN;Trusted_Connection=True;MultipleActiveResultSets=true"))
        {

            connection.Open();

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


            for (var i = 0; i < batchSize; i++)
            {
                dataTable.Rows.Add(
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10),
                GetRandomString(10));

                if (i % 100 == 0)
                {
                    Console.Write(".");
                }
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


        }
    }

    private static void Main(string[] args)
    {
        AsyncMain().GetAwaiter().GetResult();
    }



    public static string GetRandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}