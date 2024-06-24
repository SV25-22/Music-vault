using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Courses.Repositories.EntityFrameworkConfigurations;

public class IzvodiConfiguration : IEntityTypeConfiguration<Izvodi> {
    public void Configure(EntityTypeBuilder<Izvodi> builder) {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .IsRequired()
            .HasColumnType("integer");

        builder.Property(i => i.Uloga)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar");

        builder.HasOne(i => i.Izvodjac)
            .WithMany()
            .IsRequired();

        builder.HasOne(i => i.MuzickiSadrzaj)
            .WithMany()
            .IsRequired();
    }
}