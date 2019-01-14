//-----------------------------------------------------------------------
// <copyright file="MathLib.cs" company="Ghervin Diduch">
//     Copyright (c) Ghervin Diduch. All rights reserved.
// </copyright>
// <author>Ghervin Diduch</author>
//-----------------------------------------------------------------------

namespace Mathematics
{
    using System;
    using System.Numerics;
    using Mathematics.Factorials;

    /// <summary>
    /// Bibliothek, welche mathematische Funktionen zur verfügung stellt.
    /// TODO: Handle SystemOutOfMemoryException bei Fakultätsberechnung großer Zahlen
    /// TODO: switches entfernen
    /// </summary>
    public class MathLib
    {
        /// <summary>
        /// Initialisiert die Klasse MathLib
        /// </summary>
        public MathLib()
        {
            //Test
        }

        /// <summary>
        /// Initialisiert die MathLib Klasse und setzt den CalculationTyp.
        /// </summary>
        /// <param name="type"></param>
        public MathLib(CalculationTyps type)
            : this()
        {
            this.CalculationType = type;
        }

        /// <summary>
        /// Enum aller möglichen Berechnungsarten
        /// </summary>
        public enum CalculationTyps
        {
            /// <summary>
            /// Rekursive Berechungen
            /// </summary>
            Recursive,

            /// <summary>
            /// Berechnungen anhand einer Liste
            /// </summary>
            List
        }

        /// <summary>
        /// Die Art nach dem die Berechnungen der Biblithek ausgeführt werden sollen
        /// </summary>
        public CalculationTyps CalculationType { get; set; }

        /// <summary>
        /// Berechet die Fakultät von 'n'.
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der Fakturierung</returns>
        public BigInteger Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("'n' muss >= 0 sein.");

            switch (this.CalculationType)
            {
                case CalculationTyps.List:
                    return new Factorial().CalculateWithList(n);
                case CalculationTyps.Recursive:
                    return new Factorial().CalculateWithRecursion(n);
                default:
                    return new Factorial().CalculateWithRecursion(n); 
            }
        }

        /// <summary>
        /// Berechet die potenzierte Fakultät von 'n'
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der potenzierten Fakultät</returns>
        public BigInteger SquareFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("'n' muss >= 0 sein.");

            switch (this.CalculationType)
            {
                case CalculationTyps.List:
                    return new SquareFactorial().CalculateWithList(n);
                case CalculationTyps.Recursive:
                    return new SquareFactorial().CalculateWithRecursion(n);
                default:
                    return new SquareFactorial().CalculateWithRecursion(n);
            }
        }

        /// <summary>
        /// Berechet die Fakultät von 'n', beachtet dabei allerdings nur ungrade Zahlen.
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das ergebniss der Fakturierung aller ungraden Zahlen</returns>
        public BigInteger UnevenFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("'n' muss >= 0 sein.");

            switch (this.CalculationType)
            {
                case CalculationTyps.List:
                    return new UnevenFactorial().CalculateWithList(n);
                case CalculationTyps.Recursive:
                    return new UnevenFactorial().CalculateWithRecursion(n);
                default:
                    return new UnevenFactorial().CalculateWithRecursion(n);
            }
        }
    }
}
