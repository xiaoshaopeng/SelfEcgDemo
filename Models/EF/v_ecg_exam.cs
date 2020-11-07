using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Models.EF
{
    public class v_ecg_exam
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int exam_id { get; set; }

        [StringLength(50)]
        public string filler_order_no { get; set; }

        public int? user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte status { get; set; }

        [Key]
        [Column(Order = 2)]
        public string name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string sex { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte age { get; set; }

        [StringLength(30)]
        public string id_card { get; set; }

        [StringLength(50)]
        public string col_ip { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime exam_date { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime local_date { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string data_filename { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(10)]
        public string rhythm { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(10)]
        public string printerval { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(10)]
        public string qrsduration { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(10)]
        public string qrsaxis { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(10)]
        public string qtinterval { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(10)]
        public string qtc { get; set; }

        [StringLength(200)]
        public string diag_ten { get; set; }

        [StringLength(200)]
        public string diag_nine { get; set; }

        [StringLength(200)]
        public string diag_eight { get; set; }

        [StringLength(200)]
        public string diag_seven { get; set; }

        [StringLength(200)]
        public string diag_six { get; set; }

        [StringLength(200)]
        public string diag_five { get; set; }

        [StringLength(200)]
        public string diag_four { get; set; }

        [StringLength(200)]
        public string diag_three { get; set; }

        [StringLength(200)]
        public string diag_two { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(200)]
        public string diag_one { get; set; }

        public int? critical_value { get; set; }
    }
}