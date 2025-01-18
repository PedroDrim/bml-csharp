namespace simulation.src.model {
 
    /// <summary>
    /// Interface para analise dos dados
    /// </summary>
    public interface ITableAnalysis<T> {      
 
        /// <summary>
        /// Realiza a analise dos dados
        /// </summary>
        /// <param name="userInfoList">Lista de dados a ser analisada</param>
        /// <returns>Resultado da analise</returns>
        T Analysis(List<UserInfo> userInfoList);
    }
}