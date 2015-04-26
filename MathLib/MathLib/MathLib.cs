//-----------------------------------------------------------------------
// <copyright file="MathLib.cs" company="Ghervin Diduch">
//     Copyright (c) Ghervin Diduch. All rights reserved.
// </copyright>
// <author>Ghervin Diduch</author>
//-----------------------------------------------------------------------

namespace MathLib
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// Bibliothek, welche mathematische Funktionen zur verfügung stellt.
    /// </summary>
    public class MathLib
    {
        #region Privates
        /// <summary>
        /// Die Art nach dem die Berechnungen der Biblithek ausgeführt werden sollen
        /// </summary>
        private CalculationType calcType = CalculationType.Recursive;

        /// <summary>
        /// Logging Channel
        /// </summary>
        private TraceSource log;
        #endregion

        #region Konstruktoren

        /// <summary>
        /// Initialisiert die MathLib Klasse und initialisiert Logginchannel "MathLibLog"
        /// </summary>
        public MathLib()
        {
            this.log = new TraceSource("MathLibLog");
        }

        /// <summary>
        /// Initialisiert die MathLib Klasse und setzt den CalculationTyp.
        /// </summary>
        /// <param name="type"></param>
        public MathLib(CalculationType type)
            : this()
        {
            this.calcType = type;
            this.log.TraceEvent(TraceEventType.Verbose, 16, "MathLib: MathLib initialisiert mit Berechnungsart: " + this.calcType.ToString());
        }

        #endregion

        #region Enums

        /// <summary>
        /// Enum aller möglichen Berechnungsarten
        /// </summary>
        public enum CalculationType
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
        #endregion

        #region Public Functions

        /// <summary>
        /// Berechet die Fakultät von 'n'.
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der Fakturierung</returns>
        public BigInteger Factorial(int n)
        {
            if (n < 0)
            {
                this.log.TraceEvent(TraceEventType.Warning, 4, "Factorial: 'n' muss >= 0 sein.");
                throw new ArgumentException("'n' muss >= 0 sein.");
            }

            switch (this.calcType)
            {
                case CalculationType.Recursive:
                    return this.FactorialRecursive(n);
                case CalculationType.List:
                    return this.FactorialList(n);
                default:
                    return this.FactorialRecursive(n);
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
            {
                this.log.TraceEvent(TraceEventType.Warning, 4, "SquareFactorial: 'n' muss >= 0 sein.");
                throw new ArgumentException("'n' muss >= 0 sein.");
            }

            switch (this.calcType)
            {
                case CalculationType.Recursive:
                    return this.SquareFactorialRecursive(n);
                case CalculationType.List:
                    return this.SquareFactorialList(n);
                default:
                    return this.SquareFactorialRecursive(n);
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
            {
                this.log.TraceEvent(TraceEventType.Warning, 4, "UnevenFactorial: 'n' muss >= 0 sein.");
                throw new ArgumentException("'n' muss >= 0 sein.");
            }

            switch (this.calcType)
            {
                case CalculationType.Recursive:
                    return this.UnevenFactorialRecursive(n);
                case CalculationType.List:
                    return this.UnevenFactorialList(n);
                default:
                    return this.UnevenFactorialRecursive(n);
            }
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Berechet die Fakultät von 'n', beachtet dabei allerdings nur ungrade Zahlen.
        /// Arbeitet intern mit einer Liste
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das ergebniss der Fakturierung aller ungraden Zahlen</returns>
        private BigInteger UnevenFactorialList(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            this.log.TraceEvent(TraceEventType.Verbose, 16, "UnevenFactorialList: Ermittle alle ungraden Zahlen zwischen 1 und " + n);

            List<BigInteger> numbers = Enumerable.Range(1, n).Select(i => (BigInteger)i).Where(x => this.IsOdd(x)).ToList();

            this.log.TraceEvent(TraceEventType.Verbose, 16, "UnevenFactorialList: Alle ungraden Zahlen zwischen 1 und " + n + " ermittelt.");
            this.log.TraceEvent(TraceEventType.Verbose, 16, string.Join(",", numbers));

            return numbers.Aggregate((workingNumber, next) => workingNumber * next);
        }

        /// <summary>
        /// Berechet die Fakultät von 'n', beachtet dabei allerdings nur ungrade Zahlen.
        /// Arbeitet intern mit Rekursion
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der Fakturierung aller ungraden Zahlen</returns>
        private BigInteger UnevenFactorialRecursive(BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }

            return this.IsOdd(n) ? n * this.UnevenFactorialRecursive(n - 1) : this.UnevenFactorialRecursive(n - 1);
        }

        /// <summary>
        /// Berechet die Fakultät von 'n'.
        /// Arbeitet intern mit einer Liste.
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der Fakturierung</returns>
        private BigInteger FactorialList(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            this.log.TraceEvent(TraceEventType.Verbose, 16, "FactorialList: Ermittle alle Zahlen zwischen 1 und " + n);

            List<BigInteger> numbers = Enumerable.Range(1, n).Select(i => (BigInteger)i).ToList();

            this.log.TraceEvent(TraceEventType.Verbose, 16, "FactorialList: Alle Zahlen zwischen 1 und " + n + " ermittelt.");
            this.log.TraceEvent(TraceEventType.Verbose, 16, "FactorialList: " + string.Join(",", numbers));

            return numbers.Aggregate((workingNumber, next) => workingNumber * next);
        }

        /// <summary>
        /// Berechet die Fakultät von 'n'.
        /// Arbeitet intern mit Rekursion.
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das Ergebniss der Fakturierung</returns>
        private BigInteger FactorialRecursive(BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }

            this.log.TraceEvent(TraceEventType.Verbose, 16, "FactorialRecursive: Berechne " + n + " *");

            return n * this.FactorialRecursive(n - 1);
        }

                /// <summary>
        /// Berechnet die potenzierte Fakultät von 'n', anhand einer Liste
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das ergebniss der potenzierten Fakturierung</returns>
        private BigInteger SquareFactorialList(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            this.log.TraceEvent(TraceEventType.Verbose, 16, "SquareFactorialList: Ermittle alle potenzierten Zahlen zwischen 1 und " + n);

            List<BigInteger> numbers = Enumerable.Range(1, n).Select(i => (BigInteger)Math.Pow((double)i, 2)).ToList();

            this.log.TraceEvent(TraceEventType.Verbose, 16, "SquareFactorialList: Alle potenzierten Zahlen zwischen 1 und " + n + " ermittelt.");
            this.log.TraceEvent(TraceEventType.Verbose, 16, "SquareFactorialList: " + string.Join(",", numbers));

            return numbers.Aggregate((workingNumber, next) => workingNumber * next);
        }

        /// <summary>
        /// Berechnet die potenzierte Fakultät von 'n', mithilfe von Rekursion
        /// </summary>
        /// <param name="n">Die Zahl welche Fakturiert werden soll</param>
        /// <returns>Das ergebniss der potenzierten Fakturierung</returns>
        private BigInteger SquareFactorialRecursive(BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }

            this.log.TraceEvent(TraceEventType.Verbose, 16, "SquareFactorialRecursive: Berechne " + n + " ^ 2 *");

            return BigInteger.Pow(n, 2) * this.SquareFactorialRecursive(n - 1);
        }

        /// <summary>
        /// Gibt an ob die übergebene Zahl ungrade ist.
        /// </summary>
        /// <param name="value">Die zu prüfende Zahl</param>
        /// <returns>True wenn die Zahl ungrade ist.</returns>
        private bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Gibt an ob die übergebene Zahl ungrade ist.
        /// </summary>
        /// <param name="value">Die zu prüfende Zahl</param>
        /// <returns>True wenn die Zahl ungrade ist.</returns>
        private bool IsOdd(BigInteger value)
        {
            return !value.IsEven;
        }

        #endregion
    }
}
