using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForms.Model
{
    class AppVersion
    {
        public int VersionId { get; set; }
        public string LatestVersion { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
