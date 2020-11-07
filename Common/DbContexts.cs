using SelfEcgDemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Common
{
    public class DbContexts : DbContext
    {
        public DbContexts() : base("name=DbContexts") { }

        public DbSet<t_user> T_User { get; set; }
        public DbSet<t_signature> T_Signature { get; set; }
        public DbSet<v_ecg_exam> V_Ecg_Exam { get; set; }
    }
}