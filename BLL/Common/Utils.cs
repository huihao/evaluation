using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eva.BLL
{
    public static class Utils
    {
        public static string GetClassName(int id)
        {
            var bll = new Class();
            return bll.GetModel(id).Name;
        }
        public static string GetCollegeName(int id)
        {
            var bll = new College();
            return bll.GetModel(id).Name;
        }
        public static string GetMajorName(int id)
        {
            var bll = new Major();
            return bll.GetModel(id).Name;
        }
        public static string GetCourseName(int id)
        {
            var bll = new Course();
            return bll.GetModel(id).Name;
        }

        public static decimal GetCourseGpa(int id)
        {
            var bll = new Course();
            return decimal.Parse(bll.GetModel(id).Gpa.ToString());
        }

        public static int GetCollegeIdByName(string name)
        {
            var list = new BLL.College().GetModelList(" Name= '" + name + "'");
            return list.Count > 0 ? list[0].Id : -1;
        }

        public static int GetMajorIdByName(string collegeName, string majorName)
        {
            int collegeId = GetCollegeIdByName(collegeName);
            if (collegeId > 0)
            {
                var list = new BLL.Major().GetModelList(" Name= '" + majorName + "'" + " and CollegeId= " + collegeId);
                return list.Count > 0 ? list[0].Id : -1;
            }
            else
            {
                return -1;
            }

        }

        public static int GetClassIdByName(string collegeName, string majorName, string className)
        {

            int majorId = GetMajorIdByName(collegeName, majorName);
            if (majorId > 0)
            {
                var list = new BLL.Class().GetModelList(" Name= '" + className + "'" + " and MajorId= " + majorId);
                return list.Count > 0 ? list[0].Id : -1;
            }
            else
            {
                return -1;
            }

        }
        public static string GetStudentName(int studentId)
        {
            var bll = new Eva.BLL.WebUser();
            return bll.GetModelByStudentId(studentId).Name;
        }

        public static string GetItemName(int itemId)
        {
            var bll = new Eva.BLL.Item();
            return bll.GetModel(itemId).Name;
        }

        public static int GetStuIdByName(string stuName)
        {


            var list = new BLL.WebUser().GetModelList(" Name= '" + stuName+" '");
                return list.Count > 0 ? Convert.ToInt32( list[0].StudentId) : -1;
           

        }
        public static int GetCourseIdByName(string courseName)
        {
            var list = new BLL.Course().GetModelList(" Name= '" + courseName+" ' ");
            return list.Count > 0 ? list[0].Id : -1;

        }
        public static string GetAuthNamebyId(int id)
        {
            var bll = new BLL.Authority();
            return bll.GetModel(id).Name;
        }



        public static bool GetMark(string stuName, string courseName)
        {
            var list = new BLL.Mark().GetModelList(" StudentId= " + GetStuIdByName(stuName) + " And CourseId = " + GetCourseIdByName(courseName));
            return list.Count > 0 ? true : false;
        }
   

    }
}
