using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.CoreUnitTest
{
    using SAF.Core;
    using NUnit.Framework;

    [TestFixture]
    class DesignByContractTest
    {
        [SetUp]
        public void setUp()
        {
        }

        [TearDown]
        public void tearDown()
        {
        }

        [Test]
        public void testThrowPreconditionError()
        {
            Assert.DoesNotThrow(() => DesignByContract.throwPreconditionError(true, "precondition error #1"));

            //ContractViolation ex = Assert.Throws<PreconditionViolation>(() => DesignByContract.throwPreconditionError(false, "precondition error #2"));
            ContractViolation ex = Assert.Catch<ContractViolation>(() => DesignByContract.throwPreconditionError(false, "precondition error #2"));
            //Assert.That(ex.Message, Is.EqualTo("message"));
        }

        [Test]
        public void testThrowPostconditionError()
        {
            Assert.DoesNotThrow(() => DesignByContract.throwPostconditionError(true, "postcondition error #1"));

            //ContractViolation ex = Assert.Throws<PostconditionViolation>(() => DesignByContract.throwPostconditionError(false, "postcondition error #2"));
            ContractViolation ex = Assert.Catch<ContractViolation>(() => DesignByContract.throwPostconditionError(false, "postcondition error #2"));
            //Assert.That(ex.Message, Is.EqualTo("message"));
        }

        [Test]
        public void testThrowInvariantError()
        {
            Assert.DoesNotThrow(() => DesignByContract.throwInvariantError(true, "invariant error #1"));

            //ContractViolation ex = Assert.Throws<InvariantViolation>(() => DesignByContract.throwInvariantError(false, "invariant error #2"));
            ContractViolation ex = Assert.Catch<ContractViolation>(() => DesignByContract.throwInvariantError(false, "invariant error #2"));
            //Assert.That(ex.Message, Is.EqualTo("message"));
        }

        [Test]
        public void testThrowRuntimeError()
        {
            ContractViolation ex = Assert.Throws<ContractViolation>(() => DesignByContract.throwRuntimeError("run-time error"));
            //Assert.That(ex.Message, Is.EqualTo("message"));
            Console.WriteLine(ex.Message);
        }
    }
}
