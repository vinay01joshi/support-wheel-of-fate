using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWOF.BusinessLogic;
using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOF.Test.Rules
{
    [TestClass]
    public  class ConsecutiveDayRuleTests
    {
        private ConsecutiveDayRule _rule;

        [TestInitialize]
        public void TestInitialize()
        {
            _rule = new ConsecutiveDayRule();
        }

        [TestMethod]
        public void IsValid_ReturnsTrue_WhenLessThanTwoShiftsDefined()
        {
            //Arrange
            var shiftId = 0;
            var candidateId = 1;
            var shifts = new List<Shift>(0);

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ReturnsTrue_WhenNoMatchingShiftsOnPreviousDay()
        {
            //Arrange
            var shiftId = 4;
            var candidateId = 2;
            var shifts = new List<Shift>
            {
                //Monday
                new Shift(0) { Engineer = new EngineerModel { Id = 1}},
                new Shift(1) { Engineer = new EngineerModel { Id = 2}},
                //Tuesday                                     
                new Shift(2) { Engineer = new EngineerModel { Id = 3}},
                new Shift(3) { Engineer = new EngineerModel { Id = 4}},
            };

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ReturnsFalse_WhenCandidateFoundOnPreviousAfternoon()
        {
            //Arrange
            var shiftId = 4;
            var candidateId = 4;
            var shifts = new List<Shift>
            {
                //Monday
                new Shift(0) { Engineer = new EngineerModel { Id = 1}},
                new Shift(1) { Engineer = new EngineerModel { Id = 2}},
                //Tuesday                                     
                new Shift(2) { Engineer = new EngineerModel { Id = 3}},
                new Shift(3) { Engineer = new EngineerModel { Id = 4}},
            };

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ReturnsFalse_WhenCandidateFoundOnPreviousMorning()
        {
            //Arrange
            var shiftId = 4;
            var candidateId = 3;
            var shifts = new List<Shift>
            {
                //Monday
                new Shift(0) { Engineer = new EngineerModel { Id= 1}},
                new Shift(1) { Engineer = new EngineerModel { Id= 2}},
                //Tuesday                                     
                new Shift(2) { Engineer = new EngineerModel { Id= 3}},
                new Shift(3) { Engineer = new EngineerModel { Id= 4}},
            };

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void IsValid_ReturnsTrue_WhenProposedAfternoonSameAsMorning()
        {
            //Arrange
            var shiftId = 5;
            var candidateId = 5;
            var shifts = new List<Shift>
            {
                //Monday
                new Shift(0) { Engineer = new EngineerModel { Id = 1 }},
                new Shift(1) { Engineer = new EngineerModel { Id = 2 }},
                //Tuesday                                     
                new Shift(2) { Engineer = new EngineerModel { Id = 3 }},
                new Shift(3) { Engineer = new EngineerModel { Id = 4 }},
                //Wednesday                                   
                new Shift(4) { Engineer = new EngineerModel { Id = 5 }},
            };

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ReturnsTrue_WhenShiftDoesNotHaveEnginnerAssigned()
        {
            //Arrange
            var shiftId = 4;
            var candidateId = 3;
            var shifts = new List<Shift>
            {
                //Monday
                new Shift(0) { Engineer = new EngineerModel { Id = 1 }},
                new Shift(1) { Engineer = new EngineerModel { Id = 2 }},
                //Tuesday - no engineer allocated to slot
                new Shift(2),
                new Shift(3),
            };

            //Act
            var result = _rule.IsValid(shiftId, candidateId, shifts);

            //Assert
            Assert.IsTrue(result);
        }

    }
}
