namespace simulation.src.model.exception {

    /// <summary>
    /// Classe para o tratamento de erro durante a leitura dos dados
    /// </summary>
    /// <param name="message">Mensagem de erro</param>
    /// <returns></returns>
    public class DataReaderException(string message) : Exception(message) {}
}