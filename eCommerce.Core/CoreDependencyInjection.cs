
/// <summary>
/// Provides extension methods for adding infrastructure services to the dependency injection container.
/// </summary>
public static class CoreDependencyInjection
{
    /// <summary>
    /// Adds infrastructure services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the added services.</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
