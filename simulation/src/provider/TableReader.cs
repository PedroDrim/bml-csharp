using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {

    /// <summary>
    /// Classe responsavel por ler e disponibilizar os dados em um formato desejado
    /// </summary>
    /// <remarks>
    /// Construtor publico da classe
    /// </remarks>
    /// <param name="fileName">Nome do arquivo de dados a ser lido</param>
    public class TableReader(string fileName) : IDataReader {

        /// <summary>
        /// Nome do arquivo de dados
        /// </summary>
        /// <returns>Nome do arquivo de dados</returns>
        public readonly string FileName = fileName;

        /// <summary>
        /// Lista contendo os dados
        /// </summary>
        private List<UserInfo> UserInfoList = [];

        public void Open() {
            this.UserInfoList = this.DeserializeFile(this.FileName);
        }

        /// <summary>
        /// Obtem todos os dados disponiveis
        /// </summary>
        /// <returns>Lista contendo todos os dados disponiveis</returns>
        public List<UserInfo> Read() {
            return this.UserInfoList;
        }

        /// <summary>
        /// Obtem os dados disponiveis dentro de um intervalo
        /// </summary>
        /// <param name="startIndex">Inicio do intervalo</param>
        /// <param name="endIndex">Fim do intervalo</param>
        /// <returns>Lista contendo todos os dados disponiveis dentro do intervalo especificado</returns>
        public List<UserInfo> Read(int startIndex, int endIndex) {
            if(startIndex < 0) throw new InvalidParameterException("'startIndex' é menor que 0");
            if(endIndex < 0) throw new InvalidParameterException("'endIndex' é menor que 0");
            if(startIndex >= endIndex) throw new InvalidParameterException("'startIndex' é maior ou igual á 'endIndex'");

            return this.UserInfoList.GetRange(startIndex, endIndex);
        }

        /// <summary>
        /// Desserializa o arquivo de dados, convertendo-o em uma lista de 'UserInfo'
        /// </summary>
        /// <param name="fileName">Nome do arquivo de dados</param>
        /// <returns>Lista contendo os dados desserilizados</returns>
        private List<UserInfo> DeserializeFile(string fileName) {
            if(fileName == null) throw new InvalidParameterException("'fileName' e null");

            try {
                IEnumerable<UserInfo> list = File.ReadAllLines(fileName)[1..].Where(it => it != "").Select(this.ConvertLine);
                List<UserInfo> userInfoList = [..list];
                return [..userInfoList];
            } catch (FileNotFoundException) {
                throw new DataReaderException("Arquivo não encontrado");
            }
        }

        /// <summary>
        /// Converte a linha em um 'UserInfo'
        /// </summary>
        /// <param name="line">line Linha a ser desserializada</param>
        /// <returns>Objeto 'UserInfo'</returns>
        private UserInfo ConvertLine(string line) {
            string[] values = line.Split(",");

            string user = values[0].Trim();
            string password = values[1].Trim();

            double credit = double.Parse(values[2].Trim(),
                System.Globalization.CultureInfo.InvariantCulture
            );

            UserInfo userInfo = new(user, password, credit);
            return userInfo;
        }
    }
}