using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CoreDome.Model;

namespace CoreDome.Service
{
    public class StudentService : IStudent
    {
        /// <summary>
        /// 这里就模仿一些数据库
        /// </summary>
        private readonly List<Student> students = new List<Student>();
        /// <summary>
        /// 初始化
        /// </summary>
        public StudentService()
        {
            students.Add(new Student
            {
                ID = 1,
                Name = "lint",
                Age = 21
            });
            students.Add(new Student
            {
                ID = 2,
                Name = "lints",
                Age = 21
            });
        }

        public Task AddStudentAsync(Student student)
        {
            return Task.Run(() => students.Add(student));
        }

        /// <summary>
        /// 异步获取所有的学生
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Student>> GetAllStudentAsync()
        {
           

            return Task.Run(() => students.AsEnumerable());
        }
        /// <summary>
        /// 根据ID获取该学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Student> GetStudentByIDAsync(int id)
        {
            return Task.Run(() => students.FirstOrDefault(x => x.ID == id));
        }
    }
}
