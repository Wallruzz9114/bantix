using System;
using System.Linq;
using API.Utils;
using AutoMapper;
using Core.Services.Interfaces;
using Data.Enums;
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
    [Authorize]
    public class AgentController : BaseController
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AgentController(INotificationHandler<EntityNotification> notificationHandler, IUserService userService, IMediatorHandler mediator, IAgentRepository agentRepository, IMapper mapper, IConfiguration configuration) : base(notificationHandler, userService, mediator)
        {
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Authorize(Policy = "Authenticated")]
        public AgentViewModel GetOne()
        {
            var agent = _agentRepository.GetAll()?.FirstOrDefault();
            return _mapper.Map<AgentViewModel>(agent ?? throw new ArgumentNullException(nameof(agent)));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AgentLoginInputViewModel viewModel)
        {
            var agent = _agentRepository
                .Find(a => a.BusinessId == viewModel.BusinessId && a.Password == viewModel.EncryptedPassword)
                .FirstOrDefault();

            if (agent is null)
            {
                HandleError("Agent", "Invalid Business ID/password");
                return Response(viewModel);
            }

            var userViewModel = new UserViewModel
            {
                Id = UserId,
                UserType = UserType.Agent
            };

            return Response(new
            {
                token = TokenHandler.GenerateToken(userViewModel, _configuration),
                agent = _mapper.Map<AgentViewModel>(agent)
            });
        }
    }
}