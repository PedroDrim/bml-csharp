namespace simulation.src.model {
 
    /// <summary>
    /// Interface para leitura de dados
    /// </summary>
    public interface IDataReader {      

        /// <summary>
        /// Obtem todos os dados disponiveis
        /// </summary>
        /// <returns>Lista contendo todos os dados disponiveis</returns>
        void Open();

        /// <summary>
        /// Obtem todos os dados disponiveis
        /// </summary>
        /// <returns>Lista contendo todos os dados disponiveis</returns>
        List<UserInfo> Read();

        /// <summary>
        /// Obtem os dados disponiveis dentro de um intervalo
        /// </summary>
        /// <param name="startIndex">Inicio do intervalo</param>
        /// <param name="endIndex">Fim do intervalo</param>
        /// <returns>Lista contendo todos os dados disponiveis dentro do intervalo especificado</returns>
        List<UserInfo> Read(int startIndex, int endIndex);

    }
}