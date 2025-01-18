using simulation.src.model;
using simulation.src.provider;
using System.Text.Json;

namespace simulation {

    public class Config {
        public required string[] INPUT_FILENAME_LIST { get; set; }
        public required string OUTPUT_FILENAME { get; set; }
    }

    public class Program {

        static void Main(string[] args) {
            Config configuration = GetConfiguration(args[0]);
            
            string[] inputList = configuration.INPUT_FILENAME_LIST;
            string output = configuration.OUTPUT_FILENAME;

            IBenchmarkOutput benchmark = new BenchmarkMeasure();

            ITableAnalysis<double[]> summaryAnalysis = new SummaryAnalysis();
            ITableAnalysis<List<UserInfo>> bubbleSortAnalysis = new BubbleSortAnalysis();
            ITableAnalysis<List<UserInfo>> quickSortAnalysis = new QuickSortAnalysis();
            ITableAnalysis<List<UserInfo>> languageSortAnalysis = new LanguageSortAnalysis();

            for (int index = 0; index < inputList.Length; index++) {
                string input = inputList[index];
                Console.WriteLine("[START] Arquivo: " + index);

                //==================================================
                // Leitura dos dados
                Console.WriteLine("\t[LOG] Read");
                benchmark.Start("Read@" + index);
                TableReader tableReader = new (input);
                List<UserInfo> list = tableReader.Read();
                benchmark.End("Read@" + index);
                //==================================================
                // Analise dos dados (Summary)
                Console.WriteLine("\t[LOG] Summary");
                benchmark.Start("SummaryAnalisys@" + index);
                double[] summary = summaryAnalysis.Analysis(list);
                benchmark.End("SummaryAnalisys@" + index);
                //==================================================
                // Analise dos dados (Bubble)
                Console.WriteLine("\t[LOG] Bubble");
                benchmark.Start("BubbleAnalisys@" + index);
                List<UserInfo> bubble = bubbleSortAnalysis.Analysis(list);
                benchmark.End("BubbleAnalisys@" + index);
                //==================================================
                // Analise dos dados (Quick)
                Console.WriteLine("\t[LOG] Quick");
                benchmark.Start("QuickAnalisys@" + index);
                List<UserInfo> quick = quickSortAnalysis.Analysis(list);
                benchmark.End("QuickAnalisys@" + index);
                //==================================================
                // Analise dos dados (Language)
                Console.WriteLine("\t[LOG] Language");
                benchmark.Start("LanguageAnalisys@" + index);
                List<UserInfo> lang = languageSortAnalysis.Analysis(list);
                benchmark.End("LanguageAnalisys@" + index);
                //==================================================

                Console.WriteLine("[END] Arquivo: " + index);
            }

            benchmark.Export(output, TimeFormat.MILISSEGUNDOS);
        }

        static Config GetConfiguration(string fileName) {
            string jsonString = File.ReadAllText(fileName);
            Config config = JsonSerializer.Deserialize<Config>(jsonString)!;
            return config;
        }
    }
}
