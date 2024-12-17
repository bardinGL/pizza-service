using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _CategoryRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<CategoryDto>(entity);
            return new GetCategoryByIdQueryResponse
            {
                Category = result
            };
        }
    }
}
