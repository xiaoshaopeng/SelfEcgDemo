using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Models.EF
{
    /**
     当类写好后，要写主键[Key]，以及必须输入的[Required],限制条件[StringLength(50)]等
        byte指的是数据库的tinyint,加问号？是可为空
         */
    /// <summary>
    /// 用户表
    /// </summary>
    public class t_user
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        [StringLength(50)]
        public string account { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(2)]
        public string sex { get; set; }
        public byte? age { get; set; }
        [StringLength(50)]
        public string id_card { get; set; }
        [StringLength(20)]
        public string phone { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(200)]
        public string user_address { get; set; }
        public int user_group { get; set; }
        
        public bool user_state { get; set; }
        public int? doctor_state { get; set; }
    }
}