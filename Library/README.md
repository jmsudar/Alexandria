# Library
Library provides the tools necessary to create and traverse collections of ordered text files arranged in a tree hierarchy. The creation tools exist to make it easier to intuitively take notes and create FAQs on any subject you may wish, including images, bullet and numbered lists, and flow diagrams. The traversal tools take these notes and turn them into a richly formatted wiki, either to remain on your personal device for your reference, or to be placed as a static HTML website to share with others. Later versions of Library will support options to instead encrypt your library files to be stored in a database and retrieved from a front end.
In addition to the wiki tooling, Library provides tools to access your notes from a cli, the intention being to allow developers to have access to their personal library of notes either in at-a-glance form for refreshers, with step by step instructions included in their FAQ, and through integrated cli windows in an IDE, all without leaving the development environment.

## Environment Setup
### Unit Test Setup
The unit tests for Alexandria include basic traversal of an included test directory, named `TestSource` by default. In order to keep this filepath generalized, an environment variable named `ALX_TESTDIR` is used. If you would like to call it something else, update the variable fetch call on (this line)[https://github.com/jsudar/Alexandria/blob/createLibraryREADME/Library_UnitTests/MethodsTests.cs#L13].

Regardless of what you name this variable, set is at a permanent environment variable via the instructions below.

#### Mac and Linux

Edit your permanent Bash profile at `~/.bash_profile` and set the environment variable to point at the your top-level Alexandria directory

```export ALX_TESTDIR="/Users/YourName/Programming/Alexandria/"```

If you are using Visual Studio, you may also need to add an alias in the same file to launch it from terminal to make use these environment variables.

```alias vs='/Applications/Visual\ Studio.app/Contents/MacOS/VisualStudio &'```

Additionally, on Mac, before browsing to any Alexandria files in finder, you may find it easier to disable the creation of `.DS_Store` files, as these will cause the file count in the unit tests to be off. In Terminal, run the command below:

```defaults write com.apple.desktopservices DSDontWriteNetworkStores true```
