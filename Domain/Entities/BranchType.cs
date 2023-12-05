using Domain.Premetives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class BranchType : Entity
    {
        public BranchType(Guid id, string branchTypeNameInNepali, string branchTypeInEnglish) : base(id)
        {
            BranchTypeNameInNepali = branchTypeNameInNepali;
            BranchTypeInEnglish = branchTypeInEnglish;
            
        }

        public string BranchTypeNameInNepali { get; set; }
        public string BranchTypeInEnglish { get; set; }
    }
}
