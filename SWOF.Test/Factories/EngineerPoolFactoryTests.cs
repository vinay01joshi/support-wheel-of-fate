using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SWOF.BusinessLogic;
using SWOF.Core.Contract;
using SWOF.Core.Resources;
using SWOF.Persistence;
using System.Collections.Generic;

namespace SWOF.Factories.Test
{
    [TestClass]
    public class EngineerPoolFactoryTests
    {
        private Mock<IEngineerRepository> _mockEngineerRepository;
        private Mock<IRandomAdapter> _mockRandomAdapter;
        private EngineerPoolFactory _factory;


        [TestInitialize]
        public void TestInitialize()
        {
            _mockEngineerRepository = new Mock<IEngineerRepository>();
            _mockRandomAdapter = new Mock<IRandomAdapter>();

            _factory = new EngineerPoolFactory(_mockEngineerRepository.Object,
                _mockRandomAdapter.Object);

            _mockEngineerRepository.Setup(m => m.ReadAll()).Returns(new List<EngineerModel>
            {
                new EngineerModel { Id = 1, Name = "Jon"},
                new EngineerModel { Id = 2, Name = "Test"}
            });
        }

        [TestMethod]
        public void Create_ReturnsPool_WhenOneShiftPerEngineerPerPeriod()
        {
            //Arrange
            var shiftsPerEngineerPerPeriod = 1;

            //Act
            var result = _factory.Create(shiftsPerEngineerPerPeriod);

            //Assert
            Assert.AreEqual(2, result.Available);
        }

        [TestMethod]
        public void Populate_ReturnsList_WhenTwoShiftsPerEngineerPerPeriod()
        {
            //Arrange
            var shiftsPerEngineerPerPeriod = 2;

            //Act
            var result = _factory.Create(shiftsPerEngineerPerPeriod);

            //Assert
            Assert.AreEqual(4, result.Available);
        }

        [TestMethod]
        public void Populate_ReturnsEmptyList_WhenZeroShiftsPerEngineerPerPeriod()
        {
            //Arrange
            var shiftsPerEngineerPerPeriod = 0;

            //Act
            var result = _factory.Create(shiftsPerEngineerPerPeriod);

            //Assert
            Assert.AreEqual(0, result.Available);
        }
    }
}
