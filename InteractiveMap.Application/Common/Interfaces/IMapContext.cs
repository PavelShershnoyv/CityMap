using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IMapContext
{
    DbSet<Mark> Marks { get; set; }
    DbSet<UserMark> UserMarks { get; set; }
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
