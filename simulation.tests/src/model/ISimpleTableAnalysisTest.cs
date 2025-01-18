namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class Mock : ISimpleTableAnalysis {
    public double Analysis(List<UserInfo> list) {
        return 0;
    }
}

public class ISimpleTableAnalysisTest {

    [Fact]
    public void AnalysisIntegration() {
        ISimpleTableAnalysis mock = new Mock();
        Assert.True(mock.Analysis([]) == 0, "1. Integracao do 'analysis()'");
    }
}
