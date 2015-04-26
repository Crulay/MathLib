//-----------------------------------------------------------------------
// <copyright file="MathLib_UnitTests.cs" company="Ghervin Diduch">
//     Copyright (c) Ghervin Diduch. All rights reserved.
// </copyright>
// <author>Ghervin Diduch</author>
//-----------------------------------------------------------------------

namespace MathLib_UnitTests
{
    using System;
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testklasse für die Mathematische Bibliothek "MathLib"
    /// </summary>
    [TestClass]
    public class MathLib_UnitTests
    {
        #region Fakultätstests
        /// <summary>
        /// Testtet die rekursive Berechnung der Fakultät von n = 20.
        /// Ergebniss > int.MaxValue
        /// </summary>
        [TestMethod]
        public void Factorial_2432902008176640000_When_RecursiveFactorial_20()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 2432902008176640000;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.Factorial(20);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testtet die listenbasierte Berechnung der Fakultät von n = 20.
        /// Ergebniss > int.MaxValue
        /// </summary>
        [TestMethod]
        public void Factorial_2432902008176640000_When_ListFactorial_20()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 2432902008176640000;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.Factorial(20);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testtet die listenbasierte Berechnung der Fakultät von n = 9.
        /// </summary>
        [TestMethod]
        public void Factorial_362880_When_ListFactorial_9()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 362880;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.Factorial(9);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die rekursive Berechnung der Fakultät mit n = 0.
        /// </summary>
        [TestMethod]
        public void Factorial_1_When_RecursiveFactorial_0()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.Factorial(0);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Argumentprüfung auf negative Zahlen bei der Fakultätsberechnung
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Factorial_ArgumentException_When_Factorial_BelowZero()
        {
            // assemble
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            target.Factorial(-15);
        }

        #region Grenzwerttests
        /*
        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void Factorial_XX_When_RecursiveFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.Factorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void Factorial_XX_When_ListFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.Factorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }
        */
        #endregion

        #endregion

        #region Ungrade Fakultätstests

        /// <summary>
        /// Testtet die rekursive Berechnung der ungraden Fakultät von n = 5 (Ungrades n).
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_15_When_RecursiveFactorial_5()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 15;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.UnevenFactorial(5);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testtet die rekursive Berechnung der ungraden Fakultät von n = 6 (grades n).
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_15_When_RecursiveFactorial_6()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 15;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.UnevenFactorial(6);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testtet die listenbasierte Berechnung der ungraden Fakultät von n = 5 (Ungrades n).
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_15_When_ListFactorial_5()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 15;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.UnevenFactorial(5);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testtet die listenbasierte Berechnung der ungraden Fakultät von n = 6 (grades n).
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_15_When_ListFactorial_6()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 15;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.UnevenFactorial(6);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die rekursive Berechnung der ungraden Fakultät mit n = 0.
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_1_When_RecursiveFactorial_0()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.UnevenFactorial(0);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Argumentprüfung auf negative Zahlen bei der ungraden Fakultätsberechnung
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnevenFactorial_ArgumentException_When_Factorial_BelowZero()
        {
            // assemble
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            target.UnevenFactorial(-15);
        }

        #region Grenzwerttests
        /*
        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_XX_When_RecursiveFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.UnevenFactorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void UnevenFactorial_XX_When_ListFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.UnevenFactorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }
         * */
        #endregion

        #endregion

        #region Faktorierte Fakultätstests

        /// <summary>
        /// Testet die listenbasierte Berechnung der potenzierte Fakultät mit n = 6.
        /// </summary>
        [TestMethod]
        public void SquareFactorial_518400_When_ListFactorial_6()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 518400;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.SquareFactorial(6);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die rekursive Berechnung der potenzierte Fakultät mit n = 6.
        /// </summary>
        [TestMethod]
        public void SquareFactorial_518400_When_RecursiveFactorial_6()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 518400;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.SquareFactorial(6);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die rekursive Berechnung der potenzierte Fakultät mit n = 0.
        /// </summary>
        [TestMethod]
        public void SqareFactorial_1_When_RecursiveFactorial_0()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.SquareFactorial(0);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Argumentprüfung auf negative Zahlen bei der faktorierten Fakultätsberechnung
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SqareFactorial_ArgumentException_When_Factorial_BelowZero()
        {
            // assemble
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            target.SquareFactorial(-15);
        }

        #region Grenzwerttests

        /*
        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void SqareFactorial_XX_When_RecursiveFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.Recursive);

            // act
            actual = target.SquareFactorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Grenzwerttest für eingaben von n = int.MaxValue.
        /// </summary>
        [TestMethod]
        public void SqareFactorial_XX_When_ListFactorial_MaxInt()
        {
            // assemble
            BigInteger actual;
            BigInteger expected = 1;
            MathLib.MathLib target = new MathLib.MathLib(MathLib.MathLib.CalculationType.List);

            // act
            actual = target.SquareFactorial(int.MaxValue);

            // assert
            Assert.AreEqual(expected, actual);
        }
         */

        #endregion

        #endregion
    }
}
