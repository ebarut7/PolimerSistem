using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetraPolimerSistem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tetra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disTicaretler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IthalatFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IhracatFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonsimentoNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonteynirNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeyannameNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosyaNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunTonaj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaturaNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimatYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GirisYapanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatilabilirKisim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeslimYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdemeDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaliyetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disTicaretler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sevkiyatDetaylar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sofor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCKN = table.Column<int>(type: "int", nullable: false),
                    TelefonNumara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sevkiyatDetaylar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disTicaretMaliyetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisTicaretId = table.Column<int>(type: "int", nullable: false),
                    Kur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunTonaj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GumrukOran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GumrukVergisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DamgaVergisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LokalMasraf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimanMasraf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdinoBedel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GumrukKomisyon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nakliye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Demuraj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Diger = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunBedelDoviz = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TLMasraf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DovizMasraf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTLMaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamDovizMaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaliyetliBirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KarliBirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disTicaretMaliyetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_disTicaretMaliyetler_disTicaretler_DisTicaretId",
                        column: x => x.DisTicaretId,
                        principalTable: "disTicaretler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProformaNumara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiparisVerenFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiparisAlanFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SevkTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DovizCinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunTonaj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SevkDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SevkiyatDetayId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NakliyeTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaliyetTL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaliyetDoviz = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamDovizMaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTLMaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SevkiyatDetayId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_sevkiyatDetaylar_SevkiyatDetayId1",
                        column: x => x.SevkiyatDetayId1,
                        principalTable: "sevkiyatDetaylar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_disTicaretMaliyetler_DisTicaretId",
                table: "disTicaretMaliyetler",
                column: "DisTicaretId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_SevkiyatDetayId1",
                table: "orders",
                column: "SevkiyatDetayId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appRole");

            migrationBuilder.DropTable(
                name: "appUser");

            migrationBuilder.DropTable(
                name: "disTicaretMaliyetler");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "disTicaretler");

            migrationBuilder.DropTable(
                name: "sevkiyatDetaylar");
        }
    }
}
