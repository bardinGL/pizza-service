﻿using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.AspNetCore.Identity;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffService : DomainService, IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffRepository _staffRepository;
        private readonly UserManager<AppUser> _userManager;

        public StaffService(IUnitOfWork unitOfWork, IStaffRepository staffRepository, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _staffRepository = staffRepository;
            _userManager = userManager;
        }

        public async Task<Guid> CreateAsync(string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status)
        {
            var entity = new Staff(Guid.NewGuid(), fullName, phone, email, staffType, status);
            _staffRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffRepository.HardDelete(entity);
                }
                else
                {
                    _staffRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status, string? newPassword = null)
        {
            var entity = await _staffRepository.GetSingleByIdAsync(id);
            entity.UpdateStaff(fullName, phone, email, staffType, status);

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                var user = await _userManager.FindByIdAsync(entity.AppUserId.ToString());
                if (user == null)
                {
                    throw new BusinessException("User not found.");
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
                if (!resetResult.Succeeded)
                {
                    var errorMessage = string.Join(", ", resetResult.Errors.Select(e => e.Description));
                    throw new BusinessException(errorMessage);
                }
            }

            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
