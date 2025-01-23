namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class TimeFormatTest {

    [Fact]
    public void SEGUNDOSMustBeValid() {
        TimeFormat? value = TimeFormat.SEGUNDOS;
        Assert.True(value is TimeFormat, "1. 'TimeFormat.SEGUNDOS' devera ser valido");
    }

    [Fact]
    public void MILLISEGUNDOSMustBeValid() {
        TimeFormat? value = TimeFormat.MILISSEGUNDOS;
        Assert.True(value is TimeFormat, "2. 'TimeFormat.MILISEGUNDOS' devera ser valido");
    }

    [Fact]
    public void NANOSEGUNDOSMustBeValid() {
        TimeFormat? value = TimeFormat.NANOSSEGUNDOS;
        Assert.True(value is TimeFormat, "3. 'TimeFormat.NANOSSEGUNDOS' devera ser valido");
    }
}