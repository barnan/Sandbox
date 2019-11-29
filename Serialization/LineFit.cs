namespace Serialization
{
    public class LineFit
    {
        private double _slope, _intercept, _R2, _slopeError, _interceptError;
        private double _residual2;
        private double _end1Column, _end1Row, _end2Column, _end2Row;   // End points of the line
        private bool _invertedRepresentation;

        public double Residual2
        {
            get { return _residual2; }
            set { _residual2 = value; }
        }

        public double Row(double column, int scale)
        {
            if (InvertedRepresentation)
            {
                return (column - Intercept / scale) / Slope;
            }

            return column * Slope + Intercept / scale;
        }

        public double Column(double row, int scale)
        {
            if (InvertedRepresentation)
            {
                return row * Slope + Intercept / scale;
            }

            return (row - Intercept / scale) / Slope;
        }

        public double End2Row
        {
            get { return _end2Row; }
            set { _end2Row = value; }
        }

        public double End2Column
        {
            get { return _end2Column; }
            set { _end2Column = value; }
        }

        public double End1Row
        {
            get { return _end1Row; }
            set { _end1Row = value; }
        }

        public double End1Column
        {
            get { return _end1Column; }
            set { _end1Column = value; }
        }

        public bool InvertedRepresentation
        {
            get { return _invertedRepresentation; }
            set { _invertedRepresentation = value; }
        }

        public double InterceptError
        {
            get { return _interceptError; }
            set { _interceptError = value; }
        }

        public double SlopeError
        {
            get { return _slopeError; }
            set { _slopeError = value; }
        }

        public double R2
        {
            get { return _R2; }
            set { _R2 = value; }
        }

        public double Intercept
        {
            get { return _intercept; }
            set { _intercept = value; }
        }

        public double Slope
        {
            get { return _slope; }
            set { _slope = value; }
        }
    }

}
