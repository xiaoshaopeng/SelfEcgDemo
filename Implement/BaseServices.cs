using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Implement
{
    public class BaseServices
    {
        // 增删改查
        // 操作数据库，使用数据库类db

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public async void Post(object item) { }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public async void Delete(int id) { }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        public async void Put(object item) { }
    }
}