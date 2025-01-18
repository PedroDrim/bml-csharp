using simulation.src.model;

namespace simulation.src.provider {

    /// <summary>
    /// Classe que implementa a interface "SimpleTableAnalysis",
    /// responsável por obter o menor valor de "credit" em uma lista de usuarios
    /// </summary>
    public class MinValueAnalysis : ISimpleTableAnalysis {
        
        /// <summary>
        /// Método de interface, responsável por obter o menor valor de credit na lista de "UserInfo"
        /// </summary>
        /// <param name="list">Lista de "UserInfo"</param>
        /// <returns>Menor valor de credit</returns>
        public double Analysis(List<UserInfo> list) {

            double min = double.MaxValue;
            foreach(UserInfo userInfo in list) {
                if(min > userInfo.Credit) min = userInfo.Credit;
            }

            return min;
        }
    }
}
