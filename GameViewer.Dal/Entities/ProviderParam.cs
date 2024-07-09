using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameViewer.Dal.Entities
{
    public class ProviderParam
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public int OrderId { get; set; }
        public string Type { get; set; }
        public string? DefaultValue { get; set; }

        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }



    }
}
