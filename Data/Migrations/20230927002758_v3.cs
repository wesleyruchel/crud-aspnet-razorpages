using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_aspnet.Data.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               INSERT INTO Groups (Name) VALUES ('Grupo 1');
               INSERT INTO SubGroups (Name, GroupId) VALUES ('Sub 1', (SELECT last_insert_rowid()));

               INSERT INTO Groups (Name) VALUES ('Grupo 2');
               INSERT INTO SubGroups (Name, GroupId) VALUES ('Sub 2', (SELECT last_insert_rowid()));
               INSERT INTO SubGroups (Name, GroupId) VALUES ('Sub 3', (SELECT last_insert_rowid()));

            ");
        }
    }
}
