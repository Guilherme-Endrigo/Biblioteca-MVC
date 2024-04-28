using Xunit;
using BibliotecaImpacta.Models;

namespace TestProject.ModelsTest
{
    public class ErrorViewModelTest
    {
        private ErrorViewModel _errorViewModel;

        public ErrorViewModelTest()
        {
            _errorViewModel = new ErrorViewModel();
        }

        [Fact]
        public void TestRequestIdProperty()
        {
            string testValue = "Teste";
            _errorViewModel.RequestId = testValue;
            Assert.Equal(testValue, _errorViewModel.RequestId);
        }

        [Fact]
        public void TestShowRequestIdProperty()
        {
            _errorViewModel.RequestId = "Teste";
            Assert.True(_errorViewModel.ShowRequestId);

            _errorViewModel.RequestId = null;
            Assert.False(_errorViewModel.ShowRequestId);
        }
    }
}

