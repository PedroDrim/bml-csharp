namespace simulation.tests.src.model.exception;

using Xunit;
using simulation.src.model.exception;

public class InvalidParameterExceptionTest {

    [Fact]
    public void MustBeInstanciable() {
        InvalidParameterException exception = new ("Error");
        Assert.True(exception is InvalidParameterException, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void MustBeTrowable() {
        bool valid;
        try {
            throw new InvalidParameterException("Error");
        } catch (InvalidParameterException) {
            valid = true;
        }
        Assert.True(valid, "2. Devera ser lancado como erro corretamente");
    }
}