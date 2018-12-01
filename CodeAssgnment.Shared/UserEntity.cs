using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssgnment.Shared
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string ForeNames { get; set; }
        public string SurName { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public bool Gender { get; set; }
        public string HomeNo { get; set; }
        public string WorkNo { get; set; }
        public string MobileNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

    }
}
