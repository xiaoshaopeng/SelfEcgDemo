using SelfEcgDemo.Common;
using SelfEcgDemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelfEcgDemo.Controllers
{
    public class LoginController : Controller
    {
        DbContexts db = new DbContexts();
        /**
         login页面两个方法，分别是登入、登出
     登入逻辑：
         用户名和密码，和密码加密后，和数据库进行比较，一致则成功，跳转页面，失败则提示
            进一步解析：登录，肯定有登录的对象
     登出：
         清除一切相关信息，并跳转到登录界面
      */
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>        
        public ActionResult UserLogin(t_user user)
        {
            var flag = db.T_User.Where(a=>a.account.Equals(user.account)).FirstOrDefault();
            if (flag!=null)
            {
                if (user.password.Equals(flag.password))
                {
                    return JsonReturn.ReturnView(StateCode.Success, "登录成功");
                }
                else
                {
                    return JsonReturn.ReturnView(StateCode.Error, "登录失败");
                }
            }
            else
            {
                return JsonReturn.ReturnView(StateCode.Error, "账户不存在");
            }
        }
        /// <summary>
        ///  用户登出
        /// </summary>        
        public ActionResult SignOut()
        {
            return View();
        }
    }
}
