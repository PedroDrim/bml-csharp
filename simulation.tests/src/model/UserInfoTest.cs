namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class UserInfoTest {

    [Fact]
    public void MustBeInstantiable() {
        UserInfo userinfo = new UserInfo("user", "password");
        Assert.True(userinfo is UserInfo, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void SetUsernameMustBeValid() {
        bool valid = true;
        try {
            UserInfo userinfo = new UserInfo("user", "password");
            userinfo.User = "newUser";
        } catch (Exception _) {
            valid = false;
        }

        Assert.True(valid, "2. 'user' devera ser alteravel");
    }

   [Fact]
    public void SetPasswordMustBeValid() {
        bool valid = true;
        try {
            UserInfo userinfo = new UserInfo("user", "password");
            userinfo.Password = "newPassword";
        } catch (Exception _) {
            valid = false;
        }

        Assert.True(valid, "3. 'password' devera ser alteravel");
    }

    [Fact]
    public void GetUsernameMustBeValid() {
        UserInfo userinfo = new UserInfo("user", "password");
        Assert.True(userinfo.User == "user", "4. 'user' devera ser obtido corretamente");
    }

    [Fact]
    public void GetPasswordMustBeValid() {
        UserInfo userinfo = new UserInfo("user", "password");
        Assert.True(userinfo.Password == "HASHdrowssap000", "5. 'password' devera ser obtido corretamente");
    }
}