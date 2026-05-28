using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasySmart.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Умный дом и безопасность" },
                    { 2, "Смарт-освещение" },
                    { 3, "Роботы-пылесосы" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Xiaomi" },
                    { 2, "Aqara" },
                    { 3, "Philips Hue" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Article", "CategoryId", "Description", "Dimensions", "Image", "ManufacturerId", "Model", "Name", "Power", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "X-VAC-S10", 3, "Умный робот-пылесос с лазерной навигацией LDS и мощностью всасывания 4000 Па. Поддерживает влажную и сухую уборку, управляется через приложение Mi Home.", "350x350x94.5 mm", "images/products/xiaomi-s10.png", 1, "S10 (B106GL)", "Робот-пылесос Xiaomi Robot Vacuum S10", "45W", 18990.00m, 0 },
                    { 2, "AQ-HUB-M2", 1, "Главный шлюз для построения экосистемы умного дома. Поддерживает протоколы Zigbee 3.0, инфракрасный пульт (IR), Wi-Fi, Bluetooth и Ethernet подключение.", "100.5x100.5x30.7 mm", "images/products/aqara-m2.png", 2, "HM2-G01", "Центр умного дома Aqara Hub M2", "10W", 5490.00m, 0 },
                    { 3, "PH-BULB-E27", 2, "Смарт-лампа с цоколем E27. Поддерживает 16 миллионов цветов и синхронизацию с музыкой, фильмами или играми. Работает через Bluetooth и Hue Bridge.", "110x60 mm", "images/products/philips-e27.png", 3, "E27 Smart Bulb", "Умная светодиодная лампа Philips Hue White and Color Ambiance", "9W", 4190.00m, 0 },
                    { 4, "AQ-DOOR-SEN", 1, "Беспроводной датчик, определяющий состояние окон или дверей в реальном времени с отправкой пуш-уведомлений на смартфон через протокол Zigbee.", "41x22x11 mm", "images/products/aqara-door.png", 2, "MCCGQ11LM", "Датчик открытия дверей и окон Aqara Door and Window Sensor", "CR1632 Battery", 1290.00m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
