using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListCustomerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetListCustomerQueryResponse> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(
                x => (request.GetListCustomerDto.FullName == null || x.FullName.Contains(request.GetListCustomerDto.FullName))
                && (request.GetListCustomerDto.Phone == null || x.Phone.Contains(request.GetListCustomerDto.Phone)),
                includeProperties: request.GetListCustomerDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListCustomerDto.SortBy)
                .Skip(request.GetListCustomerDto.SkipCount).Take(request.GetListCustomerDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.CustomerErrorConstant.CUSTOMER_NOT_FOUND);
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCustomerQueryResponse(result, totalCount);
        }
    }
}
