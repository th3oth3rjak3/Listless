using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SQLite;

namespace Listless.Persistence.Entities;
internal class DbListItem
{
    [PrimaryKey, AutoIncrement]
    internal int Id { get; set; }

    [ForeignKey(nameof(UserList))]
    internal int UserListId { get; set; }

    internal required DbUserList UserList { get; set; }

    [StringLength(maximumLength: 300)]
    internal required string Description { get; set; }

    internal int IsStarted { get; set; }

    internal int IsComplete { get; set; }

    internal string? StartBy { get; set; }

    internal string? DueBy { get; set; }

}
