namespace ConsoleApp1.Services
{
    internal class SingletonService
    {
        private readonly TransientService _transientService;

        public SingletonService(TransientService transientService)
        {
            _transientService = transientService;
        }

        public string Console()
        {
            return _transientService.Console();
        }
    }

}
