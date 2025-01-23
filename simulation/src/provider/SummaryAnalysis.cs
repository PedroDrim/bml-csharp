using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {

    /// <summary>
    ///  Classe para analise de dados, obtem a media dos valores dos creditos dos usuarios
    /// </summary>
    public class SummaryAnalysis : ITableAnalysis<double[]> {
        
        /// <summary>
        /// Realiza a analise de media dos dados
        /// </summary>
        /// <param name="list">Lista de dados a ser analisada</param>
        /// <returns>Media dos valores dos creditos</returns>
        public double[] Analysis(List<UserInfo> list) {
            if(list == null || (list.Count == 0))
                throw new InvalidParameterException("'userInfoList' é null ou vazio");

            double sum = 0;
            double min = double.MaxValue;
            double max = double.MinValue;
            
            foreach(UserInfo userInfo in list) {
                sum += userInfo.Credit;
                if(min > userInfo.Credit) min = userInfo.Credit;
                if(max < userInfo.Credit) max = userInfo.Credit;
            }

            double mean = sum/list.Count;
            double[] range = [min, max, mean];
            return range;
        }
    }
}