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
using System.IO;
using System.Linq;

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
        /// <param name="operatingSystem">The target operating system.</param>
        /// <param name="architecture">The target processor architecture.</param>
        /// <returns>A recommended filename for a binary package.</returns>
        /// <exception cref="ArgumentNullException"><c>projectName</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>version</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>projectName</c> contains an illegal character.</exception>
        /// <exception cref="ArgumentException"><c>version</c> contains an illegal character.</exception>
        public static string GenerateBinaryPackageName(string projectName, string version, OperatingSystem operatingSystem, Architecture architecture)
        {
            if (projectName == null)
            {
                throw new ArgumentNullException(nameof(projectName));
            }

            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            foreach (char illegalChar in Path.GetInvalidFileNameChars().Union(Path.GetInvalidPathChars()))
            {
                if (projectName.Contains(illegalChar))
                {
                    throw new ArgumentException($"Argument contains illegal character '{illegalChar}'", nameof(projectName));
                }

                if (version.Contains(illegalChar))
                {
                    throw new ArgumentException($"Argument contains illegal character '{illegalChar}'", nameof(version));
                }
            }

            projectName = projectName.Replace(' ', '_');

            return $"{projectName}-{version}-{operatingSystem.AsString()}-{architecture.AsString()}";
        }

        /// <summary>
        /// Generates the filename of a source package.
        /// </summary>
        /// <param name="projectName">The name of the application.</param>
        /// <param name="version">The version of the application.</param>
        /// <returns>A recommended filename for a source package.</returns>
        /// <exception cref="ArgumentNullException"><c>projectName</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>version</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>projectName</c> contains an illegal character.</exception>
        /// <exception cref="ArgumentException"><c>version</c> contains an illegal character.</exception>
        public static string GenerateSourcePackageName(string projectName, string version)
        {
            return GeneratePackageName(projectName, version, "src");
        }

        /// <summary>
        /// Generates the filename of a package with the given <paramref name="suffix"/>.
        /// </summary>
        /// <param name="projectName">The name of the application.</param>
        /// <param name="version">The version of the application.</param>
        /// <param name="suffix">The desired suffix of the package name.</param>
        /// <returns>A recommended filename for a source package.</returns>
        /// <exception cref="ArgumentNullException"><c>projectName</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>version</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>suffix</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>projectName</c> contains an illegal character.</exception>
        /// <exception cref="ArgumentException"><c>version</c> contains an illegal character.</exception>
        /// <exception cref="ArgumentException"><c>suffix</c> contains an illegal character.</exception>
        public static string GeneratePackageName(string projectName, string version, string suffix)
        {
            if (projectName == null)
            {
                throw new ArgumentNullException(nameof(projectName));
            }

            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (suffix == null)
            {
                throw new ArgumentNullException(nameof(suffix));
            }

            foreach (char illegalChar in Path.GetInvalidFileNameChars().Union(Path.GetInvalidPathChars()))
            {
                if (projectName.Contains(illegalChar))
                {
                    throw new ArgumentException($"Argument contains illegal character '{illegalChar}'", nameof(projectName));
                }

                if (version.Contains(illegalChar))
                {
                    throw new ArgumentException($"Argument contains illegal character '{illegalChar}'", nameof(version));
                }

                if (suffix.Contains(illegalChar))
                {
                    throw new ArgumentException($"Argument contains illegal character '{illegalChar}'", nameof(version));
                }
            }

            projectName = projectName.Replace(' ', '_');

            return $"{projectName}-{version}-{suffix}";
        }
    }
}
