using CSharpHelp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SelfEcgDemo.Common
{
    public class JsonResult : JsonResult<object>
    {
        public JsonResult() : base() { }
    }
    public class JsonResult<T> : ActionResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据对象，不适用时说着为null
        /// </summary>
        public T Data { get; set; }
        public string AesKey { get; set; }

        public JsonResult()
        {

        }

        // 还原ActionResult的方法
        public override void ExecuteResult(ControllerContext context)
        {
            if (State == 2) { Message = ""; }
            var contents = string.Format("{{\"state\":{0},\"msg\":\"{1}\"}}", State, Message);
            if (Data != null)
            {
                contents = string.Format("{{\"state\":{0},\"msg\":\"{1}\",\"data\":{2}}}", State, Message, JsonHelp.ToJson(Data));
            }
            // 返回conten的内容，以及编码
            new ContentResult
            {
                Content = contents,
                ContentEncoding = System.Text.Encoding.UTF8
            }.ExecuteResult(context);
        }
    }

    
}