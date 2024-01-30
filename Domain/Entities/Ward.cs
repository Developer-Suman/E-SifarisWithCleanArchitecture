using Domain.Premetives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ward : CustomEntity
    {
        public Ward(int id, int wardNo, bool isWardCreated) : base(id)
        {
            WardNo = wardNo;
            IsWardCreated = isWardCreated;
            
        }

        public int WardNo { get; set; }
        public bool IsWardCreated { get; set; }
    }
}
