using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMassage);

    public class TypeTests
    {   
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
 
            var result  = log("Hello");
            Assert.Equal(3, count);
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }


        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact] 
        public void ValuesTypesAlsoPassByValue(){

            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "John";
            var upper = MakeUpperCase(name);

            Assert.Equal("John", name);
            Assert.Equal("JOHN", upper);

        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }



        private void SetInt(ref int x){
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassedByRef()
        {
            // arrange 
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetNameRef(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameRef(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            //book.Name = name;
        }

        [Fact]
        public void CSharpIsPassedByValue()
        {
            // arrange 
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange 
            InMemoryBook book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
           book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferetObjects()
        {   
            // arrange 
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange 
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
