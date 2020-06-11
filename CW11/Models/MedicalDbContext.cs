using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW11.Models
{
    public class MedicalDbContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public MedicalDbContext() { }

        public MedicalDbContext(DbContextOptions options)
        :base(options){

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Primary keys
            builder.Entity<Medicament>().HasKey(q => q.IdMedicament);
            builder.Entity<Prescription>().HasKey(q => q.IdPrescription);
            builder.Entity<Prescription_Medicament>().HasKey(q =>
                new {
                    q.IdMedicament,
                    q.IdPrescription
                });

            //Relationships
            builder.Entity<Prescription_Medicament>()
                .HasOne(t => t.Medicament)
                .WithMany(t => t.Prescription_Medicaments)
                .HasForeignKey(t => t.IdMedicament);

            builder.Entity<Prescription_Medicament>()
                .HasOne(t => t.Prescription)
                .WithMany(t => t.Prescription_Medicaments)
                .HasForeignKey(t => t.IdPrescription);


            //Seed data
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor=1,FirstName = "Piotr", LastName="Kwiatek",Email="email@mail.com" });
            doctors.Add(new Doctor { IdDoctor=2,FirstName = "Pawel", LastName = "Kowalski", Email = "email2@mail.com" });

            builder.Entity<Doctor>().HasData(doctors);

            var patients = new List<Patient>();
            patients.Add(new Patient { IdPatient = 1, FirstName = "Damian", LastName = "Idzikowski", BirthDate=new DateTime(1999,2,13)});
            patients.Add(new Patient { IdPatient = 2, FirstName = "Krzysztof", LastName = "Popowski", BirthDate=new DateTime(1995, 3, 15) });

            builder.Entity<Patient>().HasData(patients);

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription=1,Date= new DateTime(2020, 2, 13),DueDate= new DateTime(2019, 2, 13),IdDoctor=1,IdPatient=1 });
            prescriptions.Add(new Prescription { IdPrescription=2,Date= new DateTime(2020, 2, 13), DueDate = new DateTime(2019, 2, 13), IdDoctor = 1, IdPatient = 2 });

            builder.Entity<Prescription>().HasData(prescriptions);

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament { IdMedicament=1,Name="Apap",Descripiton="Przeciwbolowy",Type="Lek"});
            medicaments.Add(new Medicament { IdMedicament=2,Name="Apap Noc", Descripiton = "Przeciwbolowy", Type = "Lek" });

            builder.Entity<Medicament>().HasData(medicaments);

            var prescriptionsMedicament = new List<Prescription_Medicament>();
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament=1,IdPrescription=1,Dose=10,Details="Opis" });
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament=2,IdPrescription=1,Dose=12,Details="Opis 2"});

            builder.Entity<Prescription_Medicament>().HasData(prescriptionsMedicament);
        }
    }
}
