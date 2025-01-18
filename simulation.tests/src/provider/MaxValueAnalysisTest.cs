namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;
using simulation.src.provider;

public class MaxValueAnalysisTest {

    [Fact]
    public void MustBeInstantiable() {
        MaxValueAnalysis mock = new ();
        Assert.True(mock is MaxValueAnalysis, "1. Devera ser inscanciavel");
    }

    [Fact]
    public void AnalysisMustBeValid() {
        MaxValueAnalysis mock = new ();
        List<UserInfo> input = new([
            new UserInfo("u1", "p1", 1),
            new UserInfo("u2", "p2", 2),
            new UserInfo("u3", "p3", 3)
        ]);
        double output = mock.Analysis(input);
        Assert.True(output == 3, "2. 'analysis()' devera ser valido caso possua parametros validos");
    }
}