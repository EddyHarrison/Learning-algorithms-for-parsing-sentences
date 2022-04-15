namespace Orders
{
    class OrderVariants : IOrder
    {
        IOrder[] arrayOrders;
        public bool Required {get; set;} = true;

        public OrderVariants(IOrder[] arrayOrders)
        {
            this.arrayOrders = arrayOrders;
        }

        public OrderVariants(IOrder[] arrayOrders, bool required) : this(arrayOrders)
        {
            this.Required = required;
        }

        public int Processing(string expression)
        {
            int output;

            for (int index = 0; index < this.arrayOrders.Length; index++)
            {
                output = this.arrayOrders[index].Processing(expression);
                
                if (output != -1)
                {
                    return output;
                }
            }

            return -1;
        }
    }
}