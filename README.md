## Pasos para el despliegue

1. **Construir el paquete**:
   Utiliza el comando `dotnet pack` para generar un archivo `.nupkg`.

   ```sh
   dotnet pack --configuration Release
   ```

Esto generará el paquete en la carpeta `bin/Release`.

2. **Instalar el paquete**:
   En la terminal, navega a la carpeta donde se generó el paquete y procede a instalarlo con la CLI de `dotnet` usando el siguiente comando:

   ```sh
   dotnet tool install --global --add-source {ruta del paquete} GitHubActivity
   ```

   Ejemplo:

   ```sh
   dotnet tool install --global --add-source ./GitHubActivity/bin/Release/ GitHubActivity
   ```

3. **Ejecutar la CLI de GitHubActivity**:
   Una vez instalado, puedes ejecutar la herramienta usando el siguiente comando:

   ```sh
   github-activity <username>
   ```

   Reemplaza `<username>` con el nombre de usuario de GitHub para obtener la información deseada.


