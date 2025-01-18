
using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {

    /// <summary>
    ///  Classe para ordenacao quickSort
    /// </summary>
    public class QuickSortAnalysis : ITableAnalysis<List<UserInfo>> {
        
        private UserInfo[] arrayUserInfo = [];


        /// <summary>
        /// Realiza uma ordenacao quickSort
        /// </summary>
        /// <param name="userInfoList">Lista de dados a ser ordenada</param>
        /// <returns>Lista ordenada</returns>
        public List<UserInfo> Analysis(List<UserInfo> userInfoList) {
            if (userInfoList.Count == 0)
                throw new InvalidParameterException("'userInfoList' é vazio");

            return this.QuickSort(userInfoList);
        }

        /// <summary>
        /// Iniciando quickSort
        /// </summary>
        /// <param name="array">Lista a ser ordenada</param>
        /// <returns>Lista ordenada</returns>
        private List<UserInfo> QuickSort(List<UserInfo> array) {
            int tamanho = array.Count;
            if (tamanho <= 1)
                return array;

            // Obtendo posicao central
            double middle = tamanho / 2;
            int meio = (int) Math.Floor(middle);
            UserInfo pivot = array[meio];

            // Separando vetores
            List<UserInfo> menores = array.FindAll(value => value.Credit < pivot.Credit);
            List<UserInfo> iguais = array.FindAll(value => value.Credit == pivot.Credit);
            List<UserInfo> maiores = array.FindAll(value => value.Credit > pivot.Credit);

            // Obtendo vetores
            List<UserInfo> arrayMenores = this.QuickSort(menores);
            List<UserInfo> arrayMaiores = this.QuickSort(maiores);

            // Retornando vetor
            return [.. arrayMaiores, .. iguais, .. arrayMenores];
        }
    }
}