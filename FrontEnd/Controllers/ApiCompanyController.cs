using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Model;
using Company.Model.Entities;
using FrontEnd.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCompanyController : ControllerBase
    {
        #region variables globales
        private readonly DataBaseContext dbContext;
        #endregion

        #region constructor
        public ApiCompanyController()
        {
            this.dbContext = new DataBaseContext();
        }
        #endregion

        // GET: api/<ApiController>
        [HttpGet]
        public dynamic Get()
        {
            return dbContext.IdentificationType.OrderBy(x => x.idIdentificationType);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public Respons Get(int id)
        {
            Company.Model.Entities.Company searchCompany = dbContext.Company.Where(x => x.nitCompany == id).FirstOrDefault();

            if (searchCompany != null)
            {
                if (searchCompany.unableRegistry == true)
                {
                    return new Respons() { state = "601", error = "false", message = "La Identificación de la empresa No puede ser procesada" };
                }
                else {
                    return new Respons() { state = "200", error = "false", message = "La empresa puede continuar el proceso.!!", custom = searchCompany };
                }
            }
            else {
                return new Respons() { state = "602", error = "false", message = "La Identificación de la empresa No esta registrada" };
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        public Respons Post([FromBody] Company.Model.Entities.Company value)
        {
            dynamic val = value;
            try {

                this.dbContext.Company.Update(value);
                CompanyRegistry valueCompanyRegistry = this.dbContext.CompanyRegistry.Where(x => x.idCompany == value.idCompany).FirstOrDefault();
                if (valueCompanyRegistry != null)
                {
                    valueCompanyRegistry.dateRegistry = DateTime.Now;
                    this.dbContext.CompanyRegistry.Update(valueCompanyRegistry);
                }
                else {
                    this.dbContext.CompanyRegistry.Add(
                        new CompanyRegistry()
                        {
                            dateRegistry = DateTime.Now,
                            idCompany = value.idCompany
                        }
                    );
                }

                if (this.dbContext.SaveChanges() <= 0)
                {
                    return new Respons() { state = "601", error = "true", message = "Error al almacenar la información" };
                }

                return new Respons() { state = "200", error = "false", message = "Información almacenada con exito.!" };

            } catch (Exception ex) {
                return new Respons() { state = "601", error = "true", message = "Error al almacenar la información" };
            }
            
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company.Model.Entities.Company value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
