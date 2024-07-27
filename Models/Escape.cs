class Escape{
    private static string[] IncognitasSalas {get; set;}
    private static int EstadoJuego{get; set;} = 1;
    const int cantSalas = 5;

    private static void InicializarJuego(){
        IncognitasSalas = new string[cantSalas] {"4F", "a", "a", "a", "a"};
    }    

    public static int GetEstadoJuego() {
        return EstadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        if (IncognitasSalas == null || IncognitasSalas.Length == 0)
        {
            InicializarJuego();
        }

        if(EstadoJuego < Sala)
        {
            return false;
        }
        
        if(Incognita == IncognitasSalas[Sala - 1]){
            EstadoJuego++;
            return true;
        }
        else
            return false;
        
    }
}
