using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Common
{
    public class StateCode
    {
        /// <summary>
        /// 无权限-1
        /// </summary>
        public const int UNAUTHORIZED = -1;
        /// <summary>
        /// 成功0
        /// </summary>
        public const int Success = 0;
        /// <summary>
        /// 错误1
        /// </summary>
        public const int Error = 1;
        /// <summary>
        /// 异常2
        /// </summary>
        public const int Exception = 2;
    }
}