namespace simulation.tests.src.provider;

using Xunit;
using simulation.src.model;
using simulation.src.model.exception;
using simulation.src.provider;

public class SummaryAnalysisTest {

    [Fact]
    public void MustBeInstantiable() {
        SummaryAnalysis mock = new ();
        Assert.True(mock is SummaryAnalysis, "1. Devera ser inscanciavel");
    }

    [Fact]
    public void AnalysisMustBeValid() {
        SummaryAnalysis mock = new ();
        List<UserInfo> input = new([
            new UserInfo("u1", "p1", 1),
            new UserInfo("u2", "p2", 2),
            new UserInfo("u3", "p3", 3)
        ]);
        double[] output = mock.Analysis(input);
        Assert.True(output.SequenceEqual([1, 3, 2]), "2. 'analysis()' devera ser valido caso possua parametros validos");
    }

    [Fact]
    public void AnalysisMustThrowErroIfEmpty() {
        SummaryAnalysis mock = new ();
        bool valid = false;
        try {
            double[] output = mock.Analysis([]);            
        } catch (InvalidParameterException) {
            valid = true;
        }
        Assert.True(valid, "3. 'analysis()' devera ser invalido caso o parametro seja vazio");
    }
}