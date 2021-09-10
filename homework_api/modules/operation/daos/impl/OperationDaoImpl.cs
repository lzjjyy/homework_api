using homework_api.modules.login.models.DTO;
using mdland_utils_lib.Attributes;

namespace homework_api.modules.login.daos.impl
{
    [AutoRegistry]
    public class OperationDaoImpl : IOperationDao
    {
        public static TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));

        public TPercy Init(TLocation location)
        {
            MyCar = new TPercy(location);
            return MyCar;
        }

        public object Show()
        {
            return MyCar.Show();
        }

        TLocation IOperationDao.GetLocation()
        {
            return MyCar.Location;
        }

        public TPercy Run(string pCommands)
        {
            char[] chars = pCommands.ToCharArray();
            foreach (char c in chars)
            {
                MyCar.Move(c);
            }
            MyCar.CaluCoverage();
            return MyCar;
        }
    }
}