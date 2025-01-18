namespace simulation.src.model {

    /// <summary>
    /// Interface "SimpleTableAnalysis"
    /// </summary>
    public interface ISimpleTableAnalysis {      

        /// <summary>
        /// Método de interface, responsável por realizar a análise na lista de "UserInfo"
        /// </summary>
        /// <param name="list">Lista de "UserInfo"</param>
        /// <returns>valor da análise</returns>
        double Analysis(List<UserInfo> list);
    }
}
