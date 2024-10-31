using Microsoft.Data.SqlClient;
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
    public class RoomService :IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IProcedureRepository<RoomGridModel> _procedureRepositoryRoom;

        public RoomService(IRoomRepository roomRepository, IProcedureRepository<RoomGridModel> procedureRepositoryRoom)
        {
            _roomRepository = roomRepository;
            _procedureRepositoryRoom = procedureRepositoryRoom;
        }

        public SearchResult<RoomGridModel> GetRoomsForGrid(RoomSearchModel roomSearchModel)
        {

            if (roomSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(roomSearchModel.SearchText) ? roomSearchModel.SearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@StudentDormId", roomSearchModel.StudentDormId.HasValue ? roomSearchModel.StudentDormId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@BlockId", roomSearchModel.BlockId.HasValue ? roomSearchModel.BlockId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(roomSearchModel.OrderColumn) ? roomSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", roomSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", roomSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", roomSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryRoom.ExecListResultQuery("[config].[FilterRooms]", parameters.ToArray());
            var result = new SearchResult<RoomGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }
        public void CreateRoom(RoomCreateUpdateModel roomCreateUpdateModel)
        {
            if (roomCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }
            var room = roomCreateUpdateModel.ToDomain<Room, RoomCreateUpdateModel>();
            _roomRepository.Create(room);
        }

        public void UpdateRoom(RoomCreateUpdateModel roomCreateUpdateModel)
        {
            if (roomCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да биде null ");
            }

            var room = _roomRepository.GetById(roomCreateUpdateModel.Id);
            if (room == null)
            {
                throw new StudentDormsException("Не постои запис за соба во база");
            }
            room.IsActive = roomCreateUpdateModel.IsActive;
            room.Order = roomCreateUpdateModel.Order;
            room.RoomNo = roomCreateUpdateModel.RoomNo;
            room.Capacity = roomCreateUpdateModel.Capacity;
            room.BlockId = roomCreateUpdateModel.BlockId;
            _roomRepository.Update(room);
        }

        public void DeleteRoomById(int id)
        {
            var deletedRoom = _roomRepository.GetById(id);

            if (deletedRoom == null)
            {
                throw new StudentDormsException("Собата  со даденотo id не постои");
            }

            if (_roomRepository.HasAssociatedAnnualAccommodations(id))
            {
                throw new StudentDormsException("Собата е поврзанa со годишно сместување");
            }
            else _roomRepository.DeleteById(id);
        }

        public RoomViewModel GetRoomById(int roomid)
        {
            var room = _roomRepository.GetRoomForUpdateById(roomid);
            if (room == null)
            {
                throw new StudentDormsException("За собата со даденотo id нема запис");
            }

           
            var result = new RoomViewModel
            {
                Id = room.Id,
                Order = room.Order,
                Block = new DropdownViewModel<int> {
                    Id = room.BlockId,
                    Title = room.Block.Name
                },
                Capacity=room.Capacity,
                RoomNo=room.RoomNo,
                StudentDorm =new DropdownViewModel<int> {
                    Id=room.Block.StudentDormId,
                Title=room.Block.StudentDorm.Name}
                
            };

            return result;
        }
        public List<DropdownViewModel<int>> GetRoomsForDropdown()
        {
            var rooms = _roomRepository.GetAll();
            if (rooms == null)
            {
                throw new StudentDormsException("Не постои запис за собите");

            }
            var result = rooms.Select(x => x.ToModel<DropdownViewModel<int>, Room>()).ToList();
            return result;

        }

        public List<DropdownViewModel<int>> GetRoomsForDropdownByBlockId(int BlockId)
        {
            var dorms = _roomRepository.GetRoomsForDropdownByBlockId(BlockId);
            if (dorms == null)
            {
                return new List<DropdownViewModel<int>>();
            }

            var result = dorms.Select(x => x.ToModel<DropdownViewModel<int>, Room>()).ToList();
            return result;
        }

    }
}
