using FluentAssertions;
using IdealWeightCalculator.Data;
using IdealWeightCalculator.Data.Model;
using IdealWeightCalculator.DataAccessLayers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class IntegrationTests
    {

        [TestMethod]
        public void AddUser_WithGoodUser_Save()
        {
            User user = new User()
            {
                Email = "abdo@yahoo.com",
                Name = "AbdoHosny",
                BithDate=new DateTime(1997,8,1)
            };
            DataAcessLayer dataAcess = new DataAcessLayer(new ApplicationDbContext());

            dataAcess.AddUser(user);
            User userFindTo=dataAcess.GetUserByName(user.Name);

            userFindTo.Should().BeEquivalentTo(user);

        }

    }
}
