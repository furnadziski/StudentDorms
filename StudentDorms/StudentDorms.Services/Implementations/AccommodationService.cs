using Microsoft.Data.SqlClient;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Implementations;
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
   public  class AccommodationService : IAccommodationService
    {
        private readonly IProcedureRepository<AccommodationGridModel> _procedureRepositoryAccommodation;
        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationService(IProcedureRepository<AccommodationGridModel> procedureRepositoryAccommodation,
            IAccommodationRepository accommodationRepository)
        {
            _procedureRepositoryAccommodation = procedureRepositoryAccommodation;
            _accommodationRepository = accommodationRepository;
        }

        
  public SearchResult<AccommodationGridModel> GetAccommodationsForGrid(AccommodationSearchModel accommodationSearchModel)
        {

            if (accommodationSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@CapacitySearch", accommodationSearchModel.CapacitySearch.HasValue ? accommodationSearchModel.CapacitySearch.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@StudentDormId", accommodationSearchModel.StudentDormId));
            parameters.Add(new SqlParameter("@Year", accommodationSearchModel.Year));
            parameters.Add(new SqlParameter("@BlockId", accommodationSearchModel.BlockId.HasValue ? accommodationSearchModel.BlockId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@UserId", accommodationSearchModel.Userid.HasValue ? accommodationSearchModel.Userid.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@HasFreeSpaceOnly", accommodationSearchModel.HasFreeSpaceOnly.HasValue ? accommodationSearchModel.HasFreeSpaceOnly.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@RoomSearchText", !string.IsNullOrEmpty(accommodationSearchModel.RoomSearchText) ? accommodationSearchModel.RoomSearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(accommodationSearchModel.OrderColumn) ? accommodationSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", accommodationSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", accommodationSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", accommodationSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryAccommodation.ExecListResultQuery("[accommodation].[FilterAccommodation]", parameters.ToArray());
            var result = new SearchResult<AccommodationGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }
    }
}
