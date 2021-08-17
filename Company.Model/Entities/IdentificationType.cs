using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Company.Model.Entities
{
    public class IdentificationType
    {
        public IdentificationType()
        {
            identificationTypeHasCompany = new HashSet<Company>();
        }
        [Key]
        public int idIdentificationType { get; set; }
        public string identificationName { get; set; }
        public string identificationDescription { get; set; }
        public virtual ICollection<Company> identificationTypeHasCompany { get; set; }
    }
}
