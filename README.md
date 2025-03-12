## Clone repo 📋

```sh
  git clone https://github.com/xavilitoh/github-activity.git
  cd GitHubActivity
```

## Prerequisites 📦

To run this project, you need to have the following dependencies installed:

1. **.NET Core SDK 9.0**:
   You can download and install the .NET Core SDK 9.0 from the official [.NET download page](https://dotnet.microsoft.com/download/dotnet/9.0).

2. **Visual Studio Code** (or any other code editor of your choice):
   You can download and install Visual Studio Code from the official [Visual Studio Code download page](https://code.visualstudio.com/Download).

3. **C# Extension for Visual Studio Code**:
   After installing Visual Studio Code, you can install the C# extension from the [Visual Studio Code Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

## Installing Dependencies 🛠️

### .NET Core SDK 9.0

1. Visit the [.NET download page](https://dotnet.microsoft.com/download/dotnet/9.0).
2. Download the installer for your operating system (Windows, macOS, or Linux).
3. Run the installer and follow the instructions to complete the installation.

### Visual Studio Code

1. Visit the [Visual Studio Code download page](https://code.visualstudio.com/Download).
2. Download the installer for your operating system.
3. Run the installer and follow the instructions to complete the installation.

### C# Extension for Visual Studio Code

1. Open Visual Studio Code.
2. Go to the Extensions view by clicking on the square icon in the sidebar or pressing `Ctrl+Shift+X`.
3. In the search box, type `C#` and press Enter.
4. Click on the `C#` extension from Microsoft and then click the `Install` button.

## Deployment Steps 🚀

To execute the program you should run the following command:
```bash
  # dotnet run <username>
  dotnet run xavilitoh
```

### Install as a global tool 🛠️

1. **Build the package**:
   Use the `dotnet pack` command to generate a `.nupkg` file.

   ```sh
   dotnet pack --configuration Release
   ```

This will generate the package in the `bin/Release` folder.

2. **Install the package**:
   In the terminal, navigate to the folder where the package was generated and proceed to install it with the `dotnet` CLI using the following command:

   ```sh
   dotnet tool install --global --add-source {ruta del paquete} GitHubActivity
   ```

   Example:

   ```sh
   dotnet tool install --global --add-source ./GitHubActivity/bin/Release/ GitHubActivity
   ```

3. **Run the GitHubActivity CLI**:
   Once installed, you can run the tool using the following command:

   ```sh
   github-activity <username>
   ```

   Replace `<username>` with the GitHub username to get the desired information.

This project is part of [GitHub User Activity](https://roadmap.sh/projects/github-user-activity).