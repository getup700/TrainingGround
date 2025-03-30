namespace ConsoleApp1.Services
{
    internal class TransientService
    {
        public TransientService()
        {

        }

        public string Console()
        {
            return Guid.NewGuid().ToString();
        }
    }

}
