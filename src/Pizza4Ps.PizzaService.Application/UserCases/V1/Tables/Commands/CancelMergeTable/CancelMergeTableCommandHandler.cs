﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CancelMergeTable
{
    public class CancelMergeTableCommandHandler : IRequestHandler<CancelMergeTableCommand>
    {
        private readonly ITableMergeRepository _tableMergeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;

        public CancelMergeTableCommandHandler(ITableRepository tableRepository,
            IUnitOfWork unitOfWork, ITableMergeRepository tableMergeRepository)
        {
            _tableMergeRepository = tableMergeRepository;
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
        }
        public async Task Handle(CancelMergeTableCommand request, CancellationToken cancellationToken)
        {
            var tables = await _tableRepository.GetListAsTracking(x => x.TableMergeId == request.TableMergeId).ToListAsync();
            //if (!tables.Any())
            //{
            //    throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            //}

            if (tables.Any(t => t.CurrentOrderId != null))
                throw new BusinessException("Bàn đã được sử dụng cho một đơn hàng, vui lòng kiểm tra lại");
            foreach (var table in tables)
            {
                table.CancelMerge();
                table.SetClosing();
                _tableRepository.Update(table);
            }
            var tableMerge = await _tableMergeRepository.GetSingleByIdAsync(request.TableMergeId);
            _tableMergeRepository.HardDelete(tableMerge);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
