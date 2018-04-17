using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocceBallLeague.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public string ThrowingArm { get; set; }

        public int? TeamId { get; set; }
        public Teams Team { get; set; }

    }
}
