using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
    /// <summary>
    /// 数据访问类:Mark
    /// </summary>
    public partial class Mark
    {
        public DataSet GetListMarkWithTeacher(int teacherid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Mark.Id,Mark.CourseId,Mark.StudentId,Mark.EvalutionId,Mark.Score,Mark.BonusPoint,Mark.AcademicYear,Mark.SchoolTerm,Mark.CheckStep ");
            strSql.Append(" FROM Mark ,Teach");
            strSql.Append(" where Mark.CourseId=Teach.CourseId and Teach.TeacherId=" + teacherid + " and Mark.CheckStep=1");
            
            return DbHelperSQL.Query(strSql.ToString());

        }

    }
}

