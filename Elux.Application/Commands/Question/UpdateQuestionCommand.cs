using MediatR;

namespace Elux.Application.Commands.Question
{
    public class UpdateQuestionCommand : IRequest<bool>
    {
        public List<Guid> QuestionsId { get; set; }
    }
}
