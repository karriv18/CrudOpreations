using System.Collections.Generic;
using CrudOpreations.Model.Request;
using CrudOpreations.Model.Response;
using CrudOpreations.Repository;


namespace CrudOpreations.Services;
public class UserManagementServices : IUserManagementServices
{
    private readonly IUserManagementRepository userManagementRepository;
    public UserManagementServices(IUserManagementRepository _usermanagementRepository)
    {
        userManagementRepository = _usermanagementRepository;
    }
    public async Task<bool> CreateAsync(UserRequest request, CancellationToken cancellationToken = default)
    {
        var isCreated = await userManagementRepository.CreateAsync(request, cancellationToken);
        return isCreated;
    }

    public Task<UserResponse> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var userResponse = userManagementRepository.GetByIdAsync(id, cancellationToken);

        return userResponse;
    }


    public Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var isDelete = userManagementRepository.DeleteAsync(id, cancellationToken);

        return isDelete;
    }

    public Task<List<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var usersResponse = userManagementRepository.GetAllAsync(cancellationToken);

        return usersResponse;
    }

    public Task<bool> UpdateAsync(int id, UserRequest request, CancellationToken cancellationToken = default)
    {
        var userResponse = userManagementRepository.UpdateAsync(id, request, cancellationToken);

        return userResponse;
    }

}
