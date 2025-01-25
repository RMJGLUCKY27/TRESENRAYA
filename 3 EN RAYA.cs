using System;

class Program
{
    // Tablero de juego representado como un arreglo de caracteres.
    // Cada posición del tablero corresponde a un número del 1 al 9, que se puede seleccionar por los jugadores.
    static char[] tablero = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    // Variable que indica el jugador actual: 1 para el jugador 1 y 2 para el jugador 2.
    static int jugadorActual = 1;

    static void Main(string[] args)
    {
        // Variable para controlar si el juego sigue en curso.
        bool jugando = true;

        // Bucle principal del juego.
        while (jugando)
        {
            // Limpia la consola y muestra el tablero actualizado.
            Console.Clear();
            MostrarTablero();

            // Muestra un mensaje indicando al jugador actual que elija una posición.
            Console.WriteLine($"Jugador {jugadorActual}, es tu turno.");
            Console.Write("Elige una posición (1-9): ");

            // Lee la entrada del jugador y verifica si es válida.
            if (int.TryParse(Console.ReadLine(), out int posicion) && posicion >= 1 && posicion <= 9)
            {
                // Verifica si la posición seleccionada está disponible.
                if (tablero[posicion - 1] != 'X' && tablero[posicion - 1] != 'O')
                {
                    // Marca la posición en el tablero con 'X' o 'O' según el jugador actual.
                    tablero[posicion - 1] = jugadorActual == 1 ? 'X' : 'O';

                    // Comprueba si el jugador actual ha ganado.
                    if (VerificarGanador())
                    {
                        Console.Clear();
                        MostrarTablero();
                        Console.WriteLine($"¡Jugador {jugadorActual} ha ganado!");
                        jugando = VolverAJugar(); // Pregunta si desean reiniciar el juego.
                    }
                    // Comprueba si todas las posiciones están ocupadas y no hay ganador (empate).
                    else if (VerificarEmpate())
                    {
                        Console.Clear();
                        MostrarTablero();
                        Console.WriteLine("¡Es un empate!");
                        jugando = VolverAJugar();
                    }
                    else
                    {
                        // Cambia al siguiente jugador si el juego continúa.
                        CambiarJugador();
                    }
                }
                else
                {
                    // Mensaje de error si la posición ya está ocupada.
                    Console.WriteLine("Esa posición ya está ocupada. Presiona Enter para intentar de nuevo.");
                    Console.ReadLine();
                }
            }
            else
            {
                // Mensaje de error si la entrada no es válida.
                Console.WriteLine("Entrada inválida. Presiona Enter para intentar de nuevo.");
                Console.ReadLine();
            }
        }
    }

    // Método para mostrar el estado actual del tablero en consola.
    static void MostrarTablero()
    {
        // Formato del tablero con líneas divisorias.
        Console.WriteLine("\n {0} | {1} | {2}", tablero[0], tablero[1], tablero[2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2}", tablero[3], tablero[4], tablero[5]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2}\n", tablero[6], tablero[7], tablero[8]);
    }

    // Método para verificar si algún jugador ha ganado.
    static bool VerificarGanador()
    {
        // Combinaciones ganadoras representadas como índices del arreglo del tablero.
        int[,] combinacionesGanadoras = {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Filas
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columnas
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonales
        };

        // Recorre las combinaciones y verifica si los valores en esas posiciones son iguales.
        for (int i = 0; i < combinacionesGanadoras.GetLength(0); i++)
        {
            if (tablero[combinacionesGanadoras[i, 0]] == tablero[combinacionesGanadoras[i, 1]] &&
                tablero[combinacionesGanadoras[i, 1]] == tablero[combinacionesGanadoras[i, 2]])
            {
                return true; // Retorna verdadero si hay una combinación ganadora.
            }
        }

        return false; // Retorna falso si no hay ganador.
    }

    // Método para verificar si todas las posiciones del tablero están ocupadas (empate).
    static bool VerificarEmpate()
    {
        foreach (char c in tablero)
        {
            if (c != 'X' && c != 'O')
            {
                return false; // Retorna falso si hay al menos una posición libre.
            }
        }
        return true; // Retorna verdadero si todas las posiciones están ocupadas.
    }

    // Método para cambiar el turno al otro jugador.
    static void CambiarJugador()
    {
        jugadorActual = (jugadorActual == 1) ? 2 : 1;
    }

    // Método para preguntar si los jugadores desean reiniciar el juego.
    static bool VolverAJugar()
    {
        Console.Write("¿Deseas jugar otra vez? (S/N): ");
        string respuesta = Console.ReadLine().ToUpper();
        if (respuesta == "S")
        {
            ReiniciarTablero(); // Reinicia el tablero al estado inicial.
            jugadorActual = 1; // Restablece el turno al jugador 1.
            return true;
        }
        return false; // Termina el juego si la respuesta es "N".
    }

    // Método para reiniciar el tablero a su estado inicial (1-9).
    static void ReiniciarTablero()
    {
        for (int i = 0; i < tablero.Length; i++)
        {
            tablero[i] = (char)('1' + i); // Asigna los valores originales al tablero.
        }
    }
}
