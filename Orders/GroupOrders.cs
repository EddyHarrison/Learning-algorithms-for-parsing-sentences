namespace Orders
{
    class GroupOrders : IOrder
    {
        IOrder[] arrayOrders;
        int position = -1;
        public bool Required {get; set;} = true;

        public GroupOrders(IOrder[] arrayOrders)
        {
            this.arrayOrders = arrayOrders;
        }

        public GroupOrders(IOrder[] arrayOrders, bool required) : this(arrayOrders)
        {
            this.Required = required;
        }

        public int Processing(string expression)
        {
            int result = 0;

            if (expression.Length == 0)
            {
                this.position = result;
                return -1;
            }

            int output;

            for (int index = 0; index < this.arrayOrders.Length; index++)
            {
                output = this.arrayOrders[index].Processing(expression.Substring(result));

                if (output == -1)
                {
                    if (this.arrayOrders[index].Required)
                    {
                        position = result;
                        return -1;
                    }

                    output = 0;
                }

                result += output;
            }

            return result;
        }

        public int getPosition()
        {
            return this.position;
        }
    }
}