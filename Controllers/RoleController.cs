using CSharpHelp.MyFile;
using SelfEcgDemo.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SelfEcgDemo.Controllers
{
    public class RoleController : Controller
    {
        DbContexts db = new DbContexts();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charts()
        {
            int id = 1304;
            var data = db.V_Ecg_Exam.Where(v => v.exam_id == id).FirstOrDefault();
            //return JsonReturn.ReturnView(StateCode.Success, "成功", GetEcgFile(data.data_filename));
            return Content(GetEcgFile(data.data_filename));
        }
        public string GetEcgFile(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            string rawFileName = @"E:\log_zhongjk\2020\07\21\17\20200721171301468830.raw";                
            byte[] tt = FileHelp.FileGetByte(rawFileName);
            if (tt == null)
                return "";
            sb.Append("[");
            for (int j = 0; j < 8; j++)
            {
                sb.Append(j == 0 ? "[" : ",[");
                StringBuilder sb30000 = new StringBuilder();
                int count = 0;
                for (int i = 0; i < tt.Length; i = i + 16)
                {
                    sb30000.Append("," + BitConverter.ToInt16(tt, i + j * 2) + "");
                    count++;
                }
                if (sb30000.Length > 0)
                    sb.Append(sb30000.ToString().Substring(1));
                sb.Append("]");
            }
            sb.Append("]");
            return sb.ToString();            
        }
    }
}
