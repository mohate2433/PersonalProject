using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Contente).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.DateModified).IsRequired();
            builder.Property(x => x.Views).IsRequired();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
