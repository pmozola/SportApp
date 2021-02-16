using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Domain;

namespace SportApp.Infrastructure
{
    public class WeightAggregateConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Value).IsRequired();
        }
    }
}
