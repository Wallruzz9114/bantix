using System;
using System.Linq;
using AutoMapper;
using Core.Utilities;
using Core.ViewModels;
using Data.Enums;
using Data.Interfaces;
using Data.Repositories.Interfaces;
using Data.ViewModels;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    public class AgentsController : BaseController
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AgentsController(INotificationHandler<EntityNotification> notificationHandler, IUserService userService, IMediatorHandler mediator, IAgentRepository agentRepository, IMapper mapper, IConfiguration configuration) : base(notificationHandler, userService, mediator)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public AgentViewModel GetOne()
        {
            var agent = _agentRepository.GetAll()?.FirstOrDefault();
            return _mapper.Map<AgentViewModel>(agent ?? throw new ArgumentNullException(nameof(agent)));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AgentLoginViewModel loginViewModel)
        {
            var agent = _agentRepository
                .Find(a => a.BusinessId == loginViewModel.BusinessId && a.Password == loginViewModel.EncryptedPassword)
                .FirstOrDefault();

            if (agent is null)
            {
                HandleError("Agent", "Invalid Business ID/password");
                return Response(loginViewModel);
            }

            var userViewModel = new UserViewModel
            {
                Id = agent.Id,
                UserType = UserType.Agent
            };
            var authResponse = new
            {
                token = TokenHandler.CreateToken(userViewModel, _configuration),
                agent = _mapper.Map<AgentViewModel>(agent)
            };

            return Response(authResponse);
        }
    }
}