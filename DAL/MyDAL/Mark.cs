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
            strSql.Append("select Mark.Id,Mark.CourseId,Mark.StudentId,Mark.EvalutionId,Mark.Score,Mark.BonusPoint,Mark.AcademicYear,Mark.SchoolTerm,Mark.CheckStep,Mark.Reason ");
            strSql.Append(" FROM Mark ,Teach");
            strSql.Append(" where Mark.CourseId=Teach.CourseId and Teach.TeacherId=" + teacherid + " and Mark.CheckStep=1");
            
            return DbHelperSQL.Query(strSql.ToString());

        }
        public DataSet GetListMarkWithStu(int stuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CourseId,StudentId,EvalutionId,Score,BonusPoint,AcademicYear,SchoolTerm,CheckStep,Reason ");
            strSql.Append(" FROM Mark ");
            strSql.Append(" where  StudentId =" + stuId + " and CheckStep=1");

            return DbHelperSQL.Query(strSql.ToString());

        }

    }
}

