## Información sobre la librería `System.Diagnostics`

| **Clase**         | **Propiedades Relevantes**                                  | **Métodos Relevantes**                                  |
|-------------------|-------------------------------------------------------------|---------------------------------------------------------|
| **Process**       | `Id`, `ProcessName`, `StartTime`, `TotalProcessorTime`       | `Start()`, `Kill()`, `GetProcesses()`, `GetProcessById()` |
| **ProcessStartInfo** | `FileName`, `Arguments`, `UseShellExecute`                |                                                     |
| **Stopwatch**     | N/A                                                         | `Start()`, `Stop()`, `ElapsedMilliseconds`, `Reset()`    |
| **EventLog**      | `Log`, `Entries`                                            | `WriteEntry()`, `Clear()`                               |
| **Debug**         | N/A                                                         | `WriteLine()`, `Assert()`                               |

## Descripción de las Clases y Métodos

### **Process**
La clase `Process` permite gestionar y obtener información sobre los procesos del sistema operativo. Es útil para iniciar, terminar y obtener detalles sobre los procesos en ejecución.

### **ProcessStartInfo**
La clase `ProcessStartInfo` se usa para configurar la información de inicio de un proceso antes de su ejecución, como el archivo a ejecutar y los argumentos necesarios.

### **Stopwatch**
La clase `Stopwatch` permite medir el tiempo de ejecución de bloques de código. Ideal para realizar análisis de rendimiento.

### **EventLog**
`EventLog` permite interactuar con los registros de eventos del sistema operativo, como los de Windows. Puedes escribir entradas en los registros o limpiarlos.

### **Debug**
La clase `Debug` se usa para realizar tareas de depuración, como escribir mensajes en la ventana de depuración de Visual Studio o verificar condiciones con `Assert`.


##Informacion sobre navegadores y sus procesos - hilos
Cuando abres más de una pestaña, se pueden abrir nuevos hilos dentro del mismo proceso, pero no se abren nuevos procesos (por lo general). Cada hilo se encarga de tareas o pestañas específicas, y el sistema operativo administra estos hilos dentro de un solo proceso de navegador.

## Comparativa entre `Thread` y `Task` en C#

### Clase `Thread`
La clase `Thread` en C# se utiliza para crear y gestionar hilos en un programa. Cada hilo permite ejecutar código de manera concurrente, facilitando el paralelismo en las aplicaciones.

#### Métodos más relevantes de `Thread`:
- **`Start()`**: Inicia la ejecución del hilo.
- **`Sleep(int milliseconds)`**: Suspende el hilo durante un número específico de milisegundos.
- **`Join()`**: Hace que el hilo actual espere hasta que el hilo invocado termine.
- **`Abort()`**: Termina la ejecución de un hilo (desaconsejado por problemas de seguridad y fiabilidad).
- **`IsAlive`**: Propiedad que indica si el hilo sigue en ejecución.

### Clase `Task`
La clase `Task` representa una unidad de trabajo asincrónica. A diferencia de `Thread`, `Task` es más flexible y está diseñada para operaciones asincrónicas, como las realizadas con `async` y `await`.

#### Métodos más relevantes de `Task`:
- **`Run()`**: Inicia la ejecución de una tarea asincrónica.
- **`Wait()`**: Bloquea el hilo actual hasta que la tarea se complete.
- **`WhenAll()`**: Espera a que todas las tareas especificadas finalicen.
- **`WhenAny()`**: Espera hasta que cualquiera de las tareas especificadas finalice.

### Comparativa entre `Thread` y `Task`

| **Característica**          | **Thread**                              | **Task**                              |
|----------------------------|-----------------------------------------|---------------------------------------|
| **Propósito**               | Crear y gestionar hilos manualmente.    | Representar y gestionar operaciones asincrónicas. |
| **Control de ejecución**    | Más bajo nivel, controla el ciclo de vida del hilo manualmente. | Más alto nivel, maneja la ejecución en segundo plano con mayor facilidad. |
| **Manejo de excepciones**   | Las excepciones no controladas pueden finalizar el hilo. | Las excepciones se manejan de forma más robusta mediante `Task.Exception`. |
| **Paralelismo**             | Ideal para procesos que requieren control total sobre hilos. | Mejor para tareas asincrónicas que no requieren control sobre hilos específicos. |
| **Uso recomendado**         | Tareas que requieren ejecución concurrente a bajo nivel. | Operaciones asincrónicas como IO, bases de datos, tareas paralelas. |

- Usa **`Thread`** cuando necesites control completo sobre la ejecución de hilos, aunque generalmente se prefiere `Task` para una mayor flexibilidad y facilidad en operaciones asincrónicas.
- Usa **`Task`** para operaciones paralelas o asincrónicas que no requieren un control manual del ciclo de vida del hilo.
