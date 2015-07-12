using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MVCStudy_ViewModels;

namespace MVCStudy_Tests.ViewModels
{
    [TestFixture]
   public class Tests_Game
    {
        private Game mGame;
        [SetUp]
        public void Setup()
        {
            mGame = new Game();
            mGame.Cards = new CardSet();
            mGame.Cards.UniqueID = Guid.NewGuid();
            mGame.Cards.AddRange(Enumerable.Range(0, 50).Select(x => new Card{SetID =  mGame.Cards.UniqueID, UniqueID = Guid.NewGuid()}));
        }

        [Test]
        public void Percentage()
        {
            Assert.IsNull(mGame.Percentage);
        }

    }
}
