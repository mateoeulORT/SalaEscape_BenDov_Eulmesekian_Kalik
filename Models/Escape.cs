class Escape{
    private static string[] IncognitasSalas {get; set;}
    private static int EstadoJuego{get; set;} = 1;
    const int cantSalas = 5;
    private static void InicializarJuego(){
        IncognitasSalas = new string[cantSalas];
        for (int i = 0; i < IncognitasSalas.Length; i++)
        {
            IncognitasSalas[i] = " ";
        }
    }    
    public static int GetEstadoJuego() {
        return EstadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        if(IncognitasSalas.Length == 0)
            InicializarJuego();

        if(EstadoJuego < Sala)
        {
            return false;
        }
        else{
            if(Incognita == IncognitasSalas[EstadoJuego]){
                EstadoJuego++;
                return true;
            }
            else
                return false;
        }
    }
}