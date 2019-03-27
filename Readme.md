Cube.FileSystem
====

[![NuGet](https://img.shields.io/nuget/v/Cube.FileSystem.svg)](https://www.nuget.org/packages/Cube.FileSystem/)
[![AppVeyor](https://ci.appveyor.com/api/projects/status/6exuqpkn7ct3a790?svg=true)](https://ci.appveyor.com/project/clown/cube-filesystem)
[![Azure Pipelines](https://dev.azure.com/cube-soft-jp/Cube.FileSystem/_apis/build/status/cube-soft.Cube.FileSystem?branchName=master)](https://dev.azure.com/cube-soft-jp/Cube.FileSystem/_build)
[![Codecov](https://codecov.io/gh/cube-soft/Cube.FileSystem/branch/master/graph/badge.svg)](https://codecov.io/gh/cube-soft/Cube.FileSystem)

Cube.FileSystem is an I/O library for CubeSoft libraries and applications.
The library is available for .NET Framework 3.5, 4.5 or more.

## Installation

You can install using NuGet like this:

    PM> Install-Package Cube.FileSystem

Or select it from the NuGet packages UI on Visual Studio.

## Dependencies

* [Cube.Core](https://github.com/cube-soft/Cube.Core)
* [AlphaFS](https://alphafs.alphaleonis.com/)

## Contributing

1. Fork [Cube.FileSystem](https://github.com/cube-soft/Cube.FileSystem/fork) repository.
2. Create a feature branch from the master or stable branch (e.g. git checkout -b my-new-feature origin/master). Note that the master branch may refer some pre-released NuGet packages. Try the [rake clean](https://github.com/cube-soft/Cube.FileSystem/blob/master/Rakefile) command when build errors occur.
3. Commit your changes.
4. Rebase your local changes against the stable (or master) branch.
5. Run test suite with the [NUnit](https://nunit.org/) console or the Visual Studio (NUnit 3 test adapter) and confirm that it passes.
6. Create new Pull Request.

## License

Copyright © 2010 [CubeSoft, Inc.](https://www.cube-soft.jp/)
The project is licensed under the [Apache 2.0](https://github.com/cube-soft/Cube.FileSystem/blob/master/License.txt).