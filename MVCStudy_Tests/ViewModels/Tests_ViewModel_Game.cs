using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MVCStudy_ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy_Tests.ViewModels
{
    [TestFixture]
   public class Tests_ViewModel_Game
    {
        private ViewModel_Game mGame;
        [SetUp]
        public void Setup()
        {
            mGame = new ViewModel_Game();
            mGame.Cards = new ViewModel_CardSet();
            mGame.Cards.AddRange(Enumerable.Range(0, 50).Select(x => new ViewModel_Card{UniqueID = Guid.NewGuid()}));
        }

        [Test]
        public void Percentage_NoMatches()
        {
            Assert.IsNull(mGame.Percentage);
        }

        [Test]
        public void Percentage_Matches()
        {
            //mGame.Cards.Take(5).ToList().ForEach(x => x.Matched = true);
            //mGame.Flips = 10;
            //Assert.AreEqual(50, mGame.Percentage);

            //mGame.Cards.ForEach(x => x.Matched = false);

            //mGame.Cards.Take(3).ToList().ForEach(x => x.Matched = true);
            //mGame.Flips = 100;
            //Assert.AreEqual(3, mGame.Percentage);

            //mGame.Cards.ForEach(x => x.Matched = false);

            //mGame.Cards.Take(13).ToList().ForEach(x => x.Matched = true);
            //mGame.Flips = 52;
            //Assert.AreEqual(25, mGame.Percentage);
        }


        [Test]
        public void Score_NoMatches()
        {
            Assert.AreEqual(1, mGame.Score);
        }


        //[Test]
        //public void Score_Matches_ZeroSeconds()
        //{
        //    mGame.Cards.Take(5).ToList().ForEach(x => x.Matched = true);
        //    mGame.Flips = 10;
        //    Assert.AreEqual(2500, mGame.Score);
        //}

        //[Test]
        //public void Score_Matches_WithTime()
        //{
        //    mGame.Cards.Take(5).ToList().ForEach(x => x.Matched = true);
        //    mGame.Flips = 10;
        //    mGame.WinTimeSeconds = 60 * 5;
        //    Assert.AreEqual(2200, mGame.Score);
        //}

        //[Test]
        //public void Score_Matches__WithTime_NoNegativeGame()
        //{
        //    mGame.Cards.Take(5).ToList().ForEach(x => x.Matched = true);
        //    mGame.Flips = 10;
        //    mGame.WinTimeSeconds = 60 * 500;
        //    Assert.AreEqual(1, mGame.Score);
        //}

        [Test]
        public void WinTime_Format()
        {
            mGame.WinTimeSeconds = 62 * 5;
            DisplayFormatAttribute prop = (DisplayFormatAttribute)mGame.GetType().GetProperty("WinTime").GetCustomAttributes(typeof(DisplayFormatAttribute), false).FirstOrDefault();
            Assert.AreEqual("05:10", String.Format(prop.DataFormatString, mGame.WinTime));
        }

        //[Test]
        //public void Precentage_Format()
        //{
        //    mGame.Cards.Take(5).ToList().ForEach(x => x.Matched = true);
        //    mGame.Flips = 10;
        //    DisplayFormatAttribute prop = (DisplayFormatAttribute)mGame.GetType().GetProperty("Percentage").GetCustomAttributes(typeof(DisplayFormatAttribute), false).FirstOrDefault();
        //    Assert.AreEqual("50%", String.Format(prop.DataFormatString, mGame.Percentage));
        //}
     

    }
}
