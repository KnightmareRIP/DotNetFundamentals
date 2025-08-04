using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Dapper.ConsoleApp;

internal class AllInOne
{
    const string CONNECTION_STRING = "Server=127.0.0.1;Database=LabWorX;User Id=sa;Password=@dm1n123#;TrustServerCertificate=True;";
    const string INSERT_SQL = @"
Insert into Header
    (Id, Name, State, Expires, Amount, Terminated) 
  Values
    (@Id, @Name, @State, @Expires, @Amount, @Terminated)";

    const string UPDATE_SQL = @"
Update Header Set
    Name = @Name, State = @State,
    Expires = @Expires, Amount = @Amount,
    Terminated = @Terminated
  Where Id = @Id";

    const string DELETE_SQL = @"
Delete From Header
  Where Id = @Id";

    const string SELECT_SQL = @"
Select
    Id, Name, State, Expires, Amount, Terminated
  From Header with (nolock)";

    const string SELECT_BY_ID__SQL = @"
Select
    Id, Name, State, Expires, Amount, Terminated
  From Header with (nolock)
  Where Id = @Id";

    internal static async Task RunAsync()
    {

        using DbConnection connection = new SqlConnection(CONNECTION_STRING);
        await connection.OpenAsync();

        Console.WriteLine("Connection opened successfully!");
        Console.WriteLine("Press any key to close the connection...");
        Console.ReadKey();

        // Insert a new record into the 'Header' table
        var rec = new Header
        {
            Id = Guid.NewGuid(),
            Name = "Marge Simpson"
        };

        var affectedRows = await connection.ExecuteAsync(INSERT_SQL, rec);

        Console.WriteLine($"{affectedRows} record(s) inserted into the 'Header' table.");


        // Update an existing record in the 'Header' table
        var updateRec = new Header
        {
            Id = Guid.Parse("9D0E1388-7994-4C73-9B26-5EE92C411ECA"),
            Name = "Liza Simpson"
        };

        affectedRows = await connection.ExecuteAsync(UPDATE_SQL, updateRec);

        Console.WriteLine($"{affectedRows} record(s) updated into the 'Header' table.");

        // Delete a record from the 'Header' table
        var deleteRec = new Header
        {
            Id = Guid.Parse("7467C7CF-66AF-4C82-9E12-2E02FA757458")
        };

        affectedRows = await connection.ExecuteAsync(DELETE_SQL, deleteRec);

        Console.WriteLine($"{affectedRows} record(s) deleted into the 'Header' table.");


        // Select all records in the 'Header' table
        var headers = await connection.QueryAsync<Header>(SELECT_SQL);

        // Select a record by Id in the 'Header' table
        var header = await connection.QueryFirstOrDefaultAsync<Header>(SELECT_BY_ID__SQL, new { Id = "50EFD1DF-6A33-4F28-883B-652164EACE54" });


        await connection.CloseAsync();

        Console.WriteLine("\n\nConnection closed successfully!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

public class Header
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? State { get; set; } = null;
    public DateTime? Expires { get; set; } = null;
    public Decimal? Amount { get; set; } = null;
    public bool Terminated { get; set; }
}

