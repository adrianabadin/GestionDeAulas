# Proyecto CURS Sistema de gestion de aulas
## Trabajo de practicas profesionales Tecnicatura superior en programacion UTN Pacheco

## Integrantes 
* Lucas Centurion
* Enzo Di Candia
* Adrian Abadin 

## Relevamiento 
El *Centro Universitario Regional Saladillo* (CURS) es una instituci�n educativa de car�cter municipal que ofrece una amplia oferta acad�mica mediante alianzas con instituciones universitarias como la UBA, la UNLP, la UTN y la UNQ. Gracias a estas colaboraciones, los estudiantes pueden cursar carreras como la Tecnicatura Universitaria en Programaci�n, la Licenciatura en Administraci�n, Contador P�blico y Asistente Terap�utico, entre otras. Sin embargo, esta oferta no es constante todos los a�os; algunas carreras, como Contador P�blico, son permanentes, mientras que otras, como la Tecnicatura en Programaci�n, se ofrecen solo en cohortes espec�ficas. El CURS opera de lunes a s�bado, de 8:00 a 22:00 hs, y su variada oferta acad�mica requiere una organizaci�n eficaz, en especial para la gesti�n de reservas de aulas.
Actualmente, el CURS cuenta con siete aulas. Dos de estas, el Aula 3 y el Aula 4, se han unificado para formar un espacio con capacidad para aproximadamente 70 personas. Otras cuatro aulas tienen capacidad para 32 personas cada una, y el Aula N� 1, tambi�n conocida como �Punto Digital�, es utilizada como laboratorio digital y est� reservada para clases espec�ficas, como rob�tica. Adem�s de las aulas, el CURS dispone de un Sal�n de Usos M�ltiples (SUM), que tambi�n est� incluido en el sistema de reservas y es utilizado para diversos eventos. Este espacio puede ser reservado tanto por las instituciones aliadas como por otras organizaciones externas, tales como colegios profesionales (por ejemplo, el Colegio de Abogados o el Colegio de Odont�logos) o autoridades municipales. Los datos registrados para cada aula incluyen el n�mero de aula, la capacidad m�xima y cualquier caracter�stica espec�fica, como el Punto Digital
La gesti�n de reservas en el CURS es realizada por tres personas del �rea administrativa, mediante hojas de Google Sheets. Cada hoja representa un mes, cada columna un d�a, y cada d�a se divide en 14 m�dulos de una hora. Las reservas generalmente se realizan con antelaci�n, aunque en ocasiones los docentes las solicitan con poca anticipaci�n. Al realizar una reserva, se registran el d�a y horario de la clase, el nombre y apellido del docente, la carrera y la instituci�n a la que pertenece, y se consulta la cantidad de alumnos esperada para asignar el aula adecuada. Si todas las aulas est�n ocupadas en el horario solicitado, se asignar� al docente una de mayor capacidad si est� disponible; de no ser posible, se le informar�n los horarios alternativos para su reserva. 
En el caso del SUM, se registra el nombre de la instituci�n que solicita la reserva, el nombre completo del responsable y su contacto (tel�fono o correo electr�nico), el tipo de evento que se realizar� y la fecha y hora de la reserva.
El proceso para la cancelaci�n y modificaci�n de reservas incluye el registro de los motivos del cambio, qui�n lo solicit� y qui�n lo realiz�. Esto permite un control claro de los cambios y facilita auditor�as. Adem�s, se cu�ndo se necesita se imprime un reporte de reservas. Este se utiliza principalmente para la liquidaci�n de vi�ticos, e incluye tanto las reservas efectivas, como as� tambi�n las modificaciones y bajas ocurridas en el per�odo, especificando el motivo, la persona que solicit� el cambio y qui�n lo efectu�. Para cancelar una reserva, el solicitante se comunica con el personal administrativo, quien procede a eliminar los datos de la reserva. Esta flexibilidad, que permite actualmente, que cualquier persona agregue, modifique o borre reservas, puede ocasionar inconvenientes, como superposiciones de reservas o complicaciones en la gesti�n de vi�ticos.

Finalmente, el CURS tiene previsto, a mediano plazo, expandir su infraestructura mediante la incorporaci�n de ocho nuevas aulas y un aula magna.

## Entorno de Ejecucion
El concepto seria implementar una aplicacion web que permita el acceso a los usuarios sin la necesidad de una red local que les permita acceso a la base de datos.
Es por esto que una solucion descentralizada permitira la gestion del sistema desde la infraestructura sin complegizar la conectividad ya presente en la institucion.

## Tecnologias a implementar
* Aplicacion Web Patron *MVC ASP .NET CORE* 8.0 
* Base de Datos Sql Server 
* ORM Entity Framework
* Authenticacion y autorizacion Identity Core

## Arquitectura
El dise�o de la aplicacion sera utilizando arquitectur MVC (Modelo,Vista,Controlador) lo que permite una solucion sencilla, monorepo y con codigo legible y escalable para poder ampliar o modificar en el largo plazo
Se aplicaran los patrones de dise�o actualmente reconocidos en las arquitecturas clean para .NET que es la inyeccion de dependencias mediante un patron de servicios y repositorios.
Esto permitira el desarrollo de una aplicacion que respete los principios SOLID  para el desarrollo de arquitecturas de software 


