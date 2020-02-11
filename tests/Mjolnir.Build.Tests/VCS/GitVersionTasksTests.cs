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
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Build.VCS;

namespace Mjolnir.Build.Tests.VCS
{
    /// <summary>
    /// Contains unit tests for the <see cref="GitVersionTasks"/> class.
    /// </summary>
    [TestClass]
    public class GitVersionTasksTests
    {
        /// <summary>
        /// Checks the <see cref="GitVersionTasks.GetGitTagVersion(string, ulong)"/> method.
        /// </summary>
        [TestMethod]
        public void GetGitVersionTest()
        {
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;

                while (!File.Exists(Path.Combine(path, "global.json")))
                {
                    path = Path.GetFullPath(Path.Combine(path, ".."));
                }

                (string shortVersion, string longVersion, string semanticVersion) = GitVersionTasks.GetGitTagVersion(path, 987);

                Assert.IsFalse(string.IsNullOrWhiteSpace(shortVersion));
                Assert.IsFalse(string.IsNullOrWhiteSpace(longVersion));
                Assert.IsFalse(string.IsNullOrWhiteSpace(semanticVersion));

                StringAssert.Contains(longVersion, "987");
                StringAssert.Contains(semanticVersion, "+");

                StringAssert.Contains(shortVersion, ".");
                StringAssert.Contains(longVersion, ".");
                StringAssert.Contains(semanticVersion, ".");
            }
            catch (Exception ex) when (ex.GetType().FullName == "LibGit2Sharp.RepositoryNotFoundException")
            {
                Assert.Inconclusive();
            }
        }

        /// <summary>
        /// Checks the <see cref="GitVersionTasks.GetGitTagVersionComponents(string)"/> method.
        /// </summary>
        /// <remarks>
        /// This test will be set to <c>inconclusive</c> if this is not a git repository.
        /// </remarks>
        [TestMethod]
        public void GetGitTagVersionComponents()
        {
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;

                while (!File.Exists(Path.Combine(path, "global.json")))
                {
                    path = Path.GetFullPath(Path.Combine(path, ".."));
                }

                (ulong major, ulong minor, ulong revision, ulong commits, string shasum) = GitVersionTasks.GetGitTagVersionComponents(path);

                Assert.IsTrue(major >= 0);
                Assert.IsTrue(minor >= 0);
                Assert.IsTrue(revision >= 0);
                Assert.IsTrue(commits >= 0);
                Assert.IsFalse(string.IsNullOrEmpty(shasum));
            }
            catch (Exception ex) when (ex.GetType().FullName == "LibGit2Sharp.RepositoryNotFoundException")
            {
                Assert.Inconclusive();
            }
        }
    }
}
