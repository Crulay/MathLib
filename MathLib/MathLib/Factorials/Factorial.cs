//-----------------------------------------------------------------------
// <copyright file="Factorial.cs" company="Ghervin Diduch">
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
    /// Stellt die Berechnung der Fakultäten zur verfügung
    /// </summary>
    public class Factorial
    {
        public Factorial()
        {
        }

        /// <summary>
        /// Berechnet die Fakultät von 'n' bis 0.
        /// Arbeitet intern mit einer Liste.
        /// </summary>
        /// <param name="n">Ausgangszahl für die berechnung der Fakultät</param>
        /// <returns>Das Ergebniss der Berechnung</returns>
        public virtual BigInteger CalculateWithList(int n)
        {
            ValidateN(n);

            if (n == 0)
                return 1;

            List<BigInteger> numbers = Enumerable
                .Range(1, n)
                .Select(i => (BigInteger)i)
                .ToList();

            return numbers.Aggregate((workingNumber, next) => workingNumber * next);
        }

        /// <summary>
        /// Berechnet die Fakultät von 'n' bis 0.
        /// Arbeitet intern mit Rekursion.
        /// </summary>
        /// <param name="n">Ausgangszahl für die berechnung der Fakultät</param>
        /// <returns>Das Ergebniss der Berechnung</returns>
        public virtual BigInteger CalculateWithRecursion(BigInteger n)
        {
            ValidateN(n);

            if (n == 0)
                return 1;

            return n * this.CalculateWithRecursion(n - 1);
        }

        /// <summary>
        /// Validiert ob N >= 0 ist
        /// </summary>
        /// <param name="n"></param>
        protected void ValidateN(BigInteger n)
        {
            if (n < 0)
                throw new ArgumentException("'n' muss >= 0 sein.");
        }
    }
}
