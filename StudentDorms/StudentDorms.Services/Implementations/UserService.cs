using Microsoft.Data.SqlClient;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.Base;
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
   public class UserService : IUserService
    {
        private readonly IProcedureRepository<UserGridModel> _procedureRepositoryUser;
 
        public UserService(IProcedureRepository<UserGridModel> procedureRepositoryUser)
        {
            _procedureRepositoryUser = procedureRepositoryUser;
            
        }
        public SearchResult<UserGridModel> GetUsersForGrid(UserSearchModel userSearchModel)
        {
           
            if (userSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(userSearchModel.SearchText) ? userSearchModel.SearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@RoleId", userSearchModel.RoleId.HasValue?userSearchModel.RoleId.Value: (object)DBNull.Value));
            parameters.Add(new SqlParameter("@GenderId", userSearchModel.GenderId.HasValue?userSearchModel.GenderId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@IsActive", userSearchModel.IsActive.HasValue?userSearchModel.IsActive.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(userSearchModel.OrderColumn) ? userSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", userSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", userSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", userSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryUser.ExecListResultQuery("[config].[FilterUsers]", parameters.ToArray());
            var result = new SearchResult<UserGridModel>();
            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }

       
    }
}

