using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
    public enum Bordes
    {
        Solido = 1,
        Punteado,
        Rayado,
        Doble
    }

   
    public enum ColorElipse
    {
        Rojo = 1,
        Verde,
        Azul,
        Amarillo,
        Negro
    }

   
    public class Elipse
    {
        public int SemiejeMayor { get; set; }
        public int SemiejeMenor { get; set; }
        public Bordes Borde { get; set; }
        public ColorElipse Color { get; set; }

       
        public Elipse(int semiejeMayor, int semiejeMenor, Bordes borde, ColorElipse color)
        {
            SemiejeMayor = semiejeMayor;
            SemiejeMenor = semiejeMenor;
            Borde = borde;
            Color = color;
        }

        
        public double CalcularArea()
        {
            return Math.PI * SemiejeMayor * SemiejeMenor;
        }

        
        public double CalcularPerimetro()
        {
            double a = SemiejeMayor;
            double b = SemiejeMenor;
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }

        
        public override bool Equals(object obj)
        {
            return obj is Elipse elipse &&
                   SemiejeMayor == elipse.SemiejeMayor &&
                   SemiejeMenor == elipse.SemiejeMenor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SemiejeMayor, SemiejeMenor);
        }
    }
}
