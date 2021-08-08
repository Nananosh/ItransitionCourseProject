using Bogus;
using UiTestFramework.Data.Models;

namespace UiTestFramework.Data.Factories
{
    public static class UserDataFactory
    {
        public static UserModel GetRandomUser()
        {
            var userFaker = new Faker<UserModel>()
                .CustomInstantiator(f => new UserModel())
                .RuleFor(p => p.Email, f => $"{RandomStringFactory.GetRandomString(6)}.{f.Internet.Email()}")
                .RuleFor(p => p.Name, f => $"{f.Internet.UserName()}_{RandomStringFactory.GetRandomString(6)}")
                .RuleFor(p => p.Password, f => f.Internet.Password() + "z1Z*Test");
            return userFaker.Generate();
        }
    }
}