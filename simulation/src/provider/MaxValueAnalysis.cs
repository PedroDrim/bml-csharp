using simulation.src.model;

namespace simulation.src.provider {
    
    /// <summary>
    /// Classe que implementa a interface "SimpleTableAnalysis",
    /// responsável por obter o maior valor de "credit" em uma lista de usuarios
    /// </summary>
    public class MaxValueAnalysis : ISimpleTableAnalysis {
    
        /// <summary>
        /// Método de interface, responsável por obter o maior valor de credit na lista de "UserInfo"
        /// </summary>
        /// <param name="list">Lista de "UserInfo"</param>
        /// <returns>Maio valor de credit</returns>
        public double Analysis(List<UserInfo> list) {

            double max = double.MinValue;
            foreach(UserInfo userInfo in list) {
                if(max < userInfo.Credit) max = userInfo.Credit;
            }

            return max;
        }
    }
}
