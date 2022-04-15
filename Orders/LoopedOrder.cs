namespace Orders
{
    class LoopedOrder : IOrder
    {
        IOrder order;
        public bool Required {get; set;} = true;

        public LoopedOrder(IOrder order)
        {
            this.order = order;
        }

        public LoopedOrder(IOrder order, bool required) : this(order)
        {
            this.Required = required;
        }

        public int Processing(string expression)
        {
            int result = 0;
            int output;

            while (true)
            {
                output = this.order.Processing(expression.Substring(result));

                if (output == -1)
                {
                    break;
                }

                result += output;
            }

            if (result == 0)
            {
                result--;
            }

            return result;
        }
    }
}