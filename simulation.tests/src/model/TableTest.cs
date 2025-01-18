namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class TableTest {

    [Fact]
    public void MustBeInstantiable() {
        Table table = new ("../../../../data/test.csv");
        Assert.True(table is Table, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void GetUserInfoListMustBeValid() {
        Table table = new ("../../../../data/test.csv");
        List<UserInfo> userInfoList = table.UserInfoList;
        Assert.True(userInfoList.Count == 10, "2. 'userInfoList' devera retornar valor corretamente");
    }
}