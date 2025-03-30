namespace ConsoleApp1.TransientDepenSingleton
{
    internal class Transient
    {
        private string _Key;

        public Transient()
        {
            _Key = Guid.NewGuid().ToString();
        }

        public string Output()
        {
            return _Key;
        }
    }

}
