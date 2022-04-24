using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;

namespace datingapp1.Persistence.EF;

public class DatingAppContext: DbContext
{
    public DatingAppContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<City> City { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
            ApplyConfigurationsFromAssembly
            (typeof(DatingAppContext).Assembly);


        /*foreach (var item in DummyCities.Get())
        {
            modelBuilder.Entity<Category>().HasData(item);
        }

        foreach (var item in DummyPosts.Get())
        {
            modelBuilder.Entity<Post>(b =>
            {
                b.HasData(item);
            });

        }

        foreach (var item in DummyWebinars.Get())
        {
            modelBuilder.Entity<Webinar>().HasData(item);*/
        }
    }
}
