using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Company.Model.Entities;

namespace Company.Model
{
    public partial class DataBaseContext : DbContext
    {
        #region " [ Variables globales ] "

        private string ConnectionTxt = string.Empty;

		#endregion

		#region " [ Constructor e inicializador de variables ] "

		public DataBaseContext()
		{
			//this.ConnectionTxt = "server=localhost;database=CompanyDB;Trusted_Connection=false; MultipleActiveResultSets=true;User Id= sa;Password=Pablo2309#*";
			dynamic Data = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")));
			this.ConnectionTxt = Data.DataBaseInfo.Connection.Value;
		}

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

		#endregion

		#region " [ Definición inicial de tablas DbSet ] "

		public virtual DbSet<Company.Model.Entities.Company> Company { get; set; }
		public virtual DbSet<IdentificationType> IdentificationType { get; set; }
		public virtual DbSet<CompanyRegistry> CompanyRegistry { get; set; }

		#endregion

		#region " [ Creacion de modelo de tablas y relaciones ] "

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<IdentificationType>(entity =>
			{
				entity.ToTable("IdentificationType");

				entity.Property(e => e.identificationName)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.identificationDescription)
					.HasMaxLength(200);

				entity.HasData(
					new IdentificationType() { idIdentificationType = 1, identificationName = "NIT", identificationDescription = "Descripción de NIT" },
					new IdentificationType() { idIdentificationType = 2, identificationName = "Cedula Ciudadania", identificationDescription = "Descripción de Cedula de Ciudadania" },
					new IdentificationType() { idIdentificationType = 3, identificationName = "Cedula Extranjeria", identificationDescription = "Descripción de Cedula de Extranjeria" },
					new IdentificationType() { idIdentificationType = 4, identificationName = "Pasaporte", identificationDescription = "Descripción de Pasaporte" }
				);

			});

			modelBuilder.Entity<Company.Model.Entities.Company>(entity =>
			{
				entity.ToTable("Company");

				entity.Property(e => e.identificationNumber)
					.IsRequired();

				entity.Property(e => e.email)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.companyName)
					.HasMaxLength(100);

				entity.Property(e => e.firtsName)
					.HasMaxLength(100);

				entity.Property(e => e.secondName)
					.HasMaxLength(100);

				entity.Property(e => e.firtsLastName)
					.HasMaxLength(100);

				entity.Property(e => e.secondLastName)
					.HasMaxLength(100);

				entity.Property(e => e.phone)
					.HasMaxLength(20);

				entity.HasOne(d => d.identificationType)
					.WithMany(p => p.identificationTypeHasCompany)
					.HasForeignKey(d => d.idIdentificationType)
					.HasConstraintName("FK_identificationTypeToCompany");

				entity.HasData(
					new Company.Model.Entities.Company() { idCompany = 1, nitCompany = 900674335, idIdentificationType = 1, identificationNumber = 900674335, companyName = "Nombre Compañia 1", email = "emailcompania1@email.com", phone = "333444555", unableRegistry = true },
					new Company.Model.Entities.Company() { idCompany = 2, nitCompany = 900674336, idIdentificationType = 2, identificationNumber = 1222333444, firtsName = "Pedro", firtsLastName = "Perez", email = "pedroperez@email.com", phone = "344566788", unableRegistry = false},
					new Company.Model.Entities.Company() { idCompany = 3, nitCompany = 811033098, idIdentificationType = 3, identificationNumber = 8907654, companyName = "Nombre Compañia 2", email = "emailcompania2@email.com", phone = "322433544", unableRegistry = false }
				);
			});

			modelBuilder.Entity<CompanyRegistry>(entity =>
			{
				entity.ToTable("CompanyRegistry");

				entity.Property(e => e.dateRegistry)
					.IsRequired();

				entity.HasOne(d => d.company)
					.WithMany(p => p.companyHasCompanyRegistry)
					.HasForeignKey(d => d.idCompany)
					.HasConstraintName("FK_CompanyToCompanyRegistry");

			});

			OnModelCreatingPartial(modelBuilder);
		}

		#endregion

		#region " [Configuración para conexión del contexto] "
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				if (string.IsNullOrEmpty(this.ConnectionTxt))
				{
					throw new System.Exception("Connection is not defined.");
				}
				optionsBuilder.UseSqlServer(this.ConnectionTxt);
			}
		}

		#endregion

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
