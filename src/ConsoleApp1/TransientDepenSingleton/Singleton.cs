namespace ConsoleApp1.TransientDepenSingleton
{
    internal class Singleton
    {
        private Transient _transient;
        private string _key;

        public Singleton(Transient transient)
        {
            _key = Guid.NewGuid().ToString();
            _transient = transient;
        }

        public string Output()
        {
            return _transient.Output();
        }

        public string Output2()
        {
            return _transient.Output();
        }
    }

}
