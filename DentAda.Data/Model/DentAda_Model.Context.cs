﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentAda.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DentAdaEntities : DbContext
    {
        public DentAdaEntities()
            : base("name=DentAdaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ANNOUNCEMENT> ANNOUNCEMENT { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ConnectionLog> ConnectionLog { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Exception> Exception { get; set; }
        public virtual DbSet<ExceptionFeedBack> ExceptionFeedBack { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuthorization> RoleAuthorization { get; set; }
        public virtual DbSet<RoleSideMenu> RoleSideMenu { get; set; }
        public virtual DbSet<RoleTopMenu> RoleTopMenu { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<SideMenu> SideMenu { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }
        public virtual DbSet<SystemUserRole> SystemUserRole { get; set; }
        public virtual DbSet<SystemUserRoleLocation> SystemUserRoleLocation { get; set; }
        public virtual DbSet<SystemUserRoleParameter> SystemUserRoleParameter { get; set; }
        public virtual DbSet<SystemUserTicket> SystemUserTicket { get; set; }
        public virtual DbSet<TopMenu> TopMenu { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<Village> Village { get; set; }
        public virtual DbSet<CDC> CDC { get; set; }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
    
        public virtual ObjectResult<Role_List_Result> Role_List(Nullable<System.Guid> tbsUserId, Nullable<long> systemUserId)
        {
            var tbsUserIdParameter = tbsUserId.HasValue ?
                new ObjectParameter("TbsUserId", tbsUserId) :
                new ObjectParameter("TbsUserId", typeof(System.Guid));
    
            var systemUserIdParameter = systemUserId.HasValue ?
                new ObjectParameter("SystemUserId", systemUserId) :
                new ObjectParameter("SystemUserId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Role_List_Result>("Role_List", tbsUserIdParameter, systemUserIdParameter);
        }
    }
}
