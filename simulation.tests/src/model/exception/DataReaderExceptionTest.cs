namespace simulation.tests.src.model.exception;

using Xunit;
using simulation.src.model.exception;

public class DataReaderExceptionTest {

    [Fact]
    public void MustBeInstanciable() {
        DataReaderException exception = new ("Error");
        Assert.True(exception is DataReaderException, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void MustBeTrowable() {
        bool valid;
        try {
            throw new DataReaderException("Error");
        } catch (DataReaderException) {
            valid = true;
        }
        Assert.True(valid, "2. Devera ser lancado como erro corretamente");
    }
}