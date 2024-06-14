using Generators;

namespace WebApplication1;

[Register(ServiceLifetime.Scoped, typeof(ITest))]
public class Test : ITest
{
    
}

public interface ITest
{
    
}