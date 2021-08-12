using homework_api.modules.common.BaseController;
using homework_api.modules.login.models.DTO;
using homework_api.modules.login.services;
using Microsoft.AspNetCore.Mvc;

namespace homework_api.modules.login.controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class OperationController: SessionApiController
    {
        private readonly IOperationService _loginService;

        public OperationController(IOperationService loginService)
        {
            _loginService = loginService;
        }


        /// <summary>
        /// 着陆
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object Init(TLocation Location)
        {
            return _loginService.Init(Location);
        }

        /// <summary>
        /// 显示当前状态与搜索记录，并绘图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Show()
        {
            return _loginService.Show();
        }


        /// <summary>
        /// 取当前位置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetLocation()
        {
            return _loginService.GetLocation();
        }

        /// <summary>
        /// 执行批量指令
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Run(string pCommands)
        {
            return _loginService.Run(pCommands);
        }

    }
}