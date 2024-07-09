using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameViewer.Dal.Entities
{
    public class ParamValue
    {
        public int Id{ get; set; }
        public int ParamId { get; set; }
        public string Value { get; set; }
        public int RowId { get; set; }

        [ForeignKey("ParamId")]
        public ProviderParam Parameter{ get; set; }

    }
}
