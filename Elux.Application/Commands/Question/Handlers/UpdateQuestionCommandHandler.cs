using Elux.Dal.Data;
using MediatR;

namespace Elux.Application.Commands.Question.Handlers
{
    public class UpdateQuestionCommandHandler (ApplicationDbContext context): IRequestHandler<UpdateQuestionCommand, bool>
    {
        public Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
