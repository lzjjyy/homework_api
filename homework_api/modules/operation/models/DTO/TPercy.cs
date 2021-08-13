using System;
using System.Collections.Generic;
using System.Linq;
namespace homework_api.modules.login.models.DTO
{
    /// <summary>
    /// TPercy
    /// </summary>
    public class TPercy
    {
        public List<TMoveInfo> Pathway { set; get; }
        public TLocation Location { set; get; }
        public TPercy(TLocation p)
        {
            Location = p;
            Pathway = new List<TMoveInfo> { new TMoveInfo()
            {
                Command='S',
                Location = p,
                Message="Landing completed",
                Expand=new List<TLocation>(),
            } };
        }
        /// <summary>
        /// 单步移动
        /// </summary>
        /// <param name="pCommand"></param>
        /// <returns></returns>
        public TLocation Move(char pCommand)
        {
            string pMessage;
            List<TLocation> pExpand;

            TLocation newLocation = new TLocation(Location.Face, Location.X, Location.Y);
            pExpand = new List<TLocation>();
            pMessage = newLocation.Move(pCommand);
            if (pCommand == 'H') //使用无人机
            {
                try
                {
                    /*
                     XOO
                     OOO
                     OOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) - 1, Location.Y - 1);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     OXO
                     OOO
                     OOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X), Location.Y - 1);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     OOX
                     OOO
                     OOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) + 1, Location.Y - 1);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     O00
                     XOO
                     OOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) - 1, Location.Y);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     OOO
                     OOX
                     OOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) + 1, Location.Y);
                    pExpand.Add(aLocation);
                }
                catch { }

                try
                {
                    /*
                     OOO
                     OOO
                     XOO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) - 1, Location.Y + 1);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     OOO
                     OOO
                     OXO
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X), Location.Y + 1);
                    pExpand.Add(aLocation);
                }
                catch { }
                try
                {
                    /*
                     OOO
                     OOO
                     OOX
                     */
                    TLocation aLocation = new TLocation(Location.Face, TLocation.IntX(Location.X) + 1, Location.Y + 1);
                    pExpand.Add(aLocation);
                }
                catch { }
            }
            Pathway.Add(new TMoveInfo()
            {
                Command = pCommand,
                Location = newLocation,
                Message = pMessage,
                Expand = pExpand,
            });
            Location = newLocation;
            return newLocation;
        }

        //↑，↓，←，→
        private char getDirection(char p)
        {
            if (p == 'E')
                return '→';
            else if (p == 'S')
                return '↓';
            else if (p == 'W')
                return '←';
            else if (p == 'N')
                return '↑';
            else return p;
        }

        private string updateStr(string pStr,int pIndex,char pChar)
        {
            char[] chars= pStr.ToCharArray();
            chars[pIndex] = pChar;
            return new string(chars);
        }
        /// <summary>
        /// 以图显示
        /// </summary>
        /// <returns></returns>
        public object Show()
        {
            string[] picture = new string[26];
            picture[0] = "  ABCDEFGHIJKLMNOPQRSTUVWXY";
            for (int i = 1; i <= 25; i++)
            {
                //picture[i] = string.Format("{0:00}", i)+"OOOOOOOOOOOOOOOOOOOOOOOOO";
                picture[i] = string.Format("{0:00}", i) + "                         ";
                //picture[i] = string.Format("{0:00}", i) +   "_________________________";
            }
            foreach(var v in Pathway)
            {
               
                picture[v.Location.Y] = updateStr(picture[v.Location.Y], TLocation.IntX(v.Location.X) + 1, getDirection(v.Location.Face));
                foreach(var vv in v.Expand)
                {
                    picture[vv.Y] = updateStr(picture[vv.Y], TLocation.IntX(vv.X) + 1, 'X');
                }
            }
            return new
            {
                Location,
                Pathway,
                Picture = picture
            };
        }
    }

    /// <summary>
    /// 移动指令执行（后）情况记录
    /// </summary>
    public class TMoveInfo
    {
        /// <summary>
        /// 移动指令
        /// </summary>
        public char Command { set; get; }
        /// <summary>
        /// 执行指令后位置情况
        /// </summary>
        public TLocation Location { set; get; }
        /// <summary>
        /// 执行指令后返回信息（invalid:信息无效;）
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// 无人机搜索区域
        /// </summary>
        public List<TLocation> Expand { set; get; }
    }

    /// <summary>
    /// 位置对象
    /// </summary>
    public class TLocation
    {
        //enum TFace { East, South, West, North };
        private const int maxX = 25;
        private const int maxY = 25;
        private static List<char> _xList = new List<char> { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private int _X;
        private int _Y;
        /// <summary>
        /// E(East),S(South),W(West),N(North)
        /// </summary>
        public char Face { set; get; }
        /// <summary>
        /// X坐标
        /// </summary>
        public char X
        {
            get { return _xList[_X]; }
            set { _X = _xList.IndexOf(value); }
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y
        {
            get { return _Y; }
            set { _Y = value; }
        }
        /// <summary>
        /// X 用char ,建坐标类构造函数
        /// </summary>
        /// <param name="pFace"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public TLocation(char pFace, char pX, int pY)
        {
            X = pX;
            if (_X < 1 || _X > maxX)
            {
                throw new Exception(string.Format("X=[{0}]  invalid", pX));
            }
            Y = pY;
            if (_Y < 1 || _Y > maxY)
            {
                throw new Exception(string.Format("Y=[{0}]  invalid", pY));
            }
            Face = pFace;
            if (Face != 'E' && Face != 'S' && Face != 'W' && Face != 'N')
            {
                throw new Exception(string.Format("Face=[{0}]  invalid", pFace));
            }
        }

        /// <summary>
        /// X用int ,建坐标类构造函数
        /// </summary>
        /// <param name="pFace"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public TLocation(char pFace, int pX, int pY)
        {
            _X = pX;
            if (_X < 1 || _X > maxX)
            {
                throw new Exception(string.Format("X=[{0}]  invalid", pX));
            }
            _Y = pY;
            if (_Y < 1 || _Y > maxY)
            {
                throw new Exception(string.Format("Y=[{0}]  invalid", pY));
            }
            Face = pFace;
            if (Face != 'E' && Face != 'S' && Face != 'W' && Face != 'N')
            {
                throw new Exception(string.Format("Face=[{0}]  invalid", pFace));
            }
        }

        /// <summary>
        /// X坐标，'A'->1
        /// </summary>
        /// <param name="pX"></param>
        /// <returns></returns>
        public static int IntX(char pX)
        {
            int x = _xList.IndexOf(pX);
            return x;
        }

        /// <summary>
        /// 坐标移动
        /// </summary>
        /// <param name="pCommand"></param>
        /// <returns></returns>
        public string Move(char pCommand)
        {
            string msg = "invalid";
            int oldX = _X;
            int oldY = _Y;

            if (pCommand == 'F' && Face == 'E' || pCommand == 'B' && Face == 'W')
            {
                _X++;
                if (_X > maxX)
                {
                    _X = oldX;
                    msg = "fail";
                }
                else
                {
                    msg = "success";
                }
            }
            else if (pCommand == 'F' && Face == 'W' || pCommand == 'B' && Face == 'E')
            {
                _X--;
                if (_X < 1)
                {
                    _X = oldX;
                    msg = "fail";
                }
                else
                {
                    msg = "success";
                }
            }
            else if (pCommand == 'F' && Face == 'S' || pCommand == 'B' && Face == 'N')
            {
                _Y++;
                if (_Y > maxY)
                {
                    _Y = oldY;
                    msg = "fail";
                }
                else
                {
                    msg = "success";
                }
            }
            else if (pCommand == 'F' && Face == 'N' || pCommand == 'B' && Face == 'S')
            {
                _Y--;
                if (_Y < 1)
                {
                    _Y = oldY;
                    msg = "fail";
                }
                else
                {
                    msg = "success";
                }
            }
            else if (pCommand == 'L' && Face == 'E' || pCommand == 'R' && Face == 'W')
            {
                Face = 'N';
                msg = "success";
            }
            else if (pCommand == 'L' && Face == 'W' || pCommand == 'R' && Face == 'E')
            {
                Face = 'S';
                msg = "success";
            }
            else if (pCommand == 'L' && Face == 'N' || pCommand == 'R' && Face == 'S')
            {
                Face = 'W';
                msg = "success";
            }
            else if (pCommand == 'L' && Face == 'S' || pCommand == 'R' && Face == 'N')
            {
                Face = 'E';
                msg = "success";
            }


            return msg;
        }
    }
}