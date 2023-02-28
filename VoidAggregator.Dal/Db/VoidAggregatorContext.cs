using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoidAggregator.Dal.Entities;
using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Dal.Db
{
	public class VoidAggregatorContext : IdentityDbContext<ApplicationUser>
	{
		public VoidAggregatorContext(DbContextOptions<VoidAggregatorContext> options) : base(options)
		{ }

		public DbSet<Song> Songs { get; set; }
		public DbSet<Release> Releases { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Label> Labels { get; set; }
		public DbSet<AuthorSong> AuthorsSongs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Release>()
				.HasOne(r => r.Author)
				.WithMany(a => a.Releases)
				.HasForeignKey(r => r.AuthorId)
				.IsRequired(true);

			modelBuilder.Entity<Author>()
				.HasOne(a => a.Label)
				.WithMany(l => l.Authors)
				.HasForeignKey(a => a.LabelId)
				.IsRequired(false);

			modelBuilder.Entity<Song>()
				.HasOne(s => s.Release)
				.WithMany(r => r.Songs)
				.HasForeignKey(s => s.ReleaseId)
				.IsRequired(true);

			modelBuilder.Entity<AuthorSong>()
				.HasOne(@as => @as.Author)
				.WithMany(a => a.AuthorsSongs)
				.HasForeignKey(@as => @as.AuthorId)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<AuthorSong>()
				.HasOne(@as => @as.Song)
				.WithMany(s => s.AuthorsSongs)
				.HasForeignKey(@as => @as.SongId)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);
        }
	}
}
