using System.Text.Json;
using simulation.src.model;
using simulation.src.model.exception;

namespace simulation.src.provider {
 
    /// <summary>
    /// Classe para captura de estados de tempo (benchmark)
    /// </summary>
    public class BenchmarkMeasure : IBenchmarkOutput {      

        /// <summary>
        /// Mapa de estados
        /// </summary>
        private readonly Dictionary<string, double> benchMap = [];

        /// <summary>
        /// Marca de inicio de estado
        /// </summary>
        private readonly string START_MARK = "_S";

        /// <summary>
        /// Marca de final de estado
        /// </summary>
        private readonly string END_MARK = "_E";

        /// <summary>
        /// Inicio da captura de estado
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        public void Start(string tag) {
            if(tag == null) throw new InvalidParameterException("'tag' e null");

            double time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            this.benchMap.Add(tag + START_MARK, time);
        }

        /// <summary>
        /// Fim da captura de estado
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        public void End(string tag) {
            if(tag == null) throw new InvalidParameterException("'tag' e null");

            double time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            this.benchMap.Add(tag + END_MARK, time);
        }

        /// <summary>
        /// Resultado da captura de estado especifica
        /// </summary>
        /// <param name="tag">Nome da captura referente</param>
        /// <param name="format">Formato do resultado</param>
        /// <returns>Tempo decorrido entre o inicio e o fim da captura de estado</returns>
        public double Result(string tag, TimeFormat format) {
            if(tag == null) throw new InvalidParameterException("'tag' e null");
            
            bool startTag = this.benchMap.ContainsKey(tag + START_MARK);
            bool endTag = this.benchMap.ContainsKey(tag + END_MARK);

            if(!startTag || !endTag) throw new BenchmarkException("Não encontrado par 'inicio-fim' de:" + tag);

            double start = this.benchMap[tag + START_MARK];
            double end = this.benchMap[tag + END_MARK];
            return (end - start) * Math.Pow(10,(int)format);
        }

        /// <summary>
        /// Resultado de todas as capturas de estado
        /// </summary>
        /// <param name="format">Formato do resultado</param>
        /// <returns>Mapa contendo o tempo decorrido entre o inicio e o fim da captura de estado para cada estado gerado.</returns>
        public Dictionary<string, double> Result(TimeFormat format) {
            Dictionary<string, double> mapResult = [];
            ICollection<string> tagSet = this.benchMap.Keys;

            foreach(string tagMark in tagSet) {
                string tag = tagMark.Split("_")[0];
                double time = this.Result(tag, format);
                mapResult[tag] = time;
            }

            return mapResult;
        }

        /// <summary>
        /// Exporta o resultado no formato de um arquivo
        /// </summary>
        /// <param name="fileName">Nome do arquivo de saida</param>
        /// <param name="format">Formato do resultado</param>
        public void Export(string fileName, TimeFormat format) {
            if(fileName == null) throw new InvalidParameterException("'fileName' e null");

            Dictionary<string, double> mapResult = this.Result(format);
            string jsonString = JsonSerializer.Serialize(mapResult);            
            File.WriteAllText(fileName, jsonString);
        }
    }
}