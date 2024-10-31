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
using StudentDorms.Models.ViewModels;
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
    public class AnnualAccommodationService : IAnnualAccommodationService
    {
        private readonly IProcedureRepository<AccommodationGridModel> _procedureRepositoryAccommodation;
        private readonly IAnnualAccommodationRepository _accommodationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAnnualAccommodationUserRepository _annualAccommodationUserRepository;


        public AnnualAccommodationService(IProcedureRepository<AccommodationGridModel> procedureRepositoryAccommodation,
            IAnnualAccommodationRepository accommodationRepository, IUserRepository userRepository,IAnnualAccommodationUserRepository annualAccommodationUserRepository)
        {
            _procedureRepositoryAccommodation = procedureRepositoryAccommodation;
            _accommodationRepository = accommodationRepository;
            _userRepository = userRepository;
            _annualAccommodationUserRepository = annualAccommodationUserRepository;
        }


        public SearchResult<AccommodationGridModel> GetAnnualAccommodationsForGrid(AnnualAccommodationSearchModel accommodationSearchModel)
        {

            if (accommodationSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@Year", accommodationSearchModel.Year));
            parameters.Add(new SqlParameter("@BlockId", accommodationSearchModel.BlockId.HasValue ? accommodationSearchModel.BlockId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@StudentDormId", accommodationSearchModel.StudentDormId));
            parameters.Add(new SqlParameter("@HasFreeSpaceOnly", accommodationSearchModel.HasFreeSpaceOnly));
            parameters.Add(new SqlParameter("@CapacitySearch", accommodationSearchModel.CapacitySearch.HasValue ? accommodationSearchModel.CapacitySearch.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@UserId", accommodationSearchModel.Userid.HasValue ? accommodationSearchModel.Userid.Value : (object)DBNull.Value));
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

        public void UpdateAnnualAccommodation(AccommodationCreateUpdateModel accommodationCreateUpdateModel)
        {
            if (accommodationCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да биде null ");
            }

            var accommodation = _accommodationRepository.GetByIdWithStudents(accommodationCreateUpdateModel.Id);
            if (accommodation == null)
            {
                throw new StudentDormsException("Не постои запис за сместувањето во база");
            }

            var newUsers = accommodationCreateUpdateModel.Users
                   .Select(x => new AnnualAccommodationUser
                   { Id = x.Id,
                       User = _userRepository.GetById(x.Id)
                   }).ToList();
            var currentUsers = accommodation.AnnualAccommodationUsers;
            var genderId = 0;
            foreach (var user in newUsers)
            {

                if (genderId == 0 || genderId == user.User.GenderId)
                {
                    genderId = user.User.GenderId;
                } else throw new StudentDormsException("Студентите мора да бидат од ист пол");

            }
            var usersToAdd = newUsers
                .Where(newUser => !currentUsers.Any(currentUser => currentUser.Id == newUser.Id))
                .ToList();


            if (usersToAdd.Count > accommodation.Room.Capacity) {
                throw new StudentDormsException("Го надминавте капацитетот на собата");
            }
            
            var usersToRemove = currentUsers
                .Where(currentUser => !newUsers.Any(newUser => newUser.Id == currentUser.Id))
                .ToList();

          
            

            foreach (var user in usersToAdd)
            {
                 var tmp = new AnnualAccommodationUser
                 {
                     UserId = user.Id,
                     AnnualAccommodationId = accommodation.Id
                 };
                 _annualAccommodationUserRepository.Create(tmp);
                          
            }
                


            foreach (var user in usersToRemove)
            {
               _annualAccommodationUserRepository.Delete(user);
            }
                  }

        public AccommodationViewModel GetAccommodationById(int accId)
        {
            var accommodation = _accommodationRepository.GetByIdWithStudents(accId);
            if (accommodation == null)
            {
                throw new StudentDormsException("За сместувањето со даденотo id нема запис");
            }


            var res = new AccommodationViewModel
            {
                Id = accommodation.Id,
                Students = accommodation.AnnualAccommodationUsers.Select(x => x.ToModel<DropdownViewModel<int>, AnnualAccommodationUser>()).ToList(),
                Capacity = accommodation.Room.Capacity,
                Room=accommodation.Room.RoomNo
             };
                return res;
            }

        }
    }
