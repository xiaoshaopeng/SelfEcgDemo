using SelfEcgDemo.Common;
using SelfEcgDemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace SelfEcgDemo.Controllers
{
    public class UserController : Controller
    {
        DbContexts db = new DbContexts();

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="account">账号</param>     
        [HttpGet]
        public ActionResult Get(string account)
        {
            List<t_user> list = new List<t_user>();
            if (account != "")
            {
                list = db.T_User.Where(a => a.account == account).ToList();
                if (list != null)
                    return JsonReturn.ReturnView(StateCode.Success, "查询账户'" + account + "'成功", list);
                else
                    return JsonReturn.ReturnView(StateCode.Error, "没有这个人的数据");
            }
            else
            {
                list = db.T_User.AsQueryable().ToList();
                return JsonReturn.ReturnView(StateCode.Success, "查询所有人成功", list);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>   
        [HttpPost]
        public ActionResult Post(t_user user)
        {
            var exsitUser = db.T_User.Where(a => a.account == user.account);
            if (exsitUser.Count() == 0)
            {
                if (user.sex == null && user.sex.Length > 2) return JsonReturn.ReturnView(StateCode.Error, "未选择年龄");
                if (user.account != null && user.password != null && user.name != null)
                {
                    db.T_User.Add(user);
                    db.SaveChanges();
                    return JsonReturn.ReturnView(StateCode.Success, "添加成功");
                }
                else
                {
                    return JsonReturn.ReturnView(StateCode.Error, "账号或密码和姓名，三项不可为空");
                }
            }
            else return JsonReturn.ReturnView(StateCode.Error, "该用户已存在于列表");
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPut]
        public ActionResult Put(t_user user)
        {
            var exsitUser = db.T_User.Where(a => a.account == user.account).FirstOrDefault();
            if (exsitUser == null) return JsonReturn.ReturnView(StateCode.Error, "没有这条数据的存在");
            else
            {
                exsitUser.name = user.name;
                exsitUser.sex = user.sex == "男" ? "1" : "0";
                exsitUser.phone = user.phone;
                exsitUser.user_address = user.user_address;
                exsitUser.id_card = user.id_card;
                exsitUser.age = user.age;
                exsitUser.email = user.email;
                db.SaveChanges();
                return JsonReturn.ReturnView(StateCode.Success, "修改成功");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="account">删除的账号</param>
        [HttpDelete]
        public ActionResult Delete(int userid)
        {
            var exsitUser = db.T_User.Where(a => a.user_id == userid).FirstOrDefault();
            if (exsitUser != null)
            {
                db.T_User.Remove(exsitUser);
                db.SaveChanges();
                return JsonReturn.ReturnView(StateCode.Success, "删除成功");
            }
            else
            {
                return JsonReturn.ReturnView(StateCode.Error, "删除失败，没有这条数据的存在");
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="signature"></param>
        [HttpPost]
        public ActionResult UploadPost(t_signature signature)
        {
            // 为对应的用户创建文件夹存放其电子签名
            string fileSavePath = AppDomain.CurrentDomain.BaseDirectory + "FileSave\\" + signature.doctorId;
            if (!Directory.Exists(fileSavePath))
                Directory.CreateDirectory(fileSavePath);
            if (Request.Files.Count == 0)
            {
                return JsonReturn.ReturnView(StateCode.Error, "未接受到上传文件！");
            }
            else
            {
                HttpPostedFileBase file = Request.Files[0];
                string errorMsg = "传输的文件不是jpg或png的类型，您传输的是" + file.ContentType + "，此类型不支持";

                // 限制文件类型
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                    // 限制文件大小
                    int fileSize = 1262485504; // 等于1024KB
                    if (file.ContentLength > fileSize)
                        return JsonReturn.ReturnView(StateCode.Error, "您传输的文件大小超过定义的1024kb大小，请修改图片大小进行传输");

                    var user = db.T_User.Where(a => a.user_id == signature.doctorId).FirstOrDefault();
                    if (user != null)
                    {
                        // 若已存在文件，先清除旧文件
                        DirectoryInfo directory = new DirectoryInfo(fileSavePath);
                        if (directory.GetFiles().Count() > 0)
                        {
                            foreach(var item in directory.GetFiles())
                            {
                                item.Delete();
                            }                            
                        }
                        var userSignature = db.T_Signature.Where(item => item.doctorId == signature.doctorId).FirstOrDefault();
                        if (userSignature != null)
                        {
                            userSignature.signatureFile = file.FileName;                                                                                  
                        }
                        else
                        {                            
                            db.T_Signature.Add(signature);
                        }
                        file.SaveAs(fileSavePath + "\\" + file.FileName);
                        db.SaveChanges();
                        return JsonReturn.ReturnView(StateCode.Success, "上传文件" + file.FileName + "成功");

                    }
                    else
                    {
                        return JsonReturn.ReturnView(StateCode.Error, "上传失败，没有找到对应的医生");
                    }                        
                    
                }
                else return JsonReturn.ReturnView(StateCode.Error, errorMsg);
            }
        }
        [HttpGet]
        public ActionResult GetFile(int doctorId)
        {
            var isFile = db.T_Signature.Where(a => a.doctorId == doctorId);
            if (isFile.Count() > 0)
            {                
                string imgPath = ConfigHelp.imgDirPath + doctorId + "/"+ isFile.First().signatureFile;
                return JsonReturn.ReturnView(StateCode.Success, "该用户已拥有电子签名", imgPath);
            }
            else
            {
                return JsonReturn.ReturnView(StateCode.Error, "获取图片失败");
            }
        }
    }
}
