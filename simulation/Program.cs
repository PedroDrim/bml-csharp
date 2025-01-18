using System.Text;
using simulation.src.model;
using simulation.src.provider;

namespace simulation {

    /// <summary>
    /// Criando uma classe inicial "Program"
    /// </summary>
    public class Program {

        /// <summary>
        /// Método primário de execução 
        /// </summary>
        /// <param name="args">Lista de parametros iniciais</param>
        static void Main(string[] args) {
            
            string arquivo = prepareArgs(args);

            // Obtendo o tempo inicial de leitura em milissegundos
            long leitura_inicio = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // Convertendo arquivo em lista de "UserInfo"
            Table table = new (arquivo);

            // Obtendo o tempo final de leitura em milissegundos
            long leitura_fim = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            List<UserInfo> list = table.UserInfoList;

            ISimpleTableAnalysis maxValue = new MaxValueAnalysis();
            ISimpleTableAnalysis minValue = new MinValueAnalysis();
            ISimpleTableAnalysis meanValue = new MeanAnalysis();

            // Obtendo o tempo inicial de analise em milissegundos
            long analise_inicio = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // Realizando analises
            double max = maxValue.Analysis(list);
            double min = minValue.Analysis(list);
            double mean = meanValue.Analysis(list);

            // Obtendo o tempo final de analise em milissegundos
            long analise_fim = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // Dados de saida
            StringBuilder builder = new StringBuilder();
            builder.Append("[OK]Arquivo: ").Append(arquivo).Append('\n');
            builder.Append("[OK]Tempo_leitura: ").Append(leitura_fim - leitura_inicio).Append(" ms").Append('\n');
            builder.Append("[OK]Tempo_analise: ").Append(analise_fim - analise_inicio).Append(" ms").Append('\n');
            builder.Append("[OK]Max: ").Append(max).Append('\n');
            builder.Append("[OK]Min: ").Append(min).Append('\n');
            builder.Append("[OK]Mean: ").Append(mean);

            Console.WriteLine("[START] Csharp_" + arquivo);
            Console.WriteLine(builder.ToString());
            Console.WriteLine("[END] Csharp_" + arquivo);

        }

        /// <summary>
        /// Método para captura e tratamento dos parametros obtidos via console
        /// </summary>
        /// <param name="args">Lista de parametros iniciais</param>
        private static string prepareArgs(string[] codes) {
            if(codes.Length != 1) {
                Console.WriteLine("Parametros inválidos.");
                Environment.Exit(-1);
            }

            return codes[0];
        }
    }
}
