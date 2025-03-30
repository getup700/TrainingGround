namespace ConsoleApp1.Services
{
    internal class ScopeService
    {
        private string _service;
        private readonly SingletonService _singletonService;

        public ScopeService(SingletonService singletonService)
        {
            _service = Guid.NewGuid().ToString();
            _singletonService = singletonService;
        }

        public string Console()
        {
            //return _singletonService.Console();
            return _service;
        }
    }

}
