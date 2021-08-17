using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Company.Model.Entities
{
    public class Company
    {
        public Company()
        {
            companyHasCompanyRegistry = new HashSet<CompanyRegistry>();
        }

        [Key]
        public int idCompany { get; set; }
        public int identificationNumber { get; set; }
        public int nitCompany { get; set; }
        public string companyName { get; set; }
        public string firtsName { get; set; }
        public string secondName { get; set; }
        public string firtsLastName { get; set; }
        public string secondLastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool authorizedSendEmail {get; set;}
        public bool authorizedSendPhone { get; set; }
        public bool unableRegistry { get; set; } 
        public int idIdentificationType { get; set; }
        public virtual IdentificationType identificationType { get; set; }
        public virtual ICollection<CompanyRegistry> companyHasCompanyRegistry { get; set; }
    }
}
