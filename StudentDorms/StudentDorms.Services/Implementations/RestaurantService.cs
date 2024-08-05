using StudentDorms.AutoMapper;
using StudentDorms.Common.Exceptions;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IProcedureRepository<RestaurantGridModel> _procedureRepositoryRestaurant;
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IProcedureRepository<RestaurantGridModel> procedureRepositoryRestaurant, 
                                 IRestaurantRepository restaurantRepository)
        {
            _procedureRepositoryRestaurant = procedureRepositoryRestaurant;
            _restaurantRepository = restaurantRepository;
            
        }

        public SearchResult<RestaurantGridModel> GetRestaurantsForGrid(RestaurantSearchModel restaurantSearchModel)
        {
            var result = new SearchResult<RestaurantGridModel>();
            result.Data = new List<RestaurantGridModel>();
            result.Count = 0;

            return result;
            //if (restaurantSearchModel == null)
            //{
            //    throw new StudentDormsException("Моделот не постои!");
            //}
            //var parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            //parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(restaurantSearchModel.SearchText) ? restaurantSearchModel.SearchText : (object)DBNull.Value));
            //parameters.Add(new SqlParameter("@OrderColumn", restaurantSearchModel.OrderColumn));
            //parameters.Add(new SqlParameter("@OrderDirection", restaurantSearchModel.OrderDirection));
            //parameters.Add(new SqlParameter("@PageNumber", restaurantSearchModel.PageNumber));
            //parameters.Add(new SqlParameter("@RowsPerPage", restaurantSearchModel.RowsPerPage));

            //var dbResult = _procedureRepositoryRestaurant.ExecListResultQuery("[config].[FilterRestaurants]", parameters.ToArray());
            //var result = new SearchResult<RestaurantGridModel>();
            //result.Data = dbResult.ToList();
            //result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            //return result;
        }

        public void CreateRestaurant(RestaurantCreateUpdateModel restaurantCreateUpdateModel)
        {
            if(restaurantCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }

            //var restaurant = restaurantCreateUpdateModel.ToDomain<Restaurant, UserCreateUpdateModel>();
            //restaurant.CreatedBy = "gorazdn";
            //restaurant.DateCreated = DateTime.Now;
            //restaurant.ModifiedBy = "gorazdn";
            //restaurant.DateModified = DateTime.Now;
            //_restaurantRepository.Create(restaurant);
        }

        public void UpdateRestaurant(RestaurantCreateUpdateModel restaurantUpdateModel)
        {
            if (restaurantUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да биде null ");
            }

            var restaurant = _restaurantRepository.GetById(restaurantUpdateModel.Id);
            if(restaurant == null)
            {
                throw new StudentDormsException("Не постои запис за ресторан во база");
            }

            restaurant.Order = restaurantUpdateModel.Order;
            restaurant.Participation = restaurantUpdateModel.Participation;
            restaurant.Name = restaurantUpdateModel.Name;

            _restaurantRepository.Update(restaurant);
        }

        public void DeleteRestaurantById(int id)
        {
            var deletedRestaurant = _restaurantRepository.GetById(id);

            if (deletedRestaurant == null)
            {
                throw new StudentDormsException("Ресторан со даденотo id не постои");
            }
           
            _restaurantRepository.DeleteById(id);
        }

        public RestaurantCreateUpdateModel GetRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if(restaurant == null)
            {
                throw new StudentDormsException("За ресторанот со даденотo id нема запис");
            }
            var result = restaurant.ToDomain<RestaurantCreateUpdateModel, Restaurant>();
            return result;
        }

        public List<DropdownViewModel<int>> GetRestaurantsForDropdown()
        {
            var restaurants = _restaurantRepository.GetAll();
            if(restaurants == null)
            {
                throw new StudentDormsException("Не постои запис за рестораните");
            }

            var result = restaurants.Select(x => x.ToModel<DropdownViewModel<int>, Restaurant>()).ToList();
            return result;
        }
    }
}
