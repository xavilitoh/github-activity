Para desplegar y ejecutar tu aplicación desde la línea de comandos utilizando el CLI de .NET, sigue estos pasos:

1. **Empaquetar la aplicación**:
   Primero, asegúrate de que tu proyecto esté configurado correctamente y que todos los archivos necesarios estén incluidos. Luego, puedes empaquetar tu aplicación utilizando el comando `dotnet publish`.

   ```sh
   dotnet publish -c Release -o ./publish
   ```

   Este comando compilará tu aplicación en modo Release y colocará los archivos compilados en la carpeta `./publish`.

2. **Instalar la aplicación**:
   Una vez que la aplicación esté empaquetada, puedes ejecutarla directamente desde la carpeta de publicación. Navega a la carpeta `./publish` y ejecuta el archivo ejecutable generado.

   ```sh
   cd ./publish
   ./GitHubActivity
   ```

3. **Documentación del despliegue**:
   Crea un archivo `README.md` en la raíz de tu proyecto con las instrucciones de despliegue. Aquí tienes un ejemplo de cómo podría verse:

   ```markdown
   # Despliegue de GitHubActivity

   ## Requisitos
   - .NET SDK 6.0 o superior

   ## Pasos para empaquetar y desplegar

   1. **Empaquetar la aplicación**:
      ```sh
      dotnet publish -c Release -o ./publish
      ```

    2. **Navegar a la carpeta de publicación**:
       ```sh
       cd ./publish
       ```

    3. **Ejecutar la aplicación**:
       ```sh
       ./GitHubActivity
       ```

   ## Uso
   Para ejecutar la aplicación, proporciona un nombre de usuario de GitHub como argumento:
   ```sh
   ./GitHubActivity <nombre_de_usuario>
   ```

   Por ejemplo:
   ```sh
   ./GitHubActivity octocat
   ```
   ```

Guarda este contenido en el archivo `README.md` para que otros desarrolladores puedan seguir las instrucciones de despliegue y ejecución de tu aplicación.