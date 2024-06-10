# Usa la imagen oficial de Microsoft SQL Server
FROM mcr.microsoft.com/mssql/server:2019-latest

# Establece las variables de entorno para aceptar el EULA y la contraseña de SA
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Pass123456789_

# Copia el script de configuración de SQL Server al contenedor
COPY setup.sql /usr/src/setup.sql

# Establece el puerto de escucha de SQL Server
EXPOSE 1433

# Ejecución del script de configuración al iniciar el contenedor
CMD /opt/mssql/bin/sqlservr & sleep 30 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /usr/src/setup.sql \
    && wait
