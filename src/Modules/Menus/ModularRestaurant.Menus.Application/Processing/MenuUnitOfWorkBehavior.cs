using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Application.Processing.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Processing
{
    public class MenuUnitOfWorkBehavior<TCommand, TResult> : UnitOfWorkBehavior<IMenusUnitOfWork, TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        public MenuUnitOfWorkBehavior(IMenusUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
