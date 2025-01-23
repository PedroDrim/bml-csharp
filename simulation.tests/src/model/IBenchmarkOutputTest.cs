namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;
using System.Collections.Generic;

public class MockBenchmarkOutput : IBenchmarkOutput {
    public void Start(string tag) {
        return;
    }

    public void End(string tag) {
        return;
    }

    public void Export(string fileName, TimeFormat format) {
        return;
    }


    public double Result(string tag, TimeFormat format) {
        return 0;
    }


    public Dictionary<string, double> Result(TimeFormat format) {
        return [];
    }

}

public class IBenchmarkOutputTest {

    [Fact]
    public void StartIntegration() {
        IBenchmarkOutput mock = new MockBenchmarkOutput();
        bool valid = true;
        try {
            mock.Start("");
        } catch (Exception) {
            valid = false;
        }
        Assert.True(valid, "1. Integracao do 'Start()'");
    }

    [Fact]
    public void EndIntegration() {
        IBenchmarkOutput mock = new MockBenchmarkOutput();
        bool valid = true;
        try {
            mock.End("");
        } catch (Exception) {
            valid = false;
        }
        Assert.True(valid, "2. Integracao do 'End()'");
    }

    [Fact]
    public void ExportIntegration() {
        IBenchmarkOutput mock = new MockBenchmarkOutput();
        bool valid = true;
        try {
            mock.Export("", TimeFormat.MILISSEGUNDOS);
        } catch (Exception) {
            valid = false;
        }
        Assert.True(valid, "3. Integracao do 'Export()'");
    }

    [Fact]
    public void ResultIntegration() {
        IBenchmarkOutput mock = new MockBenchmarkOutput();
        double value = mock.Result("", TimeFormat.MILISSEGUNDOS);
        Assert.True(value == 0, "4. Integracao do 'Result()'");
    }

    [Fact]
    public void ResultOverwriteIntegration() {
        IBenchmarkOutput mock = new MockBenchmarkOutput();
        Dictionary<string, double> value = mock.Result(TimeFormat.MILISSEGUNDOS);
        Assert.True(value.Count == 0, "5. Integracao do 'Result()'");
    }
}
