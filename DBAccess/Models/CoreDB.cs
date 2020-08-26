using System;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Abp.Dependency;
using Abp.Domain.Repositories;
using DBAccess.Service;
using Abp.Domain.Uow;
using App.DBHelper;
#nullable disable

namespace DBAccess.Models
{
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(BaseService<>),
        typeof(BaseService<,>)
        )]
    public partial class CoreDB : AbpDbContext
    {
        public CoreDB(DbContextOptions<CoreDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<AdministratorAdministratorRoleMapping> AdministratorAdministratorRoleMappings { get; set; }
        public virtual DbSet<AdministratorRole> AdministratorRoles { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<AdvertisementFile> AdvertisementFiles { get; set; }
        public virtual DbSet<AdvertisementTerminalMapping> AdvertisementTerminalMappings { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentPictureMapping> AppointmentPictureMappings { get; set; }
        public virtual DbSet<ArticlePictureMapping> ArticlePictureMappings { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Carousel> Carousels { get; set; }
        public virtual DbSet<CarouselCategory> CarouselCategories { get; set; }
        public virtual DbSet<Cjbdoctor> Cjbdoctors { get; set; }
        public virtual DbSet<CjbdoctorInstitution> CjbdoctorInstitutions { get; set; }
        public virtual DbSet<CjbdoctorPic> CjbdoctorPics { get; set; }
        public virtual DbSet<Cjbpatient> Cjbpatients { get; set; }
        public virtual DbSet<CrmMenu> CrmMenus { get; set; }
        public virtual DbSet<CrmPower1> CrmPower1s { get; set; }
        public virtual DbSet<CrmPower2> CrmPower2s { get; set; }
        public virtual DbSet<Dbill> Dbills { get; set; }
        public virtual DbSet<DbillDetail> DbillDetails { get; set; }
        public virtual DbSet<DchatMessage> DchatMessages { get; set; }
        public virtual DbSet<DchatSession> DchatSessions { get; set; }
        public virtual DbSet<DdutyDoctor> DdutyDoctors { get; set; }
        public virtual DbSet<DepartmentGroup> DepartmentGroups { get; set; }
        public virtual DbSet<DfuntionList> DfuntionLists { get; set; }
        public virtual DbSet<DguestMessage> DguestMessages { get; set; }
        public virtual DbSet<DguestReplay> DguestReplays { get; set; }
        public virtual DbSet<DhealthRecord> DhealthRecords { get; set; }
        public virtual DbSet<DmessageList> DmessageLists { get; set; }
        public virtual DbSet<DmessageSendLog> DmessageSendLogs { get; set; }
        public virtual DbSet<DoctorDepartmentMapping> DoctorDepartmentMappings { get; set; }
        public virtual DbSet<DuserLogin> DuserLogins { get; set; }
        public virtual DbSet<ExternalAuthenticationRecord> ExternalAuthenticationRecords { get; set; }
        public virtual DbSet<GuestMessagePictureMapping> GuestMessagePictureMappings { get; set; }
        public virtual DbSet<GuestReplayPictureMapping> GuestReplayPictureMappings { get; set; }
        public virtual DbSet<HealthRecordPicture> HealthRecordPictures { get; set; }
        public virtual DbSet<HeapMap> HeapMaps { get; set; }
        public virtual DbSet<HisBussinessType> HisBussinessTypes { get; set; }
        public virtual DbSet<JobTrigger> JobTriggers { get; set; }
        public virtual DbSet<LdepartDoctor> LdepartDoctors { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<MigrationLog> MigrationLogs { get; set; }
        public virtual DbSet<MigrationLogCurrent> MigrationLogCurrents { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleCategory> ModuleCategories { get; set; }
        public virtual DbSet<ModuleFile> ModuleFiles { get; set; }
        public virtual DbSet<NursingTeam> NursingTeams { get; set; }
        public virtual DbSet<OnlineInquiry> OnlineInquiries { get; set; }
        public virtual DbSet<ParentUserChildUserMapping> ParentUserChildUserMappings { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecords { get; set; }
        public virtual DbSet<PermissionRecordRoleMapping> PermissionRecordRoleMappings { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<PillReminder> PillReminders { get; set; }
        public virtual DbSet<QrtzBlobTrigger> QrtzBlobTriggers { get; set; }
        public virtual DbSet<QrtzCalendar> QrtzCalendars { get; set; }
        public virtual DbSet<QrtzCronTrigger> QrtzCronTriggers { get; set; }
        public virtual DbSet<QrtzFiredTrigger> QrtzFiredTriggers { get; set; }
        public virtual DbSet<QrtzJobDetail> QrtzJobDetails { get; set; }
        public virtual DbSet<QrtzLock> QrtzLocks { get; set; }
        public virtual DbSet<QrtzPausedTriggerGrp> QrtzPausedTriggerGrps { get; set; }
        public virtual DbSet<QrtzSchedulerState> QrtzSchedulerStates { get; set; }
        public virtual DbSet<QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; }
        public virtual DbSet<QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; }
        public virtual DbSet<QrtzTrigger> QrtzTriggers { get; set; }
        public virtual DbSet<ReviewItem> ReviewItems { get; set; }
        public virtual DbSet<SchemaSnapshot> SchemaSnapshots { get; set; }
        public virtual DbSet<ServicesReview> ServicesReviews { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<TcontentType> TcontentTypes { get; set; }
        public virtual DbSet<Tdepartment> Tdepartments { get; set; }
        public virtual DbSet<TdoctorList> TdoctorLists { get; set; }
        public virtual DbSet<TdutyDepartment> TdutyDepartments { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<ThealthCard> ThealthCards { get; set; }
        public virtual DbSet<Tinstitution> Tinstitutions { get; set; }
        public virtual DbSet<TmessageClass> TmessageClasses { get; set; }
        public virtual DbSet<TmessageType> TmessageTypes { get; set; }
        public virtual DbSet<TsystemType> TsystemTypes { get; set; }
        public virtual DbSet<UserInstitutionMapping> UserInstitutionMappings { get; set; }
        public virtual DbSet<VGuestMessage> VGuestMessages { get; set; }
        public virtual DbSet<VGuestMessage1> VGuestMessage1s { get; set; }
        public virtual DbSet<VGustMessage1> VGustMessage1s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastActivityDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AdministratorAdministratorRoleMapping>(entity =>
            {
                entity.HasKey(x => new { x.AdministratorId, x.AdministratorRoleId })
                    .HasName("PK_dbo.Administrator_AdministratorRole_Mapping");

                entity.ToTable("Administrator_AdministratorRole_Mapping");

                entity.HasIndex(x => x.AdministratorRoleId, "IX_AdministratorRole_Id");

                entity.HasIndex(x => x.AdministratorId, "IX_Administrator_Id");

                entity.Property(e => e.AdministratorId).HasColumnName("Administrator_Id");

                entity.Property(e => e.AdministratorRoleId).HasColumnName("AdministratorRole_Id");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.AdministratorAdministratorRoleMappings)
                    .HasForeignKey(x => x.AdministratorId)
                    .HasConstraintName("FK_dbo.Administrator_AdministratorRole_Mapping_dbo.Administrator_Administrator_Id");

                entity.HasOne(d => d.AdministratorRole)
                    .WithMany(p => p.AdministratorAdministratorRoleMappings)
                    .HasForeignKey(x => x.AdministratorRoleId)
                    .HasConstraintName("FK_dbo.Administrator_AdministratorRole_Mapping_dbo.AdministratorRole_AdministratorRole_Id");
            });

            modelBuilder.Entity<AdministratorRole>(entity =>
            {
                entity.ToTable("AdministratorRole");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("Advertisement");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<AdvertisementFile>(entity =>
            {
                entity.ToTable("AdvertisementFile");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdvertisementTerminalMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Advertisement_Terminal_Mapping");

                entity.Property(e => e.AdvertisementId).HasColumnName("Advertisement_Id");

                entity.Property(e => e.TerminalId).HasColumnName("Terminal_Id");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookingTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastWaitTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<AppointmentPictureMapping>(entity =>
            {
                entity.ToTable("Appointment_Picture_Mapping");

                entity.HasIndex(x => x.AppointmentId, "IX_AppointmentId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentPictureMappings)
                    .HasForeignKey(x => x.AppointmentId)
                    .HasConstraintName("FK_dbo.Appointment_Picture_Mapping_dbo.Appointment_AppointmentId");
            });

            modelBuilder.Entity<ArticlePictureMapping>(entity =>
            {
                entity.ToTable("Article_Picture_Mapping");

                entity.HasIndex(x => x.ArticleId, "IX_ArticleId");

                entity.HasIndex(x => x.PictureId, "IX_PictureId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticlePictureMappings)
                    .HasForeignKey(x => x.ArticleId)
                    .HasConstraintName("FK_dbo.Article_Picture_Mapping_dbo.DMessageList_ArticleId");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.ArticlePictureMappings)
                    .HasForeignKey(x => x.PictureId)
                    .HasConstraintName("FK_dbo.Article_Picture_Mapping_dbo.Picture_PictureId");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("Building");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<Carousel>(entity =>
            {
                entity.ToTable("Carousel");

                entity.HasIndex(x => x.CarouselCategoryId, "IX_CarouselCategoryId");

                entity.HasIndex(x => x.PictureId, "IX_PictureId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.CarouselCategory)
                    .WithMany(p => p.Carousels)
                    .HasForeignKey(x => x.CarouselCategoryId)
                    .HasConstraintName("FK_dbo.Carousel_dbo.CarouselCategory_CarouselCategoryId");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Carousels)
                    .HasForeignKey(x => x.PictureId)
                    .HasConstraintName("FK_dbo.Carousel_dbo.Picture_PictureId");
            });

            modelBuilder.Entity<CarouselCategory>(entity =>
            {
                entity.ToTable("CarouselCategory");

                entity.HasIndex(x => x.ParentId, "IX_ParentID");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(x => x.ParentId)
                    .HasConstraintName("FK_dbo.CarouselCategory_dbo.CarouselCategory_ParentID");
            });

            modelBuilder.Entity<Cjbdoctor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CJBDoctors");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastActivityDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CjbdoctorInstitution>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CJBDoctorInstitution");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");
            });

            modelBuilder.Entity<CjbdoctorPic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CJBDoctorPic");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Cjbpatient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CJBPatient");

                entity.Property(e => e.BillTime)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JsfullName).HasColumnName("JSFullName");

                entity.Property(e => e.JsmobNo).HasColumnName("JSMobNo");
            });

            modelBuilder.Entity<CrmMenu>(entity =>
            {
                entity.ToTable("crm_menu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Upid).HasColumnName("upid");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<CrmPower1>(entity =>
            {
                entity.ToTable("crm_power1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Power).HasColumnName("power");
            });

            modelBuilder.Entity<CrmPower2>(entity =>
            {
                entity.ToTable("crm_power2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Power1).HasColumnName("power1");

                entity.Property(e => e.Power2).HasColumnName("power2");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Dbill>(entity =>
            {
                entity.ToTable("DBill");

                entity.HasIndex(x => x.HisBussinessTypeCode, "IX_HisBussinessTypeCode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BillTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.GoTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("就诊时间");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.OrderTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 2)");

                entity.Property(e => e.PayTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Reason)
                    .HasColumnType("text")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.HasOne(d => d.HisBussinessTypeCodeNavigation)
                    .WithMany(p => p.Dbills)
                    .HasForeignKey(x => x.HisBussinessTypeCode)
                    .HasConstraintName("FK_dbo.DBill_dbo.HisBussinessType_HisBussinessTypeCode");
            });

            modelBuilder.Entity<DbillDetail>(entity =>
            {
                entity.ToTable("DBillDetail");

                entity.HasIndex(x => x.BillId, "IX_BillID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.BillTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.PayTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.DbillDetails)
                    .HasForeignKey(x => x.BillId)
                    .HasConstraintName("FK_dbo.DBillDetail_dbo.DBill_BillID");
            });

            modelBuilder.Entity<DchatMessage>(entity =>
            {
                entity.ToTable("DChatMessage");

                entity.HasIndex(x => x.ChatSessionId, "IX_ChatSessionID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ChatSessionId).HasColumnName("ChatSessionID");

                entity.Property(e => e.ClientAppid).HasColumnName("ClientAPPID");

                entity.Property(e => e.DutyAppid).HasColumnName("DutyAPPID");

                entity.Property(e => e.HelpId).HasColumnName("HelpID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.ReciveTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.SendId).HasColumnName("SendID");

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ToId).HasColumnName("ToID");

                entity.HasOne(d => d.ChatSession)
                    .WithMany(p => p.DchatMessages)
                    .HasForeignKey(x => x.ChatSessionId)
                    .HasConstraintName("FK_dbo.DChatMessage_dbo.DChatSession_ChatSessionID");
            });

            modelBuilder.Entity<DchatSession>(entity =>
            {
                entity.ToTable("DChatSession");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BeginTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.LastMsgTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<DdutyDoctor>(entity =>
            {
                entity.ToTable("DDutyDoctor");

                entity.HasIndex(x => x.DepartId, "IX_DepartID");

                entity.HasIndex(x => x.DoctorId, "IX_DoctorID");

                entity.HasIndex(x => x.DutyDepartId, "IX_DutyDepartID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DutyDepartId).HasColumnName("DutyDepartID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastLogoutTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.DdutyDoctors)
                    .HasForeignKey(x => x.DepartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DDutyDoctor_dbo.TDepartments_DepartID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DdutyDoctors)
                    .HasForeignKey(x => x.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DDutyDoctor_dbo.TDoctorList_DoctorID");

                entity.HasOne(d => d.DutyDepart)
                    .WithMany(p => p.DdutyDoctors)
                    .HasForeignKey(x => x.DutyDepartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DDutyDoctor_dbo.TDutyDepartment_DutyDepartID");
            });

            modelBuilder.Entity<DepartmentGroup>(entity =>
            {
                entity.ToTable("DepartmentGroup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<DfuntionList>(entity =>
            {
                entity.ToTable("DFuntionList");

                entity.HasIndex(x => x.ParentId, "IX_ParentID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ParentIdlist).HasColumnName("ParentIDList");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(x => x.ParentId)
                    .HasConstraintName("FK_dbo.DFuntionList_dbo.DFuntionList_ParentID");
            });

            modelBuilder.Entity<DguestMessage>(entity =>
            {
                entity.ToTable("DGuestMessage");

                entity.HasIndex(x => x.InstitutionId, "IX_DGuestMessage");

                entity.HasIndex(x => x.DepartmentId, "IX_DGuestMessage_1");

                entity.HasIndex(x => x.DoctorId, "IX_DGuestMessage_2");

                entity.HasIndex(x => x.AddUserId, "IX_DGuestMessage_3");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DepartmentId).HasComment("科室ID");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.IsNew)
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否新消息");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<DguestReplay>(entity =>
            {
                entity.ToTable("DGuestReplay");

                entity.HasIndex(x => x.DguestMessageEntityId, "IX_DGuestMessageEntityId");

                entity.HasIndex(x => x.AddUserId, "IX_DGuestReplay");

                entity.HasIndex(x => x.EditUserId, "IX_DGuestReplay_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DguestMessageEntityId).HasColumnName("DGuestMessageEntityId");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.IsNew)
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否新消息");

                entity.HasOne(d => d.DguestMessageEntity)
                    .WithMany(p => p.DguestReplays)
                    .HasForeignKey(x => x.DguestMessageEntityId)
                    .HasConstraintName("FK_dbo.DGuestReplay_dbo.DGuestMessage_DGuestMessageEntityId");
            });

            modelBuilder.Entity<DhealthRecord>(entity =>
            {
                entity.ToTable("DHealthRecord");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
            });

            modelBuilder.Entity<DmessageList>(entity =>
            {
                entity.ToTable("DMessageList");

                entity.HasIndex(x => x.MsgClassId, "IX_MsgClassId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.PostTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.TopOverTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.TopTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.MsgClass)
                    .WithMany(p => p.DmessageLists)
                    .HasForeignKey(x => x.MsgClassId)
                    .HasConstraintName("FK_dbo.DMessageList_dbo.TMessageClass_MsgClassId");
            });

            modelBuilder.Entity<DmessageSendLog>(entity =>
            {
                entity.ToTable("DMessageSendLog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BillTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Link).HasMaxLength(1000);

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<DoctorDepartmentMapping>(entity =>
            {
                entity.HasKey(x => new { x.EmployeeId, x.DepartmentId })
                    .HasName("PK_dbo.Doctor_Department_Mapping");

                entity.ToTable("Doctor_Department_Mapping");

                entity.HasIndex(x => x.DepartmentId, "IX_Department_Id");

                entity.HasIndex(x => x.EmployeeId, "IX_Employee_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DoctorDepartmentMappings)
                    .HasForeignKey(x => x.DepartmentId)
                    .HasConstraintName("FK_dbo.Doctor_Department_Mapping_dbo.TDepartments_Department_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DoctorDepartmentMappings)
                    .HasForeignKey(x => x.EmployeeId)
                    .HasConstraintName("FK_dbo.Doctor_Department_Mapping_dbo.TDoctorList_Employee_Id");
            });

            modelBuilder.Entity<DuserLogin>(entity =>
            {
                entity.ToTable("DUserLogin");

                entity.HasIndex(x => x.MainMemberId, "IX_MainMemberID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.HealthCardId).HasColumnName("HealthCardID");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.MainMemberId).HasColumnName("MainMemberID");

                entity.HasOne(d => d.MainMember)
                    .WithMany(p => p.InverseMainMember)
                    .HasForeignKey(x => x.MainMemberId)
                    .HasConstraintName("FK_dbo.DUserLogin_dbo.DUserLogin_MainMemberID");
            });

            modelBuilder.Entity<ExternalAuthenticationRecord>(entity =>
            {
                entity.ToTable("ExternalAuthenticationRecord");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<GuestMessagePictureMapping>(entity =>
            {
                entity.ToTable("GuestMessage_Picture_Mapping");

                entity.HasIndex(x => x.GuestMessageId, "IX_GuestMessageId");

                entity.HasIndex(x => x.PictureId, "IX_PictureId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.GuestMessage)
                    .WithMany(p => p.GuestMessagePictureMappings)
                    .HasForeignKey(x => x.GuestMessageId)
                    .HasConstraintName("FK_dbo.GuestMessage_Picture_Mapping_dbo.DGuestMessage_GuestMessageId");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.GuestMessagePictureMappings)
                    .HasForeignKey(x => x.PictureId)
                    .HasConstraintName("FK_dbo.GuestMessage_Picture_Mapping_dbo.Picture_PictureId");
            });

            modelBuilder.Entity<GuestReplayPictureMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GuestReplay_Picture_Mapping");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<HealthRecordPicture>(entity =>
            {
                entity.HasIndex(x => x.HealthRecordId, "IX_HealthRecordId");

                entity.HasIndex(x => x.PictureId, "IX_PictureId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.HealthRecord)
                    .WithMany(p => p.HealthRecordPictures)
                    .HasForeignKey(x => x.HealthRecordId)
                    .HasConstraintName("FK_dbo.HealthRecordPictures_dbo.DHealthRecord_HealthRecordId");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.HealthRecordPictures)
                    .HasForeignKey(x => x.PictureId)
                    .HasConstraintName("FK_dbo.HealthRecordPictures_dbo.Picture_PictureId");
            });

            modelBuilder.Entity<HeapMap>(entity =>
            {
                entity.ToTable("HeapMap");

                entity.HasIndex(x => x.BuildingId, "IX_BuildingId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.HeapMaps)
                    .HasForeignKey(x => x.BuildingId)
                    .HasConstraintName("FK_dbo.HeapMap_dbo.Building_BuildingId");
            });

            modelBuilder.Entity<HisBussinessType>(entity =>
            {
                entity.HasKey(x => x.Code)
                    .HasName("PK_dbo.HisBussinessType");

                entity.ToTable("HisBussinessType");

                entity.HasIndex(x => x.Code, "IX_Code")
                    .IsUnique();
            });

            modelBuilder.Entity<JobTrigger>(entity =>
            {
                entity.ToTable("JobTrigger");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.NextTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.PrevTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<LdepartDoctor>(entity =>
            {
                entity.ToTable("LDepartDoctor");

                entity.HasIndex(x => x.DepartId, "IX_DepartID");

                entity.HasIndex(x => x.DoctorId, "IX_DoctorId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.LdepartDoctors)
                    .HasForeignKey(x => x.DepartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LDepartDoctor_dbo.TDepartments_DepartID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LdepartDoctors)
                    .HasForeignKey(x => x.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LDepartDoctor_dbo.TDoctorList_DoctorId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(x => new { x.MigrationId, x.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<MigrationLog>(entity =>
            {
                entity.HasKey(x => new { x.MigrationId, x.CompleteDt, x.ScriptChecksum });

                entity.ToTable("__MigrationLog");

                entity.HasComment("This table is required by ReadyRoll SQL Projects to keep track of which migrations have been executed during deployment. Please do not alter or remove this table from the database.");

                entity.HasIndex(x => x.CompleteDt, "IX___MigrationLog_CompleteDt");

                entity.HasIndex(x => x.Version, "IX___MigrationLog_Version");

                entity.HasIndex(x => x.SequenceNo, "UX___MigrationLog_SequenceNo")
                    .IsUnique();

                entity.Property(e => e.MigrationId)
                    .HasColumnName("migration_id")
                    .HasComment("The unique identifier of a migration script file. This value is stored within the <Migration /> Xml fragment within the header of the file itself.\r\n\r\nNote that it is possible for this value to repeat in the [__MigrationLog] table. In the case of programmable object scripts, a record will be inserted with a particular ID each time a change is made to the source file and subsequently deployed.\r\n\r\nIn the case of a migration, you may see the same [migration_id] repeated, but only in the scenario where the \"Mark As Deployed\" button/command has been run.");

                entity.Property(e => e.CompleteDt)
                    .HasColumnName("complete_dt")
                    .HasComment("The date/time that the migration finished executing. This value is populated using the SYSDATETIME function in SQL Server 2008+ or by using GETDATE in SQL Server 2005.");

                entity.Property(e => e.ScriptChecksum)
                    .HasMaxLength(64)
                    .HasColumnName("script_checksum")
                    .HasComment("A SHA256 representation of the migration script file at the time of build.  This value is used to determine whether a migration has been changed since it was deployed. In the case of a programmable object script, a different checksum will cause the migration to be redeployed.\r\nNote: if any variables have been specified as part of a deployment, this will not affect the checksum value.");

                entity.Property(e => e.AppliedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("applied_by")
                    .HasComment("The executing user at the time of deployment (populated using the SYSTEM_USER function).");

                entity.Property(e => e.Deployed)
                    .HasColumnName("deployed")
                    .HasDefaultValueSql("((1))")
                    .HasComment("This column contains a number of potential states:\r\n\r\n0 - Marked As Deployed: The migration was not executed.\r\n1- Deployed: The migration was executed successfully.\r\n2- Imported: The migration was generated by importing from this DB.\r\n\r\n\"Marked As Deployed\" and \"Imported\" are similar in that the migration was not executed on this database; it was was only marked as such to prevent it from executing during subsequent deployments.");

                entity.Property(e => e.PackageVersion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("package_version")
                    .HasComment("If you have enabled SQLCMD Packaging in your ReadyRoll project, or if you are using Octopus Deploy, this will be the version number that your database package was stamped with at build-time.");

                entity.Property(e => e.ReleaseVersion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("release_version")
                    .HasComment("If you are using Octopus Deploy, you can use the value in this column to look-up which release was responsible for deploying this migration.\r\nIf deploying via PowerShell, set the $ReleaseVersion variable to populate this column.\r\nIf deploying via Visual Studio, this column will always be NULL.");

                entity.Property(e => e.ScriptFilename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("script_filename")
                    .HasComment("The name of the migration script file on disk, at the time of build.\r\nIf Semantic Versioning has been enabled, then this value will contain the full relative path from the root of the project folder. If it is not enabled, then it will simply contain the filename itself.");

                entity.Property(e => e.SequenceNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sequence_no")
                    .HasComment("An auto-seeded numeric identifier that can be used to determine the order in which migrations were deployed.");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("version")
                    .HasComment("The semantic version that this migration was created under. In ReadyRoll projects, a folder can be given a version number, e.g. 1.0.0, and one or more migration scripts can be stored within that folder to provide logical grouping of related database changes.");
            });

            modelBuilder.Entity<MigrationLogCurrent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("__MigrationLogCurrent");

                entity.HasComment("This view is required by ReadyRoll SQL Projects to determine whether a migration should be executed during a deployment. The view lists the most recent [__MigrationLog] entry for a given [migration_id], which is needed to determine whether a particular programmable object script needs to be (re)executed: a non-matching checksum on the current [__MigrationLog] entry will trigger the execution of a programmable object script. Please do not alter or remove this table from the database.");

                entity.Property(e => e.AppliedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("applied_by");

                entity.Property(e => e.CompleteDt).HasColumnName("complete_dt");

                entity.Property(e => e.Deployed).HasColumnName("deployed");

                entity.Property(e => e.MigrationId).HasColumnName("migration_id");

                entity.Property(e => e.ScriptChecksum)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("script_checksum");

                entity.Property(e => e.ScriptFilename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("script_filename");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.ModuleCategory)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(x => x.ModuleCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ModuleCategory_Module");
            });

            modelBuilder.Entity<ModuleCategory>(entity =>
            {
                entity.ToTable("ModuleCategory");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IntroText).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<ModuleFile>(entity =>
            {
                entity.ToTable("ModuleFile");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleFiles)
                    .HasForeignKey(x => x.ModuleId)
                    .HasConstraintName("ForeignKey_ModuleId");
            });

            modelBuilder.Entity<NursingTeam>(entity =>
            {
                entity.ToTable("NursingTeam");

                entity.HasIndex(x => x.DepartmentId, "IX_DepartmentId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.NursingTeams)
                    .HasForeignKey(x => x.DepartmentId)
                    .HasConstraintName("FK_dbo.NursingTeam_dbo.TDepartments_DepartmentId");
            });

            modelBuilder.Entity<OnlineInquiry>(entity =>
            {
                entity.ToTable("OnlineInquiry");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.Subject).HasMaxLength(500);

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<ParentUserChildUserMapping>(entity =>
            {
                entity.HasKey(x => new { x.ChildUserId, x.ParentUserId })
                    .HasName("PK_dbo.ParentUser_ChildUser_Mapping");

                entity.ToTable("ParentUser_ChildUser_Mapping");

                entity.HasIndex(x => x.ChildUserId, "IX_ChildUserId");

                entity.HasIndex(x => x.ParentUserId, "IX_ParentUserId");

                entity.HasOne(d => d.ChildUser)
                    .WithMany(p => p.ParentUserChildUserMappingChildUsers)
                    .HasForeignKey(x => x.ChildUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParentUser_ChildUser_Mapping_dbo.DUserLogin_ChildUserId");

                entity.HasOne(d => d.ParentUser)
                    .WithMany(p => p.ParentUserChildUserMappingParentUsers)
                    .HasForeignKey(x => x.ParentUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParentUser_ChildUser_Mapping_dbo.DUserLogin_ParentUserId");
            });

            modelBuilder.Entity<PermissionRecord>(entity =>
            {
                entity.ToTable("PermissionRecord");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PermissionRecordRoleMapping>(entity =>
            {
                entity.HasKey(x => new { x.PermissionRecordId, x.AdministratorRoleId })
                    .HasName("PK_dbo.PermissionRecord_Role_Mapping");

                entity.ToTable("PermissionRecord_Role_Mapping");

                entity.HasIndex(x => x.AdministratorRoleId, "IX_AdministratorRole_Id");

                entity.HasIndex(x => x.PermissionRecordId, "IX_PermissionRecord_Id");

                entity.Property(e => e.PermissionRecordId).HasColumnName("PermissionRecord_Id");

                entity.Property(e => e.AdministratorRoleId).HasColumnName("AdministratorRole_Id");

                entity.HasOne(d => d.AdministratorRole)
                    .WithMany(p => p.PermissionRecordRoleMappings)
                    .HasForeignKey(x => x.AdministratorRoleId)
                    .HasConstraintName("FK_dbo.PermissionRecord_Role_Mapping_dbo.AdministratorRole_AdministratorRole_Id");

                entity.HasOne(d => d.PermissionRecord)
                    .WithMany(p => p.PermissionRecordRoleMappings)
                    .HasForeignKey(x => x.PermissionRecordId)
                    .HasConstraintName("FK_dbo.PermissionRecord_Role_Mapping_dbo.PermissionRecord_PermissionRecord_Id");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.SeoFilename).HasMaxLength(300);
            });

            modelBuilder.Entity<PillReminder>(entity =>
            {
                entity.ToTable("PillReminder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.RemindContent).HasMaxLength(200);
            });

            modelBuilder.Entity<QrtzBlobTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });

                entity.ToTable("QRTZ_BLOB_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.BlobData)
                    .HasColumnType("image")
                    .HasColumnName("BLOB_DATA")
                    .HasAnnotation("Relational:ColumnType", "image");
            });

            modelBuilder.Entity<QrtzCalendar>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.CalendarName });

                entity.ToTable("QRTZ_CALENDARS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.CalendarName)
                    .HasMaxLength(200)
                    .HasColumnName("CALENDAR_NAME");

                entity.Property(e => e.Calendar)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("CALENDAR")
                    .HasAnnotation("Relational:ColumnType", "image");
            });

            modelBuilder.Entity<QrtzCronTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });

                entity.ToTable("QRTZ_CRON_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.CronExpression)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("CRON_EXPRESSION");

                entity.Property(e => e.TimeZoneId)
                    .HasMaxLength(80)
                    .HasColumnName("TIME_ZONE_ID");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzCronTrigger)
                    .HasForeignKey<QrtzCronTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzFiredTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.EntryId });

                entity.ToTable("QRTZ_FIRED_TRIGGERS");

                entity.HasIndex(x => new { x.SchedName, x.InstanceName, x.RequestsRecovery }, "IDX_QRTZ_FT_INST_JOB_REQ_RCVRY");

                entity.HasIndex(x => new { x.SchedName, x.JobGroup }, "IDX_QRTZ_FT_JG");

                entity.HasIndex(x => new { x.SchedName, x.JobName, x.JobGroup }, "IDX_QRTZ_FT_J_G");

                entity.HasIndex(x => new { x.SchedName, x.TriggerGroup }, "IDX_QRTZ_FT_TG");

                entity.HasIndex(x => new { x.SchedName, x.InstanceName }, "IDX_QRTZ_FT_TRIG_INST_NAME");

                entity.HasIndex(x => new { x.SchedName, x.TriggerName, x.TriggerGroup }, "IDX_QRTZ_FT_T_G");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.EntryId)
                    .HasMaxLength(95)
                    .HasColumnName("ENTRY_ID");

                entity.Property(e => e.FiredTime).HasColumnName("FIRED_TIME");

                entity.Property(e => e.InstanceName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("INSTANCE_NAME");

                entity.Property(e => e.IsNonconcurrent).HasColumnName("IS_NONCONCURRENT");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.JobName)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.RequestsRecovery).HasColumnName("REQUESTS_RECOVERY");

                entity.Property(e => e.SchedTime).HasColumnName("SCHED_TIME");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("STATE");

                entity.Property(e => e.TriggerGroup)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.TriggerName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");
            });

            modelBuilder.Entity<QrtzJobDetail>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.JobName, x.JobGroup });

                entity.ToTable("QRTZ_JOB_DETAILS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.JobName)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IsDurable).HasColumnName("IS_DURABLE");

                entity.Property(e => e.IsNonconcurrent).HasColumnName("IS_NONCONCURRENT");

                entity.Property(e => e.IsUpdateData).HasColumnName("IS_UPDATE_DATA");

                entity.Property(e => e.JobClassName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("JOB_CLASS_NAME");

                entity.Property(e => e.JobData)
                    .HasColumnType("image")
                    .HasColumnName("JOB_DATA")
                    .HasAnnotation("Relational:ColumnType", "image");

                entity.Property(e => e.RequestsRecovery).HasColumnName("REQUESTS_RECOVERY");
            });

            modelBuilder.Entity<QrtzLock>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.LockName });

                entity.ToTable("QRTZ_LOCKS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.LockName)
                    .HasMaxLength(40)
                    .HasColumnName("LOCK_NAME");
            });

            modelBuilder.Entity<QrtzPausedTriggerGrp>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerGroup });

                entity.ToTable("QRTZ_PAUSED_TRIGGER_GRPS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");
            });

            modelBuilder.Entity<QrtzSchedulerState>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.InstanceName });

                entity.ToTable("QRTZ_SCHEDULER_STATE");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.InstanceName)
                    .HasMaxLength(200)
                    .HasColumnName("INSTANCE_NAME");

                entity.Property(e => e.CheckinInterval).HasColumnName("CHECKIN_INTERVAL");

                entity.Property(e => e.LastCheckinTime).HasColumnName("LAST_CHECKIN_TIME");
            });

            modelBuilder.Entity<QrtzSimpleTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });

                entity.ToTable("QRTZ_SIMPLE_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.RepeatCount).HasColumnName("REPEAT_COUNT");

                entity.Property(e => e.RepeatInterval).HasColumnName("REPEAT_INTERVAL");

                entity.Property(e => e.TimesTriggered).HasColumnName("TIMES_TRIGGERED");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzSimpleTrigger)
                    .HasForeignKey<QrtzSimpleTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzSimpropTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });

                entity.ToTable("QRTZ_SIMPROP_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.BoolProp1).HasColumnName("BOOL_PROP_1");

                entity.Property(e => e.BoolProp2).HasColumnName("BOOL_PROP_2");

                entity.Property(e => e.DecProp1)
                    .HasColumnType("numeric(13, 4)")
                    .HasColumnName("DEC_PROP_1")
                    .HasAnnotation("Relational:ColumnType", "numeric(13, 4)");

                entity.Property(e => e.DecProp2)
                    .HasColumnType("numeric(13, 4)")
                    .HasColumnName("DEC_PROP_2")
                    .HasAnnotation("Relational:ColumnType", "numeric(13, 4)");

                entity.Property(e => e.IntProp1).HasColumnName("INT_PROP_1");

                entity.Property(e => e.IntProp2).HasColumnName("INT_PROP_2");

                entity.Property(e => e.LongProp1).HasColumnName("LONG_PROP_1");

                entity.Property(e => e.LongProp2).HasColumnName("LONG_PROP_2");

                entity.Property(e => e.StrProp1)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_1");

                entity.Property(e => e.StrProp2)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_2");

                entity.Property(e => e.StrProp3)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_3");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzSimpropTrigger)
                    .HasForeignKey<QrtzSimpropTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzTrigger>(entity =>
            {
                entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });

                entity.ToTable("QRTZ_TRIGGERS");

                entity.HasIndex(x => new { x.SchedName, x.CalendarName }, "IDX_QRTZ_T_C");

                entity.HasIndex(x => new { x.SchedName, x.TriggerGroup }, "IDX_QRTZ_T_G");

                entity.HasIndex(x => new { x.SchedName, x.JobName, x.JobGroup }, "IDX_QRTZ_T_J");

                entity.HasIndex(x => new { x.SchedName, x.JobGroup }, "IDX_QRTZ_T_JG");

                entity.HasIndex(x => new { x.SchedName, x.NextFireTime }, "IDX_QRTZ_T_NEXT_FIRE_TIME");

                entity.HasIndex(x => new { x.SchedName, x.MisfireInstr, x.NextFireTime }, "IDX_QRTZ_T_NFT_MISFIRE");

                entity.HasIndex(x => new { x.SchedName, x.TriggerState, x.NextFireTime }, "IDX_QRTZ_T_NFT_ST");

                entity.HasIndex(x => new { x.SchedName, x.MisfireInstr, x.NextFireTime, x.TriggerState }, "IDX_QRTZ_T_NFT_ST_MISFIRE");

                entity.HasIndex(x => new { x.SchedName, x.MisfireInstr, x.NextFireTime, x.TriggerGroup, x.TriggerState }, "IDX_QRTZ_T_NFT_ST_MISFIRE_GRP");

                entity.HasIndex(x => new { x.SchedName, x.TriggerGroup, x.TriggerState }, "IDX_QRTZ_T_N_G_STATE");

                entity.HasIndex(x => new { x.SchedName, x.TriggerName, x.TriggerGroup, x.TriggerState }, "IDX_QRTZ_T_N_STATE");

                entity.HasIndex(x => new { x.SchedName, x.TriggerState }, "IDX_QRTZ_T_STATE");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(100)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.CalendarName)
                    .HasMaxLength(200)
                    .HasColumnName("CALENDAR_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndTime).HasColumnName("END_TIME");

                entity.Property(e => e.JobData)
                    .HasColumnType("image")
                    .HasColumnName("JOB_DATA")
                    .HasAnnotation("Relational:ColumnType", "image");

                entity.Property(e => e.JobGroup)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.MisfireInstr).HasColumnName("MISFIRE_INSTR");

                entity.Property(e => e.NextFireTime).HasColumnName("NEXT_FIRE_TIME");

                entity.Property(e => e.PrevFireTime).HasColumnName("PREV_FIRE_TIME");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.StartTime).HasColumnName("START_TIME");

                entity.Property(e => e.TriggerState)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("TRIGGER_STATE");

                entity.Property(e => e.TriggerType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("TRIGGER_TYPE");

                entity.HasOne(d => d.QrtzJobDetail)
                    .WithMany(p => p.QrtzTriggers)
                    .HasForeignKey(x => new { x.SchedName, x.JobName, x.JobGroup })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS");
            });

            modelBuilder.Entity<ReviewItem>(entity =>
            {
                entity.ToTable("ReviewItem");

                entity.HasIndex(x => x.ServicesReviewId, "IX_ServicesReviewId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ServicesReview)
                    .WithMany(p => p.ReviewItems)
                    .HasForeignKey(x => x.ServicesReviewId)
                    .HasConstraintName("FK_dbo.ReviewItem_dbo.ServicesReview_ServicesReviewId");
            });

            modelBuilder.Entity<SchemaSnapshot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("__SchemaSnapshot");

                entity.HasComment("This table is used by ReadyRoll SQL Projects to store a snapshot of the schema at the time of the last deployment. Please do not alter or remove this table from the database.");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<ServicesReview>(entity =>
            {
                entity.ToTable("ServicesReview");

                entity.HasIndex(x => x.UserId, "IX_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServicesReviews)
                    .HasForeignKey(x => x.UserId)
                    .HasConstraintName("FK_dbo.ServicesReview_dbo.DUserLogin_UserId");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Memo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("memo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<TcontentType>(entity =>
            {
                entity.ToTable("TContentType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Tdepartment>(entity =>
            {
                entity.ToTable("TDepartments");

                entity.HasIndex(x => x.ParentId, "IX_ParentID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DepartmentGroupId).HasColumnName("DepartmentGroupID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.IsOnlineChat).HasComment("是否支持在线问诊");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ParentIdlist).HasColumnName("ParentIDList");

                entity.HasOne(d => d.DepartmentGroup)
                    .WithMany(p => p.Tdepartments)
                    .HasForeignKey(x => x.DepartmentGroupId)
                    .HasConstraintName("FK_dbo.TDepartments_dbo.DepartmentGroup_ID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(x => x.ParentId)
                    .HasConstraintName("FK_dbo.TDepartments_dbo.TDepartments_ParentID");
            });

            modelBuilder.Entity<TdoctorList>(entity =>
            {
                entity.ToTable("TDoctorList");

                entity.HasIndex(x => x.InstitutionId, "IX_TDoctorList");

                entity.HasIndex(x => x.UserName, "IX_TDoctorList_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Clientid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HisSystemId).HasMaxLength(50);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.IsOnlineChat)
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否在线问诊");

                entity.Property(e => e.LastOnlineTime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastOnlineTime")
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.OnlineChatPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 2)");

                entity.Property(e => e.OnlineStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("在线状态");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("密码");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("用户名");
            });

            modelBuilder.Entity<TdutyDepartment>(entity =>
            {
                entity.ToTable("TDutyDepartment");

                entity.HasIndex(x => x.DepartId, "IX_DepartID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BeginTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DepartId).HasColumnName("DepartID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.TdutyDepartments)
                    .HasForeignKey(x => x.DepartId)
                    .HasConstraintName("FK_dbo.TDutyDepartment_dbo.TDepartments_DepartID");
            });

            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.ToTable("Terminal");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.MacAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Position).HasMaxLength(255);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<ThealthCard>(entity =>
            {
                entity.ToTable("THealthCard");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BindTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.CardId).HasMaxLength(50);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Tinstitution>(entity =>
            {
                entity.ToTable("TInstitution");

                entity.HasIndex(x => x.CarouseCategoryId, "IX_CarouseCategoryId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("版本");

                entity.HasOne(d => d.CarouseCategory)
                    .WithMany(p => p.Tinstitutions)
                    .HasForeignKey(x => x.CarouseCategoryId)
                    .HasConstraintName("FK_dbo.TInstitution_dbo.CarouselCategory_CarouseCategoryId");
            });

            modelBuilder.Entity<TmessageClass>(entity =>
            {
                entity.ToTable("TMessageClass");

                entity.HasIndex(x => x.ParentId, "IX_ParentID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ParentIdlist).HasColumnName("ParentIDList");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(x => x.ParentId)
                    .HasConstraintName("FK_dbo.TMessageClass_dbo.TMessageClass_ParentID");
            });

            modelBuilder.Entity<TmessageType>(entity =>
            {
                entity.ToTable("TMessageType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<TsystemType>(entity =>
            {
                entity.ToTable("TSystemType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<UserInstitutionMapping>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.InstitutionId })
                    .HasName("PK_dbo.User_Institution_Mapping");

                entity.ToTable("User_Institution_Mapping");

                entity.HasIndex(x => x.InstitutionId, "IX_Institution_Id");

                entity.HasIndex(x => x.UserId, "IX_User_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.InstitutionId).HasColumnName("Institution_Id");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.UserInstitutionMappings)
                    .HasForeignKey(x => x.InstitutionId)
                    .HasConstraintName("FK_dbo.User_Institution_Mapping_dbo.TInstitution_Institution_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInstitutionMappings)
                    .HasForeignKey(x => x.UserId)
                    .HasConstraintName("FK_dbo.User_Institution_Mapping_dbo.DUserLogin_User_Id");
            });

            modelBuilder.Entity<VGuestMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_GuestMessage");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");
            });

            modelBuilder.Entity<VGuestMessage1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_GuestMessage1");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");
            });

            modelBuilder.Entity<VGustMessage1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_GustMessage1");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasColumnName("addtime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
