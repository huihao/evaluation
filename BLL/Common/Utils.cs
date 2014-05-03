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
    }
}
