namespace Calculator
{
    internal interface ICalculator
    {
        public enum Response
        {
            Overflow,
            DivideByZero,
            Successfully
        }
        public float GetState();
        public Response SetNewValue(float value);
        public Response ChangeSing();
        public Response TakePercentageOfNumber(float percent);
        public Response AddNumber(float number);
        public Response SubstractNumber(float number);
        public Response MultiplyByNumber(float number);
        public Response DivideByNumber(float number);
    }
}
