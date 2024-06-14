namespace WebApplication2;

[AttributeUsage(AttributeTargets.Class)]
public class RegisterAttribute : Attribute
{
    public RegisterAttribute(ServiceLifetime lifetime)
    {
            
    }

    public RegisterAttribute(ServiceLifetime lifetime, Type serviceInterface)
    {

    }
}