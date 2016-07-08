using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class InputConstraints
    {
        public static double G(string inputValueG)
        {
            return inputValueG == "" ? Constraints.EntrywayLength : double.Parse(inputValueG);
        }

        public static double C(string inputValueC)
        {
            return inputValueC == "" ? Constraints.WidthOfApartmentVariants[2] : double.Parse(inputValueC);
        }

        public static double Q(string inputValueQ)
        {
            return inputValueQ == "" ? Constraints.ThickWallsWidth : double.Parse(inputValueQ);
        }
    }
}
