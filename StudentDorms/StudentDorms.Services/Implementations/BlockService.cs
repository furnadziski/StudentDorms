﻿using Microsoft.Data.SqlClient;
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

using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Services.Implementations
{
    public class BlockService :IBlockService
    {
        private readonly IProcedureRepository<BlockGridModel> _procedureRepositoryBlock;
        private readonly IBlockRepository _blockRepository;
        private readonly IRoomRepository _roomRepository;

        public BlockService(
            IProcedureRepository<BlockGridModel> procedureRepositoryBlock,
            IBlockRepository blockRepository,
            IRoomRepository roomRepository
            )
        {
            _procedureRepositoryBlock = procedureRepositoryBlock;
            _blockRepository = blockRepository;
            _roomRepository = roomRepository;
        }

        public SearchResult<BlockGridModel> GetBlocksForGrid(BlockSearchModel blockSearchModel)
        {
            if (blockSearchModel == null)
            {
                throw new StudentDormsException("Моделот не постои!");
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TotalItems", SqlDbType.Int) { Direction = ParameterDirection.Output });
            parameters.Add(new SqlParameter("@SearchText", !string.IsNullOrEmpty(blockSearchModel.SearchText) ? blockSearchModel.SearchText : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@StudentDormId", blockSearchModel.StudentDormId.HasValue ? blockSearchModel.StudentDormId.Value : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderColumn", !string.IsNullOrEmpty(blockSearchModel.OrderColumn) ? blockSearchModel.OrderColumn : (object)DBNull.Value));
            parameters.Add(new SqlParameter("@OrderDirection", blockSearchModel.OrderDirection));
            parameters.Add(new SqlParameter("@PageNumber", blockSearchModel.PageNumber));
            parameters.Add(new SqlParameter("@RowsPerPage", blockSearchModel.RowsPerPage));

            var dbResult = _procedureRepositoryBlock.ExecListResultQuery("[config].[FilterBlocks]", parameters.ToArray());
            var result = new SearchResult<BlockGridModel>();

            result.Data = dbResult.ToList();
            result.Count = parameters[0].Value != null ? (int)parameters[0].Value : 0;
            return result;
        }

        public void CreateBlock(BlockCreateUpdateModel blockCreateUpdateModel)
        {
            if (blockCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да содржи null вредност");
            }

            var block = blockCreateUpdateModel.ToDomain<Block, BlockCreateUpdateModel>();


            _blockRepository.Create(block);
        }

        public void UpdateBlock(BlockCreateUpdateModel blockCreateUpdateModel)
        {
            if (blockCreateUpdateModel == null)
            {
                throw new StudentDormsException("Моделот не смее да биде null ");
            }

            var block = _blockRepository.GetById(blockCreateUpdateModel.Id);
            if (block == null)
            {
                throw new StudentDormsException("Не постои запис за блок во база");
            }

            block.Name = blockCreateUpdateModel.Name;
            block.Order = blockCreateUpdateModel.Order;
            block.StudentDormId = blockCreateUpdateModel.StudentDormId;
              _blockRepository.Update(block);
        }
        public void DeleteBlockById(int id)
        {
            var deletedBlock = _blockRepository.GetById(id);

            if (deletedBlock == null)
            {
                throw new StudentDormsException("Блокот со даденотo id не постои");
            }

            if (_blockRepository.HasAssociatedRooms(id))
            {
                throw new StudentDormsException("За блокот постои соба");
            }
            else _blockRepository.DeleteById(id);
        }

        public BlockViewModel GetBlockById(int blockId)
        {
            var block = _blockRepository.GetBlockForUpdateById(blockId);
            if (block == null)
            {
                throw new StudentDormsException("За блокот со даденотo id нема запис");
            }
            var result = block.ToDomain<BlockViewModel, Block>();
            return result;
        }

        public List<DropdownViewModel<int>> GetBlocksForDropdown()
        {
            var blocks = _blockRepository.GetAll();
            if (blocks == null)
            {
                return new List<DropdownViewModel<int>>();
            }

            var result = blocks.Select(x => x.ToModel<DropdownViewModel<int>, Block>()).ToList();
            return result;
        }

        public List<DropdownViewModel<int>> GetBlocksForDropdownByStudentDormId(int StudentDormid)
        {
            var blocks = _blockRepository.GetBlockByStudentDormId(StudentDormid);
            if (blocks == null)
            {
                return new List<DropdownViewModel<int>>();
            }

            var result = blocks.Select(x => x.ToModel<DropdownViewModel<int>, Block>()).ToList();
            return result;
        }

    }
}
