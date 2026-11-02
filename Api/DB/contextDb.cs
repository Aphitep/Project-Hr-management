using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public class contextDb : DbContext
    {
        public contextDb(DbContextOptions<contextDb> options) : base(options)
        {
        }

    }
}