namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class UserInfoTest {

    [Fact]
    public void MustBeInstantiable() {
        UserInfo userinfo = new UserInfo("user", "password");
        Assert.True(userinfo != null, "1. Devera ser instanciavel corretamente");
    }
}