using Microsoft.Data.SqlClient;
using StudentDorms.AutoMapper;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Implementations;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
    public class StudentDormService : IStudentDormService
    {
        private readonly IProcedureRepository<StudentDormGridModel> _procedureRepositoryStudentDorm;
        private readonly IStudentDormRepository _studentDormRepository;

        public StudentDormService(IProcedureRepository<StudentDormGridModel> procedureRepositoryStudentDorm, IStudentDormRepository studentDormRepository)
        {
            _procedureRepositoryStudentDorm = procedureRepositoryStudentDorm;
            _studentDormRepository = studentDormRepository;
        }

        public SearchResult<StudentDormGridModel> GetStudentDormsForGrid(StudentDormSearchModel studentDormSearchModel)
        {

            if (studentDormSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(studentDormSearchModel.SearchText) ? studentDormSearchModel.SearchText : (object)DBNull.Value));
      
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(studentDormSearchModel.OrderColumn) ? studentDormSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", studentDormSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", studentDormSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", studentDormSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryStudentDorm.ExecListResultQuery("[config].[FilterStudentDorms]", parameters.ToArray());
            var result = new SearchResult<StudentDormGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }

        public void CreateStudentDorm(StudentDormCreateUpdateModel studentDormCreateUpdateModel)
        {
            if (studentDormCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }
            var studentDorm = studentDormCreateUpdateModel.ToDomain<StudentDorm, StudentDormCreateUpdateModel>();

            _studentDormRepository.Create(studentDorm);
        }

        public void UpdateStudentDorm(StudentDormCreateUpdateModel studentDormCreateUpdateModel)
        {
            if (studentDormCreateUpdateModel == null) {

                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }

               var studentDorm = _studentDormRepository.GetById(studentDormCreateUpdateModel.Id);

            if (studentDorm == null)
            {
                throw new StudentDormsException("Не постои запис за студентски дом во база");
            }

            studentDorm.Order = studentDormCreateUpdateModel.Order;
            studentDorm.Name = studentDormCreateUpdateModel.Name;

            _studentDormRepository.Update(studentDorm);

        }
        public void DeleteStudentDormById(int id)
        {
            var deletedStudentDorm = _studentDormRepository.GetById(id);

            if (deletedStudentDorm == null)
            {
                throw new StudentDormsException("Студентски дом  со даденотo id не постои");
            }

            if (_studentDormRepository.HasAssociatedBlocks(id))
            {
                throw new StudentDormsException("За студенскиот дом постои блок");
            }
            else _studentDormRepository.DeleteById(id);
        }


    }
}
