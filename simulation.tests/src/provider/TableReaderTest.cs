namespace simulation.tests.src.provider;

using Xunit;
using simulation.src.model;
using simulation.src.model.exception;
using simulation.src.provider;

public class TableReaderTest {

    [Fact]
    public void MustBeInstantiable() {
        TableReader mock = new ("../../../../data/test.csv");
        Assert.True(mock is TableReader, "1. Devera ser instanciavel caso possua valor valido");
    }

    [Fact]
    public void OpenMustBeValidIfValidParameters() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = true;
        try {
            mock.Open();
        } catch (DataReaderException) {
            valid = false;
        }
        Assert.True(valid, "2. 'open()' devera retornar valor valido caso arquivo seja valido");
    }

    [Fact]
    public void OpenMustBeInvalidIfInvalidParameters() {
        TableReader mock = new ("fake.csv");
        bool valid = false;
        try {
            mock.Open();
        } catch (DataReaderException) {
            valid = true;
        }
        Assert.True(valid, "3. 'open()' devera retornar excessao caso arquivo seja invalido");
    }

    [Fact]
    public void ReadMustBeValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = true;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read();            
        } catch (InvalidParameterException) {
            valid = false;
        }
        
        Assert.True(valid, "4. 'read()' devera retornar valor valido");
    }

    [Fact]
    public void ReadOverwriteMustBeValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = true;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read(1,2);
        } catch (InvalidParameterException) {
            valid = false;
        }
        
        Assert.True(valid, "5. Sobrescrita 'read()' devera retornar valor valido caso possua valores validos");
    }

    [Fact]
    public void ReadOverwriteNegativeStartValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = false;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read(-1,2);
        } catch (InvalidParameterException) {
            valid = true;
        }
        
        Assert.True(valid, "6. Sobrescrita 'read()' devera ser invalido caso 'start' seja negativo");
    }

    [Fact]
    public void ReadOverwriteNegativeEndValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = false;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read(1,-2);
        } catch (InvalidParameterException) {
            valid = true;
        }
        
        Assert.True(valid, "7. Sobrescrita 'read()' devera ser invalido caso 'end' seja negativo");
    }

    [Fact]
    public void ReadOverwriteEndLowerThanStartValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = false;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read(2,1);
        } catch (InvalidParameterException) {
            valid = true;
        }
        
        Assert.True(valid, "8. Sobrescrita 'read()' devera ser invalido caso 'start' seja menor que 'end'");
    }

    [Fact]
    public void ReadOverwriteEndEqualThanStartValid() {
        TableReader mock = new ("../../../../data/test.csv");
        bool valid = false;
        try {
            mock.Open();
            List<UserInfo> output = mock.Read(2,2);
        } catch (InvalidParameterException) {
            valid = true;
        }
        
        Assert.True(valid, "9. Sobrescrita 'read()' devera ser invalido caso 'start' seja igual que 'end'");
    }
}