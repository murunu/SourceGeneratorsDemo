
namespace WebApplication2;

[Register(ServiceLifetime.Singleton)]
public class Test2
{
    
}


[Register(ServiceLifetime.Singleton)]
public class Test3
{
    
}


[Register(ServiceLifetime.Singleton)]
public class Test4
{
    
}


[Register(ServiceLifetime.Singleton, typeof(ITest))]
// [Register(ServiceLifetime.Singleton)]
public class Test5
{
    
}