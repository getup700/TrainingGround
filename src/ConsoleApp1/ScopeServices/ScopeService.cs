namespace ConsoleApp1.ScopeServices;

internal class ScopeService
{
    private Guid _guid;

    public ScopeService()
    {
        _guid = Guid.NewGuid();
    }

    public Guid GetGuid()
    {
        return _guid;
    }
}


internal class SingletonService
{

    private Guid _guid;

    public SingletonService()
    {
        _guid = Guid.NewGuid();
    }

    public Guid GetGuid() => _guid;
}

internal class S1Service
{
    private ScopeService _scopeService;
    private SingletonService _singletonService;

    public S1Service(ScopeService scopeService, SingletonService singletonService)
    {
        _scopeService = scopeService;
        _singletonService = singletonService;
    }

    public string GetGuid1()
    {
        return _scopeService.GetGuid().ToString() + " " + _singletonService.GetGuid().ToString();
    }

    public string GetGuid2()
    {
        return _scopeService.GetGuid().ToString() + " " + _singletonService.GetGuid().ToString();
    }
}

internal class S2Service
{
    private ScopeService _scopeService;
    private SingletonService _singletonService;

    public S2Service(ScopeService scopeService, SingletonService singletonService)
    {
        _scopeService = scopeService;
        _singletonService = singletonService;
    }

    public string GetGuid1()
    {
        return _scopeService.GetGuid().ToString()+" "+_singletonService.GetGuid().ToString();
    }

    public string GetGuid2()
    {
        return _scopeService.GetGuid().ToString() + " " + _singletonService.GetGuid().ToString();
    }
}

