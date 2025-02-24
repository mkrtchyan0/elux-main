﻿using Elux.Domain.Entities;
using Elux.Domain.Models;
using MediatR;

namespace Elux.Application.Commands.CartDraft.BookService
{
    public class AddBookServiceItemCommand : IRequest<bool>
    {
        public Guid CartDraftId { get; set; }
        public List<BookServiceItemDraftModel> Items {  get; set; } 
    }
}