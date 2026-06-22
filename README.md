# Rained CN
<p align="center">
    <img src="rained-logo.png" />
    <br />
    <a href="https://github.com/Star-Fish-C/rained-cn">CN Fork</a> | <a href="https://github.com/pkhead/rained">Original Project</a> | <a href="https://pkhead.github.io/rained/en/">Manual</a>
</p>

Rained CN is a Simplified Chinese localization fork of [pkhead/rained](https://github.com/pkhead/rained), another Rain World level editor.

在文件 - 偏好设置 - 界面 - 语言中可以选择中文、英文、中英对照。

本仓库是 [Rained](https://github.com/pkhead/rained) 的简体中文汉化版本。除了原本新增的简体中文界面外，还额外添加了 `中文 / English` 的中英对照语言选项，方便在熟悉原英文术语的同时阅读中文界面。

## 汉化内容
- 新增 `简体中文` 语言选项
- 新增 `中文 / English` 中英对照语言选项
- 汉化主菜单、偏好设置、编辑器窗口、脚本界面等 UI 文本
- 汉化图块、材质、自动图块、效果、道具等选择器中的分类和素材名称
- 对部分雨世界专有名词、区域名和素材名加入固定译名

## 使用说明
在 `Preferences -> Language` 中选择：

- `简体中文`
- `中文 / English`

如果部分新增素材或模组素材仍显示英文，通常是该名称还没有对应译名；可以继续补充到 `src/Rained/I18n.cs` 中。

## 原项目说明
Rained is another Rain World level editor. Read [this document](dist/README.md), which is bundled with every release package, for more information on how to use this software.

Please note that the "main" branch is ahead of the latest release, but is in sync with Nightly. If you want to access the repository
at the time of a certain release, use the Git tags system.

## Features
- Ease of use
- Undo/redo everything
- Re-envisioned prop editor
- Highly customizable UI
- Asset graphics and palette previews
- [Drizzle](https://github.com/SlimeCubed/Drizzle/tree/community) level rendering with a preview
- Exiting from the light editor does not mess up the screen
- Pressing escape does not crash the program

## Screenshots
![Screenshot of Rained's tile editor.](screenshot1.png)
![Screenshot of Rained's prop editor with tile graphics enabled and a palette applied.](screenshot2.png)

## Building
> [!tip]
> Additional documentation about the development setup is found [here](https://pkhead.github.io/rained/en/developing.html).

Prerequisities:
 - .NET Core toolchain
 - Python 3
 - *(optional)* OpenGL ES driver or [ANGLE libraries](src/Glib/angle) in the DLL search path.
 - *(optional)* [glslang](https://github.com/KhronosGroup/glslang) CLI

Clone with Git:
```bash
git clone --recursive https://github.com/Star-Fish-C/rained-cn
cd rained-cn
```

### Building Drizzle
These steps only need to be followed on the initial build or if you have updated Drizzle.

Compile Drizzle:
```bash
cd src/Drizzle
dotnet run --project Drizzle.Transpiler
```

Back to root directory, export some Drizzle data for Rained to build with:
```bash
dotnet run --project src/DrizzleExport.Console effects src/Rained/Assets/effects.json
```

### Generating Lua API
This step only needs to be run once, or whenever you update ImGui.NET.

In the root directory, run:
```bash
python3 tools/lua-imgui-gen.py
```

This will generate the Lua API for the imgui module.

### Building Rained

#### .NET CLI and Cake
From the root directory, build and run Rained
```bash
# only needs to be run once
dotnet tool restore

# usage of desktop GL or GLES/ANGLE is determined by OS.
dotnet cake

# alternative build command with desktop GL forced on.
dotnet cake --gles=false

# run the project!
dotnet run --no-build --project src/Rained/Rained.csproj
```

#### .NET CLI alone
This is a translation of the Cake build script:
```bash
# validate/compile updated shader source files
# if you don't have glslangValidator, just skip these steps.
python3 tools/shader-preprocessor.py gl330
python3 tools/shader-preprocessor.py gles300

# you have three options here:
dotnet build src/Rained/Rained.csproj /p:GL=ES      # you can build with ES/ANGLE
dotnet build src/Rained/Rained.csproj /p:GL=Desktop # or you can build with normal OpenGL
dotnet build src/Rained/Rained.csproj               # this will auto-select based on OS. windows = GLES/ANGLE, linux = OpenGL
```

Upon first startup, you can configure where your Data folder is located. If you chose to download and install it, Rained will download and extract [this repository](https://github.com/SlimeCubed/Drizzle.Data/tree/community).

## Contributing
Don't hestiate to report any bugs, complaints, and suggestions by creating an issue or discussion thread on GitHub, or contacting me through Discord. I am in several Rain World modding Discord servers, and I have my own server as well: https://discord.gg/raUQ4yRH9F. You may either ping me in a relevant channel in the server of your choice or DM me (they are open). And you may also join my Discord server if you find announcement channels a conveninent way of keeping track of Rained news and updates.

If you send a crash report, please send me the contents of logs/latest.log.txt before relaunching the program.

Pull requests are welcome.

Documentation about the development setup is found [here](https://pkhead.github.io/rained/en/developing.html).

You can also support me through Ko-Fi donations: https://ko-fi.com/pkhead
