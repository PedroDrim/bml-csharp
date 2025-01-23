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
            ITableAnalysis<List<UserInfo>> mergeSortAnalysis = new MergeSortAnalysis();
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
                tableReader.Open();
                List<UserInfo> list = tableReader.Read();
                benchmark.End("Read@" + index);
                //==================================================
                // Analise dos dados (Summary)
                Console.WriteLine("\t[LOG] Summary");
                benchmark.Start("SummaryAnalysis@" + index);
                double[] summary = summaryAnalysis.Analysis(list);
                benchmark.End("SummaryAnalysis@" + index);
                //==================================================
                // Analise dos dados (Merge)
                Console.WriteLine("\t[LOG] Merge");
                benchmark.Start("MergeAnalysis@" + index);
                List<UserInfo> merge = mergeSortAnalysis.Analysis(list);
                benchmark.End("MergeAnalysis@" + index);
                //==================================================
                // Analise dos dados (Quick)
                Console.WriteLine("\t[LOG] Quick");
                benchmark.Start("QuickAnalysis@" + index);
                List<UserInfo> quick = quickSortAnalysis.Analysis(list);
                benchmark.End("QuickAnalysis@" + index);
                //==================================================
                // Analise dos dados (Language)
                Console.WriteLine("\t[LOG] Language");
                benchmark.Start("LanguageAnalysis@" + index);
                List<UserInfo> lang = languageSortAnalysis.Analysis(list);
                benchmark.End("LanguageAnalysis@" + index);
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
