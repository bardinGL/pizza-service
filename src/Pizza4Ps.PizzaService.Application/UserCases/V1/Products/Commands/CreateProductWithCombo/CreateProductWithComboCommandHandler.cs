﻿using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Newtonsoft.Json;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProductWithCombo
{
    public class CreateProductWithComboCommandHandler : IRequestHandler<CreateProductWithComboCommand, ResultDto<Guid>>
    {
        private readonly IProductComboSlotRepository _productComboSlotRepository;
        private readonly IProductComboSlotItemRepository _productComboSlotItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly Cloudinary _cloudinary;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CreateProductWithComboCommandHandler(IMapper mapper,
            IProductService productService,
            IOptionRepository optionRepository,
            IOptionItemRepository optionItemRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            Cloudinary cloudinary,
            IProductComboSlotItemRepository productComboItemRepository, IProductComboSlotRepository productComboSlotRepository)
        {
            _productComboSlotRepository = productComboSlotRepository;
            _productComboSlotItemRepository = productComboItemRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _optionItemRepository = optionItemRepository;
            _optionRepository = optionRepository;
            _cloudinary = cloudinary;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateProductWithComboCommand request, CancellationToken cancellationToken)
        {
            string? imageUrl = null;
            string? imagePublicId = null;
            try
            {
                // Upload ảnh nếu có
                if (request.file != null && request.file.Length > 0)
                {
                    using var stream = request.file.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(request.file.FileName, stream),
                        UseFilename = true,
                        UniqueFilename = false,
                        Overwrite = true
                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    if (uploadResult.Error != null)
                        throw new BusinessException("Upload image failed");

                    imageUrl = uploadResult.SecureUrl.ToString();
                    imagePublicId = uploadResult.PublicId;
                }

                // Tạo product entity
                var product = new Product(
                    Guid.NewGuid(),
                    name: request.Name,
                    price: request.Price,
                    null,
                    description: request.Description,
                    categoryId: request.CategoryId,
                    productType: null,
                    imageUrl: imageUrl,
                    imagePublicId: imagePublicId,
                    productRole: ProductRoleEnum.Combo,
                    parentProductId: null
                );
                var comboSlots = new List<ComboSlotModel>();
                comboSlots = JsonConvert.DeserializeObject<List<ComboSlotModel>>(request.ComboSlots);

                // 2. Use comboItems as before
                foreach (var item in comboSlots!)
                {
                    var comboSlot = new ProductComboSlot(
                        id: Guid.NewGuid(),
                        comboId: product.Id,
                        slotname: item.SlotName);
                    _productComboSlotRepository.Add(comboSlot);
                    foreach (var option in item.ComboSlotItems)
                    {
                        var comboSlotItem = new ProductComboSlotItem(
                            id: Guid.NewGuid(),
                            productComboSlotId: comboSlot.Id,
                            productId: option.ProductId,
                            extraPrice: option.ExtraPrice);
                        _productComboSlotItemRepository.Add(comboSlotItem);
                    }
                }
                // Thêm product, option và option item vào repository
                _productRepository.Add(product);
                await _unitOfWork.SaveChangeAsync(cancellationToken);
                return new ResultDto<Guid>
                {
                    Id = product.Id,
                };
            }
            catch (Exception)
            {
                // Nếu có lỗi, xóa ảnh đã upload (nếu có)
                if (!string.IsNullOrEmpty(imagePublicId))
                {
                    await _cloudinary.DeleteResourcesAsync(new DelResParams
                    {
                        PublicIds = new List<string> { imagePublicId }
                    });
                }
                throw;
            }
        }
    }
}
