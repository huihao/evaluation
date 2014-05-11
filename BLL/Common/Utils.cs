using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eva.BLL
{
    public static class Utils
    {
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
    }
}
