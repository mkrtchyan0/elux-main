using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Services
{
    /// <summary>
    /// Command class representing a request to add a new service.
    /// </summary>
    public class AddServiceCommand : IRequest<BaseResponse<Service>>
    {
        /// <summary>
        /// Gets or sets the ID of the service group to which the service belongs.
        /// </summary>
        public Guid ServiceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the duration of the service in minutes.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        public int Price { get; set; }
    }

}
