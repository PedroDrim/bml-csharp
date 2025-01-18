namespace simulation.src.model {
 
    /// <summary>
    /// Interface para captura de estados de tempo (benchmark)
    /// </summary>
    public interface IBenchmarkOutput {      
 
        /// <summary>
        /// Inicio da captura de estado
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        void Start(string tag);

        /// <summary>
        /// Fim da captura de estado
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        void End(string tag);

        /// <summary>
        /// Resultado da captura de estado especifica
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        /// <param name="format">Formato do resultado</param>
        /// <returns>Tempo decorrido entre o inicio e o fim da captura de estado</returns>
        double Result(string tag, TimeFormat format);

        /// <summary>
        /// Resultado de todas as capturas de estado
        /// </summary>
        /// <param name="format">Formato do resultado</param>
        /// <returns>Mapa contendo o tempo decorrido entre o inicio e o fim da captura de estado para cada estado gerado.</returns>
        Dictionary<string, double> Result(TimeFormat format);

        /// <summary>
        /// Exporta o resultado no formato de um arquivo
        /// </summary>
        /// <param name="fileName">Nome do arquivo de saida</param>
        /// <param name="format">Formato do resultado</param>
        void Export(string fileName, TimeFormat format);
    }
}