using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Interfaces;
using SingleStore.NET.Application.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.Application.Countries.Queries
{
    public class GetCountryByIdQuery : IRequestWrapper<CountryViewModel>
    {
        public long Id { get; private set; }

        public GetCountryByIdQuery(long id)
        {
            Id = id;
        }
    }

    public class GetCountryByIdQueryHandler : IRequestHandlerWrapper<GetCountryByIdQuery, CountryViewModel>
    {
        private readonly ICountryService _countryService;

        public GetCountryByIdQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ServiceResult<CountryViewModel>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await this._countryService.GetByIdAsync(request.Id, cancellationToken);

            return country != null ? ServiceResult.Success(country) : ServiceResult.Failed<CountryViewModel>(ServiceError.NotFound);
        }
    }
}
