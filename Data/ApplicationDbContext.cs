using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicDating.Models.Entities;

namespace MusicDating.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Only needed when inheriting from IndentityDbContext
            // Call base functionality from the OnModelCreating method in the IndentityDbContext class.

            modelBuilder.Entity<GenreEnsemble>()
                .HasKey(bc => new { bc.GenreId, bc.EnsembleId });
            modelBuilder.Entity<GenreEnsemble>()
                .HasOne(bc => bc.Genre)
                .WithMany(b => b.GenreEnsembles)
                .HasForeignKey(bc => bc.GenreId);
            modelBuilder.Entity<GenreEnsemble>()
                .HasOne(bc => bc.Ensemble)
                .WithMany(c => c.GenreEnsembles)
                .HasForeignKey(bc => bc.EnsembleId);

            modelBuilder.Entity<UserInstrument>()
                .HasKey(bc => new { bc.Id, bc.InstrumentId });
            modelBuilder.Entity<UserInstrument>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.UserInstruments)
                .HasForeignKey(bc => bc.Id);
            modelBuilder.Entity<UserInstrument>()
                .HasOne(bc => bc.Instrument)
                .WithMany(c => c.UserInstruments)
                .HasForeignKey(bc => bc.InstrumentId);

            modelBuilder.Entity<UserInstrumentGenre>()
       .HasKey(bc => bc.UserInstrumentGenreId);
            modelBuilder.Entity<UserInstrumentGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(b => b.UserInstrumentGenres)
                .HasForeignKey(bc => bc.GenreId);
            modelBuilder.Entity<UserInstrumentGenre>()
                .HasOne(bc => bc.UserInstrument)
                .WithMany(c => c.UserInstrumentGenres)
                .HasForeignKey(bc => new { bc.Id, bc.InstrumentId });

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "1", UserName = "Kappa", LastName = "Kappa", DateCreated = new System.DateTime(2020, 12, 24) },
                new ApplicationUser { Id = "2", UserName = "Dummy", LastName = "Dummy", DateCreated = new System.DateTime(2020, 12, 24) }
            );
            // Add data - Instruments
            modelBuilder.Entity<Instrument>().HasData(
                new Instrument { InstrumentId = 1, Name = "Drums", },
                new Instrument { InstrumentId = 2, Name = "Guitar", },
                new Instrument { InstrumentId = 3, Name = "Bass", }
            );

            // Add data - userinstruments
            modelBuilder.Entity<UserInstrument>().HasData(
                new UserInstrument { Id = "1", InstrumentId = 1, Level = 5 },
                new UserInstrument { Id = "2", InstrumentId = 2, Level = 2 }
            );

            modelBuilder.Entity<Ensemble>().HasData(
            new Ensemble
            {
                EnsembleId = 1,
                EnsembleName = "U2",
                coverImg = "U2-picture",
                EnsembleDescription = "Band"
            }
        );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Rock" },
                new Genre { GenreId = 2, GenreName = "Pop" },
                new Genre { GenreId = 3, GenreName = "Classic" }
            );
            modelBuilder.Entity<GenreEnsemble>().HasData(
                new GenreEnsemble { GenreId = 1, EnsembleId = 1 },
                new GenreEnsemble { GenreId = 2, EnsembleId = 1 }
            );
            modelBuilder.Entity<UserInstrumentGenre>().HasData(
               new UserInstrumentGenre { UserInstrumentGenreId = 1, InstrumentId = 2, GenreId = 3, Id = "2" },
               new UserInstrumentGenre { UserInstrumentGenreId = 2, InstrumentId = 1, GenreId = 1, Id = "1" },
               new UserInstrumentGenre { UserInstrumentGenreId = 3, InstrumentId = 2, GenreId = 2, Id = "2" }
           );
        }

        // This means that EF (Entity Framework) will create a table called Instrument based
        // on our Instrument class.
        public DbSet<Instrument> Instruments { get; set; }

        // This means that EF (Entity Framework) will create a table called Instrument based
        // on our Instrument class.
        public DbSet<Agent> Agent { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Ensemble> Ensembles { get; set; }
        public DbSet<GenreEnsemble> GenreEnsembles { get; set; }
        public DbSet<UserInstrument> UserInstruments { get; set; }
        public DbSet<UserInstrumentGenre> UserInstrumentGenres { get; set; }
    }
}
