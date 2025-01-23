namespace simulation.tests.src.provider;

using Xunit;
using simulation.src.model;
using simulation.src.model.exception;
using simulation.src.provider;

public class LanguageSortAnalysisTest {

    [Fact]
    public void MustBeInstantiable() {
        LanguageSortAnalysis mock = new ();
        Assert.True(mock is LanguageSortAnalysis, "1. Devera ser inscanciavel");
    }

    [Fact]
    public void AnalysisMustBeValid() {
        LanguageSortAnalysis mock = new ();
        List<UserInfo> input = new([
            new UserInfo("u2", "p2", 2),
            new UserInfo("u1", "p1", 1),
            new UserInfo("u3", "p3", 3)
        ]);

        IEnumerable<double> output = mock.Analysis(input).Select(it => it.Credit);
        Assert.True(output.SequenceEqual([3,2,1]), "2. 'analysis()' devera ser valido caso possua parametros validos");
    }

    [Fact]
    public void AnalysisMustThrowErroIfEmpty() {
        LanguageSortAnalysis mock = new ();
        bool valid = false;
        try {
            List<UserInfo> output = mock.Analysis([]);            
        } catch (InvalidParameterException) {
            valid = true;
        }
        
        Assert.True(valid, "3. 'analysis()' devera ser invalido caso o parametro seja vazio");
    }
}