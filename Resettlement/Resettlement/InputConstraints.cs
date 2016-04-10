namespace Resettlement
{
    public static class InputConstraints
    {
        public static double G(string inputValueG)
        {
            return inputValueG == "" ? Constraints.DefaultG : double.Parse(inputValueG);
        }

        public static double C(string inputValueC)
        {
            return inputValueC == "" ? Constraints.DefaultC : double.Parse(inputValueC);
        }

        public static double Q(string inputValueQ)
        {
            return inputValueQ == "" ? Constraints.DefaultQ : double.Parse(inputValueQ);
        }
    }
}
