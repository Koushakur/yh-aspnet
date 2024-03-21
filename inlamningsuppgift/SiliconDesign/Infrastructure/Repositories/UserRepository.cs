using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Shared.Repositories;

public class UserRepository(DataContext dbContext) : AbstractRepository<UserEntity>(dbContext) {

    private readonly DataContext _dbContext = dbContext;
}
