using System;
using System.Threading.Tasks;
using Application.Books;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {
        private PublicBookService _public;
        private BaseContext _baseContext;
        
        [SetUp]
        public void Setup()
        {
             _baseContext = new BaseContext();
            _public = new PublicBookService(_baseContext);
        }

        [Test]
        public async Task Test1()
        {
             var list = await _public.GetAll();
             Assert.NotNull(list);
            //Assert.Equals(list.Count,2);
            //Assert.Equals(1,1);
            Assert.Pass();
        }
    }
}