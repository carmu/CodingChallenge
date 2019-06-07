using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Formas
{
    public class Circulo : IFormaGeometrica
    {
        private decimal _diametro { get; set; }

        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }
        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

    }

}
