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

using System;

namespace Mjolnir.Build
{
    /// <summary>
    /// Contains tasks related to package name generation.
    /// </summary>
    public static class PackageNameTasks
    {
        /// <summary>
        /// Generates the filename of a binary package.
        /// </summary>
        /// <param name="projectName">The name of the application.</param>
        /// <param name="version">The version of the application.</param>
        /// <param name="os">The target operating system.</param>
        /// <param name="arch">The target processor architecture.</param>
        /// <returns>A recommended filename for a binary package.</returns>
        public static string GenerateBinaryPackageName(string projectName, string version, OperatingSystem os, Architecture arch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the filename of a source package.
        /// </summary>
        /// <param name="projectName">The name of the application.</param>
        /// <param name="version">The version of the application.</param>
        /// <returns>A recommended filename for a source package.</returns>
        public static string GenerateSourcePackageName(string projectName, string version)
        {
            throw new NotImplementedException();
        }
    }
}
