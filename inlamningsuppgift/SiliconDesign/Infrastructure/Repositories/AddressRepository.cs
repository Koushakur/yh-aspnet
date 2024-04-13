using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository(IdentityContext dbContext) : AbstractRepository<AddressEntity>(dbContext) {

    private readonly IdentityContext _dbContext = dbContext;
}