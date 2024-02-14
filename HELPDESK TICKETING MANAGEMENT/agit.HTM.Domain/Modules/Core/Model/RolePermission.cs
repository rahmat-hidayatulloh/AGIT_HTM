using Agit.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agit.HTM.Domain.Modules.Core.Model
{
    [Table("TB_M_RolePermission")]
    public partial class RolePermission : IBaseRecord<Guid>
    {
        [Key]
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid PermissionID { get; set; }
    }
}
