namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class MockTableAnalysis : ITableAnalysis<double> {
    public double Analysis(List<UserInfo> list) {
        return 0;
    }
}

public class ITableAnalysisTest {

    [Fact]
    public void AnalysisIntegration() {
        ITableAnalysis<double> mock = new MockTableAnalysis();
        Assert.True(mock.Analysis([]) == 0, "1. Integracao do 'analysis()'");
    }
}
