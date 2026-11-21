namespace SimuladorLlamadas
{
    public enum EstadoLlamada
    {
        Registrada, // Sonando / recién registrada
        Activa,     // En conversación
        EnEspera    // Pausada porque entró otra llamada encima
    }
}
