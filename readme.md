# Proyecto CURS Sistema de gestion de aulas
## Trabajo de practicas profesionales Tecnicatura superior en programacion UTN Pacheco

## Integrantes 
* Lucas Centurion
* Enzo Di Candia
* Adrian Abadin 

## Relevamiento 
El *Centro Universitario Regional Saladillo* (CURS) es una institución educativa de carácter municipal que ofrece una amplia oferta académica mediante alianzas con instituciones universitarias como la UBA, la UNLP, la UTN y la UNQ. Gracias a estas colaboraciones, los estudiantes pueden cursar carreras como la Tecnicatura Universitaria en Programación, la Licenciatura en Administración, Contador Público y Asistente Terapéutico, entre otras. Sin embargo, esta oferta no es constante todos los años; algunas carreras, como Contador Público, son permanentes, mientras que otras, como la Tecnicatura en Programación, se ofrecen solo en cohortes específicas. El CURS opera de lunes a sábado, de 8:00 a 22:00 hs, y su variada oferta académica requiere una organización eficaz, en especial para la gestión de reservas de aulas.
Actualmente, el CURS cuenta con siete aulas. Dos de estas, el Aula 3 y el Aula 4, se han unificado para formar un espacio con capacidad para aproximadamente 70 personas. Otras cuatro aulas tienen capacidad para 32 personas cada una, y el Aula N° 1, también conocida como “Punto Digital”, es utilizada como laboratorio digital y está reservada para clases específicas, como robótica. Además de las aulas, el CURS dispone de un Salón de Usos Múltiples (SUM), que también está incluido en el sistema de reservas y es utilizado para diversos eventos. Este espacio puede ser reservado tanto por las instituciones aliadas como por otras organizaciones externas, tales como colegios profesionales (por ejemplo, el Colegio de Abogados o el Colegio de Odontólogos) o autoridades municipales. Los datos registrados para cada aula incluyen el número de aula, la capacidad máxima y cualquier característica específica, como el Punto Digital
La gestión de reservas en el CURS es realizada por tres personas del área administrativa, mediante hojas de Google Sheets. Cada hoja representa un mes, cada columna un día, y cada día se divide en 14 módulos de una hora. Las reservas generalmente se realizan con antelación, aunque en ocasiones los docentes las solicitan con poca anticipación. Al realizar una reserva, se registran el día y horario de la clase, el nombre y apellido del docente, la carrera y la institución a la que pertenece, y se consulta la cantidad de alumnos esperada para asignar el aula adecuada. Si todas las aulas están ocupadas en el horario solicitado, se asignará al docente una de mayor capacidad si está disponible; de no ser posible, se le informarán los horarios alternativos para su reserva. 
En el caso del SUM, se registra el nombre de la institución que solicita la reserva, el nombre completo del responsable y su contacto (teléfono o correo electrónico), el tipo de evento que se realizará y la fecha y hora de la reserva.
El proceso para la cancelación y modificación de reservas incluye el registro de los motivos del cambio, quién lo solicitó y quién lo realizó. Esto permite un control claro de los cambios y facilita auditorías. Además, se cuándo se necesita se imprime un reporte de reservas. Este se utiliza principalmente para la liquidación de viáticos, e incluye tanto las reservas efectivas, como así también las modificaciones y bajas ocurridas en el período, especificando el motivo, la persona que solicitó el cambio y quién lo efectuó. Para cancelar una reserva, el solicitante se comunica con el personal administrativo, quien procede a eliminar los datos de la reserva. Esta flexibilidad, que permite actualmente, que cualquier persona agregue, modifique o borre reservas, puede ocasionar inconvenientes, como superposiciones de reservas o complicaciones en la gestión de viáticos.

Finalmente, el CURS tiene previsto, a mediano plazo, expandir su infraestructura mediante la incorporación de ocho nuevas aulas y un aula magna.

## Entorno de Ejecucion
El concepto seria implementar una aplicacion web que permita el acceso a los usuarios sin la necesidad de una red local que les permita acceso a la base de datos.
Es por esto que una solucion descentralizada permitira la gestion del sistema desde la infraestructura sin complegizar la conectividad ya presente en la institucion.

## Tecnologias a implementar
* Aplicacion Web Patron *MVC ASP .NET CORE* 8.0 
* Base de Datos Sql Server 
* ORM Entity Framework
* Authenticacion y autorizacion Identity Core

## Arquitectura
El diseño de la aplicacion sera utilizando arquitectur MVC (Modelo,Vista,Controlador) lo que permite una solucion sencilla, monorepo y con codigo legible y escalable para poder ampliar o modificar en el largo plazo
Se aplicaran los patrones de diseño actualmente reconocidos en las arquitecturas clean para .NET que es la inyeccion de dependencias mediante un patron de servicios y repositorios.
Esto permitira el desarrollo de una aplicacion que respete los principios SOLID  para el desarrollo de arquitecturas de software 


