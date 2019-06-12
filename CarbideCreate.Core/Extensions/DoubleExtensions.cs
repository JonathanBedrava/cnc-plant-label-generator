namespace CarbideCreate.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static double InchesToMm(this double inches)
        {
            return inches * 25.4;
        }

        public static double MmToInches(this double mm)
        {
            return mm * 0.03937008;
        }
    }
}