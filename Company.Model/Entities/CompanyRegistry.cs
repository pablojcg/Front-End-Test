using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Company.Model.Entities
{
    public class CompanyRegistry
    {
        [Key]
        public int idCompanyRegistry { get; set; }
        public DateTime dateRegistry { get; set; }
        public int idCompany { get; set; }
        public virtual Company company { get; set; }
    }
}
