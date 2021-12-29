using System;
using System.Collections.Generic;
using Hotel_Astitou_Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotel_Astitou_Backend.Model
{
    public partial class HotelAstitouContext : DbContext
    {
        public HotelAstitouContext()
        {
        }

        public HotelAstitouContext(DbContextOptions<HotelAstitouContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Guarantor> Guarantors { get; set; }
        public virtual DbSet<Lodger> Lodgers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=bddhotelastitou;User Id=Mohamed;Password=Password;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("apartments");
                entity
                    .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BedroomArea).HasColumnName("bedroomArea");

                entity.Property(e => e.DiningArea).HasColumnName("diningArea");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.RentPrice)
                    .HasColumnName("rentPrice")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.Property(e => e.TotalArea).HasColumnName("totalArea");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");
                entity
                   .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.DateOfArrival)
                    .HasColumnName("date_of_arrival")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfDeparture)
                    .HasColumnName("date_of_departure")
                    .HasColumnType("datetime");

                entity.Property(e => e.LodgerId).HasColumnName("lodger_id");

            });

            modelBuilder.Entity<Guarantor>(entity =>
            {
                entity.ToTable("guarantor");
                entity
                   .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LodgerId).HasColumnName("lodger_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.HasOne(d => d.Lodger)
                    .WithMany(p => p.Guarantor)
                    .HasForeignKey(d => d.LodgerId)
                    .HasConstraintName("FK__guarantor__lodge__4F7CD00D");
            });

            modelBuilder.Entity<Lodger>(entity =>
            {
                entity.ToTable("lodgers");
                entity
                   .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                   .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Birthplace)
                    .IsRequired()
                    .HasColumnName("birthplace")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Civility)
                    .IsRequired()
                    .HasColumnName("civility")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NationalRegister)
                    .IsRequired()
                    .HasColumnName("national_register")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");
                entity
                   .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApartementId).HasColumnName("apartement_id");

                entity.Property(e => e.Idapartment).HasColumnName("idapartment");

                entity.Property(e => e.Surface).HasColumnName("surface");

                entity.HasOne(d => d.Apartement)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.ApartementId)
                    .HasConstraintName("FK__rooms__apartemen__4AB81AF0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity
                   .HasKey(x => x.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TokenForgotPassword)
                    .HasColumnName("tokenForgotPassword")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public static void PopulateDatabase(HotelAstitouContext context)
        {
            for (int i = 0; i < 10; i++)
            {

            
            context.Users.Add(
                    new User
                    {
                        Username = "kay"+1,
                        Email = "tsusuki@helb-prigogine.be"+1,
                        Password = CryptographyTool.CryptSHA512("Password"),
                    });
            context.Users.Add(
                 new User
                 {
                     Username = "kay2",
                     Email = "Tsusuki1@helb-prigogine.be"+1,
                     Password = CryptographyTool.CryptSHA512("Password2"),
                 });
            context.Lodgers.Add(new Lodger
            {
                Name = "Jean"+1,
                Firstname = "Paul"+1,
                Gender = "Male",
                Civility = "Celibataire",
                Adress = "Rue lol",
                City = "Las street",
                Country = "Japon",
                Email = "kazjeak@gmail.com",
                PostalCode = 1070,
                PhoneNumber = 0484744621,
                Birthday = new DateTime(1997, 9, 24),
                Birthplace = "Anderlecht",
                NationalRegister = "2145641241"

            });
            context.SaveChanges();

            context.Lodgers.Add(new Lodger
            {
                Name = "Jean2",
                Firstname = "Paul2",
                Gender = "femelle",
                Civility = "Celibataire2",
                Adress = "Rue lol2",
                City = "Las street2",
                Country = "Japon2",
                Email = "kazjeak2@gmail.com",
                PostalCode = 10704,
                PhoneNumber = 0484744621,
                Birthday = new DateTime(1984, 8, 24),
                Birthplace = "Anderlecht",
                NationalRegister = "2145641241"

            });
            context.SaveChanges();
            context.Guarantors.Add(new Guarantor
            {
                Name = "Jean2",
                Firstname = "Paul2",
                Gender = "femelle", 
                Adress = "Rue lol2",
                City = "Las street2",
                Country = "Japon2",
                Email = "kazjeak2@gmail.com",
                PostalCode = 10704,
                PhoneNumber = 0484744621,
                LodgerId = 1,

            });
            context.SaveChanges();
            context.Apartments.Add(new Apartment
            {
                Adress = "Adress azedcfsq",
                Type = " Type jazedghjqs",
                Floor = 56,
                RoomNumber = 2,
                TotalArea = 554,
                BedroomArea=5452,
                DiningArea=5461,
                RentPrice = 4861,
            }) ;
            context.SaveChanges();
            context.Bookings.Add(new Booking
            {
               DateOfArrival = new DateTime(2021, 8, 24),
               DateOfDeparture = new DateTime(2022, 8, 24),
               LodgerId = 1,
               ApartmentId=1,
               

            });
            context.SaveChanges();
            context.Rooms.Add(new Room
            {
                Surface=56,
                ApartementId=1,
               

            });
            context.SaveChanges();
        }
        }
    }
}
