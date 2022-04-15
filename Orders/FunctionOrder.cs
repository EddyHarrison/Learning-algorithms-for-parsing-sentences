namespace Orders
{
    public delegate int FuncProcessing(string expression);

    class FunctionOrder : IOrder
    {
        private FuncProcessing funcProcessing;
        public bool Required {get; set;} = true;

        public FunctionOrder(FuncProcessing funcProcessing)
        {
            this.funcProcessing = funcProcessing;
        }

        public FunctionOrder(FuncProcessing funcProcessing, bool required) : this(funcProcessing)
        {
            this.Required = required;
        }

        public int Processing(string expression)
        {
            return this.funcProcessing(expression);
        }
    }
}