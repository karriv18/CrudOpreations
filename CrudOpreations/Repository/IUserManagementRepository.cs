﻿using CrudOpreations.Model.Request; 
using CrudOpreations.Model.Response;
namespace CrudOpreations.Repository;

public interface IUserManagementRepository
{
    Task<bool> CreateAsync(UserRequest request, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(int id, UserRequest request, CancellationToken cancellationToken = default);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<UserResponse> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}
