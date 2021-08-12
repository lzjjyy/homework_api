using homework_api.modules.login.models.DTO;

namespace homework_api.modules.login.daos
{
    public interface IOperationDao
    {
        TPercy Init(TLocation location);
        object Show();
        TLocation GetLocation();
        TPercy Run(string pCommands);
    }
}