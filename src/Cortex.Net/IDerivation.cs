﻿// <copyright file="IDerivation.cs" company="Michel Weststrate, Jan-Willem Spuij">
// Copyright 2019 Michel Weststrate, Jan-Willem Spuij
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,
// modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom
// the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace Cortex.Net
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A derivation is a (computed) value that is derived from other (observable) values.
    /// </summary>
    public interface IDerivation : IDependencyNode
    {
        /// <summary>
        /// Gets or sets the state of the dependencies of this <see cref="IDerivation"/> instance.
        /// </summary>
        DerivationState DependenciesState { get; set; }

        /// <summary>
        /// Gets or sets the id of the current run of a derivation. Each time the derivation is tracked
        /// this number is increased by one. This number is unique within the current shared state.
        /// </summary>
        int RunId { get; set; }

        /// <summary>
        /// Gets a set of <see cref="IObservable"/> instances that are currently observed.
        /// </summary>
        ISet<IObservable> Observing { get; }

        /// <summary>
        /// Gets a set of <see cref="IObservable"/> instances that have been hit during a new derivation run.
        /// </summary>
        ISet<IObservable> NewObserving { get; }

        /// <summary>
        /// Gets or sets the trace mode of this Derivation.
        /// </summary>
        TraceMode IsTracing { get; set; }

        /// <summary>
        /// Gets a value indicating whether to warn if this derivation is required to visit at least one observable.
        /// </summary>
        bool RequiresObservable { get; }

        /// <summary>
        /// Method that is called when the <see cref="IDerivation"/> instance has become stale.
        /// </summary>
        void OnBecomeStale();
    }
}
