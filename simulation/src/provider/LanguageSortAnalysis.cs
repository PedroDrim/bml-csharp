
using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {

    /// <summary>
    ///  Classe para ordenacao pela propria linguagem
    /// </summary>
    public class LanguageSortAnalysis : ITableAnalysis<List<UserInfo>> {
        
        /// <summary>
        /// Realiza uma ordenacao pela propria linguagem
        /// </summary>
        /// <param name="list">Lista de dados a ser ordenada</param>
        /// <returns>Lista ordenada</returns>
        public List<UserInfo> Analysis(List<UserInfo> list) {
            if(list == null || (list.Count == 0))
                throw new InvalidParameterException("'userInfoList' é null ou vazio");

            List<UserInfo> sortedList = [.. list.OrderBy(it => it.Credit)];

            return sortedList;
        }
    }
}