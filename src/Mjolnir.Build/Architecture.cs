// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System.ComponentModel;

namespace Mjolnir.Build
{
    /// <summary>
    /// Specifies enumerated constants representing different processor architectures.
    /// </summary>
    public enum Architecture
    {
        /// <summary>
        /// Any architecture.
        /// </summary>
        [Description("any")]
        AnyCpu = 0,

        /// <summary>
        /// The x86 architecture (x86, i386).
        /// </summary>
        [Description("i386")]
        X86 = 1,

        /// <summary>
        /// The x64 architecture (x64, amd64, x86_64).
        /// </summary>
        [Description("amd64")]
        X64 = 2,

        /// <summary>
        /// The ia64 architecture (ia64).
        /// </summary>
        [Description("ia64")]
        IA64 = 3,
    }
}
