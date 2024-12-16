using Application.Abstractions.Data;
using Persistence.Context;

namespace Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _databaseContext;

    public UnitOfWork(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseContext.SaveChangesAsync(cancellationToken);
    }
}
