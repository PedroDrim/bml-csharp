namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;
using System.Collections.Generic;

public class MockDataReader : IDataReader {

    public void Open() {
        return;
    }

    public List<UserInfo> Read() {
        return [];
    }

    public List<UserInfo> Read(int startIndex, int endIndex) {
        return [];
    }
}

public class IDataReaderTest {

    [Fact]
    public void OpenIntegration() {
        IDataReader mock = new MockDataReader();
        bool valid = true;
        try {
            mock.Open();
        } catch (Exception) {
            valid = false;
        }
        Assert.True(valid, "0. Integracao do 'Open()'");
    }

    [Fact]
    public void ReadIntegration() {
        IDataReader mock = new MockDataReader();
        Assert.True(mock.Read().Count == 0, "1. Integracao do 'Read()'");
    }

    [Fact]
    public void ReadOverwriteIntegration() {
        IDataReader mock = new MockDataReader();
        Assert.True(mock.Read(1,1).Count == 0, "2. Integracao da sobreposicao do 'Read()'");
    }
}
