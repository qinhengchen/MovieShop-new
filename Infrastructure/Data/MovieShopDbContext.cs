﻿
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
        }


    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<MovieCast> MoviesCasts { get; set; }
    public DbSet<Crew> Crews { get; set; }
    public DbSet<MovieCrew> MovieCrews { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<Trailer>(ConfigureTrailer);
        modelBuilder.Entity<Role>(ConfigureRole);
        modelBuilder.Entity<User>(ConfigureUser);
        modelBuilder.Entity<Favorite>(ConfigureFavorite);
        modelBuilder.Entity<Purchase>(ConfigurePurchase);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<UserRole>(ConfigureUserRole);
        modelBuilder.Entity<Cast>(ConfigureCast);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
        modelBuilder.Entity<Crew>(ConfigureCrew);
        modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
        modelBuilder.Entity<Review>(ConfigureReview);
    }
    private void ConfigureReview(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Review");
        builder.HasKey(r => new { r.MovieId, r.UserId });
        builder.Property(r => r.Rating).HasColumnType("decimal(3, 2)");
        builder.Property(r => r.ReviewText).HasMaxLength(4096);
    }
    private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
    {
        builder.ToTable("MovieCrew");
        builder.HasKey(mc => new { mc.MovieId, mc.CrewID, mc.Department, mc.Job });
        builder.Property(mc => mc.Department).HasMaxLength(128);
        builder.Property(mc => mc.Job).HasMaxLength(128);
    }

    private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
    {
        builder.ToTable("Crew");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(128);
        builder.Property(c => c.Gender).HasMaxLength(4096);
        builder.Property(c => c.TmdbUrl).HasMaxLength(4096);
        builder.Property(c => c.ProfilePath).HasMaxLength(2084);
    }

    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
    {
        builder.ToTable("MovieCast");
        builder.HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });
        builder.Property(mc => mc.Character).HasMaxLength(450);
    }

    private void ConfigureCast(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable("Cast");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(128);
        builder.Property(c => c.Gender).HasMaxLength(4096);
        //builder.Property(c => c.TmdbUrl).HasMaxLength(4096);
        builder.Property(c => c.ProfilePath).HasMaxLength(2084);
    }

    private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");
        builder.HasKey(u => new { u.UserId, u.RoleId });
    }


    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.ToTable("MovieGenre");
        // create a Primary Key
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
    }

    private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchase");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.TotalPrice).HasColumnType("decimal(18, 2)");
    }

    private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("Favorite");
        builder.HasKey(x => x.Id);
    }

    private void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.Property(u => u.FirstName).HasMaxLength(128);
        builder.Property(u => u.LastName).HasMaxLength(128);
        builder.Property(u => u.HashedPassword).HasMaxLength(1024);
        builder.Property(u => u.PhoneNumber).HasMaxLength(16);
        builder.Property(u => u.Salt).HasMaxLength(1024);
        builder.Property(u => u.ProfilePictureUrl).HasMaxLength(4096);
        builder.Property(u => u.IsLocked).HasDefaultValue(false);
        builder.Property(u => u.AccessFailedCount);
    }

    private void ConfigureRole(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).HasMaxLength(24);
    }

    private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
    {
        builder.ToTable("Trailer");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(2084);
        builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
    }

    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movie");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).IsRequired().HasMaxLength(256);
        builder.Property(m => m.Overview).HasMaxLength(4096);
        builder.Property(m => m.Tagline).HasMaxLength(512);
        builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
        builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
        builder.Property(m => m.PosterUrl).HasMaxLength(2084);
        builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
        builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
        builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
        builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
        builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
        builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

    }
}
