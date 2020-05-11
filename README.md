# SOSCSRPG_CORE
### Learn C# by creating a simple RPG.<br>
Following [Scott Lilly's Build a C#/WPF RPG](https://scottlilly.com/build-a-cwpf-rpg/) tutorial series.

Using [Visual Studio Community 2019](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)<br>
### Setup is a solution with 2 projects:
- Solution is <b>SOSCSRPG_CORE</b>
- project <b>WPFUI</b> is a WPF windows application (.NET Core 3.1)
- project <b>Engine</b> is a Class Library (.NET Core 3.1)
<br>
<br>
Images need to be BitMap,  refer to TAG: BitMapConversion?<br>
Not sure how otherwise to call a png image directly from a resource file prior to lesson 14.3<br>

### The versions used in the [tutorials](http://scottlilly.com/build-a-cwpf-rpg/) don't seem to work in Core version.<br>
##### My modifications for unit testing:
- Created project <b>TestEngine</b> by selecting MSTest Test Project(.NET Core)
- Updated the already added nuget reference to the latest versions.
- Add reference to the Engine project
- Add the new test code as class libraries (no special basic test selection)


### Resources:
- [Scott Lilly](https://scottlilly.com/)
- [Windows Presentation Foundation (WPF)](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)
- [Additional .Net development information](https://dotnet.microsoft.com/download)
- [.Net on GitHub](https://github.com/dotnet)
- [WPF.Net Core: 3.1](https://docs.microsoft.com/en-us/dotnet/api/?view=netcore-3.1)


 ##### Disclaimer
I'm new at this so any suggestions or comments are appreciated.<br>
Have fun with the spiders :)

