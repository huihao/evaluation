using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eva.BLL
{
    public static class BLLFactory
    {
        private static WebUser WebUserBLLInstance;
        private static readonly object syncRootWebUser = new Object();

        public static WebUser GetWebUserBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (WebUserBLLInstance == null)
            {
                lock (syncRootWebUser)
                {
                    if (WebUserBLLInstance == null)
                        WebUserBLLInstance = new WebUser();
                }
            }
            return WebUserBLLInstance;
        }
    }
}
