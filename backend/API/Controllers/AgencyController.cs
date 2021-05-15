using System;
using System.Linq;
using AutoMapper;
using Core.Services.Interfaces;
using Core.ViewModels;
using Data.Repositories.Interfaces;
using Data.ViewModels;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AgencyController : BaseController
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AgencyController(INotificationHandler<EntityNotification> notificationHandler, IUserService userService, IMediatorHandler mediator, IAgencyRepository agencyRepository, IMapper mapper) : base(notificationHandler, userService, mediator)
        {
            _agencyRepository = agencyRepository ?? throw new ArgumentNullException(nameof(agencyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public AgencyViewModel GetOne()
        {
            var agency = _agencyRepository.GetAll()?.FirstOrDefault();
            return _mapper.Map<AgencyViewModel>(agency ?? throw new ArgumentNullException(nameof(agency)));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AgencyLoginViewModel loginViewModel)
        {
            var agency = _agencyRepository
                .Find(a => a.BusinessId == loginViewModel.BusinessId && a.Password == loginViewModel.EncryptedPassword)
                .FirstOrDefault();

            if (agency is null)
            {
                HandleError("Agency", "Invalid Business ID/password");
                return Response(loginViewModel);
            }

            var agencyToReturn = _mapper.Map<AgencyViewModel>(agency);

            return Response(agencyToReturn);
        }
    }
}