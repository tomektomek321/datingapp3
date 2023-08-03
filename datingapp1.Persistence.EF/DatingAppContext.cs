using Microsoft.EntityFrameworkCore;
using datingapp1.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace datingapp1.Persistence.EF;

public class DatingAppContext: IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DatingAppContext(DbContextOptions options)
        : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<UserLike> UserLikes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<UserHobby> UserHobbies { get; set; }
    public DbSet<Message> Messages { get; set; }



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
        base.OnModelCreating(modelBuilder);

        modelBuilder.
            ApplyConfigurationsFromAssembly
            (typeof(DatingAppContext).Assembly);

        modelBuilder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        modelBuilder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

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

        modelBuilder.Entity<Message>()
            .HasOne(u => u.Recipient)
            .WithMany(m => m.MessagesReceived)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasOne(u => u.Sender)
            .WithMany(m => m.MessagesSent)
            .OnDelete(DeleteBehavior.Restrict);

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
