using homework_api.modules.login.models.DTO;

namespace homework_api.modules.login.services
{
    public interface IOperationService
    {
        object Init(TLocation location);
        object Show();
        object GetLocation();
        object Run(string pCommands);
    }
}