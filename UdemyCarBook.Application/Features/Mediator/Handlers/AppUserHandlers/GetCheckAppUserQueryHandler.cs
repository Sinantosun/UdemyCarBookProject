using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appuserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appuserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appuserRepository = appuserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appuserRepository.GetByFilter(t => t.UserName == request.UserName && t.Password == request.Password);
           
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                var approle = await _appRoleRepository.GetByFilter(y => y.AppRoleId == user.AppRoleId);
                values.IsExist = true;
                values.UserName = request.UserName;
                values.Role = approle.Role;
                values.Id = user.Id;
                
                
            }
            return values;

        }
    }
}
