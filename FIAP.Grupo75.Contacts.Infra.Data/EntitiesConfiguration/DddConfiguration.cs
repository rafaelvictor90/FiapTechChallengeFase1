using FIAP.Grupo75.Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Grupo75.Contacts.Infra.Data.EntitiesConfiguration
{
    public class DddConfiguration : IEntityTypeConfiguration<Ddd>
    {
        public void Configure(EntityTypeBuilder<Ddd> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Code).HasMaxLength(2).IsRequired();
            builder.Property(d => d.RegionName).HasMaxLength(100).IsRequired();

            builder.HasMany(d => d.Contacts).WithOne(c => c.Ddd)
                .HasForeignKey(d => d.DddId);

            builder.HasData(
              new Ddd(1, "61", "Distrito Federal"), // -- Midwest
              new Ddd(2, "62", "Goias"),
              new Ddd(3, "64", "Goias"),
              new Ddd(4, "65", "Mato Grosso"),
              new Ddd(5, "66", "Mato Grosso"),
              new Ddd(6, "67", "Mato Grosso do Sul"),
              new Ddd(7, "82", "Alagoas"), // -- North East
              new Ddd(8, "71", "Bahia"),
              new Ddd(9, "73", "Bahia"),
              new Ddd(10, "74", "Bahia"),
              new Ddd(11, "75", "Bahia"),
              new Ddd(12, "77", "Bahia"),
              new Ddd(13, "85", "Ceara"),
              new Ddd(14, "88", "Ceara"),
              new Ddd(15, "98", "Maranhao"),
              new Ddd(16, "99", "Maranhao"),
              new Ddd(17, "83", "Paraiba"),
              new Ddd(18, "81", "Pernambuco"),
              new Ddd(19, "87", "Pernambuco"),
              new Ddd(20, "86", "Piaui"),
              new Ddd(21, "89", "Piaui"),
              new Ddd(22, "84", "Rio Grande do Norte"),
              new Ddd(23, "79", "Sergipe"),
              new Ddd(24, "68", "Acre"), // -- North
              new Ddd(25, "96", "Amapa"),
              new Ddd(26, "92", "Amazonas"),
              new Ddd(27, "97", "Amazonas"),
              new Ddd(28, "91", "Para"),
              new Ddd(29, "93", "Para"),
              new Ddd(30, "94", "Para"),
              new Ddd(31, "69", "Rondônia"),
              new Ddd(32, "95", "Roraima"),
              new Ddd(33, "63", "Tocantins"),
              new Ddd(34, "27", "Espirito Santo"), // -- Southeast
              new Ddd(35, "28", "Espirito Santo"),
              new Ddd(36, "31", "Minas Gerais"),
              new Ddd(37, "32", "Minas Gerais"),
              new Ddd(38, "33", "Minas Gerais"),
              new Ddd(39, "34", "Minas Gerais"),
              new Ddd(40, "35", "Minas Gerais"),
              new Ddd(41, "37", "Minas Gerais"),
              new Ddd(42, "38", "Minas Gerais"),
              new Ddd(43, "21", "Rio de Janeiro"),
              new Ddd(44, "22", "Rio de Janeiro"),
              new Ddd(45, "24", "Rio de Janeiro"),
              new Ddd(46, "11", "Sao Paulo"),
              new Ddd(47, "12", "Sao Paulo"),
              new Ddd(48, "13", "Sao Paulo"),
              new Ddd(49, "14", "Sao Paulo"),
              new Ddd(50, "15", "Sao Paulo"),
              new Ddd(51, "16", "Sao Paulo"),
              new Ddd(52, "17", "Sao Paulo"),
              new Ddd(53, "18", "Sao Paulo"),
              new Ddd(54, "19", "Sao Paulo"),
              new Ddd(55, "41", "Parana"), // -- South
              new Ddd(56, "42", "Parana"),
              new Ddd(57, "43", "Parana"),
              new Ddd(58, "44", "Parana"),
              new Ddd(59, "45", "Parana"),
              new Ddd(60, "46", "Parana"),
              new Ddd(61, "51", "Rio Grande do Sul"),
              new Ddd(62, "53", "Rio Grande do Sul"),
              new Ddd(63, "54", "Rio Grande do Sul"),
              new Ddd(64, "55", "Rio Grande do Sul"),
              new Ddd(65, "47", "Santa Catarina"),
              new Ddd(66, "48", "Santa Catarina"),
              new Ddd(67, "49", "Santa Catarina")
            );
        }
    }
}
