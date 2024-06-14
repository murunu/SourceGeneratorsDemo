
namespace WebApplication2;

[Register(ServiceLifetime.Scoped, typeof(ITest))]
public class Test : ITest
{
    
}

interface ITest
{
    
}