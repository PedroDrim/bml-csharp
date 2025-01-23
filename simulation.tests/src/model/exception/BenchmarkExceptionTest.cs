namespace simulation.tests.src.model.exception;

using Xunit;
using simulation.src.model.exception;

public class BenchmarkExceptionTest {

    [Fact]
    public void MustBeInstanciable() {
        BenchmarkException exception = new ("Error");
        Assert.True(exception is BenchmarkException, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void MustBeTrowable() {
        bool valid;
        try {
            throw new BenchmarkException("Error");
        } catch (BenchmarkException) {
            valid = true;
        }
        Assert.True(valid, "2. Devera ser lancado como erro corretamente");
    }
}