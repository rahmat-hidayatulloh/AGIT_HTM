using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agit.Domain;

namespace agit.HTM.Domain.Modules.Core.Model
{
    [Table("TB_M_UserRole")]
    public partial class UserRole : IBaseRecord<Guid>
    {
    [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
    
}
