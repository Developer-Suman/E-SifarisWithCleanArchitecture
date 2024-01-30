using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Premetives;

namespace Domain.Entities
{
    public sealed class Proviance : CustomEntity
    {
        public Proviance(int id, string provinceNameInNepali, string provinceNameInEnglish) : base(id)
        {
            ProvinceNameInEnglish = provinceNameInEnglish;
            ProvinceNameInNepali = provinceNameInNepali;

        }

        public string ProvinceNameInNepali { get; set; }
        public string ProvinceNameInEnglish { get; set; }
    }
}
