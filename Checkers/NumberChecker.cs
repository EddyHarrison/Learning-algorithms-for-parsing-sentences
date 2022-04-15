namespace Checkers
{
    public static class NumberChecker
    {
        public static bool Is(char expression)
        {
            return char.IsDigit(expression);
        }
        
        public static bool Is(string expression)
        {
            for (int index = 0; index < expression.Length; index++)
            {
                if (!NumberChecker.Is(expression[index]))
                {
                    return false;
                }
            }

            return true;
        }

        public static int Search(string expression)
        {
            int result = -1;

            if (expression.Length == 0)
            {
                return result;
            }

            for (int index = 0; index < expression.Length; index++)
            {
                if (!NumberChecker.Is(expression[index]))
                {
                    break;
                }

                result++;
            }

            if (result != -1)
            {
                result++;
            }

            return result;
        }
    }
}