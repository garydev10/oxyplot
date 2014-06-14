﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataPoint.cs" company="OxyPlot">
//   The MIT License (MIT)
//   
//   Copyright (c) 2014 OxyPlot contributors
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Represents a point in the data space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a point in the data space.
    /// </summary>
    /// <remarks><see cref="DataPoint" />s are transformed to <see cref="ScreenPoint" />s.</remarks>
    public struct DataPoint : ICodeGenerating
    {
        /// <summary>
        /// The undefined.
        /// </summary>
        public static readonly DataPoint Undefined = new DataPoint(double.NaN, double.NaN);

        /// <summary>
        /// The x-coordinate.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
            Justification = "Reviewed. Suppression is OK here.")]
        internal double x;

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
            Justification = "Reviewed. Suppression is OK here.")]
        internal double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPoint" /> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public DataPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Returns C# code that generates this instance.
        /// </summary>
        /// <returns>The to code.</returns>
        public string ToCode()
        {
            return CodeGenerator.FormatConstructor(this.GetType(), "{0},{1}", this.x, this.y);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.x + " " + this.y;
        }

        /// <summary>
        /// Determines whether this point is defined.
        /// </summary>
        /// <returns><c>true</c> if this point is defined; otherwise, <c>false</c>.</returns>
        public bool IsDefined()
        {
            // check that x and y is not NaN (the code below is faster than double.IsNaN)
#pragma warning disable 1718
            // ReSharper disable EqualExpressionComparison
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return this.x == this.x && this.y == this.y;
            // ReSharper restore CompareOfFloatsByEqualityOperator
            // ReSharper restore EqualExpressionComparison
#pragma warning restore 1718
        }
    }
}