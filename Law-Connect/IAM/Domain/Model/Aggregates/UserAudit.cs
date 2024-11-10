using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Law_Connect.IAM.Domain.Model.Aggregates
{
    public partial class UserAudit: IEntityWithCreatedUpdatedDate
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
