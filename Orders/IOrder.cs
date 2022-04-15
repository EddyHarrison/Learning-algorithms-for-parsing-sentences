namespace Orders
{
    interface IOrder
    {
        bool Required {get; set;}
        int Processing(string expression);
    }
}