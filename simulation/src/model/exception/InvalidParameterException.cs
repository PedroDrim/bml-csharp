namespace simulation.src.model.exception {

    /// <summary>
    /// Classe para o tratamento de erro para entradas invalidas
    /// </summary>
    /// <param name="message">Mensagem de erro</param>
    /// <returns></returns>
    public class InvalidParameterException(string message) : Exception(message) {}
}