namespace simulation.src.model.exception {

    /// <summary>
    /// Classe para o tratamento de benchmark
    /// </summary>
    /// <param name="message">Mensagem de erro</param>
    /// <returns></returns>
    public class BenchmarkException(string message) : Exception(message) {}
}