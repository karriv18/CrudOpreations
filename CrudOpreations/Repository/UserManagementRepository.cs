using Dapper;
using CrudOpreations.Model.Request;
using CrudOpreations.Model.Response;
using CrudOpreations.Database;

namespace CrudOpreations.Repository;

public class UserManagementRepository : IUserManagementRepository
{
    private readonly IDbConnectionFactory dbConnectionFactory; 
    public UserManagementRepository(IDbConnectionFactory _dbConnectionFactory)
    {
        dbConnectionFactory = _dbConnectionFactory;
    }
    public async Task<bool> CreateAsync(UserRequest request, CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        using var transaction = connection.BeginTransaction();

        try
        {
            var recordId = await connection.QuerySingleAsync<int>(new CommandDefinition(
                """
                    INSERT INTO Mst_Users 
                        (FirstName, 
                        MiddleName, 
                        LastName, 
                        BirthDay, 
                        Email, 
                        Password, 
                        IsActive
                        )
                    OUTPUT INSERTED.Id
                    VALUES
                        (@FirstName, 
                        @MiddleName, 
                        @LastName, 
                        @BirthDay, 
                        @Email, 
                        @Password, 
                        1
                        )
                """, new
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    BirthDay = request.BirthDay,
                    Email = request.Email,
                    Password = request.Password
                }, transaction: transaction, cancellationToken: cancellationToken));
            transaction.Commit();
            return recordId > 0;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }
    public async Task<UserResponse> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        using var transaction = connection.BeginTransaction();

        try
        {
            var user = await connection.QuerySingleOrDefaultAsync<UserResponse>(new CommandDefinition(
                """
                    SELECT 
                        Id,
                        FirstName,
                        MiddleName,
                        LastName,
                        BirthDay,
                        Email,
                        Password,
                        IsActive
                    FROM Mst_Users
                    WHERE Id = @Id
                """, new { Id = id }, transaction: transaction, cancellationToken: cancellationToken));
            transaction.Commit();
            return user;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
        throw new NotImplementedException();
    }
    public async Task<List<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);
        using var transaction = connection.BeginTransaction();

        try
        {
            var users = await connection.QueryAsync<UserResponse>(new CommandDefinition(
                """
                    SELECT 
                        Id,
                        FirstName,
                        MiddleName,
                        LastName,
                        BirthDay,
                        Email,
                        Password,
                        IsActive
                    FROM Mst_Users
                    WHERE IsActive = 1
                """, transaction: transaction, cancellationToken: cancellationToken));

            transaction.Commit();

            return users.ToList();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> UpdateAsync(int id, UserRequest request, CancellationToken cancellationToken = default)
    {
        var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        var transaction = connection.BeginTransaction();

        try
        {
            var userResponse = await connection.ExecuteAsync(new CommandDefinition(
                """
                    UPDATE Mst_Users SET 
                        FirstName = @FirstName,
                        MiddleName = @MiddleName,
                        LastName = @LastName,
                        BirthDay = @BirthDay,
                        Email = @Email,
                        Password = @Password
                    WHERE Id = @Id
                """,
                 new
                 {
                     FirstName = request.FirstName,
                     MiddleName = request.MiddleName,
                     LastName = request.LastName,
                     BirthDay = request.BirthDay,
                     Email = request.Email,
                     Password = request.Password,
                     Id = id
                 }, transaction: transaction, cancellationToken: cancellationToken));

            transaction.Commit();
            return true;
        }
        catch(Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }

    }
    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        var transaction = connection.BeginTransaction();

        try
        {
            var recordId = await connection.ExecuteAsync(new CommandDefinition(
                """
                    UPDATE Mst_Users SET ISActive = 0
                    WHERE Id = @Id
                """, new { Id = id }, transaction: transaction, cancellationToken: cancellationToken));
            
            transaction.Commit();
            return recordId;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }

}
