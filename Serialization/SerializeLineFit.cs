namespace Serialization
{
    public class SerializableLineFit : LineFit
    {
        public LineFit LineFit { get; set; }

        public SerializableLineFit()
        {
        }

        public SerializableLineFit(LineFit linefit)
        {
            LineFit = linefit;
        }

        public new double Residual2
        {
            get { return LineFit.Residual2; }
            set { LineFit.Residual2 = value; }
        }

        public new double Row(double column, int scale)
        {
            if (InvertedRepresentation)
            {
                return (column - Intercept / scale) / Slope;
            }

            return column * Slope + Intercept / scale;
        }

        public new double Column(double row, int scale)
        {
            if (InvertedRepresentation)
            {
                return row * Slope + Intercept / scale;
            }

            return (row - Intercept / scale) / Slope;
        }

        public new double End2Row
        {
            get { return LineFit.End2Row; }
            set { LineFit.End2Row = value; }
        }

        public new double End2Column
        {
            get { return LineFit.End2Column; }
            set { LineFit.End2Column = value; }
        }

        public new double End1Row
        {
            get { return LineFit.End1Row; }
            set { LineFit.End1Row = value; }
        }

        public new double End1Column
        {
            get { return LineFit.End1Column; }
            set { LineFit.End1Column = value; }
        }

        public new bool InvertedRepresentation
        {
            get { return LineFit.InvertedRepresentation; }
            set { LineFit.InvertedRepresentation = value; }
        }

        public new double InterceptError
        {
            get { return LineFit.InterceptError; }
            set { LineFit.InterceptError = value; }
        }

        public new double SlopeError
        {
            get { return LineFit.SlopeError; }
            set { LineFit.SlopeError = value; }
        }

        public new double R2
        {
            get { return LineFit.R2; }
            set { LineFit.R2 = value; }
        }

        public new double Intercept
        {
            get { return LineFit.Intercept; }
            set { LineFit.Intercept = value; }
        }

        public new double Slope
        {
            get { return LineFit.Slope; }
            set { LineFit.Slope = value; }
        }

    }

}
