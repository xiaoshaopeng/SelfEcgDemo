using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace SelfEcgDemo.Common
{
    public class JsonReturn
    {
        public static JsonResult ReturnView(bool flag)
        {
            return ReturnView();
        }

        public static JsonResult ReturnView(int code = StateCode.Success, string msg = "", object Data = null)
        {
            return new JsonResult
            {
                State = code,
                Message = msg,
                Data = Data,
                AesKey = "",
            };
        }
    }
}