using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Formas
{
    public class TrapecioRectangulo : IFormaGeometrica
    {
        private decimal _ladoA;
        private decimal _ladoB;
        private decimal _ladoC;
        private decimal _ladoD;
        public TrapecioRectangulo(decimal ladoA, decimal ladoB, decimal ladoC, decimal ladoD)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
            _ladoD = ladoD;
        }
        public decimal CalcularArea()
        {
            return _ladoC * ((_ladoA + _ladoB) / 2);
        }
        public decimal CalcularPerimetro()
        {
            return _ladoA + _ladoB + _ladoC + _ladoD;
        }
    }
}
