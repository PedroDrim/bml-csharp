namespace simulation.tests.src.model;

using Xunit;
using simulation.src.model;

public class UserInfoTest {

    [Fact]
    public void MustBeInstantiable() {
        UserInfo userinfo = new ("user", "password", 0);
        Assert.True(userinfo is UserInfo, "1. Devera ser instanciavel corretamente");
    }

    [Fact]
    public void SetUsernameMustBeValid() {
        bool valid = true;
        try {
            UserInfo userinfo = new ("user", "password", 0);
            userinfo.User = "newUser";
        } catch (Exception) {
            valid = false;
        }

        Assert.True(valid, "2. 'user' devera ser alteravel");
    }

   [Fact]
    public void SetPasswordMustBeValid() {
        bool valid = true;
        try {
            UserInfo userinfo = new ("user", "password", 0);
            userinfo.Password = "newPassword";
        } catch (Exception) {
            valid = false;
        }

        Assert.True(valid, "3. 'password' devera ser alteravel");
    }

   [Fact]
    public void SetCreditMustBeValid() {
        bool valid = true;
        try {
            UserInfo userinfo = new ("user", "password", 0);
            userinfo.Credit = 1;
        } catch (Exception) {
            valid = false;
        }

        Assert.True(valid, "4. 'credit' devera ser alteravel");
    }

    [Fact]
    public void GetUsernameMustBeValid() {
        UserInfo userinfo = new ("user", "password", 0);
        Assert.True(userinfo.User == "user", "5. 'user' devera ser obtido corretamente");
    }

    [Fact]
    public void GetPasswordMustBeValid() {
        UserInfo userinfo = new ("user", "password", 0);
        Assert.True(userinfo.Password == "HASHdrowssap000", "6. 'password' devera ser obtido corretamente");
    }

    [Fact]
    public void GetCreditMustBeValid() {
        UserInfo userinfo = new ("user", "password", 0);
        Assert.True(userinfo.Credit == 0, "7. 'credit' devera ser obtido corretamente");
    }
}