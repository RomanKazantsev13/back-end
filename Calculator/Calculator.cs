using static Calculator.ICalculator;

namespace Calculator
{
    internal class Calculator : ICalculator
    {
        public float GetState()
        {
            return state;
        }
        public Response SetNewValue(float value)
        {
            if (IsOverflow(value))
            {
                return Response.Overflow;
            }
            state = value;
            return Response.Successfully;
        }
        public Response ChangeSing()
        {
            state *= -1;
            return Response.Successfully;
        }
        public Response TakePercentageOfNumber(float percent)
        {
            if (IsOverflow((float)(state * percent * 0.01)))
            {
                return Response.Overflow;
            }
            state *= (float)(percent * 0.01);
            return Response.Successfully;
        }
        public Response AddNumber(float number)
        {
            if (IsOverflow(state + number))
            {
                return Response.Overflow;
            }
            state += number;
            return Response.Successfully;
        }
        public Response SubstractNumber(float number)
        {
            if (IsOverflow(state - number))
            {
                return Response.Overflow;
            }
            state -= number;
            return Response.Successfully;
        }
        public Response MultiplyByNumber(float number)
        {
            if (IsOverflow(state * number))
            {
                return Response.Overflow;
            }
            state *= number;
            return Response.Successfully;
        }
        public Response DivideByNumber(float number)
        {
            if (number == 0)
            {
                return Response.DivideByZero;
            }
            if (IsOverflow(state / number))
            {
                return Response.Overflow;
            }
            state /= number;
            return Response.Successfully;
        }

        private float state = 0;
        private bool IsOverflow(float number)
        {
            return float.IsInfinity(number);
        }
    }
}
