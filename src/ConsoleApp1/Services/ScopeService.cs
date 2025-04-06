namespace ConsoleApp1.Services
{
    internal class ScopeService
    {
        private string _service;

        public ScopeService()
        {
            _service = Guid.NewGuid().ToString();
        }

        public string Console()
        {
            //return _singletonService.Console();
            return _service;
        }
    }

}
