using homework_api.modules.login.daos;
using homework_api.modules.login.models.DTO;
using mdland_dotnet_template_lib.Common.Aop.Attribute;
using mdland_dotnet_template_lib.Common.Log;
using mdland_log_lib.Log;
using mdland_utils_lib.Attributes;

namespace homework_api.modules.login.services.impl
{
    [AutoRegistry]
    [CommonLog]
    public class OperationServiceImpl: IOperationService
    {
        private readonly IOperationDao _profileDao;
        private readonly HttpLogger _httpLogger;

        public OperationServiceImpl(IOperationDao profileDao)
        {
            _profileDao = profileDao;
            _httpLogger = LogFactory.GetHttpLog();
        }

        public object Init(TLocation location)
        {
            return _profileDao.Init(location);
        }

        public object Run(string pCommands)
        {
            return _profileDao.Run(pCommands);
        }

        public object Show()
        {
            return _profileDao.Show();
        }

        object IOperationService.GetLocation()
        {
            return _profileDao.GetLocation();
        }
    }
}