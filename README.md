This repository contains a minimal reproduction of .net sdk project with embedded resource glob not noticing changes on Windows.

## My issue
I have a C# project that we use for running database migration scripts. In an effort to both simplify the csproj file _and_ make it possible for our database developer to easily commit changes without needing to open the `.sln`, I switched to the .net SDK format and moved to using a glob pattern to demark which files must be embedded.

However, when testing this locally, I've noticed that Visual Studio will not see file additions if they match the glob. 

## Repro steps
To illustrate this. Download and build this project. Build again and verify that VS build output indicates there are 0 projects built and 1 project up-to-date. Run the project. You'll get a console window that lists one file (`test.msg`) and its contents. 

In VS or Windows Explorer, copy `test.msg` to anything you like and optionally edit the content.

Run the project again. The console window should not list the new file.

## Things I've tried
The order of the `EmbeddedResource` and `None` globs do not matter. The `TargetFramework` does not seem to matter. I've tried adding pre-build steps to force clean the bin but that pre-build only triggers when VS thinks it needs to build... which is entirely my problem with the embedded files.

There is one thing that actually does work. If I push a new file up to GitHub and a coworker does a `git pull`, VS will pick up the new file for them.

We did verify that they have the same problem locally where a new file is not picked up if they follow the repro steps.

So, we at least have a workaround for now if we want to proceed. Pay attention when developing locally. Your coworkers will probably get your changes when they pull. 

Having to pay attention when I work isn't ideal so hopefully I've just boned something and there's a simple fix to this all.
