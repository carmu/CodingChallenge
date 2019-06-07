using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Formas
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private decimal _lado { get; set; }
        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }
        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }
        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
