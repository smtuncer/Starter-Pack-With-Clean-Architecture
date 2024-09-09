using Infrastructure.Repositories;
using Project.Domain.Entities;
using Project.Infrastracture.Data.Context;

namespace Project.Infrastructure.Repositories;
public class BlogRepository : GenericRepository<Blog>
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }
}