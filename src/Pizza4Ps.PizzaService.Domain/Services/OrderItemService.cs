﻿using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class OrderItemService : DomainService, IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderItemRepository _orderitemRepository;

        public OrderItemService(IUnitOfWork unitOfWork, IOrderItemRepository orderitemRepository)
        {
            _unitOfWork = unitOfWork;
            _orderitemRepository = orderitemRepository;
        }

        public async Task<Guid> CreateAsync(string name, int quantity, decimal price, string status, Guid orderId, Guid productId)
        {
            var entity = new OrderItem(Guid.NewGuid(), name, quantity, price, status, orderId, productId);
            _orderitemRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _orderitemRepository.HardDelete(entity);
                }
                else
                {
                    _orderitemRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _orderitemRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name, int quantity, decimal price, string status, Guid orderId, Guid productId)
        {
            var entity = await _orderitemRepository.GetSingleByIdAsync(id);
            entity.UpdateOrderItem(name, quantity, price, status, orderId, productId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task UpdateStatusToCancelledAsync(Guid id, Guid orderId)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => x.OrderId.Equals(orderId) && x.Id.Equals(id)).ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);

            foreach (var entity in entities)
            {
                entity.UpdateOrderItem(entity.Name, entity.Quantity, entity.Price, "Cancelled", entity.OrderId, entity.ProductId);

            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToPendingAsync(Guid id, Guid orderId)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => x.OrderId.Equals(orderId) && x.Id.Equals(id)).ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);

            foreach (var entity in entities)
            {
                entity.UpdateOrderItem(entity.Name, entity.Quantity, entity.Price, "Pending", entity.OrderId, entity.ProductId);

            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToServedAsync(Guid id, Guid orderId)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => x.OrderId.Equals(orderId) && x.Id.Equals(id)).ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);

            foreach (var entity in entities)
            {
                entity.UpdateOrderItem(entity.Name, entity.Quantity, entity.Price, "Served", entity.OrderId, entity.ProductId);

            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToServingAsync(Guid id, Guid orderId)
        {
            var entities = await _orderitemRepository.GetListAsTracking(x => x.OrderId.Equals(orderId) && x.Id.Equals(id)).ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);

            foreach (var entity in entities)
            {
                entity.UpdateOrderItem(entity.Name, entity.Quantity, entity.Price, "Serving", entity.OrderId, entity.ProductId);

            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
