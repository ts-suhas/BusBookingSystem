using System;
using System.Collections.Generic;
using BusBookingWebApi.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Route = BusBookingWebApi.BusinessObjects.Route;

namespace BusBookingWebApi.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bu> buses { get; set; } = null!;
        public virtual DbSet<BusRoute> BusRoutes { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<DriverContact> DriverContacts { get; set; } = null!;
        public virtual DbSet<DriverEmail> DriverEmails { get; set; } = null!;
        public virtual DbSet<DriverFullTime> DriverFullTimes { get; set; } = null!;
        public virtual DbSet<DriverPartTime> DriverPartTimes { get; set; } = null!;
        public virtual DbSet<Fuel> Fuels { get; set; } = null!;
        public virtual DbSet<FuelChecker> FuelCheckers { get; set; } = null!;
        public virtual DbSet<Identity> Identities { get; set; } = null!;
        public virtual DbSet<Lisence> Lisences { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<PassengerContact> PassengerContacts { get; set; } = null!;
        public virtual DbSet<PassengerEmail> PassengerEmails { get; set; } = null!;
        public virtual DbSet<PassengerMember> PassengerMembers { get; set; } = null!;
        public virtual DbSet<PassengerNonMember> PassengerNonMembers { get; set; } = null!;
        public virtual DbSet<PassengerTicket> PassengerTickets { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Ticket1> Tickets1 { get; set; } = null!;
        public virtual DbSet<TicketPayment> TicketPayments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NRGNFB2;Database=TRANSPORT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bu>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__Bus__4B26EFE62B0FF531");

                entity.ToTable("Bus");

                entity.Property(e => e.BId)
                    .ValueGeneratedNever()
                    .HasColumnName("B_ID");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.NoPlate)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("No_Plate");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasMany(d => d.DIds)
                    .WithMany(p => p.BIds)
                    .UsingEntity<Dictionary<string, object>>(
                        "BusDriver",
                        l => l.HasOne<Driver>().WithMany().HasForeignKey("DId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BUS_DRIVER__D_ID__4D94879B"),
                        r => r.HasOne<Bu>().WithMany().HasForeignKey("BId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BUS_DRIVER__B_ID__4CA06362"),
                        j =>
                        {
                            j.HasKey("BId", "DId");

                            j.ToTable("BUS_DRIVER");

                            j.IndexerProperty<int>("BId").HasColumnName("B_ID");

                            j.IndexerProperty<int>("DId").HasColumnName("D_ID");
                        });
            });

            modelBuilder.Entity<BusRoute>(entity =>
            {
                entity.HasKey(e => e.BrId);

                entity.ToTable("BUS_ROUTE");

                entity.Property(e => e.BrId).HasColumnName("BR_ID");

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.RId).HasColumnName("R_ID");

                entity.HasOne(d => d.BIdNavigation)
                    .WithMany(p => p.BusRoutes)
                    .HasForeignKey(d => d.BId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUS_ROUTE_Bus");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.BusRoutes)
                    .HasForeignKey(d => d.RId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUS_ROUTE_ROUTES");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__CARD__C1F8DC59013E7D54");

                entity.ToTable("CARD");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CID");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__Driver__76B8FF7DD3F4FD03");

                entity.ToTable("Driver");

                entity.Property(e => e.DId)
                    .ValueGeneratedNever()
                    .HasColumnName("D_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DriverContact>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__DRIVER_C__76B8FF7D25327F1B");

                entity.ToTable("DRIVER_CONTACT");

                entity.Property(e => e.DId)
                    .ValueGeneratedNever()
                    .HasColumnName("D_ID");

                entity.Property(e => e.Contacts).HasColumnName("CONTACTS");

                entity.HasOne(d => d.DIdNavigation)
                    .WithOne(p => p.DriverContact)
                    .HasForeignKey<DriverContact>(d => d.DId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DRIVER_CON__D_ID__3B75D760");
            });

            modelBuilder.Entity<DriverEmail>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__DRIVER_E__76B8FF7D628F5945");

                entity.ToTable("DRIVER_EMAIL");

                entity.Property(e => e.DId)
                    .ValueGeneratedNever()
                    .HasColumnName("D_ID");

                entity.Property(e => e.Emails)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMAILS");

                entity.HasOne(d => d.DIdNavigation)
                    .WithOne(p => p.DriverEmail)
                    .HasForeignKey<DriverEmail>(d => d.DId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DRIVER_EMA__D_ID__38996AB5");
            });

            modelBuilder.Entity<DriverFullTime>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK__DRIVER_F__C1BEA5A2EB2B67F8");

                entity.ToTable("DRIVER_FULL_TIME");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Bonus).HasColumnName("BONUS");

                entity.Property(e => e.Salary).HasColumnName("SALARY");

                entity.HasOne(d => d.FidNavigation)
                    .WithOne(p => p.DriverFullTime)
                    .HasForeignKey<DriverFullTime>(d => d.Fid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DRIVER_FULL__FID__49C3F6B7");
            });

            modelBuilder.Entity<DriverPartTime>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__DRIVER_P__C5775520A80C9709");

                entity.ToTable("DRIVER_PART_TIME");

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("PID");

                entity.Property(e => e.NumHours).HasColumnName("NUM_HOURS");

                entity.Property(e => e.Rate).HasColumnName("RATE");

                entity.HasOne(d => d.PidNavigation)
                    .WithOne(p => p.DriverPartTime)
                    .HasForeignKey<DriverPartTime>(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DRIVER_PART__PID__46E78A0C");
            });

            modelBuilder.Entity<Fuel>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__FUEL__2C6EC7C35DA885D8");

                entity.ToTable("FUEL");

                entity.Property(e => e.FId)
                    .ValueGeneratedNever()
                    .HasColumnName("F_ID");

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.Liter).HasColumnName("LITER");

                entity.HasOne(d => d.BIdNavigation)
                    .WithMany(p => p.Fuels)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("FK__FUEL__B_ID__2D27B809");
            });

            modelBuilder.Entity<FuelChecker>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FUEL_CHECKER");

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.Liter).HasColumnName("liter");

                entity.Property(e => e.NoPlate)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("No_Plate");
            });

            modelBuilder.Entity<Identity>(entity =>
            {
                entity.ToTable("Identity");

                entity.Property(e => e.IdentityId).HasColumnName("IdentityID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Firstname).HasMaxLength(250);

                entity.Property(e => e.IdentityTypeId).HasColumnName("IdentityTypeID");

                entity.Property(e => e.Lastname).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);
            });

            modelBuilder.Entity<Lisence>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LISENCE__420BA09E4D2F82A6");

                entity.ToTable("LISENCE");

                entity.Property(e => e.LId)
                    .ValueGeneratedNever()
                    .HasColumnName("L_ID");

                entity.Property(e => e.DId).HasColumnName("D_ID");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("Expiry_Date");

                entity.Property(e => e.LType)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("L_Type");

                entity.HasOne(d => d.DIdNavigation)
                    .WithMany(p => p.Lisences)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK__LISENCE__D_ID__300424B4");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.PaId)
                    .HasName("PK__Passenge__28E0060BF1951BA4");

                entity.ToTable("Passenger");

                entity.Property(e => e.PaId)
                    .ValueGeneratedNever()
                    .HasColumnName("PA_ID");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PassengerContact>(entity =>
            {
                entity.HasKey(e => e.PaId)
                    .HasName("PK__PASSENGE__28E0060BCE405897");

                entity.ToTable("PASSENGER_CONTACT");

                entity.Property(e => e.PaId)
                    .ValueGeneratedNever()
                    .HasColumnName("PA_ID");

                entity.Property(e => e.Contacts).HasColumnName("CONTACTS");

                entity.HasOne(d => d.Pa)
                    .WithOne(p => p.PassengerContact)
                    .HasForeignKey<PassengerContact>(d => d.PaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PASSENGER__PA_ID__35BCFE0A");
            });

            modelBuilder.Entity<PassengerEmail>(entity =>
            {
                entity.HasKey(e => e.PaId)
                    .HasName("PK__PASSENGE__28E0060BE3694569");

                entity.ToTable("PASSENGER_EMAIL");

                entity.Property(e => e.PaId)
                    .ValueGeneratedNever()
                    .HasColumnName("PA_ID");

                entity.Property(e => e.Emails)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMAILS");

                entity.HasOne(d => d.Pa)
                    .WithOne(p => p.PassengerEmail)
                    .HasForeignKey<PassengerEmail>(d => d.PaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PASSENGER__PA_ID__32E0915F");
            });

            modelBuilder.Entity<PassengerMember>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK__PASSENGE__18B1A317E8F3DD4F");

                entity.ToTable("PASSENGER_Member");

                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("M_ID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("date")
                    .HasColumnName("EXP_DATE");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.PassengerMembers)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__PASSENGER_M__CID__403A8C7D");

                entity.HasOne(d => d.MIdNavigation)
                    .WithOne(p => p.PassengerMember)
                    .HasForeignKey<PassengerMember>(d => d.MId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PASSENGER___M_ID__412EB0B6");
            });

            modelBuilder.Entity<PassengerNonMember>(entity =>
            {
                entity.HasKey(e => e.Nmid)
                    .HasName("PK__PASSENGE__E32F4C81FD1A5017");

                entity.ToTable("PASSENGER_NON_MEMBER");

                entity.Property(e => e.Nmid)
                    .ValueGeneratedNever()
                    .HasColumnName("NMID");

                entity.HasOne(d => d.Nm)
                    .WithOne(p => p.PassengerNonMember)
                    .HasForeignKey<PassengerNonMember>(d => d.Nmid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PASSENGER___NMID__440B1D61");
            });

            modelBuilder.Entity<PassengerTicket>(entity =>
            {
                entity.HasKey(e => e.PtId);

                entity.ToTable("Passenger_Ticket");

                entity.Property(e => e.PtId).HasColumnName("PT_ID");

                entity.Property(e => e.PnId).HasColumnName("PN_ID");

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.HasOne(d => d.Pn)
                    .WithMany(p => p.PassengerTickets)
                    .HasForeignKey(d => d.PnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passenger_Ticket_PASSENGER_NON_MEMBER");

                entity.HasOne(d => d.TIdNavigation)
                    .WithMany(p => p.PassengerTickets)
                    .HasForeignKey(d => d.TId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passenger_Ticket_TICKETS");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__PAYMENT__A3420A775A78F55D");

                entity.ToTable("PAYMENT");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("P_ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PaId).HasColumnName("PA_ID");

                entity.HasOne(d => d.Pa)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaId)
                    .HasConstraintName("FK__PAYMENT__PA_ID__2A4B4B5E");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__ROUTES__DE152E891FFB6E4B");

                entity.ToTable("ROUTES");

                entity.Property(e => e.RId)
                    .ValueGeneratedNever()
                    .HasColumnName("R_ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__TICKET__C456D729F2D7F7D4");

                entity.ToTable("TICKET");

                entity.Property(e => e.Tid)
                    .ValueGeneratedNever()
                    .HasColumnName("TID");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.RId).HasColumnName("R_ID");

                entity.Property(e => e.TNum).HasColumnName("T_NUM");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__TICKET__P_ID__02084FDA");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RId)
                    .HasConstraintName("FK__TICKET__R_ID__01142BA1");
            });

            modelBuilder.Entity<Ticket1>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.ToTable("TICKETS");

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.Property(e => e.RId).HasColumnName("R_ID");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.Ticket1s)
                    .HasForeignKey(d => d.RId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TICKETS_ROUTES");
            });

            modelBuilder.Entity<TicketPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TICKET_Payments");

                entity.Property(e => e.TodaySales).HasColumnName("Today Sales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
