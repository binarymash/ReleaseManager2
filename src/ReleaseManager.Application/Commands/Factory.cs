using System;
using System.CodeDom;
using ReleaseManager.Application.Commands.CreateRepository;

namespace ReleaseManager.Application.Commands
{
    public class Factory
    {
        private readonly IServiceProvider _serviceProvider;

        public Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CreateRepository.Command CreateRepository()
        {
            return _serviceProvider.GetService(typeof (CreateRepository.Command)) as CreateRepository.Command;
        }
    }
}
