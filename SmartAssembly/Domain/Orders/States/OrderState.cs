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
