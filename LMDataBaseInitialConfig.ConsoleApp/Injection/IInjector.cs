namespace LMDataBaseInitialConfig.ConsoleApp.Injection
{
    public interface IInjector
    {
        T GetService<T>();

    }
}