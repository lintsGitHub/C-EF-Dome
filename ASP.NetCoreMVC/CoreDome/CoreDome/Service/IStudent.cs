using CoreDome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDome.Service
{
    public interface IStudent
    {
        /// <summary>
        /// 异步获取所有的学生
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllStudentAsync();
        /// <summary>
        /// 根据ID获取该学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Student> GetStudentByIDAsync(int id);
        /// <summary>
        /// 异步添加Student对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task AddStudentAsync(Student student);

    }
}
