using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCStudy_ViewModels;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
namespace MVCStudy_Tests.ViewModels
{
    [TestFixture]
   public class Tests_ViewModel_User
    {
        private ViewModel_User mUser;
        [SetUp]
        public void Setup()
        {
            mUser = new ViewModel_User();
            mUser.HighScoreGame =new ViewModel_Game();
            mUser.HighScoreGame.Cards = new ViewModel_CardSet();
            var sID = Guid.NewGuid();
            mUser.HighScoreGame.Cards.AddRange(Enumerable.Range(0, 50).Select(x => new ViewModel_Card{UniqueID = Guid.NewGuid()});
            mUser.Name = "Joe";
            mUser.Password = "$assaFr@s5";
        }

        [Test]
        public void NameAttribute_Max(){
            MaxLengthAttribute attr = (MaxLengthAttribute) mUser.GetType().GetProperty("Name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault();
            Assert.AreEqual(50, attr.Length);
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }

        [Test]
        public void NameAttribute_Min()
        {
            MinLengthAttribute attr = (MinLengthAttribute)mUser.GetType().GetProperty("Name", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetCustomAttributes(typeof(MinLengthAttribute), false).FirstOrDefault();
            Assert.AreEqual(3, attr.Length);
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }

        [Test]
        public void NameAttribute_Required()
        {
            RequiredAttribute attr = (RequiredAttribute)mUser.GetType().GetProperty("Name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }

        [Test]
        public void PasswordAttribute_Max()
        {
            MaxLengthAttribute attr = (MaxLengthAttribute)mUser.GetType().GetProperty("Password", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault();
            Assert.AreEqual(50, attr.Length);
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }

        [Test]
        public void PasswordAttribute_Min()
        {
            MinLengthAttribute attr = (MinLengthAttribute)mUser.GetType().GetProperty("Password", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetCustomAttributes(typeof(MinLengthAttribute), false).FirstOrDefault();
            Assert.AreEqual(6, attr.Length);
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }

        [Test] 
        public void PasswordAttribute_Password()
        {
            DataTypeAttribute attr = (DataTypeAttribute)mUser.GetType().GetProperty("Password", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetCustomAttributes(typeof(DataTypeAttribute), false).FirstOrDefault();
            Assert.AreEqual(DataType.Password, attr.DataType);
        }

        [Test]
        public void PasswordAttribute_Required()
        {
            RequiredAttribute attr = (RequiredAttribute)mUser.GetType().GetProperty("Password", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            Assert.IsNotNullOrEmpty(attr.ErrorMessage);
        }


    }
}
