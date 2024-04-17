using FA.JustBlog.Core;
using FA.JustBlog.Core.Context;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace FA.JustBlog.Test.Categories
{
    public class Tests
    {
        // Create variables to reusable
        private Mock<DbSet<Category>> _mockSet {  get; set; }
        private Mock<IJustBlogContext> _mockContext {  get; set; }

        [SetUp]
        public void Setup()
        {
            //Setup variables
            _mockSet = new Mock<DbSet<Category>>();
            _mockContext = new Mock<IJustBlogContext>();
        }

        //Cover case category not null
        [Test]
        public void CreateCategory_not_null()
        {
            _mockContext.Setup(m => m.Categories).Returns(_mockSet.Object);

            var service = new CategoryRepository(_mockContext.Object);
            service.AddCategory(new Category() { Id = 1, Name = "Categories 1", Description = "Description 1" });

            _mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once(), "Add category fail");
            _mockContext.Verify(m => m.SaveChanges(), Times.Once(), "SaveChanges Fail");
            Assert.Pass();
        }

        //Cover case category null
        [Test]
        public void CreateCategory_null()
        {
            _mockContext.Setup(m => m.Categories).Returns(_mockSet.Object);

            var service = new CategoryRepository(_mockContext.Object);
            var result = service.AddCategory(null);

            _mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Never(), "Add null item case: Add Item fail");
            _mockContext.Verify(m => m.SaveChanges(), Times.Never(), "Add null item case: SaveChanges Fail");
            Assert.Pass();
        }

    }
}