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

        private static Class ClassBLLInstance;
        private static readonly object syncRootClass = new Object();

        public static Class GetClassBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (ClassBLLInstance == null)
            {
                lock (syncRootClass)
                {
                    if (ClassBLLInstance == null)
                        ClassBLLInstance = new Class();
                }
            }
            return ClassBLLInstance;
        }

        private static College CollegeBLLInstance;
        private static readonly object syncRootCollege = new Object();

        public static College GetCollegeBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (CollegeBLLInstance == null)
            {
                lock (syncRootCollege)
                {
                    if (CollegeBLLInstance == null)
                        CollegeBLLInstance = new College();
                }
            }
            return CollegeBLLInstance;
        }

        private static Major MajorBLLInstance;
        private static readonly object syncRootMajor = new Object();

        public static Major GetMajorBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (MajorBLLInstance == null)
            {
                lock (syncRootMajor)
                {
                    if (MajorBLLInstance == null)
                        MajorBLLInstance = new Major();
                }
            }
            return MajorBLLInstance;
        }

        private static Course CourseBLLInstance;
        private static readonly object syncRootCourse = new Object();

        public static Course GetCourseBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (CourseBLLInstance == null)
            {
                lock (syncRootCourse)
                {
                    if (CourseBLLInstance == null)
                        CourseBLLInstance = new Course();
                }
            }
            return CourseBLLInstance;
        }

        private static Evaluation EvaluationBLLInstance;
        private static readonly object syncRootEvaluation = new Object();

        public static Evaluation GetEvaluationBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (EvaluationBLLInstance == null)
            {
                lock (syncRootEvaluation)
                {
                    if (EvaluationBLLInstance == null)
                        EvaluationBLLInstance = new Evaluation();
                }
            }
            return EvaluationBLLInstance;
        }

        private static Item ItemBLLInstance;
        private static readonly object syncRootItem = new Object();

        public static Item GetItemBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (ItemBLLInstance == null)
            {
                lock (syncRootItem)
                {
                    if (ItemBLLInstance == null)
                        ItemBLLInstance = new Item();
                }
            }
            return ItemBLLInstance;
        }

        private static ItemList ItemListBLLInstance;
        private static readonly object syncRootItemList = new Object();

        public static ItemList GetItemListBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (ItemListBLLInstance == null)
            {
                lock (syncRootItemList)
                {
                    if (ItemListBLLInstance == null)
                        ItemListBLLInstance = new ItemList();
                }
            }
            return ItemListBLLInstance;
        }

        private static Mark MarkBLLInstance;
        private static readonly object syncRootMark = new Object();

        public static Mark GetMarkBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (MarkBLLInstance == null)
            {
                lock (syncRootMark)
                {
                    if (MarkBLLInstance == null)
                        MarkBLLInstance = new Mark();
                }
            }
            return MarkBLLInstance;
        }

        private static Teach TeachBLLInstance;
        private static readonly object syncRootTeach = new Object();

        public static Teach GetTeachBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (TeachBLLInstance == null)
            {
                lock (syncRootTeach)
                {
                    if (TeachBLLInstance == null)
                        TeachBLLInstance = new Teach();
                }
            }
            return TeachBLLInstance;
        }

        private static Authority AuthorityBLLInstance;
        private static readonly object syncRootAuthority = new Object();

        public static Authority GetAuthorityBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (AuthorityBLLInstance == null)
            {
                lock (syncRootAuthority)
                {
                    if (AuthorityBLLInstance == null)
                        AuthorityBLLInstance = new Authority();
                }
            }
            return AuthorityBLLInstance;
        }


        private static Awards AwardsBLLInstance;
        private static readonly object syncRootAwards = new Object();

        public static Awards GetAwardsBLLInstance()
        {
            //如实例不存在，则New一个新实例，否则返回已有实例
            if (AwardsBLLInstance == null)
            {
                lock (syncRootAwards)
                {
                    if (AwardsBLLInstance == null)
                        AwardsBLLInstance = new Awards();
                }
            }
            return AwardsBLLInstance;
        }
    }
}
