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
        : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<UserLike> UserLikes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<UserHobby> UserHobbies { get; set; }



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

        modelBuilder.Entity<UserLike>()
            .HasKey(key => new { key.SourceUserId, key.LikedUserId });

        modelBuilder.Entity<UserLike>()
            .HasOne(user => user.SourceUser)
            .WithMany(user => user.LikedUsers)
            .HasForeignKey(user => user.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserLike>()
            .HasOne(user => user.LikedUser)
            .WithMany(user => user.LikedByUsers)
            .HasForeignKey(s => s.LikedUserId)
            .OnDelete(DeleteBehavior.Cascade);



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
            modelBuilder.Entity<Webinar>().HasData(item);
        }*/
    }
}
