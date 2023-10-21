using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirCnC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReviewRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "HostReviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "GuestReviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f26b6c9-5301-42da-b074-a0bd40ca38c1", "AQAAAAIAAYagAAAAEF0VUsSUykKljJ2fxKAyZPwOB0JXEsFM+y6iXAvzZ1YItL2asYRrCdRrzLkxgoQ91Q==", "e21ad8d1-2347-48bf-8db9-49a0876bafc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "7832 Estell Lakes", "https://picsum.photos/640/480/?image=183", "Hudsonfort", "2b2403d5-b501-47b3-a07d-147a8a444a60", "Pink_Kuhlman@gmail.com", true, "Garland Hermann", "Suscipit libero ea repellendus. Qui consequatur totam sit sit esse quisquam illo modi. Quia consequatur tempora excepturi aspernatur iusto libero corrupti et maiores.", "PINK_KUHLMAN@GMAIL.COM", "PINK_KUHLMAN@GMAIL.COM", "AQAAAAIAAYagAAAAEClTvoMYmtWrcLk/ohcje2mwqZ2gRjyAoYFk7DP0AK4WFPaH4+kjn0P5RFZVxOYRlQ==", "595-816-8851 x9386", "b3999589-7d2f-4d41-be72-7ae1b83470b4", "Pink_Kuhlman@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "6853 Loma Lane", "https://picsum.photos/640/480/?image=224", "Laishabury", "94f36e41-e60f-4de0-b2d0-7ad854401332", "Liana.Schuppe@gmail.com", true, "Delmer Ritchie", "Corporis nam maiores enim rem dolor sunt. Exercitationem eum corporis quasi enim esse eum quaerat quia. Commodi deserunt quia consectetur sit nam consequatur ut aut in. Saepe iusto necessitatibus ut ut qui similique officiis aut a. Dicta nihil sequi.", "LIANA.SCHUPPE@GMAIL.COM", "LIANA.SCHUPPE@GMAIL.COM", "AQAAAAIAAYagAAAAEEzxWOLO0PCRCc/f6/78LwiGwRwDFdb3P5kfQRRN3sxWMxf03OZhpZv2JZRpihqu5A==", "522.214.6728 x01861", "139fffc3-1fbc-469e-abf1-c92875ce8d52", "Liana.Schuppe@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "23048 Floy Camp", "https://picsum.photos/640/480/?image=46", "West Eltabury", "102e6ea1-cf84-463d-b771-e7229d9e9721", "Lura.Mayer@hotmail.com", true, "Aglae Leannon", "Et in molestiae error consectetur harum officiis magni. Earum odio non libero. Expedita eius voluptatum distinctio.", "LURA.MAYER@HOTMAIL.COM", "LURA.MAYER@HOTMAIL.COM", "AQAAAAIAAYagAAAAEP5L7WHzgpQymHwg3Y3vpOLhClmOWrO0ootFFKPbY5LOSW19Rogd2NCVR5nwUuoSIw==", "678.736.7313 x6934", "d3d1a282-3de2-4c58-a3d2-a9590794b305", "Lura.Mayer@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "57151 Gutkowski Neck", "https://picsum.photos/640/480/?image=1044", "East Cristianfurt", "941c27cf-3f2f-4550-b0da-bebec9fe8607", "Nico_Tromp59@hotmail.com", true, "Harry Mosciski", "Quam et accusamus nemo. Modi et totam. Voluptatibus repudiandae eveniet. Similique dolores suscipit officia aliquid possimus assumenda fugiat rerum modi. Aliquam rem id et inventore ut laborum ex nostrum.", "NICO_TROMP59@HOTMAIL.COM", "NICO_TROMP59@HOTMAIL.COM", "AQAAAAIAAYagAAAAEFtKHCmv2B/Pl+nCXJfWhPstnv/hBrbWaA6i0PIqyhBPwRR0c2lMi6pw7xtl+DrpKw==", "524.327.5105 x7341", "31b41a53-d6de-497f-afdb-33366b1a6600", "Nico_Tromp59@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "90448 Trantow Plains", "https://picsum.photos/640/480/?image=556", "Earnestinebury", "fa9239d1-bee2-4462-9c7c-de881e3f9530", "Joana9@yahoo.com", true, "Lucinda Bashirian", "Eligendi quod repudiandae eveniet asperiores. Eum corporis qui qui voluptas id similique facere. Aliquam nobis velit quia quo qui voluptates voluptatum. Sunt facere quis dolorem eos quod assumenda praesentium.", "JOANA9@YAHOO.COM", "JOANA9@YAHOO.COM", "AQAAAAIAAYagAAAAEBRZqLQczEErHeiciceC8N2FhwDrK+MbgTDVvCioSxYbAiPHhQSGV3TK4z00wr8JeA==", "(424) 873-6738 x582", "a2e5aea7-9cb5-45c0-95ae-213f3d9e1725", "Joana9@yahoo.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "18940 Bridget Mills", "https://picsum.photos/640/480/?image=868", "Hanefurt", "f21335ed-ce0c-4d2c-974a-1d4e66565131", "Bernadine8@hotmail.com", true, "Flavie Greenholt", "Ea officiis ullam alias molestiae et dicta enim et labore. Vel quibusdam quia ea. Voluptas non quis quia praesentium magni voluptatum quas sed quia. Dolores velit quae corrupti rerum sapiente quis.", "BERNADINE8@HOTMAIL.COM", "BERNADINE8@HOTMAIL.COM", "AQAAAAIAAYagAAAAEIY+Myjqu13NVbjxAU92r3DlXSfBqbcIdk/cGM1NSLw2YlhfWWdYTYSRF1Wut2HA2w==", "1-713-536-8101 x471", "0dc8aa85-ad73-4502-b217-bdf00dac3565", "Bernadine8@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "134 Patsy Key", "https://picsum.photos/640/480/?image=848", "New Gardner", "796d9099-d108-4d03-8066-67cdb7d0af57", "Mose_Aufderhar21@gmail.com", true, "Hillard Schulist", "Velit rerum veritatis natus ex. Inventore aut vel occaecati voluptatem est. At quia error dolor delectus sit ut. Ad dolorem voluptas esse.", "MOSE_AUFDERHAR21@GMAIL.COM", "MOSE_AUFDERHAR21@GMAIL.COM", "AQAAAAIAAYagAAAAEP0KaqxCm4Ftg4zE6HJbOy7UqtVpdmkRhe15rfw1PGpSF7mIS3XnII7A/JHTGVgVTA==", "(201) 350-5109", "bb3a0151-b4a9-4ace-87d6-c97b7d569dc7", "Mose_Aufderhar21@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "19006 Gilberto Ways", "https://picsum.photos/640/480/?image=522", "Port Charlottemouth", "259d4530-e13f-41f9-8314-c1a0f51c594e", "Angelo39@hotmail.com", true, "Marjory O'Keefe", "Rerum dolore veniam. Earum ipsa et. Ipsa provident porro hic molestias dicta qui necessitatibus. Tempore sed et nemo dolorem in. Magni eaque praesentium error quibusdam voluptatem quae numquam. Quidem provident exercitationem.", "ANGELO39@HOTMAIL.COM", "ANGELO39@HOTMAIL.COM", "AQAAAAIAAYagAAAAEO5LQm3cFGx+3YtIKOvyf1jMpbTK+mlP6BZPfOZ+vztpfXi18EUeKGIQqSXBGiIlvg==", "853-696-1655", "8fdc5203-73d7-4fca-94d8-46943d7afaad", "Angelo39@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "2882 Gennaro Dale", "https://picsum.photos/640/480/?image=885", "Lindton", "dfaeb2db-fdcb-497a-a497-07ff5f87a6cb", "Dashawn14@gmail.com", true, "Conrad Nolan", "Molestias dolor et quibusdam voluptas similique temporibus voluptatem occaecati. Culpa est corporis officia amet assumenda animi est. In quia placeat libero sit. Voluptas aliquam quo asperiores deserunt dolor praesentium cumque ut. Pariatur nemo magni molestias.", "DASHAWN14@GMAIL.COM", "DASHAWN14@GMAIL.COM", "AQAAAAIAAYagAAAAEMWwlXRO55wQGO1UiwfANL9tMtzewp/JAACBEkqD9QoJNS5Lah4TSb2mXnlGSnDNlA==", "706-708-4803", "745c9ec9-8fcd-48cf-9776-156e314c6ae8", "Dashawn14@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "234 Dooley Hill", "https://picsum.photos/640/480/?image=53", "North Cletusbury", "73aa35f4-3d90-41ec-a0e8-d115dcad0438", "Skylar75@gmail.com", true, "Tyreek McGlynn", "Quas eos quas vero molestias at aut praesentium sunt. Aliquid illum sit et assumenda voluptas velit. Porro dolor culpa aut vel aspernatur est alias. Nostrum eos beatae temporibus illum eaque. Quo hic non aut voluptate aut aut.", "SKYLAR75@GMAIL.COM", "SKYLAR75@GMAIL.COM", "AQAAAAIAAYagAAAAEBsxlnCyNwJ1UIWnWm2FzUmMtbfB1Db2kMV3Ad7CiLnuhSgo1D9e6AsBa0P7zQLUsw==", "365-863-9329 x644", "057900df-4c14-4040-a404-517dd0348ae2", "Skylar75@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), 15.689400754577324, 10, "Est et harum saepe corrupti qui aliquid dolorem.", 1, 3, 50.274200115682419, 26, "Completed", 23.159017855309898, 89.122618725569637 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), 11.544472046500182, 3, "Quo qui consequuntur molestias.", 4, 3, 82.712281665588463, 29, "Completed", 22.287741814430799, 860.95503051681567 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), 12.290727560700438, 4, "Ea iusto et praesentium.", 5, 21.362671084034186, 6, 19.384519309087977, 117.12593120592516 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 15.117650829793204, 4, "Non sequi nam.", 5, 0, 33.655637547766119, 16, "Completed", 22.748319909487698, 239.79979602587761 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), 13.492541983967119, 6, "Ea labore impedit necessitatibus officia illum hic.", 1, 0, 30.10123339315804, 16, "Pending", 16.227928879571731, 240.42910461564512 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), 19.972540028377196, 7, "Labore sed corporis totam eos voluptatum in accusamus.", 5, 72.088120206672954, 12, "Completed", 24.072767216752666, 260.3096678651487 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), 16.593704763034438, "Sed ipsam saepe cum dolores autem et repudiandae quis.", 2, 5, 50.279469958922107, 30, "Completed", 20.541516007599167, 137.69416068847781 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), 20.238766598959181, 5, "Ducimus officiis nihil vel sapiente optio voluptatibus et.", 5, 3, 41.348860609343518, 6, 13.085439720004409, 405.46395180305524 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), 22.259043360977959, 3, "Incidunt qui ut id laudantium eum omnis.", 3, 1, 86.678603173050604, 11, 20.099330740673572, 302.39418362080335 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), 15.649403544765336, 9, "A omnis dolores et voluptatibus quidem eveniet consequuntur error.", 3, 2, 72.757009548124344, 14, 12.471532603350925, 682.93402208123541 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 12.717002679911282, 9, "Vel harum aliquam sapiente reprehenderit hic non nobis.", 4, 34.827693338543469, "Completed", 23.867775370299597, 175.89555140438475 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), 23.84497841128568, "Ipsa totam doloribus non aliquid et ducimus provident.", 2, 4, 87.808581048416428, 25, "Rejected", 11.541310648708397, 650.0463563989091 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), 19.816392495521136, 2, "Dignissimos minus sequi voluptates ut laboriosam.", 2, 83.311998121514279, 17, "Pending", 16.053513570892889, 369.11789855247116 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), 11.684541117823926, 5, "Nemo illo quisquam.", 1, 0, 77.323421695051195, 1, "Pending", 24.948571872716322, 732.54390824600102 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), 12.879084963435226, 7, "Voluptatem ducimus et pariatur perferendis rerum.", 1, 2, 96.114319169542142, 23, 19.663792062573883, 897.57174955188839 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), 24.443522192513331, 6, "In iure optio voluptatem suscipit mollitia similique consectetur nihil laudantium.", 3, 64.085064066040303, 20, "Completed", 13.136272199286349, 422.0901787880415 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), 14.063243033888099, 10, "Qui et autem maxime sed exercitationem.", 74.750957317040715, 14, "CancelledBeforeCheckIn", 15.578976009011292, 702.40083489626579 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), 21.513185155549422, 9, "Rerum suscipit eos nemo sapiente aut.", 33.772340919015797, 17, 12.013398582513101, 101.07126557609412 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), 21.986862739376505, 2, "Dignissimos commodi necessitatibus facere maxime dolores vel magni ad voluptatum.", 2, 0, 54.571779237921298, 3, "CheckedIn", 10.662976569519353, 250.93695626058104 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc), 11.190563437357472, 5, "Occaecati eos nulla nesciunt.", 62.947788826799638, 3, "Completed", 14.405412004595338, 88.54376426875244 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), 19.189732954888434, 3, "Nostrum facilis id.", 4, 0, 57.666996699173701, 6, "Completed", 17.538082004581, 555.73078525203277 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), 15.125302019100257, "Eum fugit vitae assumenda nihil ut.", 3, 3, 16.763179322847133, 23, "CancelledBeforeCheckIn", 20.332787119749042, 186.32670304447348 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), 23.750616154807226, 6, "Animi ipsum tenetur tenetur autem ipsa ut qui deserunt debitis.", 1, 1, 71.376630171920709, 1, "CancelledBeforeCheckIn", 22.314726842709906, 188.81860334135857 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), 12.434499454567847, 4, "Mollitia eos ipsa atque ut ut enim quia eveniet.", 3, 4, 25.764417409567145, 22, 10.977540919048689, 203.76296224058655 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), 19.897542190494264, 9, "Architecto cum culpa.", 1, 2, 77.053871370704755, 26, 20.373200360961782, 502.59397077568457 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Utc), 15.087458761171257, 7, "Architecto molestias quo nisi officiis consequuntur voluptas accusantium.", 4, 2, 59.164601345413494, 30, "Confirmed", 20.596343474611892, 94.848403581196635 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), 18.3532700974446, 10, "Nobis earum optio aut quia rerum veniam.", 4, 5, 51.999638601012407, 24, "CancelledAfterCheckIn", 24.691335000251811, 147.04388229972125 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), 18.724959660718561, 5, "Deleniti id pariatur nobis.", 3, 4, 14.736746315615679, 19, 16.658375259643808, 50.120081235978049 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 21.786283793960578, 9, "Quia laudantium cumque rem est eos ipsam.", 0, 87.670081012355567, 9, "CancelledAfterCheckIn", 13.508640394124592, 473.64532924986304 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 14.639507931910895, 8, "Itaque aut in iure perferendis quas quidem minima blanditiis.", 5, 4, 89.277784579557874, 16, "Completed", 14.859534123323856, 743.72131869169777 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), 15.287274116810458, 5, "Adipisci dolor ut deserunt modi ut dicta voluptatem.", 1, 5, 24.275490073171408, 20, "Pending", 12.516331962222999, 197.73203659123334 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 24.931676065322431, 10, "Dolores sed omnis nesciunt harum omnis ea.", 5, 4, 79.75918141466606, 2, "Pending", 14.185589434412565, 437.91317257306531 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), 14.305548378947268, "Repudiandae magnam rem laborum blanditiis quis.", 2, 1, 78.148133545755087, 29, "CheckedIn", 13.168255710496631, 574.51073890972953 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), 17.415902761338138, 8, "Est odit et sunt in.", 2, 49.553353368382254, 17, "Confirmed", 19.690650591065449, 235.31996682593262 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), 21.957561625100276, 8, "Quisquam accusantium atque.", 4, 5, 21.545294521109163, 28, "Completed", 12.063128740270521, 77.111279407589109 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), 10.785642710494777, 10, "Nihil voluptatibus voluptas sint quibusdam.", 2, 0, 31.424537940625111, 9, "CancelledBeforeCheckIn", 22.676108402463512, 127.73536493483363 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 16.763276718584176, "Eligendi corrupti illum provident qui sit odit nemo voluptatem amet.", 3, 32.701514373956371, 15, "CancelledAfterCheckIn", 11.50094499786568, 322.57785108205718 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), 13.931322136799455, 8, "Qui quas natus totam cum omnis ab voluptas vero ad.", 5, 1, 98.438543652231246, 13, 23.546452379979328, 1021.8632110390913 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23.193246240046406, 2, "Ut qui modi nobis doloremque neque.", 5, 2, 34.685980009530532, 12, "Completed", 16.720043929552091, 317.40113024584275 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), 12.925411555694367, 7, "Beatae ducimus maxime vel non atque.", 3, 3, 66.307432336684229, 16, "CancelledBeforeCheckIn", 14.551974995400318, 690.55170991793693 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 20.113600383891487, 5, "Esse necessitatibus earum sint voluptatibus nihil et fuga.", 1, 23.408464398578662, 10, "Completed", 12.638398292268903, 220.01971386478968 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), 19.449055701762756, 5, "Eveniet dolores sequi.", 1, 4, 60.116512078886458, 19, 16.458970590566373, 576.95663500230728 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), 18.107675309759841, 10, "Nostrum nihil ratione molestias non sapiente expedita.", 1, 4, 39.727772973630145, 7, 10.171096734004372, 346.10095583280537 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), 13.434099681512141, 5, "Corporis minima sunt rerum delectus sit odit corrupti.", 4, 5, 52.291552810606667, 26, "Pending", 20.233369282541997, 556.58299707012077 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), 20.451588504353545, 11, "Quae non architecto praesentium non et odit quasi sed quae.", 1, 3, 52.476817917794406, 24, 21.705497356503894, 461.97162920321267 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), 12.242410721760185, 9, "Cum excepturi qui.", 4, 3, 32.419848050934426, 5, 13.723426905311371, 285.32462203454696 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), 14.794672081704121, 6, "Quas voluptas excepturi repellat accusantium provident laboriosam est vel natus.", 2, 0, 91.33817840867151, 11, "Pending", 24.976781199111585, 131.10963168948723 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), 10.409515908737243, 11, "Sed facere reprehenderit.", 4, 3, 74.177613605060259, 22, 17.37672963368599, 695.38476798796557 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13.59973196839649, 7, "Et porro odit et ipsa modi.", 1, 2, 25.74447658902163, 21, "Completed", 19.691779492765505, 84.780464639205263 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), 20.765122184596844, 10, "Earum aut perspiciatis at dolorem.", 1, 1, 30.767528234615138, 13, 12.715089715401412, 64.247740134613395 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 23.167189142061503, 10, "Id qui sed ex asperiores consequatur sequi et.", 3, 4, 68.986702005223947, 29, 12.294332412634196, 587.35513759648722 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), 23.911160353914482, 10, "Error aut libero ipsam.", 3, 80.927516886133589, 16, "Completed", 20.745518759966984, 853.93184797521747 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 14.547986245826239, 7, "Rerum mollitia voluptas minus at eligendi qui corporis culpa.", 3, 1, 45.357011204227675, 12, "Confirmed", 20.345131629341388, 397.749207508989 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), 16.956084815252687, 6, "Commodi atque dolorum voluptatem.", 4, 2, 67.970154328029849, 5, "Completed", 21.889021968497673, 310.72572409586974 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), 19.988175277400305, 2, "Ut dolore delectus soluta vero laudantium dolore et.", 3, 3, 15.768688949554843, 12, "Pending", 15.408426464701421, 145.77742438898562 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Utc), 13.676549590206696, 4, "Quam expedita et ratione dolor praesentium saepe.", 5, 0, 45.87111458569305, 6, "Confirmed", 20.477767031754858, 217.63877496473376 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 14.473840635541823, 7, "Alias quisquam aliquid dignissimos cupiditate aut ipsum repudiandae praesentium magnam.", 5, 1, 65.599381757146858, 23, 24.724209378146679, 563.99310407086341 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), 17.117219978803234, 6, "Consequuntur et culpa nisi.", 5, 2, 20.999570635681749, 30, "Completed", 17.420734597476212, 97.536666483324694 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Utc), 16.143399225777941, 2, "Officiis repudiandae est ex similique iusto ad fuga nobis.", 4, 4, 55.6397308712491, 3, "Completed", 21.243458070864595, 148.66631903914075 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 20.532851691118999, 9, "Dolores architecto dolores fuga.", 1, 2, 84.280373410607538, 15, "Confirmed", 20.090769109653333, 462.02548785380998 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), 13.410214642882856, 10, "Dolor enim nostrum sed atque et molestiae qui.", 4, 4, 99.845802786210797, 11.273520247385095, 523.912748821322 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 21.150377908853287, 5, "Minima reiciendis consequuntur molestias.", 5, 0, 13.339588739624872, 22, "Confirmed", 19.393473254605773, 53.883439903083932 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 18.35639772805839, 5, "Sed impedit ut quia.", 28.854669000618198, 3, "Confirmed", 13.047241137375874, 60.258307866052462 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), 10.068669172682798, 7, "Veniam rem aut est quibusdam dolor.", 1, 36.777561732706673, "CancelledBeforeCheckIn", 24.283886666116153, 107.90767930421231 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), 21.292149333522254, "Repellendus iure qui deleniti voluptatibus.", 3, 0, 11.687250007707597, 16.283547324268305, 49.262946665498156 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), 22.786318552031897, 3, "Sed et id est aut repellat exercitationem porro aut dolore.", 3, 0, 32.964067447955152, 30, "CancelledAfterCheckIn", 18.271139924908404, 271.80593061262636 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), 17.847711377971187, 5, "Vitae error ut.", 2, 63.317500034451264, 26, 13.926853897133006, 348.36206544736052 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), 13.885654742034539, 3, "Nihil occaecati minima optio molestiae molestias facere illo provident.", 0, 25.452510199878233, 11, "Confirmed", 16.780780322903912, 81.571455464694921 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 11.986134609694584, 4, "Error maiores ex quo ipsam fugit id itaque.", 4, 3, 21.686403258947184, 17, "CheckedIn", 18.050573540767701, 73.40951466835665 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 13.860595253103202, 6, "Qui adipisci accusantium accusantium.", 4, 3, 79.88157971148263, 8, 23.9144832660348, 437.18297707655114 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 21.592733486452282, 6, "Voluptatem modi ea laboriosam consequatur veniam necessitatibus nihil.", 1, 30.088186779325952, 16, 19.191530097863456, 251.4015710395974 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), 23.476719948512262, 5, "Consequatur voluptas sint est voluptatum explicabo nihil.", 5, 70.989469275980611, 17, 14.477925532602626, 676.85986896494035 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), 13.849554900771578, 5, "Nam distinctio qui in deserunt dolorum est.", 3, 2, 96.970177483778684, 20, 15.632486355287458, 514.33292867495243 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), 18.548712546500965, 2, "Sed odit quibusdam vel non.", 5, 3, 41.660444290077322, 16, "Completed", 15.499853310962468, 450.65300875823664 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), 16.088195189806584, 6, "Voluptas et dolores quia tempora.", 4, 1, 77.423169850242928, 21, "Completed", 13.139891585977004, 261.49759632651239 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 13.507730900127875, 3, "Doloribus delectus error impedit sit tempore.", 4, 3, 42.050242339748969, 9, 12.386993545672174, 446.3971478432897 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), 22.300967068178792, 2, "Veniam distinctio nihil sit architecto molestiae voluptatum.", 3, 0, 90.900019424596252, 22, 14.782571983977576, 400.68361675054138 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), 14.639023045940768, 11, "Et officia voluptatem.", 1, 44.695440339873898, 27, 10.257217176566535, 427.15520328137239 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), 21.671053183345354, 2, "Quisquam corrupti magnam aperiam consequatur corrupti aliquid voluptatum.", 3, 1, 18.864209306181234, 24, "Rejected", 21.09593705748442, 155.95224607791715 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10.928353881524904, 9, "Nulla officia sed tenetur nesciunt.", 2, 68.433074298201447, 23.9687896330611, 240.19636640919035 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 15.123282907329871, "Dolores repudiandae id dolores atque consequuntur.", 3, 80.754935279086922, 27, "Completed", 18.434107342780877, 195.06726080828457 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), 21.933495139956463, 5, "Tempore voluptas debitis vitae et corrupti.", 1, 5, 73.609851207820753, 25, 21.724255249124663, 264.4873040125434 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 11.375785787464016, 9, "Architecto in provident quae dolorum nesciunt voluptas consequatur.", 21.916149157747, 22, 17.705220388891636, 226.32634859607865 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), 21.554349456377818, 8, "Est voluptatum autem.", 4, 1, 82.266518420635734, 9, "Pending", 12.295440073274296, 280.64934479155926 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), 14.113951997821239, 11, "Voluptas doloremque necessitatibus saepe quam inventore minima possimus.", 2, 0, 38.283390592352504, 10, "Rejected", 23.327937714454208, 75.725280304627944 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), 24.719386549967226, 11, "Qui laboriosam quis pariatur ab consequatur illo.", 5, 70.72372278450942, 29, "CancelledAfterCheckIn", 15.240228086966416, 252.13078299046191 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), 17.020214054373778, 6, "Doloremque est iste repellendus et assumenda temporibus nihil explicabo.", 3, 2, 79.89430030255042, 24, "CancelledBeforeCheckIn", 24.614923246469324, 281.31803820849439 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Utc), 19.328068598383503, 4, "Amet ea nam.", 3, 1, 48.109434166927862, 23.377214234178346, 379.47132200105682 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 16.324491648418906, 3, "Rerum iure tempora eum dignissimos.", 4, 3, 18.075959529991657, 6, 24.331622634841921, 76.808033343244148 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 24.828715735153946, 11, "Laborum ut ullam non voluptatem aut non.", 3, 1, 99.127020474760087, 30, 21.159900830656625, 145.11563704057068 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), 13.817634237927347, 9, "Velit consequatur qui natus pariatur ea incidunt eum.", 4, 27.301819382809626, 6, "Rejected", 11.950608958102141, 134.97552072726799 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), 21.0120410002794, 8, "Et quo qui sed dolorum nesciunt est rerum asperiores deleniti.", 1, 4, 11.513108908982112, 24.460689353462527, 56.985839262724042 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 17.067345378654338, "Enim quia numquam quia sunt veritatis.", 1, 65.459833958085028, 25, 20.475680308175725, 233.92252756108516 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), 21.13768536401107, 2, "Ut quia ut cum.", 2, 3, 88.222254017192128, 23, 15.546517208511112, 477.79547265848282 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), 15.594960028842985, 7, "Voluptates fuga alias voluptatem et est ut vel.", 2, 3, 88.144251582742868, 4, 12.658468081861065, 292.68618285893268 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), 17.89926230059055, 7, "Natus id laborum voluptate aut veritatis.", 5, 54.18688799459494, 20, "CheckedIn", 15.319208689599851, 575.08735093613973 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), 12.23212470944129, 6, "Velit quis doloremque et fugiat velit atque harum voluptatum.", 5, 1, 52.13448317545231, 19, "Completed", 18.69343213806674, 83.060040022960337 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), 14.548903267276215, 11, "Consequatur maxime minima veniam quis.", 5, 4, 70.068275695514359, 9, 14.364660210727454, 449.32321765108981 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 24.746591417649395, 3, "Repellendus ab consequatur quis sit ratione fugiat minus ut.", 5, 5, 29.410891790924389, 30, 13.217014689238807, 302.66163222520765 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), 11.383565460405618, 4, "Perspiciatis ab laborum in necessitatibus.", 5, 57.334732495001887, 17, 11.794735414814882, 367.18669584523184 });

            migrationBuilder.InsertData(
                table: "GuestReviews",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GuestId", "HostId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Rating" },
                values: new object[,]
                {
                    { 1, "Odit enim quia placeat.", new DateTime(2023, 8, 17, 22, 42, 48, 207, DateTimeKind.Local).AddTicks(3933), null, 10, 5, false, null, null, 3.0 },
                    { 2, "Omnis est aliquid non nostrum unde veniam ducimus.", new DateTime(2023, 6, 23, 6, 28, 48, 997, DateTimeKind.Local).AddTicks(9986), null, 4, 2, false, null, null, 5.0 },
                    { 3, "Architecto repellat in dolorum ab ex et ut sunt.", new DateTime(2023, 1, 19, 8, 11, 55, 343, DateTimeKind.Local).AddTicks(5472), null, 8, 1, false, null, null, 3.0 },
                    { 4, "Officiis fugit vitae quidem corrupti.", new DateTime(2023, 5, 6, 4, 41, 37, 42, DateTimeKind.Local).AddTicks(6473), null, 6, 3, false, null, null, 1.0 },
                    { 5, "Saepe necessitatibus nesciunt voluptatibus pariatur quo molestiae.", new DateTime(2023, 8, 15, 9, 34, 28, 777, DateTimeKind.Local).AddTicks(9840), null, 2, 4, false, null, null, 1.0 },
                    { 6, "Ea ipsum nihil deserunt animi vel.", new DateTime(2023, 6, 18, 9, 22, 50, 293, DateTimeKind.Local).AddTicks(3602), null, 2, 1, false, null, null, 4.0 },
                    { 7, "Rerum cumque eaque totam asperiores eaque est error sed qui.", new DateTime(2022, 11, 19, 15, 26, 33, 788, DateTimeKind.Local).AddTicks(3267), null, 4, 1, false, null, null, 5.0 },
                    { 8, "Maxime quo velit quia et quo quam omnis.", new DateTime(2022, 12, 26, 2, 3, 3, 530, DateTimeKind.Local).AddTicks(3699), null, 6, 5, false, null, null, 2.0 },
                    { 9, "Consequatur fugit id omnis explicabo quia temporibus rerum illo est.", new DateTime(2023, 4, 10, 17, 28, 34, 189, DateTimeKind.Local).AddTicks(3121), null, 6, 3, false, null, null, 2.0 },
                    { 10, "Qui et in asperiores sint.", new DateTime(2023, 3, 25, 6, 11, 8, 387, DateTimeKind.Local).AddTicks(6090), null, 11, 5, false, null, null, 5.0 },
                    { 11, "Sint voluptatem odit deserunt officia et reiciendis architecto.", new DateTime(2023, 4, 29, 11, 17, 35, 232, DateTimeKind.Local).AddTicks(6624), null, 11, 5, false, null, null, 4.0 },
                    { 12, "Nisi quisquam facere dolore molestiae atque dolore soluta inventore corporis.", new DateTime(2023, 2, 23, 14, 32, 8, 884, DateTimeKind.Local).AddTicks(3522), null, 4, 4, false, null, null, 3.0 },
                    { 13, "Fugit nam ut magnam ab optio velit laborum.", new DateTime(2022, 11, 11, 3, 24, 55, 707, DateTimeKind.Local).AddTicks(5699), null, 4, 4, false, null, null, 4.0 },
                    { 14, "Mollitia consectetur totam atque pariatur omnis et.", new DateTime(2023, 3, 17, 0, 59, 39, 160, DateTimeKind.Local).AddTicks(2136), null, 11, 3, false, null, null, 5.0 },
                    { 15, "Magni culpa at nihil enim necessitatibus consequatur autem.", new DateTime(2023, 6, 9, 1, 26, 41, 490, DateTimeKind.Local).AddTicks(7336), null, 9, 3, false, null, null, 2.0 },
                    { 16, "Quia quae sunt consequatur a aut explicabo in et autem.", new DateTime(2023, 9, 9, 10, 33, 1, 858, DateTimeKind.Local).AddTicks(807), null, 7, 1, false, null, null, 5.0 },
                    { 17, "Cupiditate ullam inventore similique sit laboriosam.", new DateTime(2023, 3, 4, 14, 18, 8, 436, DateTimeKind.Local).AddTicks(917), null, 4, 5, false, null, null, 3.0 },
                    { 18, "Cupiditate deserunt sit et ipsam quaerat commodi magnam possimus.", new DateTime(2023, 2, 19, 14, 54, 24, 330, DateTimeKind.Local).AddTicks(8218), null, 11, 5, false, null, null, 3.0 },
                    { 19, "Quae eos est ad.", new DateTime(2023, 5, 13, 0, 29, 13, 394, DateTimeKind.Local).AddTicks(950), null, 2, 1, false, null, null, 2.0 },
                    { 20, "Quod eos autem iste et magni numquam quibusdam recusandae.", new DateTime(2023, 6, 13, 10, 55, 6, 432, DateTimeKind.Local).AddTicks(1537), null, 4, 3, false, null, null, 2.0 },
                    { 21, "Qui eum ut nam voluptatem rerum.", new DateTime(2022, 11, 18, 9, 8, 37, 102, DateTimeKind.Local).AddTicks(6020), null, 9, 2, false, null, null, 4.0 },
                    { 22, "Iusto fugiat quo neque perferendis neque illo nam.", new DateTime(2023, 8, 11, 8, 18, 28, 171, DateTimeKind.Local).AddTicks(3603), null, 11, 5, false, null, null, 2.0 },
                    { 23, "Minima autem nulla pariatur aliquid ut.", new DateTime(2022, 12, 3, 23, 21, 19, 486, DateTimeKind.Local).AddTicks(4330), null, 2, 1, false, null, null, 5.0 },
                    { 24, "Consequatur quas assumenda ut vitae.", new DateTime(2023, 8, 8, 6, 29, 41, 299, DateTimeKind.Local).AddTicks(8566), null, 2, 3, false, null, null, 5.0 },
                    { 25, "Ut est commodi.", new DateTime(2023, 6, 3, 4, 47, 29, 605, DateTimeKind.Local).AddTicks(6946), null, 6, 4, false, null, null, 1.0 },
                    { 26, "Rerum eum at.", new DateTime(2023, 6, 14, 8, 2, 51, 804, DateTimeKind.Local).AddTicks(6536), null, 4, 2, false, null, null, 2.0 },
                    { 27, "Deserunt ab ea ipsum assumenda repellat ratione qui accusantium qui.", new DateTime(2023, 4, 7, 23, 58, 11, 805, DateTimeKind.Local).AddTicks(9671), null, 2, 1, false, null, null, 1.0 },
                    { 28, "Et non excepturi aut eum.", new DateTime(2023, 8, 14, 9, 26, 41, 580, DateTimeKind.Local).AddTicks(3394), null, 9, 4, false, null, null, 3.0 },
                    { 29, "Quos sit quibusdam fugit ut voluptatum excepturi.", new DateTime(2023, 1, 13, 2, 46, 42, 961, DateTimeKind.Local).AddTicks(8720), null, 9, 3, false, null, null, 4.0 },
                    { 30, "Aliquam impedit consequuntur blanditiis quia aut commodi qui.", new DateTime(2023, 8, 9, 17, 59, 59, 546, DateTimeKind.Local).AddTicks(891), null, 7, 1, false, null, null, 1.0 },
                    { 31, "Ut ut et quo quo voluptatem.", new DateTime(2022, 12, 15, 9, 19, 31, 746, DateTimeKind.Local).AddTicks(6639), null, 4, 4, false, null, null, 3.0 },
                    { 32, "Odit natus et quibusdam laboriosam praesentium doloremque ex quos illum.", new DateTime(2023, 3, 25, 14, 0, 23, 646, DateTimeKind.Local).AddTicks(5195), null, 3, 2, false, null, null, 2.0 },
                    { 33, "Eius et aperiam.", new DateTime(2022, 12, 17, 6, 32, 50, 895, DateTimeKind.Local).AddTicks(2297), null, 6, 3, false, null, null, 5.0 },
                    { 34, "Quo qui iste sint.", new DateTime(2023, 9, 26, 17, 59, 12, 711, DateTimeKind.Local).AddTicks(3947), null, 9, 3, false, null, null, 1.0 },
                    { 35, "Fuga iusto vel culpa voluptatem non debitis nisi illo.", new DateTime(2023, 9, 8, 9, 17, 0, 605, DateTimeKind.Local).AddTicks(3377), null, 5, 2, false, null, null, 2.0 },
                    { 36, "Nihil necessitatibus quo asperiores.", new DateTime(2023, 10, 15, 1, 16, 6, 725, DateTimeKind.Local).AddTicks(3956), null, 10, 5, false, null, null, 3.0 },
                    { 37, "Accusamus tempora recusandae distinctio praesentium natus dolor hic.", new DateTime(2023, 3, 15, 23, 38, 31, 664, DateTimeKind.Local).AddTicks(3199), null, 4, 2, false, null, null, 2.0 },
                    { 38, "Qui libero facere.", new DateTime(2022, 11, 23, 7, 4, 11, 504, DateTimeKind.Local).AddTicks(9807), null, 2, 3, false, null, null, 1.0 },
                    { 39, "Et distinctio rerum et voluptatibus molestiae labore illo possimus rerum.", new DateTime(2022, 10, 27, 12, 54, 30, 145, DateTimeKind.Local).AddTicks(3514), null, 9, 2, false, null, null, 1.0 },
                    { 40, "In animi ut est vero quidem eos quam et rerum.", new DateTime(2023, 5, 21, 5, 53, 50, 836, DateTimeKind.Local).AddTicks(1315), null, 2, 4, false, null, null, 3.0 },
                    { 41, "Tempora et suscipit rerum in quo.", new DateTime(2023, 6, 6, 4, 36, 48, 139, DateTimeKind.Local).AddTicks(2272), null, 2, 5, false, null, null, 2.0 },
                    { 42, "Delectus cum et omnis odio ut ducimus sint sit sit.", new DateTime(2023, 9, 5, 0, 5, 26, 833, DateTimeKind.Local).AddTicks(3616), null, 3, 1, false, null, null, 5.0 },
                    { 43, "Esse rem architecto sint vel.", new DateTime(2023, 9, 21, 16, 24, 48, 745, DateTimeKind.Local).AddTicks(7671), null, 7, 2, false, null, null, 1.0 },
                    { 44, "Quos voluptas quia alias hic.", new DateTime(2023, 7, 28, 23, 45, 11, 284, DateTimeKind.Local).AddTicks(1741), null, 9, 5, false, null, null, 2.0 },
                    { 45, "Corrupti rerum velit voluptatibus velit omnis modi repellat.", new DateTime(2022, 12, 5, 7, 11, 39, 64, DateTimeKind.Local).AddTicks(6697), null, 9, 3, false, null, null, 3.0 },
                    { 46, "Et voluptatem tempore quia quisquam ab.", new DateTime(2023, 3, 30, 10, 34, 47, 859, DateTimeKind.Local).AddTicks(7519), null, 2, 5, false, null, null, 5.0 },
                    { 47, "Officiis consequatur architecto et recusandae illo voluptate vel omnis est.", new DateTime(2022, 11, 19, 12, 31, 54, 230, DateTimeKind.Local).AddTicks(7576), null, 7, 5, false, null, null, 1.0 },
                    { 48, "Est et quis numquam illo eos enim est.", new DateTime(2023, 4, 7, 20, 56, 17, 64, DateTimeKind.Local).AddTicks(6200), null, 2, 5, false, null, null, 5.0 },
                    { 49, "Dolorem libero sequi et.", new DateTime(2023, 9, 13, 3, 10, 0, 533, DateTimeKind.Local).AddTicks(116), null, 8, 5, false, null, null, 5.0 },
                    { 50, "Sit reiciendis fugiat.", new DateTime(2022, 12, 21, 13, 17, 25, 443, DateTimeKind.Local).AddTicks(3928), null, 4, 4, false, null, null, 2.0 },
                    { 51, "Quia minima ex rerum ipsa.", new DateTime(2022, 11, 28, 0, 10, 5, 921, DateTimeKind.Local).AddTicks(1846), null, 2, 1, false, null, null, 5.0 },
                    { 52, "Placeat pariatur dolore.", new DateTime(2022, 11, 16, 3, 9, 33, 626, DateTimeKind.Local).AddTicks(5645), null, 3, 4, false, null, null, 2.0 },
                    { 53, "Nobis quia quia iusto vel cupiditate molestiae non rerum.", new DateTime(2023, 2, 1, 4, 30, 55, 519, DateTimeKind.Local).AddTicks(9570), null, 4, 2, false, null, null, 1.0 },
                    { 54, "Hic dolorem iste officia dolores debitis mollitia ut.", new DateTime(2022, 12, 16, 23, 53, 57, 949, DateTimeKind.Local).AddTicks(1757), null, 3, 2, false, null, null, 3.0 },
                    { 55, "Ab tempore qui.", new DateTime(2022, 12, 2, 13, 4, 29, 177, DateTimeKind.Local).AddTicks(7598), null, 7, 1, false, null, null, 5.0 },
                    { 56, "Voluptatem dolor tenetur vero quam.", new DateTime(2023, 8, 12, 14, 35, 8, 150, DateTimeKind.Local).AddTicks(8471), null, 11, 4, false, null, null, 3.0 },
                    { 57, "Aperiam voluptatibus placeat.", new DateTime(2023, 6, 20, 2, 21, 5, 608, DateTimeKind.Local).AddTicks(8538), null, 6, 4, false, null, null, 3.0 },
                    { 58, "Deleniti porro ratione voluptate impedit sit ut aut aut eum.", new DateTime(2023, 4, 18, 3, 58, 50, 612, DateTimeKind.Local).AddTicks(8470), null, 5, 3, false, null, null, 4.0 },
                    { 59, "Facere deleniti perspiciatis perspiciatis exercitationem eos corporis.", new DateTime(2022, 11, 8, 18, 51, 24, 103, DateTimeKind.Local).AddTicks(5552), null, 8, 2, false, null, null, 5.0 },
                    { 60, "Molestiae et reprehenderit voluptatem ratione voluptatem.", new DateTime(2023, 10, 7, 7, 23, 23, 36, DateTimeKind.Local).AddTicks(3137), null, 3, 3, false, null, null, 1.0 },
                    { 61, "Quasi minima consequuntur sit dolor et quia rerum quia.", new DateTime(2023, 1, 31, 5, 28, 57, 547, DateTimeKind.Local).AddTicks(4660), null, 10, 3, false, null, null, 2.0 },
                    { 62, "Neque nostrum doloribus aut ipsam totam impedit.", new DateTime(2023, 3, 21, 0, 5, 7, 321, DateTimeKind.Local).AddTicks(7213), null, 9, 1, false, null, null, 2.0 },
                    { 63, "Vel necessitatibus aut tempore consequatur repudiandae.", new DateTime(2023, 1, 25, 5, 4, 33, 389, DateTimeKind.Local).AddTicks(7536), null, 9, 3, false, null, null, 4.0 },
                    { 64, "Non et ea molestiae qui voluptas aliquam ea.", new DateTime(2023, 1, 13, 14, 31, 48, 399, DateTimeKind.Local).AddTicks(5731), null, 5, 5, false, null, null, 2.0 },
                    { 65, "Odit labore ipsa.", new DateTime(2023, 5, 17, 8, 21, 0, 726, DateTimeKind.Local).AddTicks(9665), null, 7, 1, false, null, null, 1.0 },
                    { 66, "Praesentium id autem praesentium minus id ut qui itaque voluptas.", new DateTime(2022, 11, 16, 5, 9, 14, 498, DateTimeKind.Local).AddTicks(2038), null, 10, 2, false, null, null, 5.0 },
                    { 67, "Maiores non incidunt et qui molestiae ut est.", new DateTime(2022, 12, 25, 21, 34, 24, 188, DateTimeKind.Local).AddTicks(4726), null, 7, 5, false, null, null, 1.0 },
                    { 68, "Reprehenderit repudiandae vel natus ut non sed distinctio.", new DateTime(2023, 8, 16, 9, 42, 6, 845, DateTimeKind.Local).AddTicks(9950), null, 8, 2, false, null, null, 1.0 },
                    { 69, "Qui voluptas illo consequatur aperiam.", new DateTime(2023, 9, 22, 23, 38, 1, 54, DateTimeKind.Local).AddTicks(2217), null, 3, 4, false, null, null, 4.0 },
                    { 70, "Qui quod quia sequi omnis est nam incidunt adipisci.", new DateTime(2023, 9, 6, 2, 22, 4, 716, DateTimeKind.Local).AddTicks(2120), null, 3, 3, false, null, null, 5.0 },
                    { 71, "Totam et qui placeat perspiciatis in vel eos sit voluptatem.", new DateTime(2022, 12, 15, 13, 28, 11, 740, DateTimeKind.Local).AddTicks(3778), null, 10, 2, false, null, null, 5.0 },
                    { 72, "Rerum totam harum qui aut et necessitatibus ratione ab dolorem.", new DateTime(2023, 3, 5, 3, 18, 56, 912, DateTimeKind.Local).AddTicks(8307), null, 3, 3, false, null, null, 5.0 },
                    { 73, "Voluptatum qui nesciunt et.", new DateTime(2023, 8, 30, 18, 47, 15, 960, DateTimeKind.Local).AddTicks(5484), null, 9, 3, false, null, null, 3.0 },
                    { 74, "Quam consectetur quam consequatur nesciunt.", new DateTime(2023, 9, 29, 22, 50, 36, 453, DateTimeKind.Local).AddTicks(66), null, 11, 2, false, null, null, 1.0 },
                    { 75, "In facere et eius qui sit nobis reprehenderit.", new DateTime(2023, 1, 4, 12, 44, 32, 365, DateTimeKind.Local).AddTicks(3021), null, 8, 5, false, null, null, 2.0 },
                    { 76, "Itaque perferendis quo cum eveniet qui unde et.", new DateTime(2023, 1, 4, 19, 7, 51, 469, DateTimeKind.Local).AddTicks(8749), null, 3, 4, false, null, null, 2.0 },
                    { 77, "Natus magnam ut eum sed qui.", new DateTime(2023, 9, 22, 15, 40, 33, 727, DateTimeKind.Local).AddTicks(2430), null, 9, 1, false, null, null, 1.0 },
                    { 78, "Rerum similique qui dolorem molestiae molestiae deserunt doloribus illum.", new DateTime(2023, 7, 15, 1, 35, 3, 662, DateTimeKind.Local).AddTicks(5789), null, 5, 1, false, null, null, 1.0 },
                    { 79, "Repellendus consectetur at ea fugiat aut tempore sapiente et labore.", new DateTime(2022, 12, 30, 6, 18, 24, 715, DateTimeKind.Local).AddTicks(9361), null, 10, 4, false, null, null, 4.0 },
                    { 80, "Excepturi doloremque nobis tempora voluptas animi.", new DateTime(2023, 8, 28, 23, 2, 25, 893, DateTimeKind.Local).AddTicks(9315), null, 5, 1, false, null, null, 1.0 },
                    { 81, "Atque nihil nulla corrupti illum.", new DateTime(2023, 7, 7, 3, 10, 34, 266, DateTimeKind.Local).AddTicks(8808), null, 7, 2, false, null, null, 4.0 },
                    { 82, "Voluptatem accusantium libero enim quis ab reiciendis asperiores exercitationem.", new DateTime(2023, 2, 19, 13, 17, 11, 830, DateTimeKind.Local).AddTicks(3421), null, 3, 4, false, null, null, 3.0 },
                    { 83, "Quasi et pariatur molestiae qui ea molestiae magnam.", new DateTime(2023, 6, 18, 19, 57, 15, 368, DateTimeKind.Local).AddTicks(3731), null, 2, 4, false, null, null, 1.0 },
                    { 84, "Esse quia officia ipsa.", new DateTime(2023, 4, 18, 1, 52, 6, 681, DateTimeKind.Local).AddTicks(580), null, 5, 4, false, null, null, 4.0 },
                    { 85, "Necessitatibus quis nam.", new DateTime(2023, 3, 1, 13, 59, 18, 869, DateTimeKind.Local).AddTicks(3634), null, 2, 2, false, null, null, 5.0 },
                    { 86, "Vel autem a voluptatibus magni ipsa quas ipsa.", new DateTime(2023, 8, 31, 0, 22, 49, 586, DateTimeKind.Local).AddTicks(875), null, 9, 5, false, null, null, 1.0 },
                    { 87, "Et quo eaque facere totam omnis asperiores et.", new DateTime(2023, 1, 7, 20, 29, 48, 778, DateTimeKind.Local).AddTicks(8228), null, 7, 5, false, null, null, 2.0 },
                    { 88, "Autem qui libero eius commodi id.", new DateTime(2023, 4, 21, 3, 37, 47, 392, DateTimeKind.Local).AddTicks(7002), null, 3, 1, false, null, null, 3.0 },
                    { 89, "Perspiciatis dignissimos voluptas doloremque ullam ex nemo est.", new DateTime(2023, 5, 18, 7, 32, 27, 514, DateTimeKind.Local).AddTicks(2787), null, 11, 1, false, null, null, 2.0 },
                    { 90, "Maiores earum possimus sint dolorem.", new DateTime(2023, 1, 16, 7, 51, 7, 144, DateTimeKind.Local).AddTicks(960), null, 11, 5, false, null, null, 3.0 },
                    { 91, "Dicta qui ducimus odit fugit incidunt vel necessitatibus in.", new DateTime(2022, 12, 15, 5, 5, 52, 910, DateTimeKind.Local).AddTicks(7568), null, 6, 5, false, null, null, 2.0 },
                    { 92, "Labore enim sapiente optio qui.", new DateTime(2023, 4, 2, 23, 36, 17, 129, DateTimeKind.Local).AddTicks(2490), null, 8, 2, false, null, null, 4.0 },
                    { 93, "Consequatur saepe nemo voluptate.", new DateTime(2023, 9, 6, 23, 57, 13, 761, DateTimeKind.Local).AddTicks(6217), null, 10, 2, false, null, null, 1.0 },
                    { 94, "Sit aut nemo hic ut sint consequuntur.", new DateTime(2023, 7, 18, 23, 22, 37, 458, DateTimeKind.Local).AddTicks(7499), null, 6, 5, false, null, null, 4.0 },
                    { 95, "Non quos aliquam et commodi placeat quia.", new DateTime(2023, 8, 21, 0, 46, 25, 387, DateTimeKind.Local).AddTicks(248), null, 8, 1, false, null, null, 1.0 },
                    { 96, "Libero eveniet tempore est perferendis expedita aperiam deleniti doloribus perferendis.", new DateTime(2023, 6, 9, 23, 59, 0, 58, DateTimeKind.Local).AddTicks(5489), null, 2, 4, false, null, null, 1.0 },
                    { 97, "Eveniet aut atque sequi.", new DateTime(2023, 6, 3, 12, 50, 30, 99, DateTimeKind.Local).AddTicks(3614), null, 11, 1, false, null, null, 2.0 },
                    { 98, "Maiores magnam est eaque impedit dignissimos.", new DateTime(2023, 6, 15, 22, 31, 14, 4, DateTimeKind.Local).AddTicks(3611), null, 5, 5, false, null, null, 5.0 },
                    { 99, "Et est enim.", new DateTime(2023, 1, 9, 20, 52, 42, 798, DateTimeKind.Local).AddTicks(2333), null, 10, 3, false, null, null, 2.0 },
                    { 100, "Praesentium corrupti laborum reprehenderit autem culpa delectus molestiae.", new DateTime(2023, 10, 11, 21, 34, 35, 974, DateTimeKind.Local).AddTicks(7060), null, 5, 5, false, null, null, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "HostReviews",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GuestId", "HostId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Rating" },
                values: new object[,]
                {
                    { 1, "Placeat beatae et eligendi sint est.", new DateTime(2023, 9, 29, 20, 35, 14, 951, DateTimeKind.Local).AddTicks(2032), null, 10, 3, false, null, null, 2.0 },
                    { 2, "Laudantium ut et occaecati nam facilis.", new DateTime(2023, 9, 3, 13, 35, 33, 554, DateTimeKind.Local).AddTicks(1734), null, 8, 2, false, null, null, 5.0 },
                    { 3, "Omnis ducimus deleniti.", new DateTime(2022, 11, 3, 5, 6, 48, 596, DateTimeKind.Local).AddTicks(2613), null, 10, 5, false, null, null, 2.0 },
                    { 4, "Eveniet aut ut deserunt ipsam quia aut natus quo.", new DateTime(2023, 1, 17, 2, 36, 6, 225, DateTimeKind.Local).AddTicks(1611), null, 3, 4, false, null, null, 4.0 },
                    { 5, "Ut qui alias ut unde.", new DateTime(2023, 3, 2, 23, 38, 33, 471, DateTimeKind.Local).AddTicks(6913), null, 10, 2, false, null, null, 1.0 },
                    { 6, "Explicabo est optio.", new DateTime(2023, 6, 24, 3, 22, 23, 643, DateTimeKind.Local).AddTicks(312), null, 10, 1, false, null, null, 4.0 },
                    { 7, "Doloribus quis facilis saepe est amet et.", new DateTime(2023, 3, 8, 18, 53, 51, 726, DateTimeKind.Local).AddTicks(6536), null, 6, 3, false, null, null, 3.0 },
                    { 8, "Illum vero expedita corporis ut sit cum vitae.", new DateTime(2023, 1, 3, 4, 29, 45, 311, DateTimeKind.Local).AddTicks(2546), null, 8, 5, false, null, null, 4.0 },
                    { 9, "Ad optio assumenda quaerat voluptatem ut et deserunt neque soluta.", new DateTime(2022, 11, 5, 22, 34, 35, 578, DateTimeKind.Local).AddTicks(8935), null, 9, 5, false, null, null, 1.0 },
                    { 10, "Est reiciendis nihil.", new DateTime(2023, 2, 3, 20, 48, 10, 792, DateTimeKind.Local).AddTicks(6972), null, 9, 5, false, null, null, 2.0 },
                    { 11, "Dicta tempora et et accusantium sed facilis soluta vitae.", new DateTime(2023, 4, 21, 19, 43, 30, 400, DateTimeKind.Local).AddTicks(6086), null, 9, 3, false, null, null, 1.0 },
                    { 12, "In voluptatem sit nisi vero quasi alias.", new DateTime(2023, 1, 23, 22, 31, 29, 93, DateTimeKind.Local).AddTicks(1608), null, 3, 4, false, null, null, 1.0 },
                    { 13, "A harum iste neque ratione temporibus ut accusamus.", new DateTime(2023, 8, 5, 21, 49, 45, 66, DateTimeKind.Local).AddTicks(6822), null, 6, 4, false, null, null, 4.0 },
                    { 14, "Incidunt eius quis perferendis et suscipit eligendi similique.", new DateTime(2023, 1, 26, 11, 27, 56, 872, DateTimeKind.Local).AddTicks(5404), null, 10, 4, false, null, null, 1.0 },
                    { 15, "Facere nulla vel iusto maiores quas.", new DateTime(2023, 4, 15, 12, 12, 29, 850, DateTimeKind.Local).AddTicks(9468), null, 11, 5, false, null, null, 3.0 },
                    { 16, "Impedit quos et dolorum.", new DateTime(2023, 1, 12, 3, 56, 52, 42, DateTimeKind.Local).AddTicks(9074), null, 5, 1, false, null, null, 1.0 },
                    { 17, "Itaque qui odit.", new DateTime(2022, 10, 26, 19, 11, 35, 764, DateTimeKind.Local).AddTicks(5451), null, 5, 4, false, null, null, 1.0 },
                    { 18, "Sit quis consequatur ut ea reiciendis impedit.", new DateTime(2022, 11, 27, 9, 33, 46, 286, DateTimeKind.Local).AddTicks(8392), null, 10, 4, false, null, null, 5.0 },
                    { 19, "Laudantium in ut qui fugiat voluptatem.", new DateTime(2023, 6, 21, 1, 22, 49, 397, DateTimeKind.Local).AddTicks(5655), null, 10, 3, false, null, null, 2.0 },
                    { 20, "Ut dolores dolore ab dolor at quia.", new DateTime(2023, 4, 8, 4, 17, 31, 619, DateTimeKind.Local).AddTicks(8891), null, 7, 3, false, null, null, 4.0 },
                    { 21, "Expedita sed saepe.", new DateTime(2023, 7, 1, 2, 29, 47, 249, DateTimeKind.Local).AddTicks(2680), null, 11, 2, false, null, null, 1.0 },
                    { 22, "Odio sunt eum voluptatem repudiandae incidunt vel illo distinctio.", new DateTime(2023, 3, 18, 17, 59, 28, 221, DateTimeKind.Local).AddTicks(6103), null, 11, 1, false, null, null, 3.0 },
                    { 23, "Ex ex et et.", new DateTime(2022, 12, 11, 12, 22, 12, 444, DateTimeKind.Local).AddTicks(770), null, 6, 2, false, null, null, 4.0 },
                    { 24, "Eos quis occaecati qui quam hic ut inventore porro sit.", new DateTime(2023, 5, 6, 16, 52, 29, 685, DateTimeKind.Local).AddTicks(7974), null, 4, 4, false, null, null, 4.0 },
                    { 25, "Vero nobis vel minima.", new DateTime(2023, 10, 7, 3, 35, 55, 799, DateTimeKind.Local).AddTicks(9355), null, 4, 4, false, null, null, 1.0 },
                    { 26, "Earum dolores corporis ducimus.", new DateTime(2023, 3, 20, 20, 51, 4, 766, DateTimeKind.Local).AddTicks(7753), null, 10, 5, false, null, null, 2.0 },
                    { 27, "Sapiente in officiis aut quidem sunt.", new DateTime(2023, 6, 30, 1, 39, 14, 450, DateTimeKind.Local).AddTicks(9466), null, 7, 1, false, null, null, 3.0 },
                    { 28, "Architecto velit ad quia aut magnam id voluptatem atque.", new DateTime(2022, 10, 21, 2, 24, 54, 535, DateTimeKind.Local).AddTicks(4210), null, 5, 1, false, null, null, 2.0 },
                    { 29, "Natus sint quis.", new DateTime(2023, 5, 24, 14, 17, 30, 851, DateTimeKind.Local).AddTicks(8755), null, 9, 4, false, null, null, 5.0 },
                    { 30, "Magnam assumenda eius rerum quia.", new DateTime(2023, 3, 5, 9, 33, 30, 811, DateTimeKind.Local).AddTicks(9543), null, 2, 5, false, null, null, 5.0 },
                    { 31, "Rem ut animi suscipit non pariatur eligendi praesentium nihil numquam.", new DateTime(2022, 12, 6, 0, 23, 31, 358, DateTimeKind.Local).AddTicks(4340), null, 10, 4, false, null, null, 1.0 },
                    { 32, "Consequatur unde id eius fugiat nihil nemo.", new DateTime(2023, 1, 4, 5, 0, 4, 346, DateTimeKind.Local).AddTicks(1822), null, 6, 1, false, null, null, 1.0 },
                    { 33, "Eligendi veniam qui at corporis alias corrupti quo mollitia.", new DateTime(2022, 11, 16, 14, 34, 36, 840, DateTimeKind.Local).AddTicks(718), null, 9, 2, false, null, null, 1.0 },
                    { 34, "Iusto maxime quo non autem facere.", new DateTime(2023, 8, 23, 2, 30, 21, 586, DateTimeKind.Local).AddTicks(7851), null, 2, 3, false, null, null, 1.0 },
                    { 35, "Et quae ut ipsam ipsa est omnis id incidunt vel.", new DateTime(2023, 2, 6, 1, 49, 8, 556, DateTimeKind.Local).AddTicks(7485), null, 5, 3, false, null, null, 4.0 },
                    { 36, "Beatae laudantium est aliquam excepturi nesciunt id.", new DateTime(2023, 7, 15, 17, 33, 59, 751, DateTimeKind.Local).AddTicks(3030), null, 3, 3, false, null, null, 5.0 },
                    { 37, "Voluptatem quasi sit quae ipsum.", new DateTime(2022, 12, 27, 23, 2, 11, 16, DateTimeKind.Local).AddTicks(945), null, 10, 5, false, null, null, 5.0 },
                    { 38, "Ea qui quisquam sequi non similique dolor nihil.", new DateTime(2023, 9, 29, 7, 5, 7, 975, DateTimeKind.Local).AddTicks(7809), null, 10, 2, false, null, null, 1.0 },
                    { 39, "Maxime molestiae architecto molestias enim recusandae voluptas soluta mollitia.", new DateTime(2023, 3, 6, 22, 20, 47, 160, DateTimeKind.Local).AddTicks(1411), null, 3, 3, false, null, null, 1.0 },
                    { 40, "Earum aliquid repudiandae distinctio.", new DateTime(2023, 6, 18, 13, 17, 46, 868, DateTimeKind.Local).AddTicks(9133), null, 4, 2, false, null, null, 1.0 },
                    { 41, "Perferendis sit consequatur soluta reiciendis assumenda.", new DateTime(2023, 9, 27, 2, 16, 21, 227, DateTimeKind.Local).AddTicks(2846), null, 3, 4, false, null, null, 1.0 },
                    { 42, "Consequatur eos nesciunt incidunt velit velit ea.", new DateTime(2022, 12, 10, 23, 56, 12, 17, DateTimeKind.Local).AddTicks(3780), null, 8, 2, false, null, null, 1.0 },
                    { 43, "Ut animi nemo.", new DateTime(2022, 12, 27, 23, 17, 4, 218, DateTimeKind.Local).AddTicks(2835), null, 8, 5, false, null, null, 2.0 },
                    { 44, "Similique sed ut alias fugit in eum nulla dolor culpa.", new DateTime(2023, 2, 14, 23, 11, 59, 98, DateTimeKind.Local).AddTicks(6552), null, 11, 4, false, null, null, 2.0 },
                    { 45, "Nemo cumque voluptates laboriosam deserunt architecto dicta omnis asperiores.", new DateTime(2023, 1, 28, 12, 1, 41, 254, DateTimeKind.Local).AddTicks(2977), null, 3, 2, false, null, null, 2.0 },
                    { 46, "Voluptatibus dolores fuga.", new DateTime(2023, 6, 19, 10, 6, 0, 686, DateTimeKind.Local).AddTicks(9106), null, 10, 5, false, null, null, 1.0 },
                    { 47, "Et iusto incidunt quas odio omnis placeat culpa impedit.", new DateTime(2023, 10, 1, 17, 45, 59, 681, DateTimeKind.Local).AddTicks(6383), null, 2, 1, false, null, null, 2.0 },
                    { 48, "Eaque est nemo velit eveniet cumque amet.", new DateTime(2023, 7, 23, 16, 36, 45, 280, DateTimeKind.Local).AddTicks(5114), null, 11, 5, false, null, null, 3.0 },
                    { 49, "Et est in laudantium quia.", new DateTime(2023, 8, 21, 8, 22, 30, 395, DateTimeKind.Local).AddTicks(9532), null, 6, 4, false, null, null, 2.0 },
                    { 50, "Consectetur non quis.", new DateTime(2023, 6, 11, 7, 39, 58, 564, DateTimeKind.Local).AddTicks(4482), null, 3, 4, false, null, null, 5.0 },
                    { 51, "Qui ut voluptatem ut magni neque sed illum est.", new DateTime(2023, 3, 13, 15, 15, 37, 570, DateTimeKind.Local).AddTicks(3680), null, 8, 4, false, null, null, 4.0 },
                    { 52, "Beatae dolorem voluptatem fugit eum officia sit nemo qui.", new DateTime(2023, 9, 14, 14, 48, 59, 293, DateTimeKind.Local).AddTicks(1548), null, 4, 1, false, null, null, 5.0 },
                    { 53, "Sunt ipsum cupiditate ut omnis sit est illum distinctio.", new DateTime(2023, 3, 9, 15, 16, 12, 122, DateTimeKind.Local).AddTicks(8588), null, 5, 4, false, null, null, 4.0 },
                    { 54, "Dolor voluptatum in aut voluptate id est suscipit.", new DateTime(2023, 8, 18, 23, 10, 9, 665, DateTimeKind.Local).AddTicks(5081), null, 10, 5, false, null, null, 1.0 },
                    { 55, "Voluptatem rerum maiores.", new DateTime(2022, 12, 29, 5, 33, 26, 621, DateTimeKind.Local).AddTicks(2458), null, 4, 5, false, null, null, 1.0 },
                    { 56, "Ea quam praesentium rerum quis.", new DateTime(2022, 10, 31, 20, 33, 44, 836, DateTimeKind.Local).AddTicks(5790), null, 5, 2, false, null, null, 4.0 },
                    { 57, "Unde dolor itaque commodi at.", new DateTime(2023, 4, 21, 9, 20, 49, 279, DateTimeKind.Local).AddTicks(3872), null, 4, 4, false, null, null, 4.0 },
                    { 58, "Dolorum delectus autem veniam tempora.", new DateTime(2022, 11, 2, 1, 33, 59, 3, DateTimeKind.Local).AddTicks(5686), null, 3, 5, false, null, null, 4.0 },
                    { 59, "Quam sunt explicabo facere molestiae laborum voluptas qui voluptatem.", new DateTime(2023, 4, 25, 0, 48, 23, 538, DateTimeKind.Local).AddTicks(4583), null, 9, 1, false, null, null, 1.0 },
                    { 60, "Enim qui aut eos.", new DateTime(2023, 3, 18, 22, 37, 48, 781, DateTimeKind.Local).AddTicks(9503), null, 9, 5, false, null, null, 3.0 },
                    { 61, "Enim ullam ad dolore.", new DateTime(2023, 10, 16, 23, 44, 48, 252, DateTimeKind.Local).AddTicks(3797), null, 5, 1, false, null, null, 4.0 },
                    { 62, "Dicta similique voluptatem consectetur et voluptas fugit eligendi aliquam voluptatem.", new DateTime(2022, 12, 3, 23, 35, 45, 5, DateTimeKind.Local).AddTicks(1641), null, 6, 3, false, null, null, 4.0 },
                    { 63, "Velit quia fuga repudiandae.", new DateTime(2022, 12, 7, 10, 8, 10, 361, DateTimeKind.Local).AddTicks(1840), null, 2, 4, false, null, null, 3.0 },
                    { 64, "Laudantium ut repudiandae neque.", new DateTime(2023, 5, 2, 6, 28, 23, 843, DateTimeKind.Local).AddTicks(7047), null, 2, 3, false, null, null, 4.0 },
                    { 65, "Molestiae et rem delectus.", new DateTime(2023, 2, 27, 11, 29, 42, 496, DateTimeKind.Local).AddTicks(2236), null, 2, 5, false, null, null, 1.0 },
                    { 66, "Temporibus numquam autem non quis nam at.", new DateTime(2023, 8, 27, 10, 58, 46, 329, DateTimeKind.Local).AddTicks(2649), null, 5, 3, false, null, null, 5.0 },
                    { 67, "Suscipit optio maxime recusandae sit.", new DateTime(2023, 4, 3, 4, 30, 57, 230, DateTimeKind.Local).AddTicks(2317), null, 9, 3, false, null, null, 1.0 },
                    { 68, "Et quaerat distinctio ducimus blanditiis aliquam atque et ad voluptatem.", new DateTime(2023, 3, 22, 17, 51, 15, 583, DateTimeKind.Local).AddTicks(7696), null, 4, 1, false, null, null, 1.0 },
                    { 69, "Sit esse neque numquam rem corporis repellat voluptatem.", new DateTime(2023, 4, 1, 3, 46, 52, 292, DateTimeKind.Local).AddTicks(3132), null, 4, 2, false, null, null, 4.0 },
                    { 70, "Aut pariatur sed ullam enim eos et officiis eos sunt.", new DateTime(2023, 10, 19, 17, 20, 24, 724, DateTimeKind.Local).AddTicks(2924), null, 8, 5, false, null, null, 3.0 },
                    { 71, "Rerum eligendi similique eligendi.", new DateTime(2023, 8, 18, 11, 32, 43, 98, DateTimeKind.Local).AddTicks(8405), null, 7, 2, false, null, null, 4.0 },
                    { 72, "At ipsa optio.", new DateTime(2023, 4, 8, 10, 30, 26, 277, DateTimeKind.Local).AddTicks(8652), null, 10, 2, false, null, null, 5.0 },
                    { 73, "Quo quam eaque voluptatibus ipsum ut deserunt.", new DateTime(2023, 1, 18, 21, 44, 32, 864, DateTimeKind.Local).AddTicks(9265), null, 7, 4, false, null, null, 2.0 },
                    { 74, "Iste nihil voluptatem perferendis.", new DateTime(2023, 4, 6, 7, 13, 33, 635, DateTimeKind.Local).AddTicks(3899), null, 4, 4, false, null, null, 2.0 },
                    { 75, "Nemo et perspiciatis vel error qui quas et in voluptas.", new DateTime(2023, 10, 20, 15, 58, 46, 641, DateTimeKind.Local).AddTicks(2097), null, 7, 4, false, null, null, 2.0 },
                    { 76, "Non recusandae blanditiis ad illo repudiandae.", new DateTime(2023, 10, 7, 20, 3, 38, 322, DateTimeKind.Local).AddTicks(5395), null, 6, 2, false, null, null, 2.0 },
                    { 77, "Aut autem cum minus consequatur dolorem neque consequatur.", new DateTime(2023, 5, 21, 23, 0, 49, 985, DateTimeKind.Local).AddTicks(350), null, 2, 3, false, null, null, 5.0 },
                    { 78, "Tempora debitis laudantium accusamus quis facilis labore.", new DateTime(2022, 10, 26, 17, 59, 18, 740, DateTimeKind.Local).AddTicks(2612), null, 2, 3, false, null, null, 4.0 },
                    { 79, "Dolores aut aliquid fuga magni maxime explicabo sunt quos vitae.", new DateTime(2023, 9, 19, 21, 36, 5, 963, DateTimeKind.Local).AddTicks(6497), null, 11, 1, false, null, null, 5.0 },
                    { 80, "Qui voluptatibus veritatis nihil illo sapiente numquam pariatur.", new DateTime(2023, 3, 9, 13, 26, 10, 108, DateTimeKind.Local).AddTicks(2456), null, 8, 3, false, null, null, 3.0 },
                    { 81, "Ipsum occaecati et iure et esse et ut.", new DateTime(2023, 1, 15, 23, 43, 57, 583, DateTimeKind.Local).AddTicks(1631), null, 8, 1, false, null, null, 5.0 },
                    { 82, "Inventore voluptatibus ut ut omnis voluptatem non quia.", new DateTime(2022, 10, 26, 12, 55, 52, 965, DateTimeKind.Local).AddTicks(8007), null, 6, 1, false, null, null, 4.0 },
                    { 83, "Est vero quos non tempore.", new DateTime(2023, 3, 3, 12, 44, 18, 692, DateTimeKind.Local).AddTicks(4258), null, 4, 5, false, null, null, 3.0 },
                    { 84, "Ea et est dolore commodi libero rerum.", new DateTime(2023, 4, 11, 7, 1, 20, 149, DateTimeKind.Local).AddTicks(1958), null, 8, 5, false, null, null, 2.0 },
                    { 85, "Ducimus soluta recusandae.", new DateTime(2023, 9, 23, 18, 56, 22, 847, DateTimeKind.Local).AddTicks(8741), null, 7, 1, false, null, null, 4.0 },
                    { 86, "Et et ut totam dolor neque sapiente sint qui unde.", new DateTime(2023, 1, 30, 15, 36, 30, 711, DateTimeKind.Local).AddTicks(8704), null, 9, 3, false, null, null, 4.0 },
                    { 87, "Quidem quia dicta modi error officiis voluptates praesentium.", new DateTime(2023, 5, 7, 7, 17, 23, 156, DateTimeKind.Local).AddTicks(5044), null, 9, 3, false, null, null, 4.0 },
                    { 88, "Quia quam incidunt accusamus.", new DateTime(2022, 10, 24, 15, 36, 16, 915, DateTimeKind.Local).AddTicks(1610), null, 2, 1, false, null, null, 4.0 },
                    { 89, "Reiciendis ipsum et molestias ut suscipit explicabo ut voluptas.", new DateTime(2022, 10, 27, 14, 13, 13, 210, DateTimeKind.Local).AddTicks(9536), null, 5, 2, false, null, null, 4.0 },
                    { 90, "Velit sunt explicabo aliquid necessitatibus alias.", new DateTime(2022, 11, 11, 3, 9, 36, 372, DateTimeKind.Local).AddTicks(3723), null, 3, 5, false, null, null, 1.0 },
                    { 91, "Voluptatibus aperiam velit est dignissimos quisquam quibusdam.", new DateTime(2023, 7, 3, 1, 11, 10, 324, DateTimeKind.Local).AddTicks(8821), null, 8, 1, false, null, null, 1.0 },
                    { 92, "Ipsa pariatur ut.", new DateTime(2023, 4, 14, 4, 46, 49, 612, DateTimeKind.Local).AddTicks(9034), null, 7, 1, false, null, null, 3.0 },
                    { 93, "Consequatur ut omnis suscipit sit in qui possimus.", new DateTime(2022, 12, 17, 2, 55, 19, 640, DateTimeKind.Local).AddTicks(9940), null, 7, 3, false, null, null, 1.0 },
                    { 94, "Et dolorum esse aut laborum eius error repellendus.", new DateTime(2022, 11, 2, 2, 15, 18, 890, DateTimeKind.Local).AddTicks(1370), null, 11, 2, false, null, null, 1.0 },
                    { 95, "Dolore incidunt voluptatum earum.", new DateTime(2023, 9, 23, 3, 37, 3, 454, DateTimeKind.Local).AddTicks(2462), null, 3, 4, false, null, null, 4.0 },
                    { 96, "Aliquam aut tempora consequatur sit quasi iusto.", new DateTime(2023, 5, 17, 14, 40, 1, 353, DateTimeKind.Local).AddTicks(184), null, 10, 4, false, null, null, 5.0 },
                    { 97, "Voluptatibus asperiores voluptatem voluptatem enim at.", new DateTime(2023, 7, 11, 10, 28, 49, 218, DateTimeKind.Local).AddTicks(1904), null, 10, 1, false, null, null, 5.0 },
                    { 98, "Voluptatem velit non qui.", new DateTime(2023, 2, 26, 17, 8, 59, 818, DateTimeKind.Local).AddTicks(6051), null, 8, 1, false, null, null, 4.0 },
                    { 99, "Quasi repellat qui veniam sapiente.", new DateTime(2022, 11, 23, 5, 33, 37, 69, DateTimeKind.Local).AddTicks(8136), null, 8, 5, false, null, null, 3.0 },
                    { 100, "Quae explicabo qui veniam voluptatum tempore.", new DateTime(2023, 6, 2, 19, 13, 32, 274, DateTimeKind.Local).AddTicks(6207), null, 6, 2, false, null, null, 4.0 }
                });

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "074 Nolan Roads", 2, 1, 6, "South Deontaeberg", 19.839105714730728, "Ipsa est voluptate qui ipsum architecto consequuntur quas. Rerum ipsam magni sequi assumenda voluptate ea suscipit. Laudantium perspiciatis magni nihil dignissimos aliquam est dicta. Quis sed pariatur enim. Consequatur est consequatur optio ut explicabo sapiente sit optio.", 4, 7.0191999999999997, -47.508899999999997, 2, 36.709053836767481, 2, "Tenetur quod odio ea dolores voluptatem error maiores voluptatem alias architecto aut incidunt sunt consequatur consequatur incidunt eius officia numquam voluptas enim aut similique minus eveniet." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "558 Dylan Passage", 3, "South Greysonville", 93.438630060307688, "Aperiam pariatur pariatur ut pariatur. Ad quasi temporibus optio. Blanditiis a laboriosam qui aut consequatur est.", -39.832500000000003, 114.37009999999999, 7, 8, 20.521299571969461, 2, "Fugit ut omnis quod qui quisquam facilis delectus asperiores ratione qui dolor est assumenda libero tenetur quas sequi illo ut harum tempora." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "927 Lesly Centers", 2, 2, "Strict", "Doyleberg", 44.07826474971835, "Quo non ullam alias quod tempora deserunt numquam delectus. Temporibus commodi consequatur. Veniam voluptas dolor nihil dolor assumenda error dolor quis.", 2, -77.094200000000001, -175.06229999999999, 6, 51.894764578982425, 1, "Nemo corporis quisquam quis esse sunt officia voluptate sint sint omnis maxime qui minus dolorem molestiae doloribus dolor ea esse facilis sit fugit a unde numquam ipsa quaerat ex.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "44011 Shannon River", 1, 3, 7, "Isadorechester", 74.781602491176926, "Non accusantium et et architecto qui excepturi quo neque quae. Dicta et sit non blanditiis non. Molestiae et et labore nihil ipsam. Eaque laborum sint et sapiente incidunt.", 5, 76.487899999999996, -25.500900000000001, 1, 4, 13.104395565314555, 2, "Mollitia hic fugiat accusamus voluptas occaecati nulla odit et dignissimos vel architecto distinctio expedita id eum.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "808 Donavon Wall", 3, 7, "Strict", "Kochview", 18.903249317943132, "Autem vel est et cumque tempora et ducimus. Eos sed rerum nihil iure. Enim aut nobis sed doloremque non quo unde.", 5, 8.2218999999999998, 120.32510000000001, 7, 8, 45.332986625553346, "Voluptatibus facere eligendi aliquid aperiam sunt mollitia non ipsum mollitia corrupti quis laudantium dolorum facilis sit fugit autem esse quia necessitatibus aut eos sequi natus.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "2111 Nikko Dale", 3, 4, 4, "Ronaldoport", 15.051268783493089, "Quia accusantium illo ratione dignissimos rerum maiores saepe. Consequatur odit similique laudantium magnam aut doloremque non molestiae rerum. Nostrum eligendi explicabo inventore aut laudantium exercitationem maxime fuga. Consequatur aut rerum et at.", 4, 38.479599999999998, -3.5699000000000001, 7, 5, 24.293957965795162, 2, "Blanditiis sit alias fugiat dignissimos cupiditate eum nisi nemo sed.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "27670 Eden Forges", 3, 3, "Strict", "New Tayaview", 60.882792600061748, "Rem ut quod veniam autem magnam ut consequuntur non. Consequatur dignissimos itaque harum provident praesentium sit. Voluptatibus ut dicta nesciunt quaerat molestiae perferendis rerum quia maxime. Asperiores enim sed assumenda omnis perferendis illo esse. Placeat facere id illum rerum nemo minima deserunt laudantium non.", 3, 28.655000000000001, 155.02690000000001, 7, 9, 46.056794338571947, 3, "Aut rerum cumque labore voluptatem reprehenderit magni vero aut est molestiae architecto sapiente repudiandae distinctio qui occaecati autem et commodi deleniti corrupti enim repudiandae quibusdam commodi illo quia.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "6675 Brent Corners", 2, 5, 1, "Lake Adalberto", 60.423430266650264, "Laborum voluptatem voluptatibus. Quibusdam distinctio quisquam excepturi ab sequi qui fugiat corporis ipsum. Alias nesciunt fuga harum atque vitae voluptatem molestiae in sed. Nihil voluptatum enim accusamus expedita voluptatum ratione beatae nihil et. Consequatur possimus ut facilis quasi voluptatem eveniet veritatis debitis non. Debitis aliquid aut quo vero.", 4, -5.6294000000000004, 122.9949, 1, 7, 13.781395024541327, "Ut aliquid odio labore non beatae voluptatem voluptatem voluptas provident voluptatum dicta omnis porro quibusdam modi maiores similique illum fugiat voluptatum repudiandae ratione sed et iure.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "272 Bosco Way", 2, 5, 3, "North Kennithmouth", 21.189692119491227, "Commodi sit quas eveniet. Quo doloremque et voluptas et eius non aut. Et adipisci et sunt et.", 4, 58.426400000000001, 33.598399999999998, 1, 4, 24.812630926571412, 1, "Adipisci molestiae molestias exercitationem possimus voluptas quidem nesciunt assumenda vero dolorem eaque aut nam reprehenderit hic ea error et eaque dolore dolore aliquid non ratione distinctio voluptas ipsum." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "3818 Haley Harbor", 2, 7, "North Casper", 26.746689516351999, "Doloremque commodi voluptatibus fugiat commodi suscipit. Molestiae eveniet commodi ut vero sed cum facere. Sit occaecati officiis ut suscipit in excepturi sequi quis in.", -56.239199999999997, -166.82480000000001, 3, 2, 78.433186554853208, 3, "Ut numquam provident doloribus cupiditate maxime eum ut ad consectetur natus cupiditate earum molestiae similique molestiae dolorum.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "41888 Wolf Shore", 1, 1, 4, "Kohlerfort", 80.302140896997216, "Doloribus omnis iure quia perferendis quo possimus qui qui quia. Dolores excepturi vel aperiam enim provident. Qui ea sed et amet. Et rerum voluptatibus vero itaque quia quos explicabo. Voluptatum voluptatem et laboriosam nisi distinctio. Ut quasi et voluptatem quidem neque mollitia placeat.", 3, 21.965399999999999, 43.395200000000003, 6, 34.978043401984344, "Ab officiis repellendus rerum perspiciatis consequatur ipsa omnis beatae voluptates quia ipsa placeat reiciendis occaecati debitis praesentium et nihil ab et voluptatem.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "PricePerNight", "Title", "Type" },
                values: new object[] { "4289 Earl Lock", 2, 5, 8, "South Fredrick", 76.606539691086297, "Et harum aperiam dolorem iste et eos ut sunt. Est voluptatem qui qui exercitationem enim odio non exercitationem. Amet numquam aliquam possimus porro laborum in officiis quibusdam ut.", -10.2066, 84.390000000000001, 64.577517315120645, "Modi et totam dolor neque autem ab quia doloribus voluptas magni velit pariatur laudantium quia sint numquam at et ullam omnis tempore.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "BedCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "63700 Allison Courts", 3, "Port Jeffereyhaven", 35.752240889468183, "Nostrum aut aut facilis sit fuga nemo. Quia architecto voluptatem commodi animi dolor facilis laudantium. Necessitatibus enim et qui cum. Maxime accusantium sit. Iure reprehenderit minus saepe qui dolores ratione ea. Quaerat facilis at natus eos labore eaque sit eveniet.", 1, 7.4538000000000002, -37.592100000000002, 9, 3, 59.659163262771031, "Excepturi quis ab voluptas dolor doloribus voluptatum sit explicabo iste quo fugiat non nisi quae voluptas rerum ut tempore ut.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "91235 Gutkowski Park", 4, 2, "West Braxtonport", 56.266595339059499, "Et et sequi nihil sapiente quam sed libero aut enim. Nesciunt ad tenetur praesentium. Aperiam consequuntur numquam. Doloremque assumenda consequatur aut ullam sit qui ratione quia. Recusandae voluptatibus qui ut maxime consequuntur aut hic hic.", 2, 44.851999999999997, 8.2708999999999993, 7, 8, 53.492643715071551, 3, "Et incidunt magni ipsa neque quo optio quae et reiciendis totam.", "HomeStay" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "55766 Sipes Causeway", 2, 4, "Strict", "Lynchmouth", 14.881346176707142, "Cupiditate nihil ab sit dicta reiciendis et perspiciatis consequatur debitis. Sit consequatur occaecati sed est voluptates voluptatem. Totam suscipit accusamus eius saepe quia autem autem et minus. Qui consequatur ullam iure harum asperiores incidunt molestiae dolores omnis. Explicabo cumque laboriosam cum iure ipsum distinctio ipsam laboriosam. Aliquid consequatur voluptatem temporibus ut est.", 3, 24.952100000000002, -36.111699999999999, 1, 4, 64.316624999221077, "Quisquam architecto necessitatibus ea sunt voluptatibus facere officiis omnis quaerat consectetur est ut optio.", "Resort" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "BathroomCount", "BedCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "07628 Barton Island", 2, 4, "Port Cristobalfort", 36.774233695701184, "Temporibus reiciendis consectetur unde et nostrum ex iusto. Eveniet pariatur fugiat. Qui in aut magni minus quas tempore. Deleniti quis et sint enim amet animi. Maiores occaecati rerum dolorem eius autem autem ea commodi officia. Voluptas consequatur eius.", 2, -39.567500000000003, 150.5436, 2, 10, 42.131238460737009, 1, "Ad tempora eaque tempore consequatur non itaque laboriosam soluta iusto repellendus ex et fugit assumenda ipsum eos repudiandae exercitationem et perspiciatis quia fugiat sunt.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "483 Kunze Pike", 3, "Flexible", "Lake Vincent", 12.21725587775531, "Omnis fugiat totam accusantium sunt id quae quas enim eius. Impedit dolorem iusto. Corporis qui odio hic quidem temporibus corporis sed minus at. Quas atque ratione. Non vel est et quo sed quas beatae natus culpa. A autem voluptatem corporis.", 2, -79.687100000000001, 49.262500000000003, 8, 4, 14.448717648502306, 2, "Adipisci qui harum id reiciendis accusamus optio consequatur non incidunt rerum cupiditate non molestiae iusto qui laborum quia id vitae vel est nesciunt excepturi.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "674 VonRueden Ports", 3, 4, 5, "Flexible", "Alvinafort", 79.716051555038135, "Facilis molestiae deleniti voluptates nihil. Et placeat aliquam voluptas earum dolor ab nisi sed. Voluptates ut repudiandae commodi veniam harum necessitatibus. Ea qui alias qui ea nisi consequuntur repellendus quo. Dolore consequatur praesentium iusto rem laudantium similique aspernatur. Perspiciatis aut id blanditiis qui.", 10.799099999999999, 19.688800000000001, 4, 4, 75.01552344709394, "Et repellat ut asperiores sequi dignissimos cumque minima aspernatur perferendis reiciendis autem voluptatem eveniet dicta ut quaerat in beatae mollitia illo.", "HomeStay" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "3474 Purdy Orchard", 3, 2, "Whiteshire", 20.990033464232638, "Est illo labore facilis autem aliquid tempore eos. Cupiditate amet animi animi mollitia saepe sunt eaque. Quas facilis ipsa voluptate unde veniam repudiandae magnam dolorem. Eos deserunt odit rerum ut omnis architecto veniam ut. Rerum vel iusto qui officiis maxime.", 3, 37.603000000000002, -161.90520000000001, 1, 26.176220725403041, 2, "Architecto vel nihil voluptatem sed quae accusamus deserunt quia doloremque dolor odio ducimus dolor.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "146 Lemuel Unions", 3, 4, 2, "East Jimmie", 18.813129508565943, "Commodi qui quod. Repudiandae et ipsa. Non odit possimus explicabo nesciunt animi. Earum fugit iure quisquam mollitia velit facilis aperiam.", 3, 88.155100000000004, 8.0818999999999992, 3, 10, 40.95777423465028, "Quia minus rerum sunt est non officiis occaecati omnis voluptatem sed sit dicta est sunt eaque voluptatibus.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "058 Kemmer Bridge", 2, 5, 5, "North Eribertoton", 62.835198580384805, "Perferendis est nesciunt. Aliquam in et perspiciatis ipsa inventore vel. Nobis maiores in sed aperiam quae corrupti quaerat. Et omnis magnam.", 5, -72.049800000000005, 49.006300000000003, 8, 6, 13.33339722523146, "Minima ipsam qui asperiores totam consequatur eligendi ut velit a nesciunt ad quae.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Address", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "6588 Toy Crescent", 3, 4, "Strict", "West Rene", 60.138092146462604, "Esse libero temporibus. Dolorem debitis molestiae et reiciendis odio cupiditate. Voluptatem beatae voluptas. Similique cumque sint. Voluptas quibusdam magni facilis odit vitae ipsa eos quae ad.", 4, 84.271199999999993, -21.484100000000002, 9, 5, 86.731470509836228, 2, "Molestias quia fugiat minus iusto amet ullam ut in sunt dolorem non non quos non sed minus beatae quas sit eum quasi repellendus.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Address", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "254 Colby Brook", 4, "Flexible", "South Andreborough", 20.495907512842543, "Libero voluptate optio et excepturi et molestiae omnis iste impedit. Cum sit provident provident reiciendis tenetur eum sequi dolor quaerat. Veniam molestiae voluptatem quas. Nesciunt ut iusto velit quidem distinctio quam non cupiditate.", 3, -1.2777000000000001, 117.4306, 5, 7, 32.434148888460939, 1, "Sint at eligendi qui possimus illo ex deleniti fugiat quo ut magnam iste velit voluptas iste libero ipsa dolor blanditiis esse nesciunt architecto.", "Resort" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "962 Abbey Mills", 1, 4, "Strict", "Lake Domenica", 57.783427003887333, "Ut ea alias ex architecto sunt optio vel aliquid aspernatur. Deleniti impedit aut voluptatem praesentium qui odio. Voluptas amet maiores qui et nisi iusto sint officiis perferendis.", 5, 13.3407, 129.44710000000001, 8, 8, 32.811655297096792, "Velit assumenda ipsam ea esse sit qui reiciendis debitis debitis.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "133 Ethelyn Throughway", 1, 3, 4, "Port Hailee", 85.554476583299078, "Excepturi consequatur odio deleniti. Repudiandae nihil beatae unde autem similique ex ex veniam quis. Similique praesentium reiciendis corrupti sunt. Odit esse harum rerum. Voluptatem laudantium ducimus esse nam cumque quod corrupti ab.", 4, -10.050800000000001, -120.28360000000001, 5, 8, 41.840311535675227, 3, "Totam voluptas nesciunt qui et reiciendis et velit voluptatem doloribus." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Address", "BathroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "73073 Cole Highway", 2, "Paucekside", 23.37234114538829, "Ipsa voluptas quidem repellat exercitationem facere dolorem laborum harum temporibus. Rerum beatae illum sit cupiditate ut ut. Facere earum voluptas distinctio nulla molestiae eveniet nisi omnis ducimus.", -37.452300000000001, 152.86879999999999, 6, 8, 75.553512388828977, "Autem fugit eaque labore non natus deleniti nostrum cupiditate molestias dignissimos magnam occaecati et qui sapiente iusto harum aut architecto eum inventore porro est.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Address", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "3611 Kreiger Rapid", 1, 4, "Strict", "Franeckishire", 90.841563359538654, "Et exercitationem minus quo expedita iure molestiae nostrum itaque eius. Fuga id nisi ducimus minima inventore inventore doloremque asperiores aut. Consequatur aut est ipsa.", 1, -17.299299999999999, 26.289999999999999, 1, 9, 14.164079648047158, 2, "Dignissimos similique magnam vel distinctio minus natus commodi laboriosam commodi tenetur quam voluptatem voluptas a." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "131 Beahan Bridge", 2, 5, 8, "Flexible", "South Lonstad", 13.747863607716745, "Voluptate doloremque ducimus. Nihil ullam cum aut quo quis sint cupiditate. Quas repellendus et aut esse aut perferendis consequatur. Voluptatem rerum cumque fugit eaque ut a. In illo alias esse.", -13.151400000000001, -51.083100000000002, 6, 9, 89.955593618527701, 3, "Sed autem odio sint reprehenderit nulla blanditiis enim ut praesentium facere sit et quod ut voluptate.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "616 Christiana Corner", 3, 2, 4, "Alvinahaven", 70.908490078701504, "Est mollitia quam. Tempora quidem animi neque. Ratione vitae ea sequi est voluptatum dicta doloribus et molestiae. Corrupti exercitationem ipsam voluptatem deleniti consequuntur velit in. Sunt alias dolor eos dolorem architecto est eos quibusdam a. Sed nisi aliquam.", 5, 86.110799999999998, -135.54910000000001, 4, 6, 96.35923477734319, 1, "Eos quia nostrum unde molestiae excepturi illum dolorem velit libero non reiciendis.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "7148 Mara Burg", 3, 5, 8, "Cydneymouth", 41.275397783610792, "Assumenda non dicta velit. Occaecati et distinctio ut porro commodi adipisci placeat. Omnis accusantium non. Sit dolor hic maiores doloremque provident voluptatum dolor animi molestiae. Architecto cum quia. Voluptatem ab et odit adipisci.", 4, 71.357500000000002, 146.81120000000001, 8, 4, 78.777764249889515, "Veritatis et id facere fugit sit sunt modi atque mollitia voluptas voluptatem minus porro tempora voluptas corporis atque quo veritatis fugit quidem vitae mollitia voluptatem sunt quas fugiat magni distinctio.", "Resort" });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { false, false, false, true, true, false, false, true, false, false, false, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsBar", "IsBeachFront", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsRoomService", "IsSeaView", "IsSpa", "IsSwimmingPool", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, true, false, true, true, false, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsBar", "IsCamperFriendly", "IsGym", "IsLandmarkView", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsTv" },
                values: new object[] { true, true, true, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsSeaView", "IsSpa", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { true, false, true, false, false, true, true, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsBar", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsGym", "IsKitchen", "IsLakeView", "IsLaptopFriendlyWorkspace", "IsSecurityCamera", "IsSpa", "IsSwimmingPool", "IsWifi" },
                values: new object[] { false, true, true, true, true, true, true, false, false, true, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsRoomService", "IsSeaView", "IsSpa", "IsTv" },
                values: new object[] { false, false, false, true, true, false, true, true, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, false, false, true, true, false, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsHotWater", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSeaView", "IsSecurityCamera", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, false, true, false, true, true, false, true, true, true, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IsBeachFront", "IsCamperFriendly", "IsElevator", "IsHotWater", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsSecurityCamera", "IsSwimmingPool" },
                values: new object[] { false, false, true, true, true, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSecurityCamera", "IsWifi" },
                values: new object[] { false, false, false, false, true, false, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsTv" },
                values: new object[] { true, true, false, false, true, false, true, true, false, false, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, true, true, false, false, false, true, false, true, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IsBreakfast", "IsKitchen", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, true, true, false, false, true, false, true, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsWifi" },
                values: new object[] { false, false, true, true, false, false, true, false, false, false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsLandmarkView", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool" },
                values: new object[] { false, false, false, false, true, false, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsLandmarkView", "IsRoomService", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { false, false, true, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsGym", "IsHotWater", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { true, false, true, true, false, false, false, false, false, false, false, true, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsSeaView", "IsSwimmingPool", "IsWheelchairAccessible" },
                values: new object[] { false, false, false, true, true, false, false, false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsCamperFriendly", "IsGym", "IsKitchen", "IsMountainView", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { false, true, false, true, true, false, false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsCamperFriendly", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsLaptopFriendlyWorkspace", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, true, false, true, false, true, false, true, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsMountainView", "IsSecurityCamera", "IsSpa", "IsTv" },
                values: new object[] { false, true, true, false, true, true, false, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsHotWater", "IsLakeView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSpa", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, true, false, false, true, false, false, false, true, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSecurityCamera", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { false, false, true, true, true, true, true, true, false, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsSecurityCamera", "IsSwimmingPool", "IsWifi" },
                values: new object[] { false, true, true, true, false, false, true, false, true, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "IsBeachFront", "IsCamperFriendly", "IsGym", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsRoomService", "IsSecurityCamera", "IsSpa", "IsWheelchairAccessible" },
                values: new object[] { false, false, true, false, false, false, false, true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsMountainView", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { true, false, true, true, false, false, false, false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsHotWater", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSeaView", "IsSpa", "IsSwimmingPool" },
                values: new object[] { true, true, false, true, false, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IsAirConditioning", "IsCamperFriendly", "IsElevator", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSecurityCamera", "IsSpa", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { false, false, false, true, false, false, false, false, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "IsAirConditioning", "IsBar", "IsCamperFriendly", "IsElevator", "IsGym", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSecurityCamera", "IsSwimmingPool", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, false, false, true, false, true, false, true, false, true, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSpa", "IsTv" },
                values: new object[] { false, false, true, false, true, true, true, true, false, true, true, false });

            migrationBuilder.InsertData(
                table: "PropertyReviews",
                columns: new[] { "Id", "Accuracy", "CheckIn", "Cleanliness", "Communication", "Content", "CreatedAt", "CreatedBy", "GuestId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Location", "PropertyId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 4, 5, "Qui eum dolores fugiat.", new DateTime(2023, 8, 8, 8, 28, 14, 334, DateTimeKind.Local).AddTicks(6758), null, 3, false, null, null, 4, 17, 5 },
                    { 2, 3, 2, 2, 3, "Numquam eum nihil nihil nihil neque eius facere culpa voluptates.", new DateTime(2023, 6, 6, 13, 40, 52, 98, DateTimeKind.Local).AddTicks(5313), null, 2, false, null, null, 4, 10, 2 },
                    { 3, 4, 4, 4, 5, "Quaerat mollitia sit placeat sed iusto nostrum perspiciatis aut distinctio.", new DateTime(2023, 6, 24, 2, 48, 57, 743, DateTimeKind.Local).AddTicks(1416), null, 9, false, null, null, 3, 19, 5 },
                    { 4, 5, 2, 3, 5, "Mollitia veritatis occaecati est iure optio.", new DateTime(2023, 4, 14, 8, 50, 37, 776, DateTimeKind.Local).AddTicks(9741), null, 8, false, null, null, 1, 25, 4 },
                    { 5, 1, 5, 4, 5, "Sit soluta maxime et asperiores nihil adipisci totam adipisci.", new DateTime(2022, 11, 7, 7, 53, 15, 973, DateTimeKind.Local).AddTicks(654), null, 11, false, null, null, 5, 28, 1 },
                    { 6, 3, 1, 1, 1, "Ut officiis quos atque ducimus omnis.", new DateTime(2022, 10, 29, 0, 8, 50, 627, DateTimeKind.Local).AddTicks(5383), null, 4, false, null, null, 1, 9, 3 },
                    { 7, 1, 4, 3, 1, "Facere ab ipsa illo corrupti autem rerum aut.", new DateTime(2022, 10, 29, 6, 20, 50, 464, DateTimeKind.Local).AddTicks(6985), null, 10, false, null, null, 3, 11, 5 },
                    { 8, 1, 5, 3, 3, "Quidem sit modi.", new DateTime(2023, 5, 8, 11, 5, 46, 528, DateTimeKind.Local).AddTicks(1477), null, 2, false, null, null, 5, 20, 4 },
                    { 9, 3, 2, 5, 5, "Quas placeat nisi voluptas enim consequatur.", new DateTime(2022, 11, 5, 17, 53, 28, 637, DateTimeKind.Local).AddTicks(9720), null, 4, false, null, null, 4, 5, 2 },
                    { 10, 3, 1, 4, 1, "Totam dicta iusto aspernatur enim nesciunt consequatur laborum.", new DateTime(2022, 11, 25, 21, 52, 9, 564, DateTimeKind.Local).AddTicks(7428), null, 3, false, null, null, 1, 7, 5 },
                    { 11, 2, 5, 1, 1, "Tempore incidunt deserunt.", new DateTime(2023, 2, 28, 9, 19, 18, 351, DateTimeKind.Local).AddTicks(6245), null, 3, false, null, null, 3, 15, 3 },
                    { 12, 2, 3, 5, 5, "Voluptatem ea aut fuga aut ut non incidunt et.", new DateTime(2023, 6, 13, 18, 47, 50, 995, DateTimeKind.Local).AddTicks(877), null, 5, false, null, null, 4, 9, 1 },
                    { 13, 4, 4, 2, 4, "Temporibus voluptas eum voluptas magnam rerum aut aut quaerat harum.", new DateTime(2023, 3, 3, 14, 53, 7, 283, DateTimeKind.Local).AddTicks(3878), null, 5, false, null, null, 2, 28, 1 },
                    { 14, 4, 3, 3, 1, "Omnis aut ut autem ullam sed sint autem ab voluptas.", new DateTime(2023, 4, 15, 23, 31, 58, 835, DateTimeKind.Local).AddTicks(9450), null, 6, false, null, null, 5, 11, 3 },
                    { 15, 4, 1, 1, 1, "Consequatur qui unde dicta.", new DateTime(2023, 5, 18, 17, 51, 30, 600, DateTimeKind.Local).AddTicks(56), null, 11, false, null, null, 1, 18, 2 },
                    { 16, 5, 2, 2, 4, "Saepe dolores et perspiciatis soluta ut earum.", new DateTime(2023, 2, 23, 21, 14, 9, 47, DateTimeKind.Local).AddTicks(1795), null, 5, false, null, null, 2, 12, 1 },
                    { 17, 4, 4, 4, 4, "Ab nam soluta voluptatem.", new DateTime(2023, 10, 7, 5, 7, 3, 475, DateTimeKind.Local).AddTicks(7011), null, 9, false, null, null, 2, 20, 1 },
                    { 18, 5, 4, 5, 2, "Harum quia quia porro dolorem consequatur aspernatur ducimus rerum aspernatur.", new DateTime(2023, 10, 6, 10, 29, 50, 517, DateTimeKind.Local).AddTicks(2524), null, 5, false, null, null, 4, 9, 5 },
                    { 19, 5, 5, 1, 1, "Enim officiis autem ut odit aut.", new DateTime(2022, 10, 29, 22, 14, 27, 447, DateTimeKind.Local).AddTicks(9928), null, 5, false, null, null, 1, 11, 5 },
                    { 20, 5, 1, 4, 5, "Facere accusantium maiores tempora minima.", new DateTime(2023, 9, 13, 16, 10, 11, 218, DateTimeKind.Local).AddTicks(962), null, 10, false, null, null, 1, 23, 3 },
                    { 21, 1, 5, 3, 2, "Labore eius cupiditate commodi eius.", new DateTime(2023, 7, 15, 1, 57, 17, 160, DateTimeKind.Local).AddTicks(817), null, 6, false, null, null, 4, 19, 3 },
                    { 22, 5, 3, 1, 3, "Animi laboriosam laboriosam.", new DateTime(2023, 6, 28, 13, 11, 6, 550, DateTimeKind.Local).AddTicks(5700), null, 10, false, null, null, 3, 7, 5 },
                    { 23, 4, 3, 5, 1, "Delectus ut sapiente incidunt officiis est culpa cum.", new DateTime(2023, 3, 27, 14, 22, 54, 745, DateTimeKind.Local).AddTicks(7211), null, 9, false, null, null, 3, 25, 2 },
                    { 24, 5, 5, 1, 3, "Nesciunt facere dicta vitae recusandae vel consequuntur aut rerum.", new DateTime(2023, 4, 11, 1, 49, 33, 946, DateTimeKind.Local).AddTicks(836), null, 7, false, null, null, 2, 9, 4 },
                    { 25, 1, 4, 3, 1, "Est repellendus tenetur quos ut enim.", new DateTime(2022, 12, 6, 16, 12, 10, 293, DateTimeKind.Local).AddTicks(9830), null, 7, false, null, null, 1, 8, 1 },
                    { 26, 4, 3, 3, 4, "Possimus qui dolor.", new DateTime(2022, 11, 6, 16, 0, 35, 144, DateTimeKind.Local).AddTicks(7595), null, 9, false, null, null, 1, 14, 1 },
                    { 27, 5, 2, 3, 2, "Recusandae qui est est ut.", new DateTime(2023, 8, 29, 3, 22, 16, 979, DateTimeKind.Local).AddTicks(5844), null, 10, false, null, null, 4, 10, 2 },
                    { 28, 3, 3, 1, 3, "Expedita perferendis blanditiis minus aspernatur exercitationem.", new DateTime(2023, 1, 13, 23, 6, 40, 201, DateTimeKind.Local).AddTicks(6169), null, 5, false, null, null, 3, 27, 5 },
                    { 29, 5, 4, 3, 1, "Rerum aliquam officia nesciunt mollitia autem.", new DateTime(2023, 8, 25, 13, 46, 39, 205, DateTimeKind.Local).AddTicks(9673), null, 2, false, null, null, 5, 13, 2 },
                    { 30, 4, 3, 4, 4, "Nihil eum earum aliquid nam eius officiis aut.", new DateTime(2023, 6, 27, 10, 57, 14, 739, DateTimeKind.Local).AddTicks(2752), null, 4, false, null, null, 1, 24, 4 },
                    { 31, 2, 3, 4, 1, "Et asperiores voluptas maxime.", new DateTime(2023, 6, 6, 6, 21, 18, 843, DateTimeKind.Local).AddTicks(2851), null, 4, false, null, null, 3, 28, 1 },
                    { 32, 4, 2, 3, 2, "Similique nam odio.", new DateTime(2023, 10, 6, 12, 43, 17, 143, DateTimeKind.Local).AddTicks(979), null, 6, false, null, null, 2, 25, 5 },
                    { 33, 4, 3, 1, 2, "Et et voluptas repudiandae doloremque sed molestiae blanditiis.", new DateTime(2022, 12, 18, 12, 45, 1, 269, DateTimeKind.Local).AddTicks(9534), null, 6, false, null, null, 2, 24, 1 },
                    { 34, 3, 5, 4, 1, "Autem sapiente est dignissimos sed eveniet.", new DateTime(2023, 7, 13, 19, 51, 44, 601, DateTimeKind.Local).AddTicks(1537), null, 11, false, null, null, 4, 16, 4 },
                    { 35, 1, 3, 3, 3, "Optio sunt velit architecto earum maiores.", new DateTime(2022, 11, 17, 8, 52, 6, 294, DateTimeKind.Local).AddTicks(2756), null, 11, false, null, null, 5, 10, 5 },
                    { 36, 3, 3, 1, 4, "Sunt recusandae architecto consectetur laudantium quo magni est perspiciatis.", new DateTime(2023, 7, 11, 17, 52, 53, 698, DateTimeKind.Local).AddTicks(1357), null, 3, false, null, null, 4, 25, 4 },
                    { 37, 1, 2, 5, 4, "Praesentium sed facilis.", new DateTime(2023, 5, 22, 16, 39, 42, 296, DateTimeKind.Local).AddTicks(1107), null, 5, false, null, null, 2, 13, 1 },
                    { 38, 5, 4, 2, 2, "Maiores ducimus sed quis ut.", new DateTime(2023, 5, 28, 21, 11, 11, 224, DateTimeKind.Local).AddTicks(9924), null, 3, false, null, null, 2, 20, 5 },
                    { 39, 5, 4, 2, 5, "At et et et et commodi in sit.", new DateTime(2023, 9, 6, 21, 58, 46, 229, DateTimeKind.Local).AddTicks(1397), null, 2, false, null, null, 5, 8, 2 },
                    { 40, 4, 4, 2, 5, "Quas non rerum.", new DateTime(2023, 3, 1, 13, 34, 22, 180, DateTimeKind.Local).AddTicks(5063), null, 9, false, null, null, 1, 8, 4 },
                    { 41, 5, 4, 2, 5, "Ipsam voluptatibus eius sed aliquid ut enim qui tenetur labore.", new DateTime(2023, 4, 3, 22, 45, 26, 828, DateTimeKind.Local).AddTicks(8818), null, 3, false, null, null, 5, 15, 5 },
                    { 42, 5, 2, 3, 1, "Soluta tenetur esse ea qui et eos veniam eum.", new DateTime(2023, 7, 4, 1, 17, 4, 65, DateTimeKind.Local).AddTicks(3389), null, 4, false, null, null, 1, 15, 3 },
                    { 43, 2, 3, 5, 1, "Reiciendis repudiandae sit est molestias qui eos velit.", new DateTime(2023, 6, 12, 5, 42, 25, 729, DateTimeKind.Local).AddTicks(9411), null, 11, false, null, null, 2, 10, 3 },
                    { 44, 5, 4, 5, 3, "Id dolores beatae rem ea libero esse magnam exercitationem temporibus.", new DateTime(2022, 11, 19, 12, 8, 3, 461, DateTimeKind.Local).AddTicks(3602), null, 7, false, null, null, 4, 21, 5 },
                    { 45, 2, 4, 2, 5, "Beatae quaerat ullam ut quia.", new DateTime(2022, 10, 25, 21, 16, 5, 464, DateTimeKind.Local).AddTicks(7566), null, 5, false, null, null, 5, 1, 1 },
                    { 46, 5, 4, 1, 3, "Ut consequatur id tenetur perferendis atque perferendis quia.", new DateTime(2023, 3, 4, 7, 29, 52, 215, DateTimeKind.Local).AddTicks(2812), null, 9, false, null, null, 3, 27, 4 },
                    { 47, 1, 1, 5, 3, "Impedit porro doloribus aut et est doloremque aut.", new DateTime(2023, 8, 6, 1, 25, 34, 969, DateTimeKind.Local).AddTicks(9065), null, 10, false, null, null, 1, 11, 4 },
                    { 48, 2, 5, 1, 3, "Sit cumque assumenda laborum eum id asperiores excepturi ut.", new DateTime(2023, 5, 14, 22, 52, 13, 587, DateTimeKind.Local).AddTicks(9191), null, 8, false, null, null, 2, 11, 4 },
                    { 49, 1, 1, 1, 3, "Consequatur maxime aut quisquam.", new DateTime(2023, 6, 6, 4, 53, 30, 882, DateTimeKind.Local).AddTicks(3211), null, 2, false, null, null, 2, 15, 2 },
                    { 50, 4, 4, 3, 3, "A id aliquid magnam harum odit neque.", new DateTime(2023, 8, 24, 6, 35, 15, 452, DateTimeKind.Local).AddTicks(8127), null, 9, false, null, null, 3, 23, 1 },
                    { 51, 4, 4, 1, 2, "Repellat minima maxime itaque magni ullam.", new DateTime(2022, 11, 13, 21, 4, 51, 171, DateTimeKind.Local).AddTicks(9118), null, 7, false, null, null, 3, 11, 4 },
                    { 52, 2, 1, 4, 2, "Beatae ex omnis quibusdam magni iure impedit.", new DateTime(2022, 10, 22, 5, 2, 43, 176, DateTimeKind.Local).AddTicks(4608), null, 9, false, null, null, 4, 24, 1 },
                    { 53, 5, 1, 1, 2, "Nisi similique dolorem.", new DateTime(2022, 11, 21, 3, 58, 59, 462, DateTimeKind.Local).AddTicks(818), null, 2, false, null, null, 5, 5, 3 },
                    { 54, 2, 1, 2, 1, "Doloremque adipisci id sed repudiandae provident et nobis.", new DateTime(2023, 2, 2, 11, 5, 50, 958, DateTimeKind.Local).AddTicks(1713), null, 5, false, null, null, 1, 26, 2 },
                    { 55, 3, 5, 2, 4, "Ipsum provident officia non eveniet.", new DateTime(2023, 8, 31, 15, 47, 19, 540, DateTimeKind.Local).AddTicks(8419), null, 7, false, null, null, 2, 8, 1 },
                    { 56, 4, 1, 3, 1, "Impedit placeat quidem vel vel architecto aut.", new DateTime(2022, 11, 3, 3, 23, 38, 222, DateTimeKind.Local).AddTicks(6095), null, 2, false, null, null, 2, 23, 2 },
                    { 57, 3, 2, 5, 1, "Nihil aut saepe debitis voluptatem libero atque.", new DateTime(2022, 12, 7, 13, 48, 41, 642, DateTimeKind.Local).AddTicks(3116), null, 10, false, null, null, 2, 3, 4 },
                    { 58, 4, 3, 2, 5, "Facilis quisquam perferendis.", new DateTime(2023, 5, 27, 11, 56, 39, 28, DateTimeKind.Local).AddTicks(4843), null, 8, false, null, null, 2, 17, 5 },
                    { 59, 5, 5, 3, 3, "Quaerat eos est eveniet est facilis.", new DateTime(2023, 7, 30, 9, 58, 17, 221, DateTimeKind.Local).AddTicks(2665), null, 11, false, null, null, 1, 13, 2 },
                    { 60, 2, 5, 1, 2, "Placeat rem dolorem voluptatem sapiente molestiae voluptas consequatur.", new DateTime(2023, 2, 6, 9, 7, 41, 53, DateTimeKind.Local).AddTicks(5057), null, 8, false, null, null, 3, 26, 2 },
                    { 61, 2, 3, 1, 2, "Ipsam dignissimos asperiores.", new DateTime(2023, 2, 8, 7, 3, 26, 776, DateTimeKind.Local).AddTicks(1628), null, 9, false, null, null, 1, 1, 4 },
                    { 62, 2, 3, 3, 4, "At modi porro necessitatibus alias minus dignissimos.", new DateTime(2023, 2, 3, 12, 37, 34, 413, DateTimeKind.Local).AddTicks(1731), null, 3, false, null, null, 3, 9, 2 },
                    { 63, 4, 4, 5, 4, "Velit neque sed itaque omnis.", new DateTime(2023, 1, 26, 0, 16, 1, 99, DateTimeKind.Local).AddTicks(8371), null, 4, false, null, null, 2, 14, 3 },
                    { 64, 4, 3, 4, 3, "Architecto sed eos.", new DateTime(2022, 11, 7, 17, 7, 16, 566, DateTimeKind.Local).AddTicks(6812), null, 5, false, null, null, 3, 25, 2 },
                    { 65, 4, 4, 3, 4, "Suscipit facilis cupiditate et dolore.", new DateTime(2023, 8, 2, 21, 57, 48, 40, DateTimeKind.Local).AddTicks(3072), null, 9, false, null, null, 2, 13, 3 },
                    { 66, 1, 2, 4, 3, "Iste iusto consectetur sed rerum tempore omnis iusto fugiat.", new DateTime(2023, 3, 12, 22, 40, 58, 602, DateTimeKind.Local).AddTicks(3198), null, 11, false, null, null, 2, 25, 2 },
                    { 67, 3, 5, 5, 4, "Et labore adipisci.", new DateTime(2023, 5, 21, 5, 5, 16, 4, DateTimeKind.Local).AddTicks(4245), null, 9, false, null, null, 1, 30, 2 },
                    { 68, 3, 1, 2, 3, "Saepe ut et id expedita facere consequuntur sed.", new DateTime(2023, 10, 8, 2, 55, 36, 82, DateTimeKind.Local).AddTicks(6735), null, 7, false, null, null, 5, 20, 1 },
                    { 69, 1, 2, 3, 2, "Qui aut molestiae animi commodi quaerat et.", new DateTime(2023, 8, 27, 15, 25, 32, 638, DateTimeKind.Local).AddTicks(9957), null, 6, false, null, null, 4, 22, 3 },
                    { 70, 1, 4, 2, 1, "Assumenda quia fugit consequatur ipsam eveniet tenetur.", new DateTime(2023, 10, 12, 6, 3, 47, 741, DateTimeKind.Local).AddTicks(1507), null, 10, false, null, null, 2, 20, 4 },
                    { 71, 2, 2, 5, 4, "Neque non sint illum qui fugit sed.", new DateTime(2023, 5, 10, 20, 32, 44, 228, DateTimeKind.Local).AddTicks(1684), null, 9, false, null, null, 5, 16, 1 },
                    { 72, 5, 4, 3, 3, "Sed quos animi molestiae.", new DateTime(2022, 12, 25, 4, 53, 6, 396, DateTimeKind.Local).AddTicks(3178), null, 11, false, null, null, 3, 8, 5 },
                    { 73, 5, 4, 4, 4, "Et ea aut expedita est qui aperiam inventore.", new DateTime(2023, 6, 20, 20, 3, 28, 619, DateTimeKind.Local).AddTicks(5785), null, 11, false, null, null, 3, 13, 4 },
                    { 74, 2, 3, 4, 3, "Magni iure aut expedita aut.", new DateTime(2023, 4, 4, 6, 16, 28, 584, DateTimeKind.Local).AddTicks(1593), null, 7, false, null, null, 4, 28, 4 },
                    { 75, 3, 4, 2, 1, "Eaque vel occaecati voluptatem eius qui autem est quaerat.", new DateTime(2023, 5, 31, 6, 21, 59, 507, DateTimeKind.Local).AddTicks(7993), null, 11, false, null, null, 2, 13, 1 },
                    { 76, 4, 1, 2, 3, "Et asperiores voluptate assumenda qui consequatur tempore quae minima.", new DateTime(2022, 10, 31, 15, 9, 42, 438, DateTimeKind.Local).AddTicks(3272), null, 11, false, null, null, 1, 16, 5 },
                    { 77, 4, 3, 4, 1, "Fuga asperiores et.", new DateTime(2023, 1, 1, 3, 23, 21, 83, DateTimeKind.Local).AddTicks(3159), null, 10, false, null, null, 5, 24, 3 },
                    { 78, 1, 2, 1, 3, "Velit et ut eius natus.", new DateTime(2023, 3, 9, 6, 4, 17, 805, DateTimeKind.Local).AddTicks(8682), null, 8, false, null, null, 3, 21, 1 },
                    { 79, 1, 5, 1, 3, "Ut vel facere qui recusandae aut reiciendis libero non et.", new DateTime(2023, 6, 13, 18, 15, 10, 457, DateTimeKind.Local).AddTicks(1260), null, 4, false, null, null, 4, 14, 1 },
                    { 80, 4, 5, 4, 1, "Odit praesentium est quas impedit magnam sed ut quam.", new DateTime(2023, 2, 14, 14, 56, 38, 575, DateTimeKind.Local).AddTicks(4433), null, 6, false, null, null, 5, 28, 5 },
                    { 81, 4, 2, 2, 2, "Suscipit nulla officia voluptatibus nemo ex.", new DateTime(2023, 6, 4, 13, 11, 43, 916, DateTimeKind.Local).AddTicks(6121), null, 5, false, null, null, 4, 3, 5 },
                    { 82, 1, 1, 5, 2, "Doloremque qui consequuntur a rerum magni sed molestias.", new DateTime(2023, 1, 31, 8, 8, 32, 920, DateTimeKind.Local).AddTicks(9603), null, 8, false, null, null, 5, 2, 1 },
                    { 83, 5, 2, 5, 2, "Corrupti nobis et labore quidem omnis architecto quod.", new DateTime(2022, 10, 23, 10, 16, 36, 55, DateTimeKind.Local).AddTicks(9732), null, 5, false, null, null, 2, 5, 5 },
                    { 84, 5, 4, 4, 3, "Sunt qui non.", new DateTime(2023, 3, 24, 18, 19, 12, 640, DateTimeKind.Local).AddTicks(2782), null, 2, false, null, null, 5, 23, 4 },
                    { 85, 1, 5, 3, 5, "Facilis natus corporis doloremque ullam et architecto dolorem.", new DateTime(2023, 9, 6, 16, 34, 35, 475, DateTimeKind.Local).AddTicks(6579), null, 7, false, null, null, 5, 28, 5 },
                    { 86, 4, 5, 3, 2, "Eos laboriosam veritatis commodi beatae eligendi earum dolores.", new DateTime(2023, 10, 14, 15, 32, 30, 710, DateTimeKind.Local).AddTicks(19), null, 7, false, null, null, 3, 13, 5 },
                    { 87, 2, 4, 5, 1, "Et libero nobis sint hic.", new DateTime(2023, 5, 29, 19, 12, 31, 288, DateTimeKind.Local).AddTicks(1892), null, 6, false, null, null, 4, 7, 3 },
                    { 88, 4, 5, 3, 3, "Aliquam minus alias.", new DateTime(2023, 4, 12, 21, 49, 32, 713, DateTimeKind.Local).AddTicks(5926), null, 10, false, null, null, 3, 22, 2 },
                    { 89, 2, 2, 5, 2, "Facilis iure ea ad.", new DateTime(2023, 9, 17, 18, 49, 26, 580, DateTimeKind.Local).AddTicks(7014), null, 9, false, null, null, 2, 23, 4 },
                    { 90, 2, 1, 1, 5, "Cum cum sed delectus autem.", new DateTime(2022, 11, 20, 13, 45, 45, 643, DateTimeKind.Local).AddTicks(4306), null, 8, false, null, null, 3, 19, 2 },
                    { 91, 5, 4, 3, 4, "Corrupti id et maxime numquam excepturi reprehenderit consequatur.", new DateTime(2022, 11, 15, 2, 34, 43, 248, DateTimeKind.Local).AddTicks(2568), null, 5, false, null, null, 5, 12, 5 },
                    { 92, 3, 4, 1, 5, "In possimus aut dicta corrupti sunt autem incidunt ab.", new DateTime(2022, 11, 30, 22, 45, 32, 138, DateTimeKind.Local).AddTicks(5430), null, 3, false, null, null, 2, 20, 1 },
                    { 93, 5, 3, 1, 5, "Hic aut praesentium a et.", new DateTime(2022, 11, 28, 9, 45, 44, 579, DateTimeKind.Local).AddTicks(1761), null, 2, false, null, null, 3, 23, 1 },
                    { 94, 1, 4, 3, 2, "Voluptates illum corporis ut blanditiis aut illum.", new DateTime(2022, 11, 23, 12, 33, 48, 627, DateTimeKind.Local).AddTicks(2406), null, 2, false, null, null, 2, 21, 4 },
                    { 95, 5, 5, 3, 4, "Quia architecto enim non ut modi enim et.", new DateTime(2023, 3, 5, 1, 14, 31, 257, DateTimeKind.Local).AddTicks(4614), null, 10, false, null, null, 3, 7, 4 },
                    { 96, 2, 3, 2, 1, "Amet alias ducimus et delectus rem.", new DateTime(2023, 8, 19, 17, 56, 58, 890, DateTimeKind.Local).AddTicks(5406), null, 2, false, null, null, 4, 29, 2 },
                    { 97, 4, 5, 2, 4, "Maxime fugit in doloremque mollitia nobis.", new DateTime(2022, 10, 22, 19, 46, 45, 988, DateTimeKind.Local).AddTicks(5922), null, 9, false, null, null, 5, 5, 5 },
                    { 98, 2, 3, 3, 1, "Aut assumenda et asperiores.", new DateTime(2023, 5, 30, 22, 31, 8, 2, DateTimeKind.Local).AddTicks(8130), null, 8, false, null, null, 3, 12, 2 },
                    { 99, 1, 5, 2, 3, "Et perferendis voluptatum consequatur libero sit.", new DateTime(2023, 1, 14, 14, 14, 13, 392, DateTimeKind.Local).AddTicks(3288), null, 10, false, null, null, 1, 4, 3 },
                    { 100, 2, 2, 3, 3, "Possimus numquam qui qui consequatur.", new DateTime(2023, 6, 22, 4, 55, 3, 448, DateTimeKind.Local).AddTicks(4820), null, 4, false, null, null, 3, 23, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "GuestReviews",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "HostReviews",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "PropertyReviews",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "HostReviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "GuestReviews");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036f45a7-5168-4f94-af72-bac6c19c462f", "AQAAAAIAAYagAAAAEBdCLQ3IJITyQsLQEQxF2aMeiVlV5kI8qvqlRVap4ArVTy4z8RBRA1L3NH2Tvm0Ufw==", "b813bdb7-f74f-4d4b-ac3a-14b296b0c5a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "38bf77a1-1b99-4565-af51-0f11a71ee05e", "Naomi_VonRueden77@gmail.com", false, "Zechariah Haley", null, "NAOMI_VONRUEDEN77@GMAIL.COM", "NAOMI_VONRUEDEN77@GMAIL.COM", "AQAAAAIAAYagAAAAEEJjjS+3xI8cOZNE626C19adaLrTpkxQsn10uhBfmoy9P81IRJ80V1Dyq5iqZ5wnwA==", null, "0c1652a8-6764-4e3d-b3b1-a24b20fce14c", "Naomi_VonRueden77@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "3b5337f1-8f09-47bf-aad8-429a18b8e70a", "Reymundo_Doyle59@gmail.com", false, "Julie Ward", null, "REYMUNDO_DOYLE59@GMAIL.COM", "REYMUNDO_DOYLE59@GMAIL.COM", "AQAAAAIAAYagAAAAEPPDqyvtjpeXR2/TkzQ1yJiXxlZaTQX7bUzPXadwkTuJYXrjnoc2PaRyZsa8vgORrA==", null, "d17ea102-8426-4958-a97a-bda102e4a101", "Reymundo_Doyle59@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "3f71ed9f-ee9a-455e-9b8b-e2ec62bcefe3", "Kaley53@gmail.com", false, "General Bahringer", null, "KALEY53@GMAIL.COM", "KALEY53@GMAIL.COM", "AQAAAAIAAYagAAAAEKv5e/kNifp3eZzUh6CAwe2D2UmwZy0pCkYwfabyq8mlh2/oCpSFIF/QT4zoH77aUQ==", null, "991afd7c-b0d3-447f-a632-bf953f7bf801", "Kaley53@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "8ccb5b3f-9dda-4968-89be-f13febd22dc0", "Robin.Borer51@hotmail.com", false, "Nasir McGlynn", null, "ROBIN.BORER51@HOTMAIL.COM", "ROBIN.BORER51@HOTMAIL.COM", "AQAAAAIAAYagAAAAEF6FVBdsd5suWJ25kv1pywheSmTGzslbrsk2CSuQiaAc0+yqjZ2kmy4PZB8kEoYOZw==", null, "48c0e053-a8f7-4b99-a729-1681557c64f9", "Robin.Borer51@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "ed2a07a2-0f48-4ccd-81c7-962f42fa5e0a", "Caleigh.Lowe4@gmail.com", false, "Else Daugherty", null, "CALEIGH.LOWE4@GMAIL.COM", "CALEIGH.LOWE4@GMAIL.COM", "AQAAAAIAAYagAAAAEFxiSALHLdBf929SuFvoEBPsskCj//ivPTh6OWpDf6TJqCn7RI91vIXSCyQ9pGeP3Q==", null, "f10e2440-2f3d-4442-8135-827957e74e69", "Caleigh.Lowe4@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "5a4f7c84-8a91-479c-85fd-65a7cc68697b", "Modesto.Konopelski17@hotmail.com", false, "Antonia Fisher", null, "MODESTO.KONOPELSKI17@HOTMAIL.COM", "MODESTO.KONOPELSKI17@HOTMAIL.COM", "AQAAAAIAAYagAAAAEIogWwWhy2Ey8midTW5MI3N2erb3aGig8NUUlRLOrPn8p30RixLRWREtKb19zs6dPw==", null, "0b43cabf-8bdf-4207-a677-76c9115d9b4e", "Modesto.Konopelski17@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "54d8e9df-679f-46ac-b178-7d6a2b688547", "Zoe34@hotmail.com", false, "Lelia Bode", null, "ZOE34@HOTMAIL.COM", "ZOE34@HOTMAIL.COM", "AQAAAAIAAYagAAAAEFsOClXl/urtYG2EfwSgtmI5zaehIfgsf60D9e7y86GGTkRV1bb4fTdnHhVM3au3Zg==", null, "c9f4889e-b59e-486b-a2df-6e126e99ab7f", "Zoe34@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "1bd74296-f57a-42c2-a4c3-c459ec781594", "Luella.Osinski9@hotmail.com", false, "Dorothea Pacocha", null, "LUELLA.OSINSKI9@HOTMAIL.COM", "LUELLA.OSINSKI9@HOTMAIL.COM", "AQAAAAIAAYagAAAAEF7wt1oMVhEtWbOAZkhAsJVpFQsao874l6xSNV+8R6VLh50ceNgaxgeRi5zjm9yEsg==", null, "a8add130-877d-4bb5-8d31-dc0413a33b66", "Luella.Osinski9@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "76aec6a9-76f4-4ef2-9682-6faee58c16f7", "Evalyn14@yahoo.com", false, "Ariel Bradtke", null, "EVALYN14@YAHOO.COM", "EVALYN14@YAHOO.COM", "AQAAAAIAAYagAAAAEAkyzKXkkygtQchiTYSorymCIkyx+KPEhEhE5A28Vz0KXTmID5yBPlO/garKOj4+4A==", null, "c3d85078-db4e-499b-8256-02ac197e5f02", "Evalyn14@yahoo.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Introduction", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { null, null, null, "8ee4fe28-fb6b-4b2f-87de-7ad18b85de12", "Maritza.Homenick@hotmail.com", false, "Tavares Turcotte", null, "MARITZA.HOMENICK@HOTMAIL.COM", "MARITZA.HOMENICK@HOTMAIL.COM", "AQAAAAIAAYagAAAAEA5rZS+jceullTmXGmPwNuQHERYuvEy9NBWzrFu29cDB1VNDQeKZ8lVoa3AxhiFS3g==", null, "d99ad7c7-537d-42fe-9bf3-b93a6f814cb5", "Maritza.Homenick@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), 19.213496733719026, 11, "Et aperiam dolorum dicta ut.", 5, 4, 90.708532732487313, 4, "Rejected", 14.735915652654002, 850.32620697875893 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), 18.477500537270437, 6, "Ut sapiente ea maiores porro dignissimos dolorum hic ratione.", 3, 0, 20.997852721672615, 5, "CancelledBeforeCheckIn", 14.10390142079714, 179.56637100977588 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), 15.240762960983609, 5, "Distinctio doloremque quia voluptatem deserunt deleniti nemo dolor et adipisci.", 3, 50.680924944851853, 4, 14.621042082740697, 333.94735471283542 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), 19.151038926599419, 7, "Id est cumque optio rerum earum et cumque dolorem hic.", 2, 4, 75.182113896691178, 25, "Confirmed", 20.190043289179343, 565.61587949261707 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), 14.774823540709718, 3, "Quidem qui qui est.", 3, 4, 89.999505848477853, 15, "Completed", 11.488693442558949, 926.25857546804718 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), 15.554051887522247, 5, "Rerum illum aut.", 3, 14.735413413564126, 26, "Rejected", 22.341429529809869, 52.630894830896239 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 15.455877482607198, "Soluta repellendus enim qui fuga eligendi nisi.", 1, 3, 71.013547343103966, 2, "Rejected", 23.924449947121389, 252.42096945904049 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), 21.682347034400976, 10, "Eum eos vel quidem quidem.", 3, 1, 17.106827468025728, 12, 11.045279508230426, 66.941281478682853 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), 18.159974769332763, 8, "Saepe culpa consequatur nisi velit rerum minus aliquam voluptatem.", 5, 3, 37.845040688144067, 3, 15.836600619194812, 147.5316974529598 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 24.448400603031509, 6, "Totam aut error sapiente.", 5, 5, 42.677848112099895, 2, 12.573231362114985, 463.80011308614547 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), 23.553093847565862, 3, "Id dolorem placeat officia aut.", 5, 22.48917381763092, "Pending", 10.554234525934239, 146.55319746165472 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 24.907202946199966, "Voluptatum quidem voluptatem aspernatur velit sit amet ut.", 3, 1, 90.403301878423335, 8, "Completed", 24.480567491071245, 501.40427982938792 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), 23.799839698531564, 3, "Laborum expedita velit totam qui incidunt.", 5, 69.434343090317171, 9, "Completed", 19.449892735226825, 459.85579097566142 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 16.69641504599279, 11, "Nemo voluptates aspernatur.", 4, 5, 48.10173570915817, 22, "Completed", 24.548578575094147, 185.55020074856145 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), 19.088321998091164, 9, "Voluptatem rerum repellendus autem provident qui qui nihil.", 5, 1, 75.998958088703404, 30, 23.50769898053321, 422.59081142214137 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), 16.712827178864391, 2, "Ipsum eos molestiae officia similique sapiente velit assumenda.", 1, 75.361989487055112, 21, "CheckedIn", 15.617379574879056, 409.14015418901903 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), 11.029683399218939, 5, "Sapiente eos quia porro ducimus.", 18.060962940280568, 28, "Rejected", 18.71936089673995, 101.99289605708117 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), 13.498123872125733, 6, "Soluta sint rerum et quae.", 48.458565581027116, 9, 11.755957120449214, 316.00547447873765 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), 14.402993149709467, 10, "Eum suscipit dicta quaerat voluptas consectetur.", 5, 1, 80.256655295042492, 30, "Completed", 22.997632941635516, 599.19721315664242 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 18.3401425591139, 10, "Ea quisquam labore nobis incidunt unde eaque modi sunt.", 83.005547027666523, 29, "CancelledBeforeCheckIn", 11.576993061161238, 693.96151184160738 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), 15.124070183376679, 5, "Modi quo sunt velit dolores incidunt esse et.", 1, 4, 44.002009443112591, 27, "CancelledAfterCheckIn", 22.03841097988693, 301.17453782193911 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), 12.348309669560763, "Ut ex molestiae iusto ut molestiae placeat ab.", 4, 5, 43.675941615570757, 18, "Rejected", 24.831533073536377, 255.55955082095093 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), 17.92318341760701, 9, "Animi sed vel excepturi corrupti possimus.", 2, 5, 32.117953404464465, 23, "Completed", 16.797324188444129, 163.192321223909 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), 16.116485821989151, 2, "Mollitia aut quaerat enim qui rerum enim suscipit sunt sed.", 4, 2, 62.433666053560621, 9, 21.533351945469747, 599.55283224950449 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), 17.569983056914332, 8, "Tempora ut autem doloribus dicta assumenda rerum enim deleniti quas.", 2, 3, 59.177619159053826, 3, 10.834182405598561, 205.93702293967439 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), 17.891812563654931, 11, "Facilis quia et nobis non perspiciatis eaque totam natus.", 1, 3, 57.958948645414459, 7, "Completed", 24.91532788469512, 332.6018836754223 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), 23.45613471336662, 6, "Eaque dolor earum placeat placeat iste placeat rerum.", 2, 4, 94.148671462648181, 1, "Completed", 13.06534404628735, 789.71085046083942 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), 19.973800093148441, 11, "Perspiciatis totam sit consequatur.", 5, 1, 98.640732609516078, 29, 10.381577423176681, 424.91830795438943 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), 24.388674316983106, 10, "Eos consequuntur officia dolores qui beatae iste enim maiores.", 5, 13.864964344514465, 4, "Completed", 14.678775898438117, 80.662343248964618 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), 23.325633527118718, 5, "Similique et laborum commodi dolor est.", 3, 1, 74.343646999318139, 13, "CheckedIn", 13.156062009072746, 333.85628353346402 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), 24.868117985366176, 10, "Dolores adipisci commodi quo aliquam ullam ducimus quo earum porro.", 3, 3, 51.590148630126478, 28, "Completed", 11.937155271662578, 139.98557051728173 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), 19.17470585722824, 5, "Cupiditate cupiditate nemo excepturi provident aut rerum quis.", 2, 5, 52.056619593164356, 19, "CancelledAfterCheckIn", 21.307680234229384, 92.539005684621984 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), 22.824908955591546, "Quia repudiandae aut maxime a.", 3, 0, 30.06375625671852, 30, "Completed", 22.924309507542063, 166.0042434900077 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), 15.401413138980098, 2, "Inventore explicabo molestias aut nihil voluptatem harum quibusdam modi.", 5, 49.776932045527474, 19, "Pending", 10.677721042721736, 374.51765850039413 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), 12.642138692861622, 3, "Eos aut ut.", 1, 3, 40.745337718657346, 2, "CheckedIn", 15.35144837777726, 272.465613382583 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Utc), 18.642409313275515, 9, "Et et et autem nemo similique et aut fuga.", 4, 2, 53.938365301614496, 7, "CancelledAfterCheckIn", 13.398174557997526, 139.91731447450204 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), 15.913598167079597, "Incidunt suscipit id at esse et ad exercitationem aut.", 5, 63.986394849901359, 23, "Completed", 16.460567221307006, 480.27892933769618 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 14.747158499174201, 3, "Et pariatur consequatur aliquid voluptatem qui voluptatem.", 3, 5, 96.708394460119649, 25, 20.904416830040745, 132.3599697893346 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), 13.972725998350867, 9, "Aut illum ullam voluptas rem laboriosam culpa.", 2, 5, 12.350217751766285, 6, "CheckedIn", 10.034495442252723, 110.45874570296759 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 15.250429045485513, 4, "Tempora expedita impedit culpa a ut.", 5, 0, 94.768188990709433, 8, "Completed", 19.93164462643233, 224.7184516533367 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 13.416433375582255, 7, "Et non distinctio ut similique nisi assumenda consequatur.", 4, 32.030340473611759, 29, "Rejected", 21.213757151123936, 162.75155242115321 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), 14.850564999089691, 4, "Non maxime iusto laboriosam tempore excepturi quae eius laborum.", 4, 2, 98.500627456933159, 4, 21.065698859215065, 528.41940114297051 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 23.497882324665703, 2, "Aliquam deserunt nostrum dolorem ullam qui doloremque est quo.", 5, 0, 18.593643704919629, 27, 16.76778057071602, 226.20209994457801 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), 15.852318200256464, 7, "Velit amet dolorem.", 5, 1, 88.998992696872591, 12, "Rejected", 11.691203115628047, 116.5425140127571 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Utc), 23.763742076517147, 2, "Et rerum qui et sunt.", 2, 1, 91.701753995502401, 30, 10.034007827586146, 400.60476588611289 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), 10.026251844517203, 6, "Corrupti aut quaerat est.", 2, 2, 69.093190809487069, 20, 21.110314528934516, 445.69571123037417 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), 13.250617588675004, 4, "Tempore fuga vel dolore ex.", 5, 2, 94.589720679493908, 22, "Completed", 11.678300988132285, 119.51863925630119 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), 21.82182750489903, 10, "Ipsam consequatur earum non cumque nam cupiditate voluptatem quisquam nihil.", 2, 2, 84.421413320136423, 25, 20.313562337998889, 126.55680316303435 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), 14.912363236387822, 10, "Ut optio unde dolores repellat incidunt qui.", 5, 3, 11.568721094497254, 20, "CancelledAfterCheckIn", 21.390917217393, 71.009443737272576 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), 17.046256882595749, 8, "Labore animi aperiam culpa quis rerum explicabo est.", 2, 2, 23.721746302865327, 2, 19.06382929108738, 130.99707138514444 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), 16.248838938725502, 5, "Aut tempore possimus et voluptatem quaerat.", 2, 5, 79.524404211078576, 12, 10.43146009769349, 424.30232009181191 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18.88401370669196, 4, "Praesentium animi est architecto et unde.", 1, 80.982979558941963, 11, "CancelledBeforeCheckIn", 11.018404886058278, 272.85135726957617 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), 17.345640945401712, 8, "Ea et doloribus mollitia eius.", 1, 3, 73.233533701651794, 30, "Completed", 24.840726107527708, 481.58756926284019 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Utc), 23.065464826220989, 4, "Ut saepe iure illum dolor recusandae molestiae expedita.", 3, 1, 35.043170841670062, 13, "Confirmed", 14.158287232857123, 282.52594795076851 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), 14.73728496338201, 6, "Dicta dolor rem tempore numquam quos.", 4, 0, 75.721707285637137, 11, "Completed", 12.870564078835748, 481.93809275604059 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 13.83284025134718, 5, "Aliquid maxime laboriosam ea quae quis molestiae consequatur aut.", 3, 2, 78.352349824667215, 2, "CancelledBeforeCheckIn", 13.591104285470875, 497.53804348482134 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), 17.83999627751129, 10, "Perferendis ducimus odit aliquam eaque incidunt ut.", 1, 3, 11.908401745290814, 13, 12.829051867928587, 102.11945861718475 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), 19.778465795768511, 8, "Et quo adipisci quo autem sunt.", 4, 0, 66.861309938701751, 5, "Confirmed", 17.651879894662628, 639.18213513874696 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), 21.476881996085275, 11, "Necessitatibus dolor qui.", 1, 2, 42.93158948390095, 18, "CheckedIn", 17.963346098532266, 382.89294396582517 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), 16.562889076210258, 3, "Odio quidem voluptas libero dicta aliquam necessitatibus.", 4, 0, 62.04432677259431, 20, "CancelledAfterCheckIn", 15.695177472741666, 280.43537363932916 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), 16.88487595255032, 2, "Consequatur quos exercitationem in.", 5, 3, 86.64035599530618, 17.026162004158149, 553.75317392854549 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), 10.954496124798375, 4, "Et ipsam esse expedita voluptatem nihil error dolore magnam ea.", 4, 2, 40.430044851989791, 23, "CancelledBeforeCheckIn", 16.641852832653562, 229.74657321740091 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), 17.409689147982228, 9, "Similique ut autem quia a.", 75.53556947593367, 15, "Completed", 10.053494052493297, 254.06989162827654 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 13.825076916452431, 11, "Beatae sed dolorem sed molestiae nemo.", 5, 51.849214966465247, "Completed", 23.085359048668742, 348.00572576391266 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), 10.257722835211529, "Aut maiores sit incidunt ut.", 4, 1, 42.742346590130069, 14.120648277446714, 366.31714383369882 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), 22.405555745978234, 8, "Quis voluptatem corrupti.", 5, 4, 60.960050464930283, 8, "Completed", 13.39736884691221, 96.762975057820725 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), 12.108798029936613, 11, "Aut eveniet quia tempore voluptas tenetur sint.", 4, 91.588927648720542, 21, 11.181938618902096, 572.82430254116196 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), 20.332113599811265, 7, "Rerum minus exercitationem ducimus ut voluptatem enim sit.", 3, 65.607714880569404, 4, "Rejected", 21.056282238477309, 631.85782976341306 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 12.618565873885068, 2, "Est veritatis illo est.", 3, 0, 88.183168513132443, 25, "Rejected", 14.752005148120071, 732.83591912706459 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), 10.172258385101484, 2, "Sed aut quia ut aliquid esse atque provident atque ducimus.", 5, 4, 55.114347940870431, 19, 15.014837687023746, 355.87318371734784 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), 14.776252611021411, 8, "Tempora sed amet.", 3, 26.289072628041588, 21, 17.248764976026251, 242.33759861138037 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), 19.401393817161416, 10, "Saepe eligendi repellat nobis quia natus voluptates vel.", 2, 78.382808703764354, 18, 17.508815879244381, 115.29301840017015 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), 24.02105378381922, 7, "Qui accusantium praesentium architecto.", 1, 4, 53.423890689486669, 12, 13.20887273679196, 197.50159858907119 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 14.22293969943911, 8, "Quia iure ipsum.", 1, 2, 29.084406506961326, 14, "Confirmed", 20.098229002822549, 150.65879473010699 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 12.754769942269951, 8, "Sed voluptate modi dicta dicta beatae enim aperiam ea qui.", 5, 5, 96.953047637606545, 10, "Confirmed", 11.468939287983476, 412.03589978067959 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 18.818398882177966, 11, "Neque quisquam saepe exercitationem qui minus.", 1, 4, 45.497363445302796, 19, 15.495804134428729, 443.79047402433184 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), 14.377945997394962, 4, "Dignissimos dolorum animi eum et quam similique.", 2, 5, 93.739381254872427, 28, 17.946802121078349, 875.97917941232515 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), 17.008878497672942, 6, "Natus et dolore beatae quo.", 2, 44.082017592086906, 4, 12.863909852892338, 294.36489390308668 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), 21.688879480754885, 11, "Sit et et ad quidem ea quas consequatur expedita qui.", 5, 4, 86.661969493082935, 16, "Completed", 17.721318400404407, 906.02989281198859 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), 16.034352129860284, 2, "Tempore ut et et.", 5, 15.32359039504842, 23.698828345239345, 192.96908442558384 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), 12.085181262327094, "Rerum quis omnis repudiandae magni aliquid omnis delectus nobis illum.", 5, 63.686316118224468, 30, "Confirmed", 14.121513521697771, 472.01090761159611 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 11.251654251871873, 11, "Sed tempora et fuga accusantium cum et odit.", 4, 4, 44.94310774549254, 22, 19.985733053375917, 480.66846476017315 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), 15.533266933498894, 10, "Et asperiores molestiae ea ut molestias aspernatur quas sed.", 45.885734836543236, 25, 14.284393922431171, 259.24633503864624 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), 12.204193920068082, 9, "In ea magnam omnis recusandae.", 1, 3, 63.11031035457556, 27, "Completed", 10.159933656397062, 653.46723112222071 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), 17.634384452991842, 10, "Quo et vitae sit et voluptas cum.", 5, 4, 95.567288260983787, 7, "Completed", 10.090171478189404, 983.39743854101914 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Utc), 15.254856716984461, 9, "Ab natus vel quo illum ut quaerat modi illo praesentium.", 2, 10.514806784912887, 4, "Completed", 15.365620762518766, 83.194511404067669 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12.629339697520724, 11, "Temporibus fugit cum.", 5, 5, 87.016249989142182, 1, "Completed", 22.179526957609347, 556.90636658998324 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), 24.402586990771653, 6, "Quae sunt quae.", 4, 3, 63.054105655941385, 10.869658933184091, 161.38045723583852 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), 23.156179279040508, 4, "Adipisci quia ut quidem quidem eveniet ipsa sed numquam ducimus.", 1, 5, 37.913413006587263, 10, 11.544823557742781, 300.09489388289416 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), 14.289481706368695, 9, "Ut maxime delectus libero sapiente voluptas pariatur ipsa cum.", 4, 2, 31.637257439882244, 22, 22.323878654749578, 68.250617801000516 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11.78768309026254, 5, "Officiis aut sequi vitae quia cupiditate quos architecto.", 3, 60.220382062404695, 14, "Completed", 22.319377316889454, 576.09049896879435 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 13.73672387893075, 7, "Culpa dolore ducimus in.", 5, 3, 18.946116633081388, 23.400773050289722, 169.76031336079021 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), 24.280051388048122, "Quidem iusto quas eum ea.", 3, 18.008980242431729, 17, 18.292897185542117, 96.599889300885422 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), 15.45383381591293, 5, "Ut est ea nobis ut doloribus magni.", 1, 0, 26.821443735402358, 11, 23.183277947470778, 119.10144296959078 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), 18.609206831481092, 6, "Quis et sint facilis id aut.", 5, 1, 38.359978527748055, 27, 18.381080580270893, 113.71024446724809 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), 20.908393579735076, 10, "Libero aut accusamus corrupti.", 0, 67.626987750392658, 15, "Confirmed", 23.936812886466484, 315.35315746777218 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[] { "Flexible", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), 11.379780298411097, 4, "Ut ut qui sed minus sit ut necessitatibus voluptatem.", 4, 2, 10.492788220659728, 28, "CancelledBeforeCheckIn", 19.000668486499713, 40.873237005570537 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 16.430469139605894, 4, "Eos unde quasi ipsam labore.", 3, 0, 74.305618236589396, 26, 19.347084004934246, 778.83373551043405 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), 17.031623343333887, 5, "Facilis sunt error sint dolores.", 3, 3, 23.03358545772441, 23, 17.924577522860119, 219.22488452798927 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CancellationPolicyType", "CheckInDate", "CheckOutDate", "CleaningFee", "GuestId", "Note", "NumberOfChildren", "PricePerNight", "PropertyId", "SystemFee", "TotalPrice" },
                values: new object[] { "Strict", new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), 23.616885844479949, 11, "Quibusdam ipsam ut odit sint.", 4, 78.439006624160584, 9, 18.011786236882084, 355.38469857800436 });

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "834 Shania Courts", 3, 3, 7, "Schimmelstad", 96.397905526645374, "Voluptatem inventore quos quod mollitia sapiente. A vero soluta et velit dolor officiis ullam. Architecto omnis rerum natus consequuntur consequatur temporibus rerum. Excepturi aut in. Qui cupiditate iste rem et et veniam debitis debitis sit. Dolorem facilis unde neque eaque.", 3, 0.93320000000000003, 49.951999999999998, 1, 94.093539705691356, 3, "Cum dolores et dolor et atque aut aliquid repellat qui incidunt porro facere tempore aut." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "24153 Beatty Crossing", 6, "South Irwin", 91.210653040377068, "Blanditiis delectus corporis beatae est. Enim reprehenderit vel molestias et quibusdam natus nostrum placeat dolores. Quos temporibus modi modi quibusdam aspernatur ut quasi rerum. Et dolores repellat neque reprehenderit. Architecto numquam numquam quibusdam excepturi reprehenderit.", -28.671900000000001, 43.770299999999999, 2, 2, 52.726442684773438, 3, "Quod explicabo laborum aut repellendus nesciunt aut adipisci ea non ut et repudiandae ut aliquam ut nobis deserunt rerum ut ipsum facilis aut consequatur ipsa quia." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "88601 Franecki Bridge", 3, 4, "Flexible", "Gradymouth", 15.615963874032923, "Aut earum id atque dolor sequi et consequuntur qui. Modi dolorem ut. Qui mollitia ut commodi sed quibusdam et. Officiis quam voluptas in praesentium. Iusto quidem libero nesciunt aut et error velit quasi.", 4, -47.374899999999997, 74.870400000000004, 10, 47.540402317271493, 2, "Tempora omnis veritatis et temporibus veniam molestiae cum quam aut beatae nam vero eius adipisci et assumenda sint ad laboriosam temporibus qui eius quod.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "31442 Liza Port", 2, 1, 2, "Isobelview", 67.3435171732649, "Tempora qui molestiae. Ut et error. Neque molestiae nihil est aperiam adipisci consequuntur iste temporibus.", 2, 68.683800000000005, -132.065, 9, 2, 80.588447694413958, 1, "Eveniet autem voluptas quidem vel labore perspiciatis est animi quibusdam occaecati aliquam consectetur enim.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "585 Oscar Keys", 2, 5, "Flexible", "East Maximillianview", 87.934445308564818, "Quas vel consequatur quasi vel est nesciunt. Dignissimos modi quod natus quo consequuntur. Aut voluptatem fugit cupiditate commodi. Necessitatibus nobis velit rerum doloremque rerum.", 2, -70.149100000000004, 100.5055, 4, 10, 85.57937917318624, "Qui sit quod earum incidunt est aut laborum illo veniam voluptatibus asperiores eos perspiciatis eius ab qui vel mollitia consequuntur eum nemo ea sed nihil quisquam nisi qui placeat.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "3961 Lyla Lake", 2, 2, 7, "North Hardy", 86.549249823892282, "Tempore omnis dolores ipsam ullam ad laboriosam. Voluptatem architecto voluptas qui ea ratione excepturi non neque. Ducimus libero numquam illum voluptates doloribus est excepturi et.", 5, 73.488699999999994, 46.508200000000002, 4, 8, 24.97399102950498, 1, "Accusamus assumenda non eaque inventore odio dolore laboriosam sint non aut earum neque tempore omnis dolores ea autem repellat molestias atque eaque sit.", "Cabin" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "1863 Kyle Mills", 2, 5, "Flexible", "Port Ryannburgh", 19.418030815379289, "Qui accusamus reiciendis pariatur aspernatur. Doloremque quas odio cupiditate enim reiciendis. Nostrum ut dolores aut voluptate qui. Neque voluptas autem a.", 1, -48.328600000000002, 37.602899999999998, 6, 4, 74.479143489378004, 2, "Necessitatibus blanditiis quo magnam voluptatem modi magnam iusto iure exercitationem laboriosam officia.", "HomeStay" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "1650 Fritsch Drives", 3, 3, 8, "Generalstad", 58.456841203052853, "Ipsum et molestiae ut minima iste suscipit recusandae enim nostrum. Cupiditate non cumque. Sit aut perferendis voluptatem debitis. Qui vel rem officiis sed. Illum nisi eveniet tempora corrupti omnis. Et odio vel dolores a.", 2, -2.9971000000000001, 27.545300000000001, 8, 4, 46.485608393020932, "Commodi quo dignissimos aut voluptas ratione modi quod facere ad iste omnis neque dolor provident perspiciatis sunt praesentium id qui deserunt beatae est.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "672 Hoppe Cove", 3, 2, 7, "Port Gayle", 14.556572562477761, "Ea fugiat id. Voluptatum eos fugiat et officiis cumque. Explicabo necessitatibus velit placeat at illum. Blanditiis repellat omnis rem occaecati aut ipsa. Voluptatem tenetur ut enim officia velit nesciunt. Nesciunt voluptates consequuntur esse.", 2, -82.592399999999998, -17.052600000000002, 6, 9, 57.990022844009097, 3, "Animi praesentium laborum rem quam harum vero ipsam architecto fuga vel recusandae non reprehenderit commodi expedita quam et explicabo cupiditate." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "68893 Price Terrace", 3, 6, "Crooksville", 86.230841793975515, "Ut fugit distinctio voluptas vel omnis ut. Veniam et ut suscipit veritatis harum quia culpa. Quam ducimus maiores explicabo et.", -12.7827, -175.97389999999999, 8, 4, 99.79160980012108, 1, "Ut necessitatibus fugit et hic similique alias est est accusamus sit dolorem aut nihil magni animi quia numquam distinctio est.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "83103 Trace Oval", 3, 5, 2, "Armstrongchester", 91.213244091227594, "Est fugiat magnam id aut. Est est aut consequatur voluptatem optio impedit quia. Aut nulla qui eum nihil voluptatem doloribus ipsum repellat cumque.", 5, -4.0301999999999998, -23.863800000000001, 5, 60.327633828544407, "Voluptatibus rerum accusamus nulla esse nesciunt sed similique ex est aut unde.", "HomeStay" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "PricePerNight", "Title", "Type" },
                values: new object[] { "99620 Iva Vista", 3, 3, 2, "Baumbachbury", 30.635263713117197, "Culpa repudiandae dolorem qui. Aut aliquid sed est unde dolorem molestiae quae est debitis. Ducimus dolores possimus sed voluptatem accusamus. Reiciendis nesciunt hic rerum assumenda et quam et.", -56.917200000000001, -13.6868, 29.996882856001108, "Mollitia nam nostrum totam doloribus vel officia et facere provident animi expedita mollitia libero quo perspiciatis iste earum non doloribus ex debitis dolore et a deleniti.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "BedCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "2917 Pacocha Ridges", 1, "West Keenanfort", 21.324492956323226, "Voluptatem nihil molestias. Magni est sit pariatur at perferendis est qui. Quos id in tempore iste laboriosam.", 3, -52.877600000000001, -123.268, 4, 2, 46.29191459992019, "Dolorum et rem et delectus fuga perferendis optio similique et qui quam accusantium fuga omnis provident esse consequuntur earum sed.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "28646 Rhea River", 1, 1, "Lake Candida", 94.467584143227597, "Consequatur consequuntur vel et qui est laudantium. Labore libero est exercitationem maxime et quisquam quasi. Saepe eos dolores deserunt nisi dolores. Rerum laboriosam aspernatur. Eum accusamus laboriosam nihil et incidunt ullam numquam magnam. Nostrum deleniti possimus nesciunt eos velit repellendus aspernatur.", 5, -15.116400000000001, 49.319099999999999, 10, 6, 21.570023084564106, 2, "Quia est aut voluptatum cupiditate tenetur id numquam qui rem rerum ipsum illum delectus aspernatur autem sed dignissimos.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "90489 Corwin Trafficway", 1, 3, "Flexible", "Michaelaside", 31.308998107023665, "Iusto at est ducimus rerum et. Reprehenderit molestiae fuga vero. Eum ea distinctio sit consequatur quasi magnam sed tempore.", 5, -9.0803999999999991, -61.757399999999997, 3, 7, 52.646005090979664, "Sint expedita enim nisi eligendi tenetur voluptatem reiciendis nihil quas dolores officiis sunt est nemo in doloremque quo sint impedit quis voluptas quaerat veritatis.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "BathroomCount", "BedCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "02335 Orn Mall", 3, 2, "Yundtshire", 74.050003139864174, "Iste dolor error ratione hic. Doloremque impedit rerum adipisci cumque. Harum exercitationem et ut ut et quia impedit ut. Aspernatur ratione maxime ut veritatis voluptatem ut corrupti corrupti.", 1, -15.8956, 107.39570000000001, 3, 4, 72.310199148351018, 2, "Minima rem quis nisi beatae qui ut numquam neque est dignissimos non ipsa.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "29751 Griffin Vista", 4, "Strict", "New Maegan", 70.799646244132646, "Saepe velit recusandae iste cum. Quam non modi voluptatem debitis aperiam quibusdam voluptatem dolorem. Et ea voluptatem id et aut facilis dolorem illo ipsum.", 5, -49.408900000000003, 2.6576, 10, 1, 25.805972391453732, 3, "Ut occaecati commodi rerum at veniam quas nisi harum fugit illum ducimus harum autem sit officia quia ratione eveniet quae molestiae eligendi sapiente.", "Room" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "1989 O'Keefe Springs", 2, 5, 4, "Strict", "Wisokystad", 64.975090567311071, "Enim eos id quia reprehenderit consequatur molestiae similique. Inventore fuga ipsum. Qui voluptatem ut nobis facere harum maiores fuga harum.", -12.7537, -130.95160000000001, 9, 5, 81.550133281727497, "Eligendi in asperiores ut neque magnam tempore repellendus quae labore mollitia et.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "BathroomCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "74809 Austin Forges", 1, 1, "South Joseberg", 99.358112221387458, "Voluptate blanditiis expedita doloribus rerum cumque vero voluptates. Sint repudiandae voluptate eaque aspernatur distinctio. Fugiat facere laudantium consectetur minus non odio nihil numquam. Rerum esse explicabo voluptatum. Porro asperiores dolores sunt animi consequatur eaque.", 2, -86.432900000000004, -4.4965999999999999, 6, 56.658037721726025, 3, "Ex excepturi qui alias quidem commodi voluptatem assumenda reprehenderit rerum dolorem at et exercitationem voluptas explicabo alias commodi sed quasi sunt itaque ut amet voluptates ea.", "Villa" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "274 Grady Mount", 1, 5, 4, "New Myrticetown", 52.439285435502363, "Officia quisquam et voluptatum et dicta magnam. Dolorum asperiores accusamus amet quam. Dolor unde assumenda fugit dolorem corporis. Velit eligendi repellendus corrupti occaecati consectetur aut et suscipit commodi. Nam a delectus mollitia ut optio hic molestiae.", 2, -73.406099999999995, -108.6386, 7, 1, 15.665447837096199, "Est ipsum nesciunt omnis et occaecati expedita sed quisquam quo et aut reiciendis reprehenderit voluptatum est quis eius rerum quidem similique tempora quaerat iusto laudantium ut modi cupiditate.", "Room" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "9724 Aisha Inlet", 3, 3, 3, "Graycehaven", 49.673659768410097, "Sunt et vel cumque esse sunt. Et voluptas mollitia molestiae sed porro vel exercitationem est tempora. Voluptatem optio et. Nihil perspiciatis vitae necessitatibus. Amet et cumque qui qui aut voluptatem illo voluptates sed.", 1, -7.9928999999999997, -98.776499999999999, 4, 8, 50.619899655376372, "Repellendus inventore reprehenderit unde eaque et ea aut incidunt possimus animi dolorem fuga ullam officia labore praesentium temporibus excepturi porro neque voluptas ad inventore.", "Resort" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Address", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "79385 Schimmel Crescent", 1, 8, "Flexible", "Kerlukestad", 49.404182107799969, "Cumque corrupti est earum ex ut cumque ipsa. Optio qui porro quidem suscipit quibusdam. Nemo magnam beatae commodi error consequuntur optio. Ullam ea minima vel qui qui qui ea voluptatem. Laborum enim quibusdam et voluptatem fuga eligendi. Exercitationem necessitatibus maxime dolor vero ducimus et necessitatibus nulla.", 3, 53.508400000000002, -33.0929, 10, 3, 83.177698658326918, 3, "Asperiores libero delectus adipisci exercitationem voluptatem aut et iusto vel repellat ea sed saepe illo voluptatibus deleniti veritatis.", "Apartment" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Address", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "690 Sofia Crescent", 5, "Strict", "Greenholtfort", 27.857208213770154, "Qui eveniet veniam quia et. Et ut possimus non et nostrum molestiae minima. Quos dolor sed deserunt.", 4, -18.3597, -130.71299999999999, 8, 9, 88.344829128616411, 3, "Nisi illo error aut ipsa non qui assumenda porro animi esse et quia voluptatibus ratione corrupti sed cupiditate deserunt.", "Room" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Address", "BathroomCount", "BedCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "092 Deja Plaza", 2, 2, "Flexible", "North Torreyshire", 93.453837302735664, "Maiores quidem est et reiciendis est. Officiis itaque accusamus delectus. Neque sunt animi in voluptatibus iure vero libero sint doloribus. Ab cum animi esse expedita tempora velit rem quisquam blanditiis. Sint cum quis non vel et quia.", 4, 84.964100000000002, -81.782899999999998, 3, 1, 14.022153592557832, "Tempora ea dolor autem dolores sit at ducimus commodi neque architecto dolore voluptatem provident atque autem ut eligendi corporis at tenetur officiis voluptatem consequatur et aspernatur quia.", "Resort" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "62275 Immanuel Canyon", 2, 4, 7, "New Faustinotown", 69.354287516420015, "Qui quo et illum odit sit nostrum minima facere repellendus. Necessitatibus ut facere mollitia nobis. Officiis soluta voluptas voluptas nisi voluptas esse debitis consequatur. Cum ex non eos. Qui impedit sapiente eum qui quis sint dolorem repudiandae.", 3, 70.867599999999996, 165.86340000000001, 8, 6, 19.201112768562325, 1, "Consectetur illum consequatur aut hic voluptatem optio non minima nemo suscipit ratione repellendus officia doloremque delectus quas est ipsa eligendi culpa et in voluptatem delectus eligendi." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Address", "BathroomCount", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "86955 Mills Highway", 1, "Ernserland", 76.934061467395409, "Ea iure quam vel sit mollitia. Ducimus ea voluptate fugit laborum nisi eum sequi quo. Voluptatum doloremque fugiat delectus. Repellat mollitia unde autem praesentium nisi dolorem dolorum.", -9.3667999999999996, 126.6152, 1, 5, 31.652852414552893, "Distinctio error quis praesentium sint officia eveniet natus commodi omnis sunt quis eum cum quis aut enim illo sit iure sed id.", "Hotel" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Address", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title" },
                values: new object[] { "37662 Ariel Prairie", 2, 2, "Flexible", "North Addisonbury", 76.923186568049573, "Quaerat aut et perferendis laudantium id libero tempore corporis. Debitis atque quam autem earum corporis. Dignissimos occaecati eius dolorem ex et corrupti enim. Corporis eum eveniet optio dignissimos beatae voluptatum aut fugit. Molestiae veritatis qui.", 5, 26.727799999999998, -86.696799999999996, 6, 3, 18.136174961492209, 3, "Velit sunt vel quasi totam fugit ab totam enim esse iusto iure dignissimos qui sit est voluptas quos." });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "Description", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "196 Brown Canyon", 3, 3, 4, "Strict", "Helgaside", 55.163791524797865, "Culpa ipsum sunt. Inventore omnis molestias ipsam sit quod libero aut. Voluptatem est tempore mollitia veniam iusto. Nemo nihil in quidem. Animi voluptate nisi quo suscipit excepturi.", -38.8155, 32.218299999999999, 8, 5, 42.164312426415883, 1, "Laborum aliquam laboriosam dignissimos odit eveniet nam nostrum optio debitis consequatur minus accusantium corporis nihil voluptatem fuga voluptatem consectetur officiis quaerat qui expedita ducimus.", "HomeStay" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Status", "Title", "Type" },
                values: new object[] { "08616 O'Conner Valley", 1, 5, 6, "Port Danielle", 59.90686624315483, "Dignissimos natus autem qui nobis. Aliquam ullam dicta hic dolores. Ratione ab cupiditate laborum molestias. Provident sunt rerum ab excepturi soluta id. Voluptatem tempore iure similique. At quia vel ea illo quis qui.", 1, -43.496099999999998, 167.26920000000001, 3, 7, 94.476946284330708, 2, "Et dolore voluptatem nemo eius consequatur autem est eligendi eos optio ea et rerum libero eligendi dolores qui dolorem rerum cumque accusantium enim quia sunt debitis quisquam.", "House" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Address", "BathroomCount", "BedCount", "BedroomCount", "City", "CleaningFee", "Description", "HostId", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "Title", "Type" },
                values: new object[] { "2050 Moen Forest", 2, 1, 1, "Karlshire", 76.618184457322101, "Nostrum nesciunt dolor autem. Eveniet ipsam ducimus repellendus perspiciatis sed illum dolores. Eaque corrupti necessitatibus quo accusamus nesciunt soluta praesentium odio tempore. Aut necessitatibus repudiandae blanditiis odit corporis sapiente fugiat. Omnis quibusdam non recusandae minus eius.", 1, -68.201999999999998, 96.790999999999997, 6, 3, 81.956888353057209, "Quasi soluta nemo assumenda quo illo consectetur ipsa delectus ut dolores eveniet et impedit ut dicta neque sequi corporis.", "Room" });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { true, true, true, false, false, true, true, false, true, true, true, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsBar", "IsBeachFront", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsRoomService", "IsSeaView", "IsSpa", "IsSwimmingPool", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, false, true, false, false, true, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsBar", "IsCamperFriendly", "IsGym", "IsLandmarkView", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsTv" },
                values: new object[] { false, false, false, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsSeaView", "IsSpa", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { false, true, false, true, true, false, false, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsBar", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsGym", "IsKitchen", "IsLakeView", "IsLaptopFriendlyWorkspace", "IsSecurityCamera", "IsSpa", "IsSwimmingPool", "IsWifi" },
                values: new object[] { true, false, false, false, false, false, false, true, true, false, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsRoomService", "IsSeaView", "IsSpa", "IsTv" },
                values: new object[] { true, true, true, false, false, true, false, false, false, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, true, true, false, false, true, true, true, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsHotWater", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSeaView", "IsSecurityCamera", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, true, false, true, false, false, true, false, false, false, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IsBeachFront", "IsCamperFriendly", "IsElevator", "IsHotWater", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsSecurityCamera", "IsSwimmingPool" },
                values: new object[] { true, true, false, false, false, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSecurityCamera", "IsWifi" },
                values: new object[] { true, true, true, true, false, true, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsTv" },
                values: new object[] { false, false, true, true, false, true, false, false, true, true, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, false, false, true, true, true, false, true, false, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IsBreakfast", "IsKitchen", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, false, false, true, true, false, true, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool", "IsWifi" },
                values: new object[] { true, true, false, false, true, true, false, true, true, true, true, true, true, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsLandmarkView", "IsSeaView", "IsSecurityCamera", "IsSwimmingPool" },
                values: new object[] { true, true, true, true, false, true, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsLandmarkView", "IsRoomService", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { true, true, false, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsGym", "IsHotWater", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { false, true, false, false, true, true, true, true, true, true, true, false, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsSeaView", "IsSwimmingPool", "IsWheelchairAccessible" },
                values: new object[] { true, true, true, false, false, true, true, true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsCamperFriendly", "IsGym", "IsKitchen", "IsMountainView", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { true, false, true, false, false, true, true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsCamperFriendly", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsLaptopFriendlyWorkspace", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, false, true, false, true, false, true, false, false, false, false, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "IsAirConditioning", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsMountainView", "IsSecurityCamera", "IsSpa", "IsTv" },
                values: new object[] { true, false, false, true, false, false, true, true, false, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsHotWater", "IsLakeView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSpa", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { true, false, true, true, false, true, true, true, false, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSecurityCamera", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { true, true, false, false, false, false, false, false, true, true, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsSecurityCamera", "IsSwimmingPool", "IsWifi" },
                values: new object[] { true, false, false, false, true, true, false, true, false, true, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "IsBeachFront", "IsCamperFriendly", "IsGym", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsRoomService", "IsSecurityCamera", "IsSpa", "IsWheelchairAccessible" },
                values: new object[] { true, true, false, true, true, true, true, false, true, true, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "IsAirConditioning", "IsBar", "IsBeachFront", "IsElevator", "IsHotWater", "IsLakeView", "IsLandmarkView", "IsMountainView", "IsSwimmingPool", "IsTv", "IsWifi" },
                values: new object[] { false, true, false, false, true, true, true, true, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "IsBar", "IsBeachFront", "IsBreakfast", "IsElevator", "IsHotWater", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSeaView", "IsSpa", "IsSwimmingPool" },
                values: new object[] { false, false, true, false, true, false, false, false, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IsAirConditioning", "IsCamperFriendly", "IsElevator", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsSecurityCamera", "IsSpa", "IsTv", "IsWheelchairAccessible" },
                values: new object[] { true, true, true, false, true, true, true, true, false, false });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "IsAirConditioning", "IsBar", "IsCamperFriendly", "IsElevator", "IsGym", "IsKitchen", "IsLandmarkView", "IsMountainView", "IsRoomService", "IsSecurityCamera", "IsSwimmingPool", "IsWheelchairAccessible", "IsWifi" },
                values: new object[] { false, true, true, false, true, false, true, false, true, false, true, false, true });

            migrationBuilder.UpdateData(
                table: "PropertyAmenities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsElevator", "IsGym", "IsHotWater", "IsLakeView", "IsMountainView", "IsRoomService", "IsSeaView", "IsSpa", "IsTv" },
                values: new object[] { true, true, false, true, false, false, false, false, true, false, false, true });
        }
    }
}
