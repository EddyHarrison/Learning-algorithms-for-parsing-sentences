namespace Checkers
{
    public static class IndentChecker
    {
        public static bool Is(string expression)
        {
            if (expression.Length == 0 || !AlphabetChecker.Is(expression[0]))
            {
                return false;
            }

            for (int index = 1; index < expression.Length; index++)
            {
                if (!(NumberChecker.Is(expression[index]) || AlphabetChecker.Is(expression[index])))
                {
                    return false;
                }
            }

            return true;
        }

        public static int Search(string expression)
        {
            if (expression.Length == 0)
            {
                return -1;
            }

            if (!AlphabetChecker.Is(expression[0]))
            {
                return -1;
            }

            int result = 1;

            for (int index = 1; index < expression.Length; index++)
            {
                if (!(NumberChecker.Is(expression[index]) || AlphabetChecker.Is(expression[index])))
                {
                    break;
                }

                result++;
            }

            return result;
        }
    }
}