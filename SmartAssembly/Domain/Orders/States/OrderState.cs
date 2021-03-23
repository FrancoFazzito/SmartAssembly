using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.States
{
    public enum OrderState
    {
        Uncompleted = 1,
        Completed = 2,
        Delivered = 3,
        Mistake = 4
    }
}
