
using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {

    /// <summary>
    ///  Classe para ordenacao MergeSort
    /// </summary>
    public class MergeSortAnalysis : ITableAnalysis<List<UserInfo>> {
        
        /// <summary>
        /// Realiza uma ordenacao MergeSort
        /// </summary>
        /// <param name="userInfoList">Lista de dados a ser ordenada</param>
        /// <returns>Lista ordenada</returns>
        public List<UserInfo> Analysis(List<UserInfo> userInfoList) {
            if (userInfoList.Count == 0)
                throw new InvalidParameterException("'userInfoList' é vazio");

            return this.MergeSort(userInfoList);
        }

        private List<UserInfo> MergeSort(List<UserInfo> array) {
            // Limite da recursividade
            int tamanho = array.Count;
            if (tamanho <= 1) return array;
        
            // Obtendo posicao central
            double middle = tamanho / 2;
            int meio = (int) Math.Floor(middle);

            // Separando vetores
            List<UserInfo> vetorEsquerda = array[..meio];
            List<UserInfo> vetorDireita = array[meio..];

            // Aplicando recursividade
            List<UserInfo> esquerda = this.MergeSort(vetorEsquerda);
            List<UserInfo> direita = this.MergeSort(vetorDireita);

            // Unificando vetores da esquerda, meio e direita
            return this.Merge(esquerda, direita);
        }

        /**
        * Metodo responsvel por unir os vetores
        * @param esquerda Vetor da esquerda
        * @param direita Vetor da direita
        * @returns Lista unificada
        */
        private List<UserInfo> Merge(List<UserInfo> esquerda, List<UserInfo> direita) {
            // Iniciando variaveis
            int indexEsquerda = 0;
            int indexDireita = 0;

            // Calculando limites
            int distanciaEsquerda = esquerda.Count;
            int distanciaDireita = direita.Count;

            // Iniciando vetor vazio
            List<UserInfo> response = [];

            // Unificando os vetores da esquerda e da direita
            while (indexEsquerda < distanciaEsquerda && indexDireita < distanciaDireita) {

                // Verificando comparacao
                if (esquerda[indexEsquerda].Credit > direita[indexDireita].Credit) {
                    // Aplicando esquerda
                    response.Add(esquerda[indexEsquerda]);
                    indexEsquerda++;
                } else {
                    // Aplicando direita
                    response.Add(direita[indexDireita]);
                    indexDireita++;
                }
            }
    
            // Obtendo vetores de resposta
            List<UserInfo> vetorEsquerda = esquerda[..indexEsquerda];
            List<UserInfo> vetorDireita = direita[indexDireita..];
            
            // Retornando resposta
            return [.. vetorEsquerda, ..vetorDireita];
        }
    }
}