using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCustomerIgnoreQueryFilterQuery, GetListCustomerIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerIgnoreQueryFilterQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetListCustomerIgnoreQueryFilterQueryResponse> Handle(GetListCustomerIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(includeProperties: request.GetListCustomerIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListCustomerIgnoreQueryFilterDto.FullName == null || x.FullName.Contains(request.GetListCustomerIgnoreQueryFilterDto.FullName))
                    && (request.GetListCustomerIgnoreQueryFilterDto.Phone == null || x.Phone.Contains(request.GetListCustomerIgnoreQueryFilterDto.Phone))
                    && x.IsDeleted == request.GetListCustomerIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListCustomerIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListCustomerIgnoreQueryFilterDto.SkipCount).Take(request.GetListCustomerIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCustomerIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
