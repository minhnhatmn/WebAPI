using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.EF
{
    public partial class DB_NHANTINContext : DbContext
    {
        public DB_NHANTINContext()
        {
        }

        public DB_NHANTINContext(DbContextOptions<DB_NHANTINContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Friendlist> Friendlists { get; set; }
        public virtual DbSet<FriendlistDetail> FriendlistDetails { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupDetail> GroupDetails { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageSeen> MessageSeens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DB_NHANTIN");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("FILES");

                entity.Property(e => e.IdAttachment)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ATTACHMENT");

                entity.Property(e => e.IdMessage).HasColumnName("ID_MESSAGE");

                entity.Property(e => e.TypeFile).HasColumnName("TYPE_FILE");

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.IdMessageNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdMessage)
                    .HasConstraintName("FK_FILES_MESSAGES");
            });

            modelBuilder.Entity<Friendlist>(entity =>
            {
                entity.HasKey(e => e.IdFriendlist);

                entity.ToTable("FRIENDLIST");

                entity.Property(e => e.IdFriendlist)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_FRIENDLIST");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Friendlists)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_FRIENDLIST_USERS");
            });

            modelBuilder.Entity<FriendlistDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdFriendlist, e.IdUser });

                entity.ToTable("FRIENDLIST_DETAIL");

                entity.Property(e => e.IdFriendlist).HasColumnName("ID_FRIENDLIST");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.TimeAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_ADD");

                entity.HasOne(d => d.IdFriendlistNavigation)
                    .WithMany(p => p.FriendlistDetails)
                    .HasForeignKey(d => d.IdFriendlist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FRIENDLIST_DETAIL_FRIENDLIST");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FriendlistDetails)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FRIENDLIST_DETAIL_USERS");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup);

                entity.ToTable("GROUPS");

                entity.Property(e => e.IdGroup)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_GROUP");

                entity.Property(e => e.IdLastmessage).HasColumnName("ID_LASTMESSAGE");

                entity.Property(e => e.NameGroup)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_GROUP");

                entity.Property(e => e.TimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_CREATE");

                entity.Property(e => e.TimeDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_DELETE");

                entity.Property(e => e.TypeGroup).HasColumnName("TYPE_GROUP");

                entity.HasOne(d => d.IdLastmessageNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.IdLastmessage)
                    .HasConstraintName("FK_GROUPS_MESSAGES");
            });

            modelBuilder.Entity<GroupDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdGroup, e.IdUser });

                entity.ToTable("GROUP_DETAIL");

                entity.Property(e => e.IdGroup).HasColumnName("ID_GROUP");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IsNotification).HasColumnName("IS_NOTIFICATION");

                entity.Property(e => e.TypeAdmin).HasColumnName("TYPE_ADMIN");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.GroupDetails)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROUP_DETAIL_GROUPS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.GroupDetails)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROUP_DETAIL_USERS");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage);

                entity.ToTable("MESSAGES");

                entity.Property(e => e.IdMessage)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MESSAGE");

                entity.Property(e => e.ContentText)
                    .HasMaxLength(500)
                    .HasColumnName("CONTENT_TEXT");

                entity.Property(e => e.IdGroup).HasColumnName("ID_GROUP");

                entity.Property(e => e.IdMessagereply).HasColumnName("ID_MESSAGEREPLY");

                entity.Property(e => e.IdUsersent).HasColumnName("ID_USERSENT");

                entity.Property(e => e.TimeDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_DELETE");

                entity.Property(e => e.TimeEdit)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_EDIT");

                entity.Property(e => e.TimeSent)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_SENT");

                entity.Property(e => e.TypeMessage)
                    .HasMaxLength(20)
                    .HasColumnName("TYPE_MESSAGE")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("FK_MESSAGES_GROUPS");

                entity.HasOne(d => d.IdMessagereplyNavigation)
                    .WithMany(p => p.InverseIdMessagereplyNavigation)
                    .HasForeignKey(d => d.IdMessagereply)
                    .HasConstraintName("FK_MESSAGES_MESSAGES");

                entity.HasOne(d => d.IdUsersentNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdUsersent)
                    .HasConstraintName("FK_MESSAGES_USERS");
            });

            modelBuilder.Entity<MessageSeen>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdMessage });

                entity.ToTable("MESSAGE_SEEN");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IdMessage).HasColumnName("ID_MESSAGE");

                entity.HasOne(d => d.IdMessageNavigation)
                    .WithMany(p => p.MessageSeens)
                    .HasForeignKey(d => d.IdMessage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGE_SEEN_MESSAGES");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MessageSeens)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGE_SEEN_USERS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("USERS");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USER");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AVATAR_URL");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER")
                    .IsFixedLength(true);

                entity.Property(e => e.TimeDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_DELETE");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<UserDevice>(entity =>
            {
                entity.HasKey(e => e.IdUserDevice);

                entity.ToTable("USER_DEVICE");

                entity.Property(e => e.IdUserDevice)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USER_DEVICE");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(150)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceTimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("DEVICE_TIME_CREATE");

                entity.Property(e => e.DeviceTimeExpried)
                    .HasColumnType("datetime")
                    .HasColumnName("DEVICE_TIME_EXPRIED");

                entity.Property(e => e.DeviceToken)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_TOKEN");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.LoginTimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGIN_TIME_CREATE");

                entity.Property(e => e.LoginTimeExpried)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGIN_TIME_EXPRIED");

                entity.Property(e => e.LoginToken)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_TOKEN");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserDevices)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_USER_DEVICE_USERS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
