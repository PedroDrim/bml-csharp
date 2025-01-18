using simulation.src.model;

namespace simulation.src.provider {

    /// <summary>
    /// Classe que implementa a interface "SimpleTableAnalysis",
    /// responsável por obter a media de valores de "credit" em uma lista de usuarios
    /// </summary>
    public class MeanAnalysis : ISimpleTableAnalysis {

        /// <summary>
        /// Método de interface, responsável por obter a media de valores de credit na lista de "UserInfo"
        /// </summary>
        /// <param name="list">Lista de "UserInfo"</param>
        /// <returns>Média de valor de credit</returns>
        public double Analysis(List<UserInfo> list) {
            double mean = list.Average(userInfo => userInfo.Credit);
            return mean;
        }
    }
}
