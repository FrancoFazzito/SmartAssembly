﻿using Application.Repositories.Interfaces;
using Domain.Orders;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrder
    {
        private readonly IDeleteById delete;

        public DeleteOrder(IDeleteById delete)
        {
            this.delete = delete;
        }

        public void Delete(int id)
        {
            delete.Delete(id);
        }
    }
}