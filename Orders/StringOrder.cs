namespace Orders
{
    class StringOrder : IOrder
    {
        private string stringOrder;
        public bool Required {get; set;} = true;

        public StringOrder(string stringOrder)
        {
            this.stringOrder = stringOrder;
        }

        public StringOrder(string stringOrder, bool required) : this(stringOrder)
        {
            this.Required = required;
        }

        public int Processing(string expression)
        {
            if (expression.StartsWith(this.stringOrder))
            {
                return this.stringOrder.Length;
            }

            return -1;
        }
    }
}