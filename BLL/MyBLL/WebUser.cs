using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
    /// <summary>
    /// WebUser
    /// </summary>
    public partial class WebUser
    {
        public DataSet GetAllStudents()
        {
            string sql = " StudentId  is not null";
            return dal.GetList(sql);
        }
        public DataSet GetStudents(int studentId)
        {
            string sql = " StudentId = "+studentId;
            return dal.GetList(sql);
        }
        public Eva.Model.WebUser Login(string loginId, string paw)
        {
            string sql = " LoginId=" + "'" + loginId + "'" + " and PassWord = " +"'"+paw+"'";
            return dal.Login(sql);
        }
        public Eva.Model.WebUser GetModelByStudentId(int studentId)
        {
            string sql = " StudentId=" + studentId;
            return dal.GetModel(sql);
        }
        public List<Model.WebUser> GetModelListStudents(int studentId)
        {
            string sql = " StudentId = " + studentId;
            DataSet ds = dal.GetList(sql);
            return DataTableToList(ds.Tables[0]);
        }
    }
}

