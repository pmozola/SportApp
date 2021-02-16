using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Domain;

namespace SportApp.Infrastructure
{
    public class ExerciseAggregateConfiguration : IEntityTypeConfiguration<Excercise>
    {
        public void Configure(EntityTypeBuilder<Excercise> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.OwnsOne(x => x.Url, buildAction: n =>
            {
                n.Property(y => y.Url).HasColumnName("video_url");
                n.Property(y => y.VideoService).HasColumnName("video_service");
            });
            builder.Property(x => x.ExerciseType)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
