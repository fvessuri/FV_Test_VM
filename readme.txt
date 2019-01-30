Cómo están organizados los archivos del test:

1) En la carpeta MyRestfulApp está la aplicación ASP.NET del tipo Web Api, está desarrollada en Visual Studio 2015 con el framerwork 4.5.2. En el archivo web.config hay que cambiar los datos del string de conexión con la clave "TestConnection" (servidor, usuario y password), se asume una conexión a un Sql Server (en mi caso es versión 2016). La url para la cotización del dolar se guardó en la sección appSettings del web.config. Los scripts para la creación de la base, tabla y datos iniciales están en el archivo "DBscripts.sql" en la carpeta inicial. Para los test usé nUnit versión 3.8.1 (con Unit3TestAdapter 3.8.0). 

2) Las respuestas al test de Javascript están en el archivo "FV_Test_js.txt" de la carpeta principal

3) Se agrega además un pdf con las consignas del test que me enviaron ("Federico Vessuri Test.pdf")

Por cualquier consulta, por favor, me escriben a mi casilla de correo en: fvessuri@gmail.com

Gracias!

Saludos,
Federico Vessuri.
