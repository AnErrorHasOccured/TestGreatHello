using NUnit.Framework;

namespace TestGreatHello.Tests
{
    public class GreetHelloTests
    {
        private IGreetHello _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Greet();
        }

        [Test]
        public void Should_Send_Me_Hello_By_Name()
        {
            var actual = _sut.GreetHello("Gino"); 
            Assert.AreEqual("Hello, Gino.", actual);
            Assert.Pass("ho salutato");
        }

        [Test]
        public void Should_Send_Me_Hello_My_Friend()
        {
            var actual = _sut.GreetHello(null);
            Assert.AreEqual("Hello, my friend.", actual);
            Assert.Pass("ti ho salutato ma non ti conosco");
        }

        [Test]
        public void Should_Send_Me_Hello_By_Uppercase()
        {
            var actual = _sut.GreetHello("IGOR");
            Assert.AreEqual("HELLO IGOR!", actual);
            Assert.Pass("ti ho salutato urlando");
        }

        [Test]
        public void Should_Send_Me_Hello_To_Two_Names()
        {
            var actual = _sut.GreetHello("Oussama", "Nicola");
            Assert.AreEqual("Hello, Oussama and Nicola." , actual);
            Assert.Pass("vi ho salutato entrambi");
        }

        [Test]
        public void Should_Handle_More_Names()
        {
            var actual= _sut.GreetHello("Gino", "Pino", "Rino", "Vino");
            Assert.AreEqual("Hello, Gino, Pino, Rino and Vino.", actual);
        }

        [Test]
        public void Should_Handler_Upper_And_Down()
        {
            var actual = _sut.GreetHello("Gino", "Pino", "RINO", "Vino");
            Assert.AreEqual("Hello, Gino, Pino and Vino. AND HELLO RINO!",actual);
        }

        [Test]
        public void Should_Handle_Element_With_Comma()
        {
            var actual = _sut.GreetHello("Gino", "Pino", "Rino, Vino");
            Assert.AreEqual("Hello, Gino, Pino, Rino and Vino.",actual);
        }
        [Test]
        public void Should_Handle_Element_With_Sign()
        {
            var actual = _sut.GreetHello("Bob", "\"Charlie, Dianne\"");
            Assert.AreEqual("Hello, Bob and Charlie, Dianne.", actual);
        }

        [Test]

        public void Sandbox()
        {
            var actual = _sut.GreetHello("BOB", "\"CHARLIE, Dianne\"");
            Assert.Pass(actual);
        }
    }
}