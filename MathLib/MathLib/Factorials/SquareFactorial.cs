//-----------------------------------------------------------------------
// <copyright file="SquareFactorial.cs" company="Ghervin Diduch">
//     Copyright (c) Ghervin Diduch. All rights reserved.
// </copyright>
// <author>Ghervin Diduch</author>
//-----------------------------------------------------------------------

namespace Mathematics.Factorials
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// Stellt die Berechnung von potenzierten Fakultäten zur verfügung.
    /// </summary>
    public class SquareFactorial : Factorial
    {
        /// <summary>
        /// Berechnet die potenzierte Fakultät aller Zahlen von 'n' bis 0.
        /// Arbeitet intern mit einer Liste.
        /// </summary>
        /// <param name="n">Ausgangszahl für die berechnung der Fakultät</param>
        /// <returns>Das Ergebniss der Berechnung</returns>
        public override System.Numerics.BigInteger CalculateWithList(int n)
        {
            ValidateN(n);

            if (n == 0)
                return 1;

            List<BigInteger> numbers = Enumerable
                .Range(1, n)
                .Select(i => (BigInteger)Math.Pow((double)i, 2))
                .ToList();

            return numbers.Aggregate((workingNumber, next) => workingNumber * next);
        }

        /// <summary>
        /// Berechnet die potenzierte Fakultät aller Zahlen von 'n' bis 0.
        /// Arbeitet intern mit Rekursion.
        /// </summary>
        /// <param name="n">Ausgangszahl für die berechnung der Fakultät</param>
        /// <returns>Das Ergebniss der Berechnung</returns>
        public override BigInteger CalculateWithRecursion(BigInteger n)
        {
            ValidateN(n);

            if (n == 0)
                return 1;

            return BigInteger.Pow(n, 2) * this.CalculateWithRecursion(n - 1);
        }
    }
}
