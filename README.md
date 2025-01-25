<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Explicación del Código</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 20px;
        }
        h1, h2 {
            color: #2c3e50;
        }
        p {
            margin: 10px 0;
        }
        ul {
            margin: 10px 0;
            padding-left: 20px;
        }
        ul li {
            margin: 5px 0;
        }
    </style>
</head>
<body>
    <h1>Explicación detallada del código</h1>
    <p>El programa implementa un juego de tres en raya para dos jugadores en consola. A continuación, se explica su funcionamiento paso a paso:</p>

    <h2>1. Declaración de variables globales</h2>
    <ul>
        <li><strong>tablero</strong>: Arreglo que representa el tablero del juego. Inicialmente, contiene los números del 1 al 9, que corresponden a las posiciones disponibles.</li>
        <li><strong>jugadorActual</strong>: Variable que rastrea de quién es el turno (jugador 1 o jugador 2).</li>
    </ul>

    <h2>2. Método Main</h2>
    <p>Este es el punto de entrada del programa. Aquí se inicializan las variables necesarias y se controla el flujo principal del juego:</p>
    <ul>
        <li>Se inicializa <strong>jugando</strong> como <code>true</code> para mantener el bucle principal activo.</li>
        <li>El bucle <code>while</code> sigue ejecutándose mientras <strong>jugando</strong> sea verdadero.</li>
    </ul>

    <h2>3. Ciclo principal del juego</h2>
    <p>Dentro del bucle principal:</p>
    <ul>
        <li>Se limpia la consola y se muestra el estado actual del tablero con <strong>MostrarTablero</strong>.</li>
        <li>Se solicita al jugador actual que elija una posición y se valida su entrada:</li>
        <ul>
            <li>Si la entrada es válida y la posición está disponible, se actualiza el tablero con el símbolo del jugador actual (X o O).</li>
            <li>Si la entrada es inválida o la posición ya está ocupada, se muestra un mensaje de error.</li>
        </ul>
    </ul>

    <h2>4. Verificación del estado del juego</h2>
    <ul>
        <li>Después de cada jugada, se llama a <strong>VerificarGanador</strong> para comprobar si alguien ha ganado:</li>
        <ul>
            <li>Este método revisa combinaciones predefinidas de filas, columnas y diagonales para encontrar tres símbolos iguales.</li>
        </ul>
        <li>Si hay un ganador, se muestra un mensaje de victoria y se pregunta si desean jugar otra vez con <strong>VolverAJugar</strong>.</li>
        <li>Si no hay ganador, se verifica un empate con <strong>VerificarEmpate</strong>. Esto ocurre si todas las casillas están ocupadas.</li>
        <li>Si no hay ganador ni empate, el turno pasa al siguiente jugador con <strong>CambiarJugador</strong>.</li>
    </ul>

    <h2>5. Métodos adicionales</h2>
    <ul>
        <li><strong>MostrarTablero</strong>: Imprime el estado actual del tablero en la consola.</li>
        <li><strong>VerificarGanador</strong>: Comprueba si alguna combinación ganadora tiene tres símbolos iguales.</li>
        <li><strong>VerificarEmpate</strong>: Verifica si todas las posiciones están ocupadas.</li>
        <li><strong>VolverAJugar</strong>: Pregunta al usuario si desea reiniciar el juego. Si la respuesta es afirmativa, se llama a <strong>ReiniciarTablero</strong>.</li>
        <li><strong>ReiniciarTablero</strong>: Restaura el tablero a su estado inicial con posiciones del 1 al 9.</li>
    </ul>

    <h2>6. Finalización del juego</h2>
    <p>El programa continúa ejecutándose hasta que los jugadores deciden no jugar más. En ese momento, el programa se cierra.</p>
</body>
</html>
