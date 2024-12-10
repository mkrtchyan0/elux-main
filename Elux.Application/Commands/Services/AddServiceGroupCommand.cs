using Azure;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Services
{
    /// <summary>
    /// Command class representing a request to add a new service group.
    /// </summary>
    public class AddServiceGroupCommand : IRequest<BaseResponse<ServiceGroup>>
    {
        /// <summary>
        /// Gets or sets the name of the service group.
        /// </summary>
        public string ServiceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the description of the service group.
        /// </summary>
        public string ServiceDescription { get; set; }

        /// <summary>
        /// Gets or sets the picture associated with the service group (e.g., URL or image path).
        /// </summary>
        public string Picture { get; set; }
    }

}
