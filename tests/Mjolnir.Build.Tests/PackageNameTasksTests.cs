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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjolnir.Build.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="PackageNameTasks"/> class.
    /// </summary>
    [TestClass]
    public class PackageNameTasksTests
    {
        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateBinaryPackageName(string, string, OperatingSystem, Architecture)"/>
        /// method with empty references (<c>null</c>).
        /// </summary>
        [TestMethod]
        public void GenerateBinaryPackageNameNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GenerateBinaryPackageName(null!, "1.0", OperatingSystem.Windows, Architecture.AnyCpu));
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GenerateBinaryPackageName("Test", null!, OperatingSystem.Windows, Architecture.AnyCpu));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateBinaryPackageName(string, string, OperatingSystem, Architecture)"/>
        /// method with illegal characters.
        /// </summary>
        [TestMethod]
        public void GenerateBinaryPackageNameInvalidTest()
        {
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GenerateBinaryPackageName("Te\\st", "1.0", OperatingSystem.Windows, Architecture.AnyCpu));
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GenerateBinaryPackageName("Test", "1:0", OperatingSystem.Windows, Architecture.AnyCpu));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateBinaryPackageName(string, string, OperatingSystem, Architecture)"/> method.
        /// </summary>
        [TestMethod]
        public void GenerateBinaryPackageNameTest()
        {
            Assert.AreEqual("My_Project-1.3.6-windows-amd64", PackageNameTasks.GenerateBinaryPackageName("My Project", "1.3.6", OperatingSystem.Windows, Architecture.X64));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateSourcePackageName(string, string)"/>
        /// method with empty references (<c>null</c>).
        /// </summary>
        [TestMethod]
        public void GenerateSourcePackageNameNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GenerateSourcePackageName(null!, "1.0"));
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GenerateSourcePackageName("Test", null!));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateSourcePackageName(string, string)"/>
        /// method with illegal characters.
        /// </summary>
        [TestMethod]
        public void GenerateSourcePackageNameInvalidTest()
        {
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GenerateSourcePackageName("Te:st", "1.0"));
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GenerateSourcePackageName("Test", "1:0"));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GenerateSourcePackageName(string, string)"/> method.
        /// </summary>
        [TestMethod]
        public void GenerateSourcePackageNameTest()
        {
            Assert.AreEqual("MyProject-1.3.6-src", PackageNameTasks.GenerateSourcePackageName("MyProject", "1.3.6"));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GeneratePackageName(string, string, string)"/>
        /// method with empty references (<c>null</c>).
        /// </summary>
        [TestMethod]
        public void GeneratePackageNameNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GeneratePackageName(null!, "1.0", "src"));
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GeneratePackageName("Test", null!, "src"));
            Assert.ThrowsException<ArgumentNullException>(() => PackageNameTasks.GeneratePackageName("Test", "1.0", null!));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GeneratePackageName(string, string, string)"/>
        /// method with illegal characters.
        /// </summary>
        [TestMethod]
        public void GeneratePackageNameInvalidTest()
        {
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GeneratePackageName("Te\\st", "1.0", "src"));
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GeneratePackageName("Test", "1:0", "src"));
            Assert.ThrowsException<ArgumentException>(() => PackageNameTasks.GeneratePackageName("Test", "1.0", "sr?"));
        }

        /// <summary>
        /// Checks the <see cref="PackageNameTasks.GeneratePackageName(string, string, string)"/> method.
        /// </summary>
        [TestMethod]
        public void GeneratePackageNameTest()
        {
            Assert.AreEqual("my_project-1.3.6-doc", PackageNameTasks.GeneratePackageName("my project", "1.3.6", "doc"));
        }
    }
}