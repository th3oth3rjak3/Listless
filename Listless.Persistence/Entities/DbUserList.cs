using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Listless.Persistence.Entities;
internal class DbUserList
{
    [PrimaryKey, AutoIncrement]
    internal int Id { get; set; }

    [StringLength(maximumLength: 50)]
    internal required string Name { get; set; }

    internal IEnumerable<DbListItem> Items { get; set; } = new List<DbListItem>();
}
