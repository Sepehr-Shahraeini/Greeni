﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EPAGRIFFINEntities : DbContext
    {
        public EPAGRIFFINEntities()
            : base("name=EPAGRIFFINEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<AssignedRole> AssignedRoles { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<PersonAward> PersonAwards { get; set; }
        public virtual DbSet<PersonCertification> PersonCertifications { get; set; }
        public virtual DbSet<PersonPatent> PersonPatents { get; set; }
        public virtual DbSet<PersonProject> PersonProjects { get; set; }
        public virtual DbSet<PersonPublication> PersonPublications { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<ViewAward> ViewAwards { get; set; }
        public virtual DbSet<ViewCertification> ViewCertifications { get; set; }
        public virtual DbSet<ViewPersonPatent> ViewPersonPatents { get; set; }
        public virtual DbSet<ViewPersonPublication> ViewPersonPublications { get; set; }
        public virtual DbSet<ViewProject> ViewProjects { get; set; }
        public virtual DbSet<NetworkGroup> NetworkGroups { get; set; }
        public virtual DbSet<PersonNetwork> PersonNetworks { get; set; }
        public virtual DbSet<ViewPersonNetwork> ViewPersonNetworks { get; set; }
        public virtual DbSet<ReviewRate> ReviewRates { get; set; }
        public virtual DbSet<UserContentActivity> UserContentActivities { get; set; }
        public virtual DbSet<ViewUserContentActivity> ViewUserContentActivities { get; set; }
        public virtual DbSet<ViewOption> ViewOptions { get; set; }
        public virtual DbSet<ViewCountry> ViewCountries { get; set; }
        public virtual DbSet<ViewPersonReview> ViewPersonReviews { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ViewPerson> ViewPersons { get; set; }
    }
}
