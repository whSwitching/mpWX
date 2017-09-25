using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mpwx.Data
{
    public class EntityModel : DbContext
    {
        public static void Initialize(EntityModel db)
        {
            db.Database.EnsureCreated();
        }

        public EntityModel(DbContextOptions<EntityModel> options) : base(options)
        {
        }
    }
}
