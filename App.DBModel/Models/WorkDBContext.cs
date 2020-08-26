using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.DBModel.Models
{
    public partial class WorkDBContext : DbContext
    {
        public WorkDBContext()
        {
        }

        public WorkDBContext(DbContextOptions<WorkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<OrgEmpRls> OrgEmpRls { get; set; }
        public virtual DbSet<OrgManagerRls> OrgManagerRls { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationManage> OrganizationManage { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectEmployeeRls> ProjectEmployeeRls { get; set; }
        public virtual DbSet<RecentContacts> RecentContacts { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleSystemPage> RoleSystemPage { get; set; }
        public virtual DbSet<Sms> Sms { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SystemPage> SystemPage { get; set; }
        public virtual DbSet<UserUsedCount> UserUsedCount { get; set; }
        public virtual DbSet<Work> Work { get; set; }
        public virtual DbSet<WorkVote> WorkVote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("添加时间");

                entity.Property(e => e.DeleteStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("删除标志");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasComment("登录时间");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("手机号");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("姓名");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("密码");

                entity.Property(e => e.Pinying).HasMaxLength(2000);

                entity.Property(e => e.Spinying)
                    .HasColumnName("SPinying")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("用户名");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RoleId });

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRole)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRole_Employee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRole_Role");
            });

            modelBuilder.Entity<OrgEmpRls>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.EmployeeId })
                    .HasName("PK_OrganizationEmployee");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasComment("组织id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("员工id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OrgEmpRls)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_OrganizationEmployee_Employee");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrgEmpRls)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_OrganizationEmployee_Organization");
            });

            modelBuilder.Entity<OrgManagerRls>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.EmployeeId });

                entity.Property(e => e.OrganizationId).HasColumnName("Organization_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OrgManagerRls)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrgManagerRls_Employee");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrgManagerRls)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrgManagerRls_Organization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.DeleteStatus)
                    .HasDefaultValueSql("((0))")
                    .HasComment("删除标志");

                entity.Property(e => e.LevelCodes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("分级编码");

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasComment("备注");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("名称");

                entity.Property(e => e.OrganizationTypeId).HasComment("组织类型");

                entity.Property(e => e.UpId)
                    .HasColumnName("UpID")
                    .HasComment("上级ID");

                entity.HasOne(d => d.OrganizationType)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.OrganizationTypeId)
                    .HasConstraintName("FK_Organization_OrganizationType");
            });

            modelBuilder.Entity<OrganizationManage>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.EmployeeId })
                    .HasName("PK_OrganizationManage_1");

                entity.Property(e => e.OrganizationId).HasColumnName("Organization_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationManage)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationManage_Organization");
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("名称");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("添加时间");

                entity.Property(e => e.IsDisable).HasDefaultValueSql("((0))");

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasComment("备注");

                entity.Property(e => e.Pingyin).HasMaxLength(1000);

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("项目名称");

                entity.Property(e => e.Spingyin)
                    .HasColumnName("SPingyin")
                    .HasMaxLength(1000);

                entity.Property(e => e.Uid).HasComment("添加人");
            });

            modelBuilder.Entity<ProjectEmployeeRls>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId });

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProjectEmployeeRls)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectEmployeeRls_ProjectEmployeeRls");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectEmployeeRls)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectEmployeeRls_Project");
            });

            modelBuilder.Entity<RecentContacts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddEmployeeId)
                    .HasColumnName("AddEmployeeID")
                    .HasComment("被添加员工");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("添加时间");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("员工");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleSystemPage>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.SystemPageId });

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.SystemPageId).HasColumnName("SystemPage_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleSystemPage)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleSystemPage_RoleSystemPage");

                entity.HasOne(d => d.SystemPage)
                    .WithMany(p => p.RoleSystemPage)
                    .HasForeignKey(d => d.SystemPageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleSystemPage_SystemPage");
            });

            modelBuilder.Entity<Sms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("发送时间");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("验证码");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("手机号");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("时间");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("操作");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("员工ID");
            });

            modelBuilder.Entity<SystemPage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(1000);

                entity.Property(e => e.PageUrl).HasMaxLength(1000);
            });

            modelBuilder.Entity<UserUsedCount>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("添加时间");

                entity.Property(e => e.Complete)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("完成度(0-100%)");

                entity.Property(e => e.CompleteMemo)
                    .HasColumnType("text")
                    .HasComment("完成总结");

                entity.Property(e => e.CompleteTime)
                    .HasColumnType("datetime")
                    .HasComment("完成时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasComment("内容");

                entity.Property(e => e.CreateEmployeeId)
                    .HasColumnName("CreateEmployeeID")
                    .HasComment("创建人");

                entity.Property(e => e.DeleteStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))")
                    .HasComment("删除标志");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("完成时间");

                entity.Property(e => e.ExcuteEmployeeId)
                    .HasColumnName("ExcuteEmployeeID")
                    .HasComment("负责人");

                entity.Property(e => e.LevelCodes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("分级编码");

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasComment("备注");

                entity.Property(e => e.Pinying).HasMaxLength(2000);

                entity.Property(e => e.PlanEndTime)
                    .HasColumnType("datetime")
                    .HasComment("计划完成时间");

                entity.Property(e => e.PlanStartTime)
                    .HasColumnType("datetime")
                    .HasComment("计划开始时间");

                entity.Property(e => e.ProjectId).HasComment("所属项目");

                entity.Property(e => e.ReceivingStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))")
                    .HasComment("接收状态");

                entity.Property(e => e.RefuseReason)
                    .HasColumnType("text")
                    .HasComment("拒绝理由");

                entity.Property(e => e.Spinying)
                    .HasColumnName("SPinying")
                    .HasMaxLength(500);

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("实际开始时间");

                entity.Property(e => e.SubCount).HasComment("子节点个数");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("标题");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("工作类型（1.自建、2.上级指派、3.协同）");

                entity.Property(e => e.UpId)
                    .HasColumnName("UpID")
                    .HasComment("父ID");

                entity.Property(e => e.Urgency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("紧急程度:1紧急重要、2重要、3紧急、4一般");

                entity.HasOne(d => d.CreateEmployee)
                    .WithMany(p => p.WorkCreateEmployee)
                    .HasForeignKey(d => d.CreateEmployeeId)
                    .HasConstraintName("FK_Work_Employee");

                entity.HasOne(d => d.ExcuteEmployee)
                    .WithMany(p => p.WorkExcuteEmployee)
                    .HasForeignKey(d => d.ExcuteEmployeeId)
                    .HasConstraintName("FK_Work_Employee1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Work)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Work_Project");
            });

            modelBuilder.Entity<WorkVote>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("时间");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("内容");

                entity.Property(e => e.Support)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("点赞");

                entity.Property(e => e.TalkEmployeeId)
                    .HasColumnName("TalkEmployeeID")
                    .HasComment("发言人");

                entity.Property(e => e.WorkId)
                    .HasColumnName("WorkID")
                    .HasComment("工作项ID");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.WorkVote)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WorkVote_Work");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
